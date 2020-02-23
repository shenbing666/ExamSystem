using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LiteDB;
using System.Data.SQLite;
using System.Data;



namespace ExamSystem
{
    public partial class ExportForm : Form
    {
        private SQLiteConnection conn;
        private SQLiteCommand cmd; 
        public ExportForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (conn = new SQLiteConnection(@"Data Source=E:\源码\题库\ExamSystem-master\bin\Debug\QB.db"))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {

                    }
                    else
                    {

                    }

                } 
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
       
           
           
           int count=0;
            //获取题目类型
            var typeName = comboBox1.Text.Trim();
            using (var db = new LiteDatabase(@"Prob.db"))
            {    
                var col = db.GetCollection<Problem>("Problem");
                //先换行分割
                var prolist = textBox1.Text.Trim().Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                Problem model ;
                Int32 index = 0;
                //题目列表，多行的每次读最后一个
                List<Problem> modelList = new List<Problem>();
                //根据每行的第一个字符和、号进行区分，如果不是新题目，就作为选项添加到上一个题目中去
                while (index <prolist.Length )
                {
                    var item = prolist[index];
                    if (String.IsNullOrEmpty(item)) continue;
                    var titles = item.Trim().Split('、');
                    if (titles.Length > 0)
                    {
                        int number;
                        if(Int32.TryParse(titles[0],out number))
                        {   //是数字，添加
                            model = new Problem();  //如果分割第1个是数字，则说明是1个新的题目
                            model.ProbId = number;
                            model.ProbText = RemovedAnswer.getStr(typeName,item);
                            //model.ProbText = item;
                            model.TypeName = typeName;
                            //确定答案，答案在（）里面，把括号里面是字符串分解并组合
                            var ans = item.Split('（', '）');
                            if (ans.Length < 2) model.Answer = string.Empty;
                            if (ans.Length > 1) model.Answer = ans[1];
                            if (ans.Length > 3) model.Answer = ans[1] + "\r\n" + ans[3];
                            modelList.Add(model);
                        }
                        else
                        {
                            //不是数字，就添加到前一个实体中去，并更新题目内容
                            modelList.Last().ProbText += ("\r\n" + item);
                        }
                    }
                    else
                    {
                        //不是数字，就添加到前一个实体中去，并更新题目内容
                        modelList.Last().ProbText += ("\r\n" + item);
                    }
                    index++;
                }
                col.InsertBulk(modelList);
                count=modelList.Count;
            }
            MessageBox.Show("导入完成，共导入" + count+ "道题，重启软件后生效！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }
    }
}