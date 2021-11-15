using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleSameInTwoFolder
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> m_dic1Same = new Dictionary<string, string>();
        Dictionary<string, string> m_dic2Same = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
        }

        //文件夹1
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog(); //是调用文件浏览器控件；           
            if (dr == System.Windows.Forms.DialogResult.OK) //是判断文件浏览器控件是否返回ok，即用户是否确定选择。如果确定选择，则弹出用户在文件浏览器中选择的路径：                
            {
                MessageBox.Show(folderBrowserDialog1.SelectedPath);
                label3.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        //文件夹2
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog2.ShowDialog(); //是调用文件浏览器控件；           
            if (dr == System.Windows.Forms.DialogResult.OK) //是判断文件浏览器控件是否返回ok，即用户是否确定选择。如果确定选择，则弹出用户在文件浏览器中选择的路径：                
            {
                MessageBox.Show(folderBrowserDialog2.SelectedPath);
                label4.Text = folderBrowserDialog2.SelectedPath;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //比较同名文件
        private void button3_Click(object sender, EventArgs e)
        {
            if (label3.Text != "" && label4.Text != "")
            {
                var dir1 = label3.Text;
                Dictionary<string, string> dic1All = new Dictionary<string, string>();
                foreach (var f in new DirectoryInfo(dir1).GetFiles("*.*", SearchOption.AllDirectories))
                {
                    FileInfo info = f;
                    dic1All[info.FullName] = info.Name;
                }

                var dir2 = label4.Text;
                Dictionary<string, string> dic2All = new Dictionary<string, string>();
                foreach (var f in new DirectoryInfo(dir2).GetFiles("*.*", SearchOption.AllDirectories))
                {
                    FileInfo info = f;
                    dic2All[info.FullName] = info.Name;
                }

                m_dic1Same.Clear();
                m_dic2Same.Clear();
                foreach (var fold1 in dic1All)
                {
                    foreach (var fold2 in dic2All)
                    {
                        if (fold1.Value == fold2.Value)
                        {
                            m_dic1Same[fold1.Key] = fold1.Value;
                            m_dic2Same[fold2.Key] = fold2.Value;
                        }
                    }
                }
                listBox1.Items.Clear();
                foreach (var item in m_dic1Same)
                {
                    listBox1.Items.Add(item.Value);
                }

                
            }
            else
            {
                MessageBox.Show("请选择两个文件夹");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var fold in m_dic1Same)
            {
                File.Delete(fold.Key);
            }
            m_dic1Same.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var fold in m_dic2Same)
            {
                File.Delete(fold.Key);
            }
            m_dic2Same.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
