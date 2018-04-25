using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DatabaseManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private static LoginForm _Instance;
        public static LoginForm Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new LoginForm();
                if (_Instance.IsDisposed)
                    _Instance = new LoginForm();
                return _Instance;
            }
        }

        public DataTable databaseList = new DataTable();
        public bool connected = false;

        private void Form_Load(object sender, EventArgs e)
        {
            comboBoxServer.Text = Properties.Settings.Default.Server;
            comboBoxAuthentication.SelectedIndex = Properties.Settings.Default.Authentication;
            comboBox_Authentication_SelectedIndexChanged(sender, EventArgs.Empty);
            if (comboBoxAuthentication.SelectedIndex == 1)
                txtUsername.Text = Properties.Settings.Default.UserName;
            if (!backgroundWorkerServers.IsBusy)
                backgroundWorkerServers.RunWorkerAsync();
        }

        private void comboBox_Authentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAuthentication.SelectedIndex == 0)
            {
                txtUsername.Text = Environment.MachineName + @"\" + Environment.UserName;
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsername.Text = "";
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        bool User_Instance = false;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!(this.ActiveControl == btnConnect || this.ActiveControl == txtPassword))
            {
                SendKeys.Send("\t");
                return;
            }
            if (comboBoxServer.Text == "")
            {
                MessageBox.Show("نام یا آدرس سرور را وارد کنید");
                comboBoxServer.Focus();
                comboBoxServer.SelectAll();
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            if (comboBoxAuthentication.SelectedIndex == 0)
            {
                if (User_Instance)
                    Program.ConnectionString = string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True;User Instance=True", comboBoxServer.Text, txtInitialCatalog.Text);
                else
                    Program.ConnectionString = string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True", comboBoxServer.Text, txtInitialCatalog.Text);
            }
            else if (comboBoxAuthentication.SelectedIndex == 1)
            {
                Program.ConnectionString = string.Format(@"Data Source={0};Initial Catalog={3};User ID={1};Password={2}", comboBoxServer.Text, txtUsername.Text, txtPassword.Text, txtInitialCatalog.Text);
            }
            DataAccess.Instance = new DataAccess(Program.ConnectionString);
            try
            {
                if (Program.ShowAllDatabases)
                    databaseList = DataAccess.Instance.GetData("SELECT * FROM [sys].[databases]");
                else
                    databaseList = DataAccess.Instance.GetData("SELECT * FROM [sys].[databases] WHERE [name]=@name", "@name", txtInitialCatalog.Text);
                connected = true;
                Properties.Settings.Default.Server = comboBoxServer.Text;
                Properties.Settings.Default.Authentication = comboBoxAuthentication.SelectedIndex;
                Properties.Settings.Default.UserName = txtUsername.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                databaseList = null;
                connected = false;
                MessageBox.Show("خطا در اتصال به دیتابیس" + "\n\n" + ex.Message);
                return;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            if (comboBoxAuthentication.SelectedIndex == 0)
            {
                Program.LoginName = Environment.MachineName + @"\" + Environment.UserName;
            }
            else if (comboBoxAuthentication.SelectedIndex == 1)
            {
                Program.LoginName = txtUsername.Text.Trim();
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.U)
            {
                User_Instance = !User_Instance;
                MessageBox.Show("User Instance=" + User_Instance.ToString());
            }
            if (e.Alt && e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                Program.ShowAllDatabases = !Program.ShowAllDatabases;
                MessageBox.Show("Show All Databases=" + Program.ShowAllDatabases.ToString());
            }
        }

        private List<string> _DataSources;
        public List<string> DataSources
        {
            get
            {
                if (_DataSources == null)
                    _DataSources = new List<string>();
                return _DataSources;
            }
            set
            {
                _DataSources = value;
            }
        }

        private void backgroundWorkerServers_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorkerServers.ReportProgress(0);
            DataTable dt = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
            if (backgroundWorkerServers.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            foreach (DataRow item in dt.Rows)
            {
                string name = item["ServerName"].ToString() + ((item["InstanceName"] == DBNull.Value || item["InstanceName"] == null || (item["InstanceName"] is string && ((string)item["InstanceName"]) == "")) ? ("") : ("\\" + item["InstanceName"].ToString()));
                this.DataSources.Add(name.Replace(Environment.MachineName, "(local)"));
            }
        }

        private void backgroundWorkerServers_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblServersRefresh.Text = "...";
        }

        private void backgroundWorkerServers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            lblServersRefresh.Text = "";
            foreach (var item in this.DataSources)
            {
                if (comboBoxServer.Items.Contains(item) == false)
                    comboBoxServer.Items.Insert(0, item);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (backgroundWorkerServers.IsBusy)
                backgroundWorkerServers.CancelAsync();
        }

    }
}
