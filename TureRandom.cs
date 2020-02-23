using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamSystem
{
    /// <summary>
    /// 生成不重复的随机数
    /// </summary>
    public class TureRandom
    {
        ArrayList nums = new ArrayList();
        private int min=-1;
        private int max = -1;
        public TureRandom(int startnum, int endnum)
        {

            if (startnum >= endnum)
            {
                throw new Exception("对不起，起始数字必须小于结尾数字！");
            }
            else
            {
                min = startnum;
                max = endnum+1;
                for (int i = startnum; i <= endnum; ++i)
                {
                    nums.Add(i);
                }
            }
        }

        public int GetNum()
        {
            if (nums.Count <= 0)
            {
                //throw new Exception("对不起，指定范围的随机数全部产生过了。");
                return -1;
            }
             
            else
            {
                Random r = new Random();
                int index = (int)(r.Next(min, max));
                while (!nums.Contains(index))//判断集合中有没有生成的随机数，如果有，则重新生成一个随机数，直到生成的随机数list集合中没有才退出循环
                {
                    index = r.Next(min, max);
                }
                for (int i = 0; i < nums.Count; i++)  //遍历nums集合，找到该值的索引，并返回
                {
                    if (nums[i].ToString() == index.ToString())
                    {
                        index = i;
                        break;
                    }
                }
                int returnnum = (int)(nums[index]);
                nums.RemoveAt(index);
                return returnnum;
            }
        }
    }
}
