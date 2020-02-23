using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LiteDB;

namespace ExamSystem
{
    public partial class ItemListControl : UserControl
    {
        public ItemListControl()
        {
            InitializeComponent();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase("Prob.db"))
            {
               
                var col = db.GetCollection<Problem>("Problem");
                //是否删除成功，成功，重新刷新界面
                bool isSuc = col.Delete(int.Parse(lblId.Text));
                if (isSuc) {
                    FrmItemList.method();
                }
            }
        }
    }
}
