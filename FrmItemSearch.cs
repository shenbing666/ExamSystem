using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ExamSystem
{
    public partial class FrmItemSearch : Form
    {
        public List<Problem> list = new List<Problem>();
        public FrmItemSearch()
        {
            InitializeComponent();
        }

        #region api
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;
        /// <summary>
        /// 启动监测程序
        /// </summary>
        public void RunHook()
        {
            _hookID = SetHook(_proc);
        }

        /// <summary>
        /// 关闭监测程序
        /// </summary>
        public void UnHook()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        /// <summary>
        /// 设置默认值与数据
        /// </summary>
        /// <param name="initInt"></param>
        /// <param name="outString">"F:\图片\精品分类\品牌图片\google徽标\@_@.gif"</param>
        public void Init(int initInt, string outString)
        {
            i = initInt;
            str = outString;
        }

        private static int i = 0;
        private static string str = @"I:\over\Images\google\@_@.jpg";

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;
                //同时按下Ctrl+V键的时候
                if (Control.ModifierKeys == Keys.Control && key.Equals(Keys.C))
                {
                    //获得剪切板数据
                    IDataObject iData = Clipboard.GetDataObject();
                    string data = ((String)iData.GetData(DataFormats.Text)).Trim();// Clipboard.GetText(TextDataFormat.UnicodeText).Trim();

                    #region
                    txtKeyValue.Text = data;
                    var models = list.Where(n => n.ProbText.Contains(data)).ToList();
                    if (models.Count == 1)
                    {
                        lblTypeName1.Text = models[0].TypeName;
                        lblAnswer1.Text = String.IsNullOrEmpty(models[0].Answer) ? "题目寻找答案" : models[0].Answer;
                        txtDisp1.Text = models[0].ProbText;
                    }
                    if (models.Count >= 2)
                    {
                        lblTypeName1.Text = models[0].TypeName;
                        lblAnswer1.Text = String.IsNullOrEmpty(models[0].Answer) ? "题目寻找答案" : models[0].Answer;
                        txtDisp1.Text = models[0].ProbText;

                        lblTypeName2.Text = models[1].TypeName;
                        lblAnswer2.Text = String.IsNullOrEmpty(models[1].Answer) ? "题目寻找答案" : models[1].Answer;
                        txtDisp2.Text = models[1].ProbText;
                    }
                    #endregion

                    //重新设置剪切板数据
                    DataObject m_data = new DataObject();
                    m_data.SetData(DataFormats.Text, true, str.Replace("@_@", Convert.ToString(++i)));
                    Clipboard.SetDataObject(m_data, true);
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        #endregion

        #region 调用API
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr SetWindowsHookEx(int idHook,

        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]

        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,

        IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //每次搜索前都要情况其他控件
            txtDisp1.Text = String.Empty;
            txtDisp2.Text = String.Empty;
            lblAnswer1.Text = String.Empty;
            lblAnswer2.Text = String.Empty;
            try
            {
                //获取剪切板数据
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text)) txtKeyValue.Text = ((String)iData.GetData(DataFormats.Text)).Trim();
                //查找满足关键词的题目
                var models = list.Where(n => n.ProbText.Contains(txtKeyValue.Text)).ToList();
                //最多只显示2个包括选择关键词的题目
                if (models.Count == 1)
                {
                    lblTypeName1.Text = models[0].TypeName;
                    lblAnswer1.Text = String.IsNullOrEmpty(models[0].Answer) ? "题目寻找答案" : models[0].Answer;
                    string s = models[0].ProbText;
                    s = RemovedAnswer.getStr(models[0].TypeName, s);
                    txtDisp1.Text = models[0].ProbText;
                    txtDisp1.Text = s;
                }
                if (models.Count >= 2)
                {
                    lblTypeName1.Text = models[0].TypeName;
                    lblAnswer1.Text = String.IsNullOrEmpty(models[0].Answer) ? "题目寻找答案" : models[0].Answer;
                    txtDisp1.Text = models[0].ProbText;

                    lblTypeName2.Text = models[1].TypeName;
                    lblAnswer2.Text = String.IsNullOrEmpty(models[1].Answer) ? "题目寻找答案" : models[1].Answer;
                    txtDisp2.Text = models[1].ProbText;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("出现错误,重启后再试！");
            }
        }
    }
}
