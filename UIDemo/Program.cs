using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;
using log4net;
using System.Reflection;
using Maticsoft.BLL.log;
using Maticsoft.BLL.proController;
using Maticsoft.Common.model;
using System.IO.Ports;
using Maticsoft.BLL.comparison;
using System.Globalization;
using Maticsoft.Common.Util;
using Maticsoft.BLL.ScanPortImage;
using System.Drawing.Imaging;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]
//[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Demo.exe.config", ConfigFileExtension = "xml", Watch = true)]
namespace Demo
{
    static class Program
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll ", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        public const int SW_RESTORE = 9;
        public static IntPtr formhwnd; 

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //图片测试
            //ScanPortImageUtil.creatScanPortImage().Save("C:\\Users\\zlpng\\Desktop\\testprint02.bmp",ImageFormat.Bmp);
            //return;
            //StringBuilder sb = new StringBuilder(@"FF-11-FF-13-43-BB-36-01-01-38-FF-0D-FF-0A-FF-11-FF-13-43-BB-37-02-02-3A-FF-0D-FF-0A-FF-11-FF-13-43-BB-37-01-01-E0-FF-0D-FF-0A-FF-11-FF-13-43-BB-37-01-01-E0-FF-0D-FF-0A-FF-11-FF-13-43-BB-37-01-01-E0-FF-0D-FF-0A-FF-11-FF-13-43-BB-37-01-01-E0-FF-0D-FF-0A-FF-11-FF-13-43-BB-37-01-01-E0-FF-0D-FF-0A-FF-11-FF-13-43-BB-37-01-01-E0-FF-0D-FF-0A-FF-11-FF-13-43-BB-37-01-01-E0-FF-0D-FF-0A-FF-11-FF-13-43-BB-37-01-01-E0-FF-0D-FF-0A-FF-11-FF-13-43-BB-37-01-01-E0-FF-0D-FF-0A-FF-11-FF-13-43-BB-37-01-01-E0-FF-0D-FF-0A-FF-11-FF-13-43-BB-37-01-01-3A-FF-0D-FF-0A-FF-11-FF-13-50-10-FF-0D-FF-0A-FF-11-FF-13-50-04-01-FF-0D-FF-0A-FF-11-FF-13-50-10-FF-0D-FF-0A-FF-11-FF-13-50-04-02-FF-0D-FF-0A-FF-11-FF-13-50-10-FF-0D-FF-0A-FF-11-FF-13-50-04-03-FF-0D-FF-0A-FF-11-FF-13-50-10-FF-0D-FF-0A-FF-11-FF-13-50-04-04-FF-0D-FF-0A-FF-11-FF-13-50-1D-FF-0D-FF-0A-FF-11-FF-13-50-4C-00-00-1B-33-FF-0D-FF-0A-FF-11-FF-13-50-1A-1B-21-01-1D-21-10-FF-0D-FF-0A-FF-11-FF-13-50-1B-61-01-1B-33-21-D6-D0-B9-FF-0D-FF-0A-FF-11-FF-13-50-FA-CC-E5-D3-FD-B2-CA-C6-B1-0A-FF-0D-FF-0A-FF-11-FF-13-50-1B-33-1A-1B-21-00-1D-21-00-1B-61-FF-0D-FF-0A-FF-11-FF-13-50-01-BE-BA-B2-CA-D7-E3-C7-F2-CA-A4-FF-0D-FF-0A-FF-11-FF-13-50-C6-BD-B8-BA-20-20-20-33-78-31-0A-FF-0D-FF-0A-FF-11-FF-13-50-32-30-34-30-39-37-2D-38-38-35-30-FF-0D-FF-0A-FF-11-FF-13-50-32-31-2D-32-37-37-35-32-32-2D-38-FF-0D-FF-0A-FF-11-FF-13-50-38-20-32-36-46-43-38-36-38-45-20-FF-0D-FF-0A-FF-11-FF-13-50-30-30-37-32-38-33-32-37-0A-A9-A4-FF-0D-FF-0A-FF-11-FF-13-50-A9-A4-A9-A4-A9-A4-A9-A4-A9-A4-A9-A4-FF-0D-FF-0A-FF-11-FF-13-50-A9-A4-A9-A4-A9-A4-A9-A4-A9-A4-A9-FF-0D-FF-0A-FF-11-FF-13-50-A4-A9-A4-A9-A4-A9-A4-A9-A4-A9-A4-FF-0D-FF-0A-FF-11-FF-13-50-A9-A4-A9-A4-A9-A4-0A-1B-21-00-1D-21-FF-0D-FF-0A-FF-11-FF-13-50-00-1B-61-00-B5-DA-31-B9-D8-20-20-FF-0D-FF-0A-FF-11-FF-13-50-D6-DC-CE-E5-30-30-31-0A-D6-F7-B6-FF-0D-FF-0A-FF-11-FF-13-50-D3-3A-B2-BC-C0-EF-CB-B9-B0-E0-CA-FF-0D-FF-0A-FF-11-FF-13-50-A8-BA-F0-20-56-73-20-BF-CD-B6-D3-3A-FF-0D-FF-0A-FF-11-FF-13-50-C4-AB-B6-FB-B1-BE-CA-A4-C0-FB-0A-FF-0D-FF-0A-FF-11-FF-13-50-CA-A4-40-31-2E-39-37-30-D4-AA-0A-FF-0D-FF-0A-FF-11-FF-13-50-B5-DA-32-B9-D8-20-20-D6-DC-CE-E5-FF-0D-FF-0A-FF-11-FF-13-50-30-30-32-0A-D6-F7-B6-D3-3A-B4-F3-DA-FF-0D-FF-0A-FF-11-FF-13-50-E6-B8-D6-B0-CD-20-56-73-20-BF-CD-FF-0D-FF-0A-FF-11-FF-13-50-B6-D3-3A-B0-D8-CC-AB-D1-F4-C9-F1-FF-0D-FF-0A-FF-11-FF-13-50-0A-CA-A4-40-31-2E-37-32-30-D4-AA-0A-FF-0D-FF-0A-FF-11-FF-13-50-B5-DA-33-B9-D8-20-20-D6-DC-CE-E5-FF-0D-FF-0A-FF-11-FF-13-50-30-30-33-0A-D6-F7-B6-D3-3A-B9-E3-FF-0D-FF-0A-FF-11-FF-13-50-B5-BA-C8-FD-BC-FD-20-56-73-20-BF-FF-0D-FF-0A-FF-11-FF-13-50-CD-B6-D3-3A-D0-C2-D0-BA-CC-EC-B6-EC-FF-0D-FF-0A-FF-11-FF-13-50-0A-CA-A4-40-31-2E-35-34-30-D4-AA-FF-0D-FF-0A-FF-11-FF-13-50-0A-28-D1-A1-CF-EE-B9-CC-B6-A8-BD-FF-0D-FF-0A-FF-11-FF-13-50-B1-BD-F0-B6-EE-CE-AA-C3-BF-31-D4-FF-0D-FF-0A-FF-11-FF-13-50-AA-CD-B6-D7-A2-B6-D4-D3-A6-B5-C4-BD-FF-0D-FF-0A-FF-11-FF-13-50-B1-BD-F0-B6-EE-29-0A-B1-BE-C6-B1-FF-0D-FF-0A-FF-11-FF-13-50-D7-EE-B8-DF-BF-C9-C4-DC-B9-CC-B6-FF-0D-FF-0A-FF-11-FF-13-50-A8-BD-B1-BD-F0-3A-33-31-2E-33-32-D4-FF-0D-FF-0A-FF-11-FF-13-50-AA-0A-20-2A-20-20-2A-20-20-2A-0A-FF-0D-FF-0A-FF-11-FF-13-50-20-2A-20-20-2A-20-20-2A-0A-20-2A-FF-0D-FF-0A-FF-11-FF-13-50-20-20-2A-20-20-2A-0A-20-2A-20-20-2A-FF-0D-FF-0A-FF-11-FF-13-50-20-20-2A-0A-20-2A-20-20-2A-20-20-FF-0D-FF-0A-FF-11-FF-13-50-2A-0A-20-2A-20-20-2A-20-20-2A-0A-FF-0D-FF-0A-FF-11-FF-13-50-20-2A-20-20-2A-20-20-2A-0A-20-2A-FF-0D-FF-0A-FF-11-FF-13-50-20-20-2A-20-20-2A-0A-20-2A-20-20-FF-0D-FF-0A-FF-11-FF-13-50-2A-20-20-2A-0A-20-2A-20-20-2A-20-20-FF-0D-FF-0A-FF-11-FF-13-50-2A-0A-20-2A-20-20-2A-20-20-2A-0A-FF-0D-FF-0A-FF-11-FF-13-50-20-2A-20-20-2A-20-20-2A-0A-20-2A-FF-0D-FF-0A-FF-11-FF-13-50-20-20-2A-20-20-2A-0A-20-2A-20-20-FF-0D-FF-0A-FF-11-FF-13-50-2A-20-20-2A-0A-20-2A-20-20-2A-20-FF-0D-FF-0A-FF-11-FF-13-50-20-2A-0A-20-2A-20-20-2A-20-20-2A-FF-0D-FF-0A-FF-11-FF-13-50-0A-20-2A-20-20-2A-20-20-2A-0A-20-2A-FF-0D-FF-0A-FF-11-FF-13-50-20-20-2A-20-20-2A-0A-20-2A-20-20-FF-0D-FF-0A-FF-11-FF-13-50-2A-20-20-2A-0A-20-2A-20-20-2A-20-FF-0D-FF-0A-FF-11-FF-13-50-20-2A-0A-20-2A-20-20-2A-20-20-2A-FF-0D-FF-0A-FF-11-FF-13-50-0A-20-2A-20-20-2A-20-20-2A-0A-20-FF-0D-FF-0A-FF-11-FF-13-50-2A-20-20-2A-20-20-2A-0A-20-2A-20-20-FF-0D-FF-0A-FF-11-FF-13-50-2A-20-20-2A-0A-20-2A-20-20-2A-20-FF-0D-FF-0A-FF-11-FF-13-50-20-2A-0A-1B-21-00-1D-21-00-1B-61-FF-0D-FF-0A-FF-11-FF-13-50-01-A9-A4-A9-A4-A9-A4-A9-A4-A9-A4-FF-0D-FF-0A-FF-11-FF-13-50-A9-A4-A9-A4-A9-A4-A9-A4-A9-A4-A9-A4-FF-0D-FF-0A-FF-11-FF-13-50-A9-A4-A9-A4-A9-A4-A9-A4-A9-A4-A9-FF-0D-FF-0A-FF-11-FF-13-50-A4-A9-A4-A9-A4-A9-A4-A9-A4-0A-B1-FF-0D-FF-0A-FF-11-FF-13-50-B6-CA-FD-3A-33-20-20-BA-CF-BC-C6-3A-FF-0D-FF-0A-FF-11-FF-13-50-20-20-20-20-20-20-36-D4-AA-20-32-FF-0D-FF-0A-FF-11-FF-13-50-30-31-36-2D-30-34-2D-31-35-20-31-FF-0D-FF-0A-FF-11-FF-13-50-30-3A-32-38-3A-30-30-0A-32-35-30-FF-0D-FF-0A-FF-11-FF-13-50-33-31-31-33-30-30-20-20-20-20-20-20-FF-0D-FF-0A-FF-11-FF-13-50-20-20-20-20-20-CE-F7-B0-B2-CA-D0-FF-0D-FF-0A-FF-11-FF-13-50-C1-D9-E4-FC-C7-F8-CC-FA-D2-BB-B4-FF-0D-FF-0A-FF-11-FF-13-50-A6-D4-BA-C4-DA-0A-B4-F3-C0-D6-CD-B8-FF-0D-FF-0A-FF-11-FF-13-50-BD-B1-B3-D8-32-36-D2-DA-A3-AC-35-FF-0D-FF-0A-FF-11-FF-13-50-D2-DA-B4-F3-C5-C9-BD-B1-33-D4-AA-FF-0D-FF-0A-FF-11-FF-13-50-BF-C9-D6-D0-32-34-30-30-CD-F2-0A-FF-0D-FF-0A-FF-11-FF-13-50-BE-BA-B2-CA-31-36-C8-D5-20-30-32-3A-FF-0D-FF-0A-FF-11-FF-13-50-33-30-20-20-20-C0-EF-B0-BA-20-76-FF-0D-FF-0A-FF-11-FF-13-50-73-20-C4-E1-CB-B9-0A-D6-D0-B9-FA-FF-0D-FF-0A-FF-11-FF-13-50-BE-BA-B2-CA-CD-F8-20-68-74-74-70-3A-FF-0D-FF-0A-FF-11-FF-13-50-2F-2F-77-77-77-2E-73-70-6F-72-74-FF-0D-FF-0A-FF-11-FF-13-50-74-65-72-79-2E-63-6E-0A-0A-1D-28-FF-0D-FF-0A-FF-11-FF-13-50-6B-03-00-30-41-06-1D-28-6B-03-00-FF-0D-FF-0A-FF-11-FF-13-50-30-42-14-1D-28-6B-03-00-30-44-02-1D-FF-0D-FF-0A-FF-11-FF-13-50-28-6B-03-00-30-43-03-1D-28-6B-04-FF-0D-FF-0A-FF-11-FF-13-50-00-30-45-30-34-1D-28-6B-23-00-30-FF-0D-FF-0A-FF-11-FF-13-50-50-30-01-02-1D-32-30-34-30-39-37-38-FF-0D-FF-0A-FF-11-FF-13-50-38-35-30-32-31-32-37-37-35-32-32-FF-0D-FF-0A-FF-11-FF-13-50-38-38-20-30-30-37-32-38-33-32-37-FF-0D-FF-0A-FF-11-FF-13-50-1D-28-6B-03-00-30-51-30-1D-56-42-FF-0D-FF-0A-FF-11-FF-13-50-00-1B-4B-20-FF-0D-FF-0A-");
            //CommandProcessor.getAllCompeleteCMD(ref sb);
//                        String re = String.Empty;
//                        String reInfo = @"中国体育彩票
//竞彩足球混合过关   4x1
//204105-201924-197873-04 1B4B3C80 00345831
//─────────────────────
//第1关周四017 让球胜平负  让球:主-1
//主队:乌克兰 Vs 客队:北爱尔兰
//平@3.200元+负@2.020元
//第2关周四018 比分 
//主队:德国 Vs 客队:波兰
//(3:3)@80.00元+(1:1)@7.000元+(2:2)@18.00元
//第3关周四101 让球胜平负  让球:主-1
//主队:巴西国际 Vs 客队:米内罗竞技
//平@3.550元+负@1.780元
//第4关周四102 比分 
//主队:弗鲁米嫩塞 Vs 客队:科林蒂安
//(0:0)@7.500元+(1:1)@6.000元+(2:2)@16.00元
//(选项固定奖金额为每1元投注对应的奖金额)
//本票最高可能固定奖金:29,081.60元
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
// *  *  *
//─────────────────────
//倍数:1  合计:     72元 2016-06-16 21:29:37
//015189601 南京市溧水区青年路宏泰二期14 15
//号门
//玩大乐透、7位数  最高5倍免单！
//关注江苏体彩官方微信抢现金红包、iPhone6s
//中国竞彩网 http://www.sporttery.cn";
//            lottery_ticket lt = new lottery_ticket();
//            lt.license_id = 9;
//            lt.play_type = "6-4c1";
//            lt.issue = "16032933";
//            lt.multiple = "1";
//            lt.bet_price = "72";
//            ComparisonUtil.comparisonFunction(lt, reInfo, out re);


