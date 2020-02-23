using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExamSystem
{
    /// <summary>
    /// 去答案
    /// </summary>
    public class RemovedAnswer
    {
        public static string getStr(string tagname, string source)
        {
            string result="";
            int a, b;
            switch (tagname)
            {
                case "填空题":
                   
                    break;
                case "单选题":
                     a = source.IndexOf('（')+1;
                     b = source.IndexOf('）');
                    result = source.Remove(a,b-a);
                    break;
                case "多选题":
                     a = source.IndexOf('（')+1;
                     b = source.IndexOf('）');
                    result = source.Remove(a,b-a);
                    break;
                case "判断题":

                    break;
                case "简答题":

                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
