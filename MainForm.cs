using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using LiteDB;

namespace ExamSystem
{
    public partial class MainForm : Form
    {
        private string answer = "";
        private TureRandom tur;

        public MainForm()
        {
            InitializeComponent();

            using (var db = new LiteDatabase("Prob.db"))
            {
                var col = db.GetCollection<Problem>("Problem");
                var c = col.Count();
                //list = col.FindAll().ToList();
                DataSource.list = col.FindAll().ToList();
            }
            radioButton1.Checked = true;
            //_proc = HookCallback;
            //RunHook();
        }
        private void 导入题库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportForm ef = new ExportForm();
            ef.Show();
        }

        private void 搜题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmItemSearch frm = new FrmItemSearch();
            frm.list = DataSource.list;
            frm.Show();
        }
        /// <summary>
        /// 随机出题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRandom_Click(object sender, EventArgs e)
        {
            //初始化
            lblAnswer.Text = "***";
            btnShow.Text = "显示";
            string type = GetTypeName();
            if (type == "错误") return;
            groupBox1.Text = type;
     
            //获取该题型下的数据
            var lst = DataSource.list.Where(s => s.TypeName == type).ToList();
            if (lst.Count < 1)
            {
                MessageBox.Show("该题型下没有题目！");
                return;
            }
            int count = lst.Count;
            if (DataSource.isChange == false)
            {
                DataSource.isChange = true;
                tur = new TureRandom(0, lst.Count - 1);
            }

            //获取随机数
            Random random = new Random();
            //int ran = random.Next(0, count);
            int ran = tur.GetNum();
            if (ran < 0)
            {
                MessageBox.Show("题目随机完毕！");
                DataSource.isChange = false;
                return;
            }
            txtContent.Text = lst[ran].ProbText;
            answer = lst[ran].Answer;
        }
        private string GetTypeName()
        {
            string result = "";
            if (radioButton1.Checked)
            {
                result = "单选题";
            }
            else if (radioButton2.Checked)
            {
                result = "多选题";
            }
            else if (radioButton3.Checked)
            {
                result = "填空题";
            }
            else if (radioButton4.Checked)
            {
                result = "判断题";
            }
            else if (radioButton5.Checked)
            {
                result = "简答题";
            }
            else
            {
                result = "错误";
            }
            return result;
        }

        /// <summary>
        ///生成制定位数的随机码（数字）
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomCode(int length)
        {
            var result = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                var r = new Random(Guid.NewGuid().GetHashCode());
                result.Append(r.Next(0, 10));
            }
            return result.ToString();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (btnShow.Text == "显示")
            {
                if (!string.IsNullOrEmpty(answer))
                {
                    lblAnswer.Text = answer;
                }
                else
                {
                    lblAnswer.Text = "暂无答案！";
                }
                 btnShow.Text = "隐藏";
            }
            else
            {
                lblAnswer.Text = "***";
                btnShow.Text = "显示";
            }
            
        }

        private void 题库列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmItemList frm = new FrmItemList();
            frm.list = DataSource.list;
            frm.Show();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            DataSource.isChange = false;
        }
    }
}
