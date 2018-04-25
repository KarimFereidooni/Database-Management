using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using DatabaseManagement;

namespace ZeroAndOne.Sql.Forms
{
    public partial class InstallLocalUpdates : Form
    {
        public InstallLocalUpdates(Guid currentApplication, Version currentProgramVersion, string connectionString, string updateFilesPath, string updateFilesExtension)
        {
            InitializeComponent();
            this.CurrentApplication = currentApplication;
            this.CurrentProgramVersion = currentProgramVersion;
            this.ConnectionString = connectionString;
            this.DataAccess = new DataAccess(connectionString);
            this.UpdateFilesPath = updateFilesPath;
            this.UpdateFilesExtension = updateFilesExtension;
        }

        private string _UpdateFilesExtension;
        /// <summary>
        /// بدون نقطه
        /// </summary>
        public string UpdateFilesExtension
        {
            get
            {
                return _UpdateFilesExtension;
            }
            set
            {
                if (value.StartsWith("."))
                    _UpdateFilesExtension = value.Substring(1);
                else
                    _UpdateFilesExtension = value;
            }
        }

        private string _ConnectionString;
        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }

        private string _UpdateFilesPath;
        public string UpdateFilesPath
        {
            get
            {
                return _UpdateFilesPath;
            }
            set
            {
                _UpdateFilesPath = value;
            }
        }

        private Guid _CurrentApplication;
        public Guid CurrentApplication
        {
            get
            {
                return _CurrentApplication;
            }
            set
            {
                _CurrentApplication = value;
            }
        }

        Version _CurrentProgramVersion;
        public Version CurrentProgramVersion
        {
            get
            {
                return _CurrentProgramVersion;
            }
            set
            {
                _CurrentProgramVersion = value;
            }
        }

        DataAccess _DataAccess;
        public DataAccess DataAccess
        {
            get
            {
                return _DataAccess;
            }
            set
            {
                _DataAccess = value;
            }
        }