            //            //测试解析用
            //try
            //{

            //SerialPort sp = new SerialPort();
            //store_machine sm = new store_machine();
            //sm.machine_code = "1111";
            //SerialPortInfo spi = new SerialPortInfo(sp, sm);
            //BaseProController bpc = new BaseProController(spi);
            //bpc.testRead();
            //return;
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
            //打开日志处理线程
            //LogUtil.getInstance().init();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //string proc = Process.GetCurrentProcess().ProcessName;
            //Process[] processes = Process.GetProcessesByName(proc);
            //if (processes.Length <= 1)
            //{
            //    //Application.Run(new FrmMain1());
            //    Login form = new Login();
            //    form.ShowDialog();
            //    if (form.DialogResult == DialogResult.OK)
            //    {
            //        form.Close();
            //        form.Dispose();
            //        Application.Run(new FrmMain());
            //    }
            //    else
            //    {
            //        Application.Exit();
            //    }

            //}
            //else
            //{
            //    for (int i = 0; i < processes.Length; i++)
            //    {
            //        if (processes[i].Id != Process.GetCurrentProcess().Id)
            //        {
            //            if (processes[i].MainWindowHandle.ToInt32() == 0)
            //            {
            //                formhwnd = FindWindow(null, "FrmMain");
            //                ShowWindow(formhwnd, 1);
            //                SwitchToThisWindow(formhwnd, true);
            //            }
            //            else
            //            {
            //                SwitchToThisWindow(processes[i].MainWindowHandle, true);
            //            }
            //        }
            //    }
            //}
            Application.Run(new Test());
        }
    }
}
