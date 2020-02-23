using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamSystem
{
    public class Problem
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Int32 Id { get; set; }

        /// <summary>题目编号，可以重复，注意不能使用Id</summary>
        public Int32 ProbId { get; set; }
        /// <summary>整个题目内容，同时包括选项</summary>
        public String ProbText { get; set; }
        /// <summary>答案，一般是题干答案中的东西</summary>
        public String Answer { get; set; }
        /// <summary>题目类型</summary>
        public String TypeName { get; set; }
    }
}
