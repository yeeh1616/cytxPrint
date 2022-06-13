﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.BLL.singleUploadParser
{
    public class FootballJqcSingleUploadParser : SingleUploadParser
    {
        public string parseLine(string line)
        {
            String _line = line.Replace("[^0123]", "").Trim();
            //长度为14
            if (_line.Length == 8)
            {
                char[] chs = _line.ToCharArray();
                String retObj = "";
                foreach (char ch in chs)
                {
                    retObj += ch + ",";
                    //字符必须为3,1,0
                    if (ch != '3' && ch != '2' && ch != '1' && ch != '0')
                    {
                        return null;
                    }
                }
                retObj = retObj.Substring(0, retObj.Length - 1);
                return retObj;
            }
            else
            {
                // 复式上传
                String[] bets = line.Split(',');
                if (bets.Length == 8)
                {
                    foreach (String bet in bets)
                    {
                        if (bet.Length > 4)
                        {
                            return null;
                        }
                        char[] chs = bet.ToCharArray();
                        foreach (char ch in chs)
                        {
                            //字符必须为3,1,0
                            if (ch != '3' && ch != '2' && ch != '1' && ch != '0')
                            {
                                return null;
                            }
                        }
                    }
                    return line;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
