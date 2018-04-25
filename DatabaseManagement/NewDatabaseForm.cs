using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DatabaseManagement
{
    public partial class NewDatabaseForm : Form
    {
        public NewDatabaseForm()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_new_database_Load(object sender, EventArgs e)
        {

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            txt_name.Text = txt_name.Text.Trim();
            txt_path.Text = txt_path.Text.Trim();
            if (txt_name.Text.Trim() == "")
            {
                MessageBox.Show("نام دیتابیس را وارد کنید");
                txt_name.Focus();
                return;
            }
            //if (txt_path.Text.Trim() == "")
            //{
            //    MessageBox.Show("مسیر ذخیره دیتابیس را وارد کنید");
            //    txt_path.Focus();
            //    return;
            //}
            if (txt_path.Text.EndsWith(@"\"))
                txt_path.Text = txt_path.Text.Substring(0, txt_path.Text.Length - 1);
            //if (!System.IO.Directory.Exists(txt_path.Text))
            //{
            //    try
            //    {
            //        System.IO.Directory.CreateDirectory(txt_path.Text);
            //    }
            //    catch
            //    {
            //        MessageBox.Show("خطا در دسترسی به مسیر وارد شده");
            //        return;
            //    }
            //}
            this.UseWaitCursor = true;
            try
            {
                txt_path.Text = txt_path.Text.Trim();
                string s;
                if (txt_path.Text == "")
                    s = string.Format(@"CREATE DATABASE [{0}]", txt_name.Text);
                else
                    s = string.Format(@"CREATE DATABASE [{0}] ON  PRIMARY ( NAME = N'{0}', FILENAME = N'{1}\{0}.mdf' , SIZE = 3072KB , FILEGROWTH = 1024KB ) LOG ON ( NAME = N'{0}_log', FILENAME = N'{1}\{0}_log.ldf' , SIZE = 1024KB , FILEGROWTH = 10%);", txt_name.Text, txt_path.Text);
                DataAccess.Instance.Execute(s);
                //s = string.Format(@"ALTER DATABASE [{0}] SET ANSI_NULL_DEFAULT OFF ;ALTER DATABASE [{0}] SET ANSI_NULLS OFF ;ALTER DATABASE [{0}] SET ANSI_PADDING OFF;ALTER DATABASE [{0}] SET ANSI_WARNINGS OFF;ALTER DATABASE [{0}] SET ARITHABORT OFF ;ALTER DATABASE [{0}] SET AUTO_CLOSE OFF ;ALTER DATABASE [{0}] SET AUTO_CREATE_STATISTICS ON ;ALTER DATABASE [{0}] SET AUTO_SHRINK OFF ;ALTER DATABASE [{0}] SET AUTO_UPDATE_STATISTICS ON ;ALTER DATABASE [{0}] SET CURSOR_CLOSE_ON_COMMIT OFF ;ALTER DATABASE [{0}] SET CURSOR_DEFAULT  GLOBAL ;ALTER DATABASE [{0}] SET CONCAT_NULL_YIELDS_NULL OFF ;ALTER DATABASE [{0}] SET NUMERIC_ROUNDABORT OFF ;ALTER DATABASE [{0}] SET QUOTED_IDENTIFIER OFF ;ALTER DATABASE [{0}] SET RECURSIVE_TRIGGERS OFF ;ALTER DATABASE [{0}] SET AUTO_UPDATE_STATISTICS_ASYNC OFF ;ALTER DATABASE [{0}] SET DATE_CORRELATION_OPTIMIZATION OFF ;ALTER DATABASE [{0}] SET PARAMETERIZATION SIMPLE ;ALTER DATABASE [{0}] SET  READ_WRITE ;ALTER DATABASE [{0}] SET RECOVERY SIMPLE ;ALTER DATABASE [{0}] SET  MULTI_USER ;ALTER DATABASE [{0}] SET PAGE_VERIFY CHECKSUM  ;USE [{0}];IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [{0}] MODIFY FILEGROUP [PRIMARY] DEFAULT;", txt_name.Text, txt_path.Text);
                //DataAccess.Instance.Execute(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در ایجاد دیتابیس" + "\n\n" + ex.Message);
                return;
            }
            finally
            {
                this.UseWaitCursor = false;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void toolStripButton_search_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("\t");

        }

        private void txt_path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (txt_path.Text.Trim() == "")
                    toolStripButton_search_Click(sender, new EventArgs());
                else
                    SendKeys.Send("\t");
        }
    }
}
