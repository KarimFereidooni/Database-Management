using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DatabaseManagement
{
    public partial class AttachForm : Form
    {
        public AttachForm()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            txt_path.Text = txt_path.Text.Trim();
            txt_name.Text = txt_name.Text.Trim();
            if (txt_path.Text == "")
            {
                MessageBox.Show("مسیر فایل اصلی دیتابیس را وارد کنید");
                txt_path.Focus();
                return;
            }
            if (txt_name.Text == "")
            {
                MessageBox.Show("نام دیتابیس را وارد کنید");
                txt_path.Focus();
                return;
            }
            this.UseWaitCursor = true;
            try
            {
                txt_path.Text = txt_path.Text.Trim();
                string s = string.Format(@"USE [master]; CREATE DATABASE [{0}] ON  ( FILENAME = N'{1}' ), ( FILENAME = N'{2}' )  FOR ATTACH ; if not exists (select name from master.sys.databases sd where name = N'{0}' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [{0}].dbo.sp_changedbowner @loginame=N'sa', @map=false", txt_name.Text, txt_path.Text, txt_path.Text.Substring(0, txt_path.Text.Length - 4) + "_log.ldf", Program.LoginName);
                DataAccess.Instance.Execute(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در وصل کردن دیتابیس" + "\n\n" + ex.Message);
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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = openFileDialog1.FileName;
                if (txt_name.Text.Trim() == "")
                    txt_name.Text = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            }
        }

        private void txt_path_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_path.Text.Trim() == "")
                    toolStripButton_search_Click(sender, new EventArgs());
                else
                    SendKeys.Send("\t");
            }
        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk_Click(sender, new EventArgs());
        }
    }
}
