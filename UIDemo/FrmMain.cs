using Maticsoft.BLL.log;
using Maticsoft.Common;
using Maticsoft.Common.model;
using Maticsoft.Common.Util;
using Maticsoft.Controller;
using Maticsoft.Controller.Scheduler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Demo
{
    public partial class FrmMain : Form
    {

        public System.Windows.Forms.ToolStripStatusLabel TStripStatusLabUpdate
        {
            get { return tStripStatusLabUpdate; }
            set { tStripStatusLabUpdate = value; }
        }

        private delegate void debugCheckDelegate();//代理

        //出票界面
        private Control cytxLotteryPrintTab = null;

        //今日出票
        PrintTicketController pcontroller = new PrintTicketController();
        ErrorTicketController etcontroller = new ErrorTicketController();
        ManualProcessingController mpcontroller = new ManualProcessingController();
        FeedbackController fbcontroller = new FeedbackController();
        AutoTaskController atcontroller = new AutoTaskController();

        public FrmMain()
        {
            InitializeComponent();

            //双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer
                        | ControlStyles.ResizeRedraw
                        | ControlStyles.Selectable
                        | ControlStyles.AllPaintingInWmPaint
                        | ControlStyles.UserPaint
                        | ControlStyles.SupportsTransparentBackColor,
                          true);
        }

        /// <summary>
        /// 加载首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                UploadController ulController = new UploadController();
                ulController.isSingleOrderExist();
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue(e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            try
            {
                UploadController ulController = new UploadController();
                ulController.isSingleTicketExist();
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue(e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
            

            try
            {
                //首页上的定时任务
                ThreadPool.QueueUserWorkItem(new WaitCallback(Tasks));
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("首页上的定时任务错误!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            try
            {
                //自动反馈
                ThreadPool.QueueUserWorkItem(new WaitCallback(StartAutoFeedback));
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("自动反馈错误!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            try
            {
                //检查逾期票
                ThreadPool.QueueUserWorkItem(new WaitCallback(ExpiredChecking));
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("检查逾期票错误!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            try
            {
                //自动备份和清除数据
                ThreadPool.QueueUserWorkItem(new WaitCallback(backUpAndClearDataTasks));
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("自动备份和清除数据错误!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            try
            {
                //自动清除日志文件夹下多余的文件
                ThreadPool.QueueUserWorkItem(new WaitCallback(clearFilesTasks));
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("自动清除日志文件夹下多余的文件错误!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            try
            {
                //加载所有的机器
                SystemSettingsController sscon = new SystemSettingsController();
                Global.storeMachineList = sscon.getAllStoreMachine();
                
                if (null != Global.storeMachineList && Global.storeMachineList.Count > 0)
                {
                    SystemSettingsController con = new SystemSettingsController();
                    //目前是单彩机版本，只取第一个
                    store_machine sm = Global.storeMachineList[0];
                    //速度级别及对应配置的初始化
                    List<speed_level_config> slclist = con.getAllSpeedLevelConfig();
                    if (null != slclist && slclist.Count > 0)
                    {
                        foreach (speed_level_config item in slclist)
                        {
                            List<speed_level_cmd> cmdList = con.getSpeedCmdByLevel(item.speed_level);
                            if (null != cmdList && cmdList.Count > 0)
                            {
                                SpeedConfigCmd scc = new SpeedConfigCmd(item, cmdList);
                                Global.SLC_DICTIONARY.Add(item.speed_level, scc);
                            }
                        }
                    }
                    //初始化彩机支持的采种
                    
                    List<machine_can_print_license> mcpllist = con.getMachineCanPrintLicenseByTId(sm.terminal_number);
                    Dictionary<String, machine_can_print_license> ldic = new Dictionary<string, machine_can_print_license>();
                    foreach (machine_can_print_license item in mcpllist)
                    {
                        ldic.Add(item.license_id.ToString(), item);
                    }
                    Global.MachineCanPrintLicenseDic.Add(sm.terminal_number, ldic);                   
                    
                    Scheduler sischeduler = new Scheduler(new SerialPort(), sm);
                    Scheduler.SerialInteriorSchedulerList.Add(sischeduler);
                    cytxLotteryPrintTab = new TabPrint(sischeduler);
                    this.plParent.Controls.Add(cytxLotteryPrintTab);                    

                    //错误选择的初始化
                    Global.errorhandlist = con.getAllErrorHandling();                    
                }
                else
                {
                    cytxLotteryPrintTab = new TabNoMachinePromptPage();
                    this.plParent.Controls.Add(cytxLotteryPrintTab);
                }
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("系统初始化出错!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            try
            {
                this.mCMarkError.lbCornerMark.MouseHover += new EventHandler(this.plCLP_MouseHover);
                this.mCMarkFeedBack.lbCornerMark.MouseHover += new EventHandler(this.plFK_MouseHover);
                this.mCMarkManual.lbCornerMark.MouseHover += new EventHandler(this.plSG_MouseHover);

                this.mCMarkError.lbCornerMark.Click += new EventHandler(this.plCLP_Click);
                this.mCMarkFeedBack.lbCornerMark.Click += new EventHandler(this.plFK_Click);
                this.mCMarkManual.lbCornerMark.Click += new EventHandler(this.plSG_Click);
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("逾期票更新错误!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            //try
            //{
            //    new GetNewUpgrader.Upgrader().UpdateStart();
            //}
            //catch
            //{ }
            
        }

        /// <summary>
        /// 清理日志文件夹下不需要的文件
        /// </summary>
        /// <param name="state"></param>
        private void clearFilesTasks(object state)
        {
            try
            {
                DirectoryInfo dinfo = null;
                String[] dictionary = new String[] { "communicate", "exception", "sys", "ticket" };
                foreach (String item in dictionary)
                {
                    dinfo = new DirectoryInfo(Application.StartupPath+"\\logs\\"+item);
                    FileInfo[] fsi = dinfo.GetFiles();
                    foreach (var file in fsi)
                    {
                        if (!file.Name.Contains(item+".log"))
                        {
                            try
                            {
                                file.Delete();
                                LogUtil.getInstance().addLogDataToQueue("删除多余文件：" + file.Name, GlobalConstants.LOGTYPE_ENUM.SYSTEM_OPERATION);
                            }
                            catch (Exception)
                            { }
                        }
                    }
                }                
            }
            catch
            {                
                throw ;
            }
        }

        private void ExpiredChecking(object state)
        {
            ExpiredCheckingController expiredCheckingController = new ExpiredCheckingController();
            while (true)
            {
                try
                {
                    expiredCheckingController.ExpiredTicketCheckingHandler();
                }
                catch (Exception e)
                {
                    LogUtil.getInstance().addLogDataToQueue("逾期票更新错误!" + e.InnerException, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                }
                finally {
                    Thread.Sleep(3000);
                }              
            }
        }


        /// <summary>
        /// 自动备份和清除数据线程
        /// </summary>
        /// <param name="state"></param>
        private void backUpAndClearDataTasks(object state)
        {
                while (true)
                {
                try
                {
                    backUpAndClearDataTasksHandler();
                }
                catch (Exception e1)
                {
                    LogUtil.getInstance().addLogDataToQueue("自动备份和清除数据线程错误!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                }
                finally {
                    Thread.Sleep(1000 * 60 * 5);
                }
            }
        }
        /// <summary>
        /// 自动备份和清除数据线程处理方法
        /// </summary>
        private void backUpAndClearDataTasksHandler()
        {
            try
            {
                while (atcontroller.backUpData())
                {
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                LogUtil.getInstance().addLogDataToQueue("自动备份异常!" + e.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

            try
            {
                while (atcontroller.clearExpiredData())
                {
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                LogUtil.getInstance().addLogDataToQueue("清理数据异常!" + e.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }

        }

        /// <summary>
        /// 自动反馈
        /// </summary>
        /// <param name="o"></param>
        private void StartAutoFeedback(object o)
        {
            FeedbackController feedbackController = new FeedbackController();
            //'自动反馈'是否开启
            while (true)
            {
                try
                {
                    if ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.IS_AUTO_FEEDBACK].Equals(
                        GlobalConstants.TrueFalseSign.TRUE) )
                    {
                        List<lottery_order> lol = feedbackController.getAllFeedbackOrderList();
                        foreach (lottery_order lo in lol)
                        {                            
                            try
                            {//出了异常不会导致其他订单处理不了
                                LogUtil.getInstance ( ).addLogDataToQueue ( "自动反馈订单>>>" + lo.id, GlobalConstants.LOGTYPE_ENUM.FEEDBACK_LOG );
                                feedbackController.ManualFeedbackSingle ( lo );
                            }
                            catch ( Exception )
                            { }                           
                        }
                    }
                }
                catch (Exception e)
                {
                    //暂时不需要处理
                    LogUtil.getInstance().addLogDataToQueue("自动反馈订单异常>>>" + e.StackTrace, GlobalConstants.LOGTYPE_ENUM.FEEDBACK_LOG);
                }
                Thread.Sleep(3000);
            }
        }

        //所有需要循环检查的任务都写在这里，如：测试网络，今日出票...
        private void Tasks(object o)
        {
            int rount = 0;
            while (true)
            {
                try
                {
                    taskHandler(rount);
                    rount++;
                    rount = rount % 10;
                    Thread.Sleep(3000);
                }
                catch (Exception e1)
                {
                    LogUtil.getInstance().addLogDataToQueue("首页检查任务线程错误!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
                }
            }
        }

        private void taskHandler(int rount)
        {
            try
            {
                //轮询Global里的'网络通讯状态'
                this.Invoke(new EventHandler(delegate(object o2, EventArgs e)
                {
                    //轮询Global里的'网络通讯状态'//设置主页右上角'今日出票'值
                    if (Global.TIME_OUT_TIMES > 0)
                    {
                        this.lbNetwork.Text = GlobalConstants.WEB_STATE.UNUSUAL;
                        this.picNetwork.Image = global::Demo.Properties.Resources.wifiNo;
                    }
                    else
                    {
                        this.lbNetwork.Text = GlobalConstants.WEB_STATE.NORMAL;
                        this.picNetwork.Image = global::Demo.Properties.Resources.wifi;
                    }

                    TicketRecordStatistics trs = new RecordController().getAllTicketedRecordStatistics("dateTime('now','start of day')", "dateTime('now','start of day','+1 day')");

                    if (null != trs)
                    {
                        this.totalTicketsNum.value = trs.ticketMoney.ToString();
                    }

                    //错漏票的音频提示
                    int errorTicketNumber = etcontroller.getAllErrorTicketOrderNum();
                    this.mCMarkError.Number = errorTicketNumber;

                    this.mCMarkFeedBack.Number = fbcontroller.getAllNeedManualFeedBackOrderNum ( Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.IS_AUTO_FEEDBACK ].Equals(GlobalConstants.TrueFalseSign.TRUE),
                        false);
                    this.mCMarkManual.Number = this.mpcontroller.getManualOrderNum();

                    if (errorTicketNumber > 0 && rount==0)
                    {
                        try
                        {
                            System.Media.SoundPlayer sp = new SoundPlayer();
                            sp.SoundLocation = Global.AUDIO_FILES_BASEDIR + Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_ERROR ];
                            sp.Play();
                        }
                        catch (Exception)
                        {}
                    }
                    else if ((this.mCMarkManual.Number > 0 || this.mCMarkFeedBack.Number > 0  )&& rount == 0)
                    {
                        try
                        {
                            System.Media.SoundPlayer sp = new SoundPlayer();
                            sp.SoundLocation = Global.AUDIO_FILES_BASEDIR + Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.AUDIO_MANUAL ];
                            sp.Play();
                        }
                        catch (Exception)
                        {}
                    }
                }));
            }
            catch (Exception e1)
            {
                LogUtil.getInstance().addLogDataToQueue("taskHandler启动异常!" + e1.StackTrace, GlobalConstants.LOGTYPE_ENUM.EXCEOTION);
            }
        }

        /// <summary>
        /// 刷新状态栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_frmMain_Tick(object sender, EventArgs e)
        {
            try
            {
                Global.SysDateMillisecond += 500;
                this.tSStatusLabDate.Text = DateUtil.getServerDateTime(DateUtil.DATE_FMT_STR2) + "     ";
                String text = this.tStripStatusLabbulletin.Text;
                this.tStripStatusLabbulletin.Text = text.Substring(1, text.Length - 1) + text.Substring(0, 1);

                this.tStripStatusLabUpdate.Text = Global.SYSTEM_CONFIG_MAP [ GlobalConstants.SYSTEM_CONFIG_KEYS.CONTROLDATA_UPDATE_DATE ];
            }
            catch (Exception)
            {}            
        }

        /// <summary>
        /// 关闭界面时，保证所有的线程都要关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmPopup frmPopup = new FrmPopup();
            if (frmPopup.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                System.Environment.Exit(System.Environment.ExitCode);                                
            }
            else
            {
                e.Cancel = true;
            }                   
        }

        /// <summary>
        /// 检查数据更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tStripStatusLabCheckVison_Click(object sender, EventArgs e)
        {
                FrmUpdate frmUpdate = new FrmUpdate(this);
                frmUpdate.ShowDialog();
        }

        private void plCP_MouseHover(object sender, EventArgs e)
        {
            this.plCP.BackgroundImage = global::Demo.Properties.Resources.CPfocuse;
        }

        private void plCP_MouseLeave(object sender, EventArgs e)
        {
            if (!this.cpClicked)
            {
                this.plCP.BackgroundImage = global::Demo.Properties.Resources.CPunfocuse;
            }
        }

        private void plFK_MouseHover(object sender, EventArgs e)
        {
            this.plFK.BackgroundImage = global::Demo.Properties.Resources.FKfocuse;
        }

        private void plFK_MouseLeave(object sender, EventArgs e)
        {
            if (!this.fkClicked)
            {
                this.plFK.BackgroundImage = global::Demo.Properties.Resources.FKunfocuse;
            }
        }

        private void plCLP_MouseHover(object sender, EventArgs e)
        {
            this.plCLP.BackgroundImage = global::Demo.Properties.Resources.CLPfocuse;
        }

        private void plCLP_MouseLeave(object sender, EventArgs e)
        {
            if (!this.clpClicked)
            {
                this.plCLP.BackgroundImage = global::Demo.Properties.Resources.CLPunfocuse;
            }
        }

        private void plJL_MouseHover(object sender, EventArgs e)
        {
            this.plJL.BackgroundImage = global::Demo.Properties.Resources.JLfocuse;
        }

        private void plJL_MouseLeave(object sender, EventArgs e)
        {
            if (!this.jlClicked)
            {
                this.plJL.BackgroundImage = global::Demo.Properties.Resources.JLunfocuse;
            }
        }

        private void plSG_MouseHover(object sender, EventArgs e)
        {
            this.plSG.BackgroundImage = global::Demo.Properties.Resources.SGfocuse;
        }

        private void plSG_MouseLeave(object sender, EventArgs e)
        {
            if (!this.sgClicked)
            {
                this.plSG.BackgroundImage = global::Demo.Properties.Resources.SGunfocuse;
            }
        }

        private void plSZ_MouseHover(object sender, EventArgs e)
        {
            this.plSZ.BackgroundImage = global::Demo.Properties.Resources.SZfocuse;
        }

        private void plSZ_MouseLeave(object sender, EventArgs e)
        {
            if (!this.szClicked)
            {
                this.plSZ.BackgroundImage = global::Demo.Properties.Resources.SZunfocuse;
            }
        }

        private void plDSSC_MouseEnter(object sender, EventArgs e)
        {
            this.plDSSC.BackgroundImage = global::Demo.Properties.Resources.danshiFocused;
        }

        private void plDSSC_MouseLeave(object sender, EventArgs e)
        {
            if (!this.dsscClicked)
            {
                this.plDSSC.BackgroundImage = global::Demo.Properties.Resources.danshiUnfocused;
            }
        }

        private bool cpClicked = true;
        private bool fkClicked = false;
        private bool clpClicked = false;
        private bool jlClicked = false;
        private bool sgClicked = false;
        private bool dsscClicked = false;
        private bool szClicked = false;
        
        private void plCP_Click(object sender, EventArgs e)
        {
            cpClicked = true;
            fkClicked = false;
            clpClicked = false;
            jlClicked = false;
            sgClicked = false;
            dsscClicked = false;
            szClicked = false;
            this.plFK.BackgroundImage = global::Demo.Properties.Resources.FKunfocuse;
            this.plCLP.BackgroundImage = global::Demo.Properties.Resources.CLPunfocuse;
            this.plJL.BackgroundImage = global::Demo.Properties.Resources.JLunfocuse;
            this.plSG.BackgroundImage = global::Demo.Properties.Resources.SGunfocuse;
            this.plSZ.BackgroundImage = global::Demo.Properties.Resources.SZunfocuse;
            this.plDSSC.BackgroundImage = global::Demo.Properties.Resources.danshiUnfocused;
            this.plCP.BackgroundImage = global::Demo.Properties.Resources.CPfocuse;

            this.plParent.Controls.Clear();
            this.CloseTabConfigPort();
            this.plParent.Controls.Add(cytxLotteryPrintTab);
        }

        private void plFK_Click(object sender, EventArgs e)
        {
            cpClicked = false;
            fkClicked = true;
            clpClicked = false;
            jlClicked = false;
            sgClicked = false;
            dsscClicked = false;
            szClicked = false;
            this.plCP.BackgroundImage = global::Demo.Properties.Resources.CPunfocuse;
            this.plCLP.BackgroundImage = global::Demo.Properties.Resources.CLPunfocuse;
            this.plJL.BackgroundImage = global::Demo.Properties.Resources.JLunfocuse;
            this.plSG.BackgroundImage = global::Demo.Properties.Resources.SGunfocuse;
            this.plSZ.BackgroundImage = global::Demo.Properties.Resources.SZunfocuse;
            this.plDSSC.BackgroundImage = global::Demo.Properties.Resources.danshiUnfocused;
            this.plFK.BackgroundImage = global::Demo.Properties.Resources.FKfocuse;

            this.plParent.Controls.Clear();
            this.CloseTabConfigPort();
            this.plParent.Controls.Add(new TabFeedback(this.plParent));
        }

        private void plCLP_Click(object sender, EventArgs e)
        {
            cpClicked = false;
            fkClicked = false;
            clpClicked = true;
            jlClicked = false;
            sgClicked = false;
            dsscClicked = false;
            szClicked = false;

            this.plCP.BackgroundImage = global::Demo.Properties.Resources.CPunfocuse;
            this.plFK.BackgroundImage = global::Demo.Properties.Resources.FKunfocuse;
            this.plJL.BackgroundImage = global::Demo.Properties.Resources.JLunfocuse;
            this.plSG.BackgroundImage = global::Demo.Properties.Resources.SGunfocuse;
            this.plSZ.BackgroundImage = global::Demo.Properties.Resources.SZunfocuse;
            this.plDSSC.BackgroundImage = global::Demo.Properties.Resources.danshiUnfocused;
            this.plCLP.BackgroundImage = global::Demo.Properties.Resources.CLPfocuse;

            this.plParent.Controls.Clear();
            this.CloseTabConfigPort();
            this.plParent.Controls.Add(new TabErrorTicket(this.plParent));
        }

        private void plJL_Click(object sender, EventArgs e)
        {
            cpClicked = false;
            fkClicked = false;
            clpClicked = false;
            jlClicked = true;
            sgClicked = false;
            dsscClicked = false;
            szClicked = false;
            this.plCP.BackgroundImage = global::Demo.Properties.Resources.CPunfocuse;
            this.plFK.BackgroundImage = global::Demo.Properties.Resources.FKunfocuse;
            this.plCLP.BackgroundImage = global::Demo.Properties.Resources.CLPunfocuse;
            this.plSG.BackgroundImage = global::Demo.Properties.Resources.SGunfocuse;
            this.plSZ.BackgroundImage = global::Demo.Properties.Resources.SZunfocuse;
            this.plDSSC.BackgroundImage = global::Demo.Properties.Resources.danshiUnfocused;
            this.plJL.BackgroundImage = global::Demo.Properties.Resources.JLfocuse;

            this.plParent.Controls.Clear();
            this.CloseTabConfigPort();
            this.plParent.Controls.Add(new TabRecord(this.plParent));
        }

        private void plSG_Click(object sender, EventArgs e)
        {
            cpClicked = false;
            fkClicked = false;
            clpClicked = false;
            jlClicked = false;
            sgClicked = true;
            dsscClicked = false;
            szClicked = false;
            this.plCP.BackgroundImage = global::Demo.Properties.Resources.CPunfocuse;
            this.plFK.BackgroundImage = global::Demo.Properties.Resources.FKunfocuse;
            this.plCLP.BackgroundImage = global::Demo.Properties.Resources.CLPunfocuse;
            this.plJL.BackgroundImage = global::Demo.Properties.Resources.JLunfocuse;
            this.plDSSC.BackgroundImage = global::Demo.Properties.Resources.danshiUnfocused;
            this.plSZ.BackgroundImage = global::Demo.Properties.Resources.SZunfocuse;
            this.plSG.BackgroundImage = global::Demo.Properties.Resources.SGfocuse;

            this.plParent.Controls.Clear();
            this.CloseTabConfigPort();
            this.plParent.Controls.Add(new TabManual());
        }

        private void plDSSC_Click(object sender, EventArgs e)
        {
            cpClicked = false;
            fkClicked = false;
            clpClicked = false;
            jlClicked = false;
            sgClicked = false;
            dsscClicked = true;
            szClicked = false;
            this.plCP.BackgroundImage = global::Demo.Properties.Resources.CPunfocuse;
            this.plFK.BackgroundImage = global::Demo.Properties.Resources.FKunfocuse;
            this.plCLP.BackgroundImage = global::Demo.Properties.Resources.CLPunfocuse;
            this.plJL.BackgroundImage = global::Demo.Properties.Resources.JLunfocuse;
            this.plSZ.BackgroundImage = global::Demo.Properties.Resources.SZunfocuse;
            this.plSG.BackgroundImage = global::Demo.Properties.Resources.SGunfocuse;
            this.plDSSC.BackgroundImage = global::Demo.Properties.Resources.danshiFocused;

            this.plParent.Controls.Clear();
            this.CloseTabConfigPort();
            this.plParent.Controls.Add(new TabUploadTxt());
        }
        
        TabConfig tabConfig = null;
        private void plSZ_Click(object sender, EventArgs e)
        {
            cpClicked = false;
            fkClicked = false;
            clpClicked = false;
            jlClicked = false;
            sgClicked = false;
            dsscClicked = false;
            szClicked = true;
            this.plCP.BackgroundImage = global::Demo.Properties.Resources.CPunfocuse;
            this.plFK.BackgroundImage = global::Demo.Properties.Resources.FKunfocuse;
            this.plCLP.BackgroundImage = global::Demo.Properties.Resources.CLPunfocuse;
            this.plJL.BackgroundImage = global::Demo.Properties.Resources.JLunfocuse;
            this.plSG.BackgroundImage = global::Demo.Properties.Resources.SGunfocuse;
            this.plSZ.BackgroundImage = global::Demo.Properties.Resources.SZfocuse;
            this.plDSSC.BackgroundImage = global::Demo.Properties.Resources.danshiUnfocused;

            this.plParent.Controls.Clear();
            this.CloseTabConfigPort();
            this.plParent.Controls.Add(tabConfig);
        }

        //关闭TabConfig控件的串口
        private void CloseTabConfigPort()
        {
            if (tabConfig == null)
            {
                tabConfig = new TabConfig();
            }
            else
            {
                tabConfig.ClosePort();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private Point mPoint = new Point();
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            } 
        }

        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnMinimizeEnter;
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnMinimize;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnCloseEnter;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackgroundImage = global::Demo.Properties.Resources.btnClose;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Visible = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }
    }
}