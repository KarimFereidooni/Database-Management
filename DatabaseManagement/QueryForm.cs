using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace DatabaseManagement
{
    public partial class QueryForm : Form
    {
        public QueryForm(string Database)
        {
            InitializeComponent();
            SelectedDatabase = Database;
        }
        public QueryForm()
        {
            InitializeComponent();
            SelectedDatabase = null;
        }

        string SelectedDatabase;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        int index = 0;
        List<string> queryList = new List<string>();

        private void btnExecute_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            if (cmbDatabase.Text.Trim() == "")
            {
                MessageBox.Show("دیتابیس را انتخاب کنید");
                cmbDatabase.Focus();
                return;
            }
            if (txtCommand.Text == "")
            {
                txtCommand.Focus();
                return;
            }
            dataGridView.DataSource = null;

            try
            {
                DataAccess.Instance.Connection.Open();
                DataAccess.Instance.Connection.ChangeDatabase(cmbDatabase.Text);
                SqlTransaction transaction = DataAccess.Instance.Connection.BeginTransaction();
                DataAccess.Instance.Command.Transaction = transaction;
                DataAccess.Instance.Command.CommandTimeout = 60;

                Regex regex = new Regex("^\\s*GO\\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                string[] lines = regex.Split(txtCommand.Text);
                for (int i = 0; i <= lines.Length - 1; i++)
                {
                    if (lines[i].Length > 0)
                    {
                        try
                        {
                            DataAccess.Instance.Execute(lines[i]);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            DataAccess.Instance.Connection.Close();
                            lblResult.ForeColor = Color.Red;
                            SetMessage(ex.Message);
                            return;
                        }
                    }
                }

                transaction.Commit();
                DataAccess.Instance.Connection.Close();
            }
            catch (Exception ex)
            {
                lblResult.ForeColor = Color.Red;
                SetMessage(ex.Message);
                return;
            }
            finally
            {
                if (DataAccess.Instance.Connection.State == ConnectionState.Open)
                    DataAccess.Instance.Connection.Close();
            }
            queryList.Add(txtCommand.Text);
            lblResult.ForeColor = Color.Blue;
            SetMessage("Query executed successfully.");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtCommand.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطا در خواندن فایل" + "\n\n" + ex.Message);
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCommand.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCommand.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtCommand.Paste();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            SetMessage(e.Exception.Message);
        }

        private void Form_query_Load(object sender, EventArgs e)
        {
            try
            {
                cmbDatabase.Items.Clear();
                foreach (DataRow r in MainForm.Instance.DatabaseList.Rows)
                {
                    cmbDatabase.Items.Add(r["name"].ToString());
                }
                if (SelectedDatabase == null)
                    cmbDatabase.SelectedItem = "master";
                else
                    cmbDatabase.SelectedItem = SelectedDatabase;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmbCommand.Items.Add("Select");
            cmbCommand.Items.Add("Insert");
            cmbCommand.Items.Add("Update");
            cmbCommand.Items.Add("Delete");
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (queryList.Count > 0)
            {
                index++;
                if (index >= queryList.Count)
                    index = queryList.Count - 1;
                txtCommand.Text = queryList[index];
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (queryList.Count > 0)
            {
                index--;
                if (index < 0)
                    index = 0;
                txtCommand.Text = queryList[index];
            }
        }

        private void cmbCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            int length;
            switch (cmbCommand.SelectedItem.ToString())
            {
                case "Insert":
                    length = txtCommand.Text.Length;
                    txtCommand.Text += "\r\nINSERT INTO [Table]() VALUES()";
                    txtCommand.Text = txtCommand.Text.Trim();
                    txtCommand.SelectionStart = txtCommand.Text.LastIndexOf("Table");
                    txtCommand.SelectionLength = 5;

                    txtCommand.Focus();
                    break;
                case "Select":
                    length = txtCommand.Text.Length;
                    txtCommand.Text += "\r\nSELECT * FROM [Table]";
                    txtCommand.Text = txtCommand.Text.Trim();
                    txtCommand.SelectionStart = txtCommand.Text.LastIndexOf("Table");
                    txtCommand.SelectionLength = 5;
                    txtCommand.Focus();
                    break;
                case "Update":
                    length = txtCommand.Text.Length;
                    txtCommand.Text += "\r\nUPDATE [Table] SET ";
                    txtCommand.Text = txtCommand.Text.Trim();
                    txtCommand.SelectionStart = txtCommand.Text.LastIndexOf("Table");
                    txtCommand.SelectionLength = 5;
                    txtCommand.Focus();
                    break;
                case "Delete":
                    length = txtCommand.Text.Length;
                    txtCommand.Text += "\r\nDELETE FROM [Table]";
                    txtCommand.Text = txtCommand.Text.Trim();
                    txtCommand.SelectionStart = txtCommand.Text.LastIndexOf("Table");
                    txtCommand.SelectionLength = 5;
                    txtCommand.Focus();
                    break;
            }

        }

        private void btn_execute_t_sql_Click(object sender, EventArgs e)
        {
            try
            {
                string file = System.IO.Path.Combine(Application.StartupPath, "SqlOut.txt");
                process_tsql.StartInfo.Arguments = string.Format("-S {0} -d {1} -q \"{2}\" -o \"{3}\"", DataAccess.Instance.Connection.DataSource, cmbDatabase.Text, txtCommand.Text, file);
                process_tsql.Start();
                process_tsql.WaitForExit();
                if (System.IO.File.Exists(file))
                    SetMessage(System.IO.File.ReadAllText(file));
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا" + "\r\n" + ex.Message);
            }
        }

        void p_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            lblResult.Text += e.Data + "\r\n";
        }

        private void process_tsql_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            SetMessage(e.Data);
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            if (cmbDatabase.Text.Trim() == "")
            {
                MessageBox.Show("دیتابیس را انتخاب کنید");
                cmbDatabase.Focus();
                return;
            }
            if (txtCommand.Text == "")
            {
                txtCommand.Focus();
                return;
            }
            dataGridView.DataSource = null;

            try
            {
                DataAccess.Instance.Connection.Open();
                DataAccess.Instance.Connection.ChangeDatabase(cmbDatabase.Text);
                SqlTransaction transaction = DataAccess.Instance.Connection.BeginTransaction();
                DataAccess.Instance.Command.CommandTimeout = 60;
                DataAccess.Instance.Command.Transaction = transaction;
                Regex regex = new Regex("^\\s*GO\\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                string[] lines = regex.Split(txtCommand.Text);
                for (int i = 0; i <= lines.Length - 1; i++)
                {
                    if (lines[i].Length > 0)
                    {
                        try
                        {
                            DataTable dt = DataAccess.Instance.GetData(lines[i]);
                            dataGridView.DataSource = dt;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            DataAccess.Instance.Connection.Close();
                            lblResult.ForeColor = Color.Red;
                            SetMessage(ex.Message);
                            return;
                        }
                    }
                }
                transaction.Commit();
                DataAccess.Instance.Connection.Close();
            }
            catch (Exception ex)
            {
                lblResult.ForeColor = Color.Red;
                SetMessage(ex.Message);
                return;
            }
            finally
            {
                if (DataAccess.Instance.Connection.State == ConnectionState.Open)
                    DataAccess.Instance.Connection.Close();
            }
            queryList.Add(txtCommand.Text);
            lblResult.ForeColor = Color.Blue;
            SetMessage("Query executed successfully.");
        }

        private void btnExecuteNoRollback_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            if (cmbDatabase.Text.Trim() == "")
            {
                MessageBox.Show("دیتابیس را انتخاب کنید");
                cmbDatabase.Focus();
                return;
            }
            if (txtCommand.Text == "")
            {
                txtCommand.Focus();
                return;
            }
            dataGridView.DataSource = null;

            try
            {
                DataAccess.Instance.Connection.Open();
                DataAccess.Instance.Connection.ChangeDatabase(cmbDatabase.Text);
                DataAccess.Instance.Command.CommandTimeout = 60;

                Regex regex = new Regex("^\\s*GO\\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                string[] lines = regex.Split(txtCommand.Text);
                for (int i = 0; i <= lines.Length - 1; i++)
                {
                    if (lines[i].Length > 0)
                    {
                        try
                        {
                            DataAccess.Instance.Execute(lines[i]);
                        }
                        catch (Exception ex)
                        {
                            DataAccess.Instance.Connection.Close();
                            lblResult.ForeColor = Color.Red;
                            SetMessage(ex.Message);
                            return;
                        }
                    }
                }

                DataAccess.Instance.Connection.Close();
            }
            catch (Exception ex)
            {
                lblResult.ForeColor = Color.Red;
                SetMessage(ex.Message);
                return;
            }
            finally
            {
                if (DataAccess.Instance.Connection.State == ConnectionState.Open)
                    DataAccess.Instance.Connection.Close();
            }
            queryList.Add(txtCommand.Text);
            lblResult.ForeColor = Color.Blue;
            SetMessage("Query executed successfully.");
        }

        void SetMessage(string text)
        {
            lblResult.Text = "";
            foreach (char ch in text)
            {
                lblResult.Text += ch.ToString();
                lblResult.Refresh();
                System.Threading.Thread.Sleep(5);
            }
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyData == Keys.A)
                txtCommand.SelectAll();
        }

        private void btnExecuteFile_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            if (cmbDatabase.Text.Trim() == "")
            {
                MessageBox.Show("دیتابیس را انتخاب کنید");
                cmbDatabase.Focus();
                return;
            }
            dataGridView.DataSource = null;

            if (openFileDialog.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
            try
            {
                DataAccess.Instance.Connection.Open();
                DataAccess.Instance.Connection.ChangeDatabase(cmbDatabase.Text);
                DataAccess.Instance.Command.CommandTimeout = 60;

                System.IO.StreamReader stream = new System.IO.StreamReader(openFileDialog.FileName);
                while (stream.EndOfStream == false)
                {
                    string line = stream.ReadLine();
                    if (line.Length > 0)
                    {
                        try
                        {
                            if (line.Trim().ToLower() != "go")
                                DataAccess.Instance.Execute(line);
                        }
                        catch (Exception ex)
                        {
                            DataAccess.Instance.Connection.Close();
                            lblResult.ForeColor = Color.Red;
                            SetMessage(ex.Message);
                            stream.Close();
                            stream.Dispose();
                            return;
                        }
                    }
                }
                stream.Close();
                stream.Dispose();
                DataAccess.Instance.Connection.Close();
            }
            catch (Exception ex)
            {
                lblResult.ForeColor = Color.Red;
                SetMessage(ex.Message);
                return;
            }
            finally
            {
                if (DataAccess.Instance.Connection.State == ConnectionState.Open)
                    DataAccess.Instance.Connection.Close();
            }
            queryList.Add(txtCommand.Text);
            lblResult.ForeColor = Color.Blue;
            SetMessage("Query executed successfully.");
        }
    }
}