        public virtual void InitDatabaseVersion()
        {
            string query = "SET ANSI_NULLS ON";
            query += Environment.NewLine + "GO" + Environment.NewLine;
            query += Environment.NewLine + "SET QUOTED_IDENTIFIER ON" + Environment.NewLine;
            query += Environment.NewLine + "GO" + Environment.NewLine;
            query += Environment.NewLine + "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DatabaseVersion]') AND type in (N'U'))" + Environment.NewLine;
            query += Environment.NewLine + "BEGIN" + Environment.NewLine;
            query += Environment.NewLine + "CREATE TABLE [dbo].[DatabaseVersion](" + Environment.NewLine;
            query += Environment.NewLine + "	[ID] [int] IDENTITY(1,1) NOT NULL," + Environment.NewLine;
            query += Environment.NewLine + "	[Version] [nvarchar](50) NOT NULL," + Environment.NewLine;
            query += Environment.NewLine + "	[ApplicationID] [uniqueidentifier] NULL," + Environment.NewLine;
            query += Environment.NewLine + " CONSTRAINT [PK_DatabaseVersion] PRIMARY KEY CLUSTERED " + Environment.NewLine;
            query += Environment.NewLine + "(" + Environment.NewLine;
            query += Environment.NewLine + "	[ID] ASC" + Environment.NewLine;
            query += Environment.NewLine + ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]" + Environment.NewLine;
            query += Environment.NewLine + ") ON [PRIMARY]" + Environment.NewLine;
            query += Environment.NewLine + "END" + Environment.NewLine;
            query += Environment.NewLine + "GO" + Environment.NewLine;
            query += Environment.NewLine + "IF NOT EXISTS (SELECT * FROM [dbo].[DatabaseVersion])" + Environment.NewLine;
            query += Environment.NewLine + "BEGIN" + Environment.NewLine;
            query += Environment.NewLine + "SET IDENTITY_INSERT [dbo].[DatabaseVersion] ON" + Environment.NewLine;
            query += Environment.NewLine + "INSERT [dbo].[DatabaseVersion] ([ID], [Version], [ApplicationID]) VALUES (1, N'1.0.0.0', NULL)" + Environment.NewLine;
            query += Environment.NewLine + "SET IDENTITY_INSERT [dbo].[DatabaseVersion] OFF" + Environment.NewLine;
            query += Environment.NewLine + "END";
            string error;
            if (!SqlHelper.RunQueryWithRollback(query, this.ConnectionString, out error))
                throw new Exception(error);
        }

        public virtual Version GetDatabaseVersion()
        {
            DataTable dt = null;
            string query = "SELECT * FROM [DatabaseVersion]";
            try
            {
                dt = this.DataAccess.GetData(query);
            }
            catch
            {
                InitDatabaseVersion();
                dt = this.DataAccess.GetData(query);
            }
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    InitDatabaseVersion();
                    return new Version(1, 0, 0, 0);
                }
                else
                {
                    return new Version(dt.Rows[0]["Version"].ToString());
                }
            }
            else
                return new Version(1, 0, 0, 0);
        }

        public void CheckForUpdate()
        {
            this.ShowDialog();
        }

        //
        // Summary:
        //     Shows the form as a modal dialog box with the currently active window set
        //     as its owner.
        //
        // Returns:
        //     One of the System.Windows.Forms.DialogResult values.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The form specified in the owner parameter is the same as the form being shown.
        //
        //   System.InvalidOperationException:
        //     The form being shown is already visible.  -or- The form being shown is disabled.
        //      -or- The form being shown is not a top-level window.  -or- The form being
        //     shown as a dialog box is already a modal form.  -or- The current process
        //     is not running in user interactive mode (for more information, see System.Windows.Forms.SystemInformation.UserInteractive).
        public new System.Windows.Forms.DialogResult ShowDialog()
        {
            return this.ShowDialog(null);
        }

        //
        // Summary:
        //     Shows the form as a modal dialog box with the specified owner.
        //
        // Parameters:
        //   owner:
        //     Any object that implements System.Windows.Forms.IWin32Window that represents
        //     the top-level window that will own the modal dialog box.
        //
        // Returns:
        //     One of the System.Windows.Forms.DialogResult values.
        //
        // Exceptions:
        //   System.ArgumentException:
        //     The form specified in the owner parameter is the same as the form being shown.
        //
        //   System.InvalidOperationException:
        //     The form being shown is already visible.  -or- The form being shown is disabled.
        //      -or- The form being shown is not a top-level window.  -or- The form being
        //     shown as a dialog box is already a modal form.  -or- The current process
        //     is not running in user interactive mode (for more information, see System.Windows.Forms.SystemInformation.UserInteractive).
        public new System.Windows.Forms.DialogResult ShowDialog(IWin32Window owner)
        {
            Version databaseVersion = GetDatabaseVersion();
            //if (this.CurrentProgramVersion.CompareTo(databaseVersion) > 0)
            //{
            string[] files = System.IO.Directory.GetFiles(this.UpdateFilesPath, "*." + this.UpdateFilesExtension, System.IO.SearchOption.TopDirectoryOnly);
            if (files.Length == 0)
                return System.Windows.Forms.DialogResult.OK;
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = System.IO.Path.GetFileNameWithoutExtension(files[i]);
            }
            UpdateFile[] updateFiles = new UpdateFile[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                updateFiles[i] = new UpdateFile(files[i]);
            }
            Array.Sort(updateFiles, VersionComparer.Instance);
            foreach (UpdateFile item in updateFiles)
            {
                Version version = new Version(item.Version);
                if (version.CompareTo(databaseVersion) > 0)
                    this.UpdateFiles.Add(item);
            }
            if (this.UpdateFiles.Count == 0)
                return System.Windows.Forms.DialogResult.OK;
            if (owner == null)
                return base.ShowDialog();
            else
                return base.ShowDialog(owner);
            //}
            //else
            //{
            //    return System.Windows.Forms.DialogResult.OK;
            //}
        }

        public class UpdateFile
        {
            public UpdateFile(string fileNameWithoutExtension)
            {
                File = fileNameWithoutExtension;
                if (fileNameWithoutExtension.EndsWith("-"))
                    Version = fileNameWithoutExtension.Substring(0, fileNameWithoutExtension.Length - 1);
                else
                    Version = fileNameWithoutExtension;
                InstallWithRollback = !fileNameWithoutExtension.EndsWith("-");
            }
            public string Version { get; set; }
            public string File { get; set; }
            public bool InstallWithRollback { get; set; }
            public override string ToString()
            {
                //for VersionComparer
                return Version;
            }
        }

        private List<UpdateFile> _UpdateFiles = new List<UpdateFile>();
        public List<UpdateFile> UpdateFiles
        {
            get
            {
                return _UpdateFiles;
            }
            set
            {
                _UpdateFiles = value;
            }
        }

        public bool IsCurrectVersion(string version)
        {
            if (version == null)
                return false;
            string[] strArray = version.Split(new char[1] { '.' });
            int length = strArray.Length;
            if (length < 2 || length > 4)
                return false;
            int _Major = int.Parse(strArray[0], (IFormatProvider)CultureInfo.InvariantCulture);
            if (_Major < 0)
                return false;
            int _Minor = int.Parse(strArray[1], (IFormatProvider)CultureInfo.InvariantCulture);
            if (_Minor < 0)
                return false;
            int num = length - 2;
            if (num <= 0)
                return true;
            int _Build = int.Parse(strArray[2], (IFormatProvider)CultureInfo.InvariantCulture);
            if (_Build < 0)
                return false;
            if (num - 1 <= 0)
                return true;
            int _Revision = int.Parse(strArray[3], (IFormatProvider)CultureInfo.InvariantCulture);
            if (_Revision < 0)
                return false;
            return true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Refresh();
            //int successCount, errorCount;
            //InstallUpdates(out  successCount, out  errorCount);
            backgroundWorker.RunWorkerAsync();
            this.Refresh();
            //if (successCount == 0 && errorCount == 0)
            //    this.Close();
            //else if (errorCount == 0)
            //{
            //    SetMessage("به روز رسانی با موفقیت به پایان رسید");
            //    timerClose.Start();
            //}
        }

        //private void InstallUpdates(out int successCount, out int errorCount)
        //{

        //}

        private void SetStatus(string text)
        {
            //lblStatus.Text = "";
            //foreach (char ch in text)
            //{
            //    lblStatus.Text += ch.ToString();
            //    lblStatus.Refresh();
            //    System.Threading.Thread.Sleep(5);
            //}
            //lblStatus.Refresh();
            listBoxStatus.Items.Add(text);
            listBoxStatus.SelectedIndex = listBoxStatus.Items.Count - 1;
            listBoxStatus.Refresh();
            //System.Threading.Thread.Sleep(1000);
        }

        private void SetMessage(string text)
        {
            //lblStatus.ForeColor = Color.Blue;
            SetStatus(text);
        }

        private void SetError(string text)
        {
            //lblStatus.ForeColor = Color.Red;
            SetStatus("خطا --> " + text);
        }

        int closeTime = 6;

        public int CloseTime
        {
            get { return closeTime; }
            set
            {
                closeTime = value;
                lblTitle.Text = "بروزرسانی با موفقیت به پایان رسید." + Environment.NewLine + value.ToString();
            }
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            CloseTime -= 1;
            if (CloseTime == 0)
            {
                timerClose.Stop();
                this.Close();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //successCount = 0;
            int errorCount = 0;
            Version databaseVersion = GetDatabaseVersion();
            foreach (UpdateFile updateFile in this.UpdateFiles)
            {
                Version updateVersion = new Version(updateFile.Version);
                if (updateVersion.CompareTo(databaseVersion) > 0)
                {
                    backgroundWorker.ReportProgress(-1, "در حال به روز رسانی پایگاه داده به نسخه " + updateFile.Version + " ...");
                    System.Data.SqlClient.SqlTransaction tr = null;

                    string filePath = System.IO.Path.Combine(this.UpdateFilesPath, updateFile.File + "." + this.UpdateFilesExtension);
                    string query = System.IO.File.ReadAllText(filePath);
                    query = query.Replace("{DBName}", GetDatabaseName());
                    query = query.Replace("{DataPath}", SqlHelper.GetDataPath(this.DataAccess));
                    try
                    {
                        if (updateFile.InstallWithRollback)
                        {
                            this.DataAccess.Connection.Open();
                            tr = this.DataAccess.Connection.BeginTransaction();
                            this.DataAccess.Transaction = tr;
                            SqlHelper.RunQuery(query, this.DataAccess);
                        }
                        else
                        {
                            SqlHelper.RunQuery(query, this.DataAccess);
                        }
                        this.DataAccess.Execute("UPDATE [DatabaseVersion] SET [Version]=@Version", "@Version", updateVersion.ToString());
                    }
                    catch
                    {
                        if (tr != null)
                        {
                            tr.Rollback();
                            this.DataAccess.Connection.Close();
                        }
                        errorCount++;
                        backgroundWorker.ReportProgress(-2, "خطا در اجرای اسکریپ به روز رسانی نسخه " + updateFile.Version);
                        e.Result = errorCount;
                        return;
                    }

                    if (tr != null)
                    {
                        tr.Commit();
                        this.DataAccess.Connection.Close();
                    }
                    //successCount++;
                    backgroundWorker.ReportProgress(-1, "اسکریپ به روز رسانی نسخه " + updateFile.Version + " با موفقیت نصب شد");
                }
            }
            e.Result = errorCount;
        }

        private string GetDatabaseName()
        {
            System.Data.SqlClient.SqlConnectionStringBuilder csb = new System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString);
            return csb.InitialCatalog;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
                SetMessage(e.UserState.ToString());
            else if (e.ProgressPercentage == -2)
                SetError(e.UserState.ToString());
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                SetMessage("عملیات بروز رسانی کنسل شد.");
            else if (e.Error != null)
                SetError("در اجرای عملیات بروز رسانی خطا رخ داده است.");
            else
            {
                if (((int)e.Result) == 0)
                {
                    SetMessage("عملیات بروز رسانی با موفقیت به پایان رسید.");
                    timerClose.Start();
                }
            }
        }
    }
}
