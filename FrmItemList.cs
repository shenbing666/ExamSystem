using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExamSystem
{
    public partial class FrmItemList : Form
    {
        public List<Problem> list = new List<Problem>();
        public delegate int MethodDelegate();
        public static MethodDelegate method;
        public FrmItemList()
        {
            InitializeComponent();
        }
        
        private void FrmItemList_Load(object sender, EventArgs e)
        {
            method += new MethodDelegate(getList);
            int count=method();
            toolStripStatusLabel2.Text =count.ToString(); ;
        }
        private int getList() {
            panel1.Controls.Clear();
            using (var db = new LiteDatabase("Prob.db"))
            {
                var col = db.GetCollection<Problem>("Problem");
                var c = col.Count();
                list = col.FindAll().ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    //绘制题库并赋值
                    ItemListControl itemListControl1 = new ItemListControl();
                    itemListControl1.Location = new System.Drawing.Point(22, 16 + (i * 175));
                    itemListControl1.Name = "itemListControl" + i;
                    itemListControl1.Size = new System.Drawing.Size(820, 170);
                    itemListControl1.TabIndex = 0;
                    this.panel1.Controls.Add(itemListControl1);

                    itemListControl1.lblAnswer.Text = list[i].Answer;
                    itemListControl1.lblId.Text = list[i].Id.ToString();
                    itemListControl1.txtItem.Text = list[i].ProbText;
                }
            }
            return list.Count;
        }
    }
}
