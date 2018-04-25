namespace DatabaseManagement
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainListView = new System.Windows.Forms.ListView();
            this.mainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_new = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_attach = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_detach = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_backup = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_restore = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatabaseProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_line = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.toolStripRight = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAttach = new System.Windows.Forms.ToolStripButton();
            this.tsbDetach = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBackup = new System.Windows.Forms.ToolStripButton();
            this.tsbRestore = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExecute = new System.Windows.Forms.ToolStripButton();
            this.btnInstallUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_statusbar_text = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownConnect = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_dis = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton_view = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuViewIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.dateTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialogUpdateFiles = new Ookii.Dialogs.VistaFolderBrowserDialog();
            this.mainContextMenuStrip.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStripRight.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainListView
            // 
            this.mainListView.BackColor = System.Drawing.Color.Beige;
            this.mainListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainListView.ContextMenuStrip = this.mainContextMenuStrip;
            this.mainListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainListView.HideSelection = false;
            this.mainListView.LargeImageList = this.imageList;
            this.mainListView.Location = new System.Drawing.Point(0, 75);
            this.mainListView.MultiSelect = false;
            this.mainListView.Name = "mainListView";
            this.mainListView.RightToLeftLayout = true;
            this.mainListView.Size = new System.Drawing.Size(665, 459);
            this.mainListView.SmallImageList = this.imageList;
            this.mainListView.TabIndex = 0;
            this.mainListView.UseCompatibleStateImageBehavior = false;
            this.mainListView.View = System.Windows.Forms.View.List;
            this.mainListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mainListView_MouseDoubleClick);
            // 
            // mainContextMenuStrip
            // 
            this.mainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_new,
            this.menu_attach,
            this.menu_refresh,
            this.menu_detach,
            this.menu_backup,
            this.menu_restore,
            this.menu_delete,
            this.menuDatabaseProperty});
            this.mainContextMenuStrip.Name = "contextMenuStrip1";
            this.mainContextMenuStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainContextMenuStrip.Size = new System.Drawing.Size(149, 180);
            this.mainContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // menu_new
            // 
            this.menu_new.Name = "menu_new";
            this.menu_new.Size = new System.Drawing.Size(148, 22);
            this.menu_new.Text = "&ایجاد دیتابیس...";
            this.menu_new.Click += new System.EventHandler(this.menuNew_Click);
            // 
            // menu_attach
            // 
            this.menu_attach.Name = "menu_attach";
            this.menu_attach.Size = new System.Drawing.Size(148, 22);
            this.menu_attach.Text = "&متصل کردن...";
            this.menu_attach.Click += new System.EventHandler(this.menu_attach_Click);
            // 
            // menu_refresh
            // 
            this.menu_refresh.Name = "menu_refresh";
            this.menu_refresh.Size = new System.Drawing.Size(148, 22);
            this.menu_refresh.Text = "&تازه سازی";
            this.menu_refresh.Click += new System.EventHandler(this.menu_refresh_Click);
            // 
            // menu_detach
            // 
            this.menu_detach.Name = "menu_detach";
            this.menu_detach.Size = new System.Drawing.Size(148, 22);
            this.menu_detach.Text = "&جدا کردن";
            this.menu_detach.Click += new System.EventHandler(this.menu_detach_Click);
            // 
            // menu_backup
            // 
            this.menu_backup.Name = "menu_backup";
            this.menu_backup.Size = new System.Drawing.Size(148, 22);
            this.menu_backup.Text = "&پشتیبان گیری";
            this.menu_backup.Click += new System.EventHandler(this.menu_backup_Click);
            // 
            // menu_restore
            // 
            this.menu_restore.Name = "menu_restore";
            this.menu_restore.Size = new System.Drawing.Size(148, 22);
            this.menu_restore.Text = "&بازیابی";
            this.menu_restore.Click += new System.EventHandler(this.menu_restore_Click);
            // 
            // menu_delete
            // 
            this.menu_delete.Name = "menu_delete";
            this.menu_delete.Size = new System.Drawing.Size(148, 22);
            this.menu_delete.Text = "&حذف";
            this.menu_delete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // menuDatabaseProperty
            // 
            this.menuDatabaseProperty.Name = "menuDatabaseProperty";
            this.menuDatabaseProperty.Size = new System.Drawing.Size(148, 22);
            this.menuDatabaseProperty.Text = "م&شخصات";
            this.menuDatabaseProperty.Click += new System.EventHandler(this.toolStripMenuItemDatabaseProperty_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "database.png");
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.mainListView);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStripRight);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.mainStatusStrip);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(794, 556);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(794, 581);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripMain);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::DatabaseManagement.Properties.Resources.Main_Title;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.lbl_line);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 75);
            this.panel1.TabIndex = 2;
            // 
            // lbl_line
            // 
            this.lbl_line.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_line.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_line.Location = new System.Drawing.Point(0, 72);
            this.lbl_line.Name = "lbl_line";
            this.lbl_line.Size = new System.Drawing.Size(665, 2);
            this.lbl_line.TabIndex = 1;
            this.lbl_line.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Location = new System.Drawing.Point(0, 45);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(665, 27);
            this.lblStatus.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitle.Size = new System.Drawing.Size(665, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ارتباط برقرار نیست";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripRight
            // 
            this.toolStripRight.AutoSize = false;
            this.toolStripRight.BackgroundImage = global::DatabaseManagement.Properties.Resources.Right_List;
            this.toolStripRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStripRight.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsbNew,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbAttach,
            this.tsbDetach,
            this.toolStripSeparator4,
            this.tsbBackup,
            this.tsbRestore,
            this.toolStripSeparator3,
            this.tsbExecute,
            this.btnInstallUpdate,
            this.tsbRefresh,
            this.tsbAbout});
            this.toolStripRight.Location = new System.Drawing.Point(665, 0);
            this.toolStripRight.Name = "toolStripRight";
            this.toolStripRight.Size = new System.Drawing.Size(129, 534);
            this.toolStripRight.TabIndex = 1;
            this.toolStripRight.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(120, 50);
            // 
            // tsbNew
            // 
            this.tsbNew.AutoSize = false;
            this.tsbNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(120, 40);
            this.tsbNew.Text = "ایجاد دیتابیس...";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.AutoSize = false;
            this.tsbDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(120, 40);
            this.tsbDelete.Text = "حذف";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // tsbAttach
            // 
            this.tsbAttach.AutoSize = false;
            this.tsbAttach.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAttach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAttach.Name = "tsbAttach";
            this.tsbAttach.Size = new System.Drawing.Size(120, 40);
            this.tsbAttach.Text = "متصل کردن...";
            this.tsbAttach.Click += new System.EventHandler(this.tsb_attach_Click);
            // 
            // tsbDetach
            // 
            this.tsbDetach.AutoSize = false;
            this.tsbDetach.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDetach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDetach.Name = "tsbDetach";
            this.tsbDetach.Size = new System.Drawing.Size(120, 40);
            this.tsbDetach.Text = "جدا کردن";
            this.tsbDetach.Click += new System.EventHandler(this.tsb_detach_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(127, 6);
            // 
            // tsbBackup
            // 
            this.tsbBackup.AutoSize = false;
            this.tsbBackup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbBackup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBackup.Name = "tsbBackup";
            this.tsbBackup.Size = new System.Drawing.Size(120, 40);
            this.tsbBackup.Text = "پشتیبان گیری";
            this.tsbBackup.Click += new System.EventHandler(this.tsb_backup_Click);
            // 
            // tsbRestore
            // 
            this.tsbRestore.AutoSize = false;
            this.tsbRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRestore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRestore.Name = "tsbRestore";
            this.tsbRestore.Size = new System.Drawing.Size(120, 40);
            this.tsbRestore.Text = "بازیابی";
            this.tsbRestore.Click += new System.EventHandler(this.tsb_restore_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(127, 6);
            // 
            // tsbExecute
            // 
            this.tsbExecute.AutoSize = false;
            this.tsbExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExecute.Name = "tsbExecute";
            this.tsbExecute.Size = new System.Drawing.Size(120, 40);
            this.tsbExecute.Text = "اجرای اسکریپت...";
            this.tsbExecute.Click += new System.EventHandler(this.tsbExecute_Click);
            // 
            // btnInstallUpdate
            // 
            this.btnInstallUpdate.AutoSize = false;
            this.btnInstallUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnInstallUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInstallUpdate.Name = "btnInstallUpdate";
            this.btnInstallUpdate.Size = new System.Drawing.Size(120, 40);
            this.btnInstallUpdate.Text = "نصب آپدیت...";
            this.btnInstallUpdate.Click += new System.EventHandler(this.btnInstallUpdate_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.AutoSize = false;
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(120, 40);
            this.tsbRefresh.Text = "تازه سازی";
            this.tsbRefresh.Click += new System.EventHandler(this.tsb_Refresh_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.AutoSize = false;
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(120, 40);
            this.tsbAbout.Text = "درباره...";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDate,
            this.lblTime,
            this.lblStatusStrip,
            this.lbl_statusbar_text});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 534);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(794, 22);
            this.mainStatusStrip.TabIndex = 3;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = false;
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(200, 17);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = false;
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(200, 17);
            // 
            // lblStatusStrip
            // 
            this.lblStatusStrip.AutoSize = false;
            this.lblStatusStrip.Name = "lblStatusStrip";
            this.lblStatusStrip.Size = new System.Drawing.Size(350, 17);
            // 
            // lbl_statusbar_text
            // 
            this.lbl_statusbar_text.AutoSize = false;
            this.lbl_statusbar_text.Name = "lbl_statusbar_text";
            this.lbl_statusbar_text.Size = new System.Drawing.Size(400, 17);
            // 
            // toolStripMain
            // 
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownConnect,
            this.toolStripButton_dis,
            this.toolStripSeparator2,
            this.toolStripDropDownButton_view});
            this.toolStripMain.Location = new System.Drawing.Point(560, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(228, 25);
            this.toolStripMain.TabIndex = 3;
            this.toolStripMain.Text = "toolStrip2";
            // 
            // toolStripDropDownConnect
            // 
            this.toolStripDropDownConnect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConnect});
            this.toolStripDropDownConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownConnect.Name = "toolStripDropDownConnect";
            this.toolStripDropDownConnect.Size = new System.Drawing.Size(75, 22);
            this.toolStripDropDownConnect.Text = "اتصال به ...";
            this.toolStripDropDownConnect.ToolTipText = "اتصال به ...";
            // 
            // menuConnect
            // 
            this.menuConnect.Image = global::DatabaseManagement.Properties.Resources.database;
            this.menuConnect.Name = "menuConnect";
            this.menuConnect.Size = new System.Drawing.Size(139, 22);
            this.menuConnect.Text = "SQL Server...";
            this.menuConnect.Click += new System.EventHandler(this.MenuConnect_Click);
            // 
            // toolStripButton_dis
            // 
            this.toolStripButton_dis.Image = global::DatabaseManagement.Properties.Resources.delete;
            this.toolStripButton_dis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_dis.Name = "toolStripButton_dis";
            this.toolStripButton_dis.Size = new System.Drawing.Size(83, 22);
            this.toolStripButton_dis.Text = "قطع اتصال";
            this.toolStripButton_dis.Click += new System.EventHandler(this.toolStripButton_dis_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton_view
            // 
            this.toolStripDropDownButton_view.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_view.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewIcon,
            this.menuViewList});
            this.toolStripDropDownButton_view.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_view.Image")));
            this.toolStripDropDownButton_view.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_view.Name = "toolStripDropDownButton_view";
            this.toolStripDropDownButton_view.Size = new System.Drawing.Size(52, 22);
            this.toolStripDropDownButton_view.Text = "نمایش";
            // 
            // menuViewIcon
            // 
            this.menuViewIcon.Name = "menuViewIcon";
            this.menuViewIcon.Size = new System.Drawing.Size(103, 22);
            this.menuViewIcon.Text = "آیکون";
            this.menuViewIcon.Click += new System.EventHandler(this.menuViewIcon_Click);
            // 
            // menuViewList
            // 
            this.menuViewList.Checked = true;
            this.menuViewList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuViewList.Name = "menuViewList";
            this.menuViewList.Size = new System.Drawing.Size(103, 22);
            this.menuViewList.Text = "لیست";
            this.menuViewList.Click += new System.EventHandler(this.menuViewList_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "SQL Database File|*.mdf";
            // 
            // dateTimeTimer
            // 
            this.dateTimeTimer.Enabled = true;
            this.dateTimeTimer.Interval = 1000;
            this.dateTimeTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // folderBrowserDialogUpdateFiles
            // 
            this.folderBrowserDialogUpdateFiles.Description = "مسیر فایل های آپدیت را مشخص کنید";
            this.folderBrowserDialogUpdateFiles.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialogUpdateFiles.SelectedPath = "";
            this.folderBrowserDialogUpdateFiles.ShowNewFolderButton = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 581);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مدیریت دیتابیس ها";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.Form_main_Resize);
            this.mainContextMenuStrip.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStripRight.ResumeLayout(false);
            this.toolStripRight.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView mainListView;
        private System.Windows.Forms.ToolStrip toolStripRight;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownConnect;
        private System.Windows.Forms.ToolStripMenuItem menuConnect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_line;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ToolStripButton tsbAttach;
        private System.Windows.Forms.ToolStripButton tsbDetach;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ToolStripButton tsbBackup;
        private System.Windows.Forms.ToolStripButton tsbRestore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_dis;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ContextMenuStrip mainContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menu_attach;
        private System.Windows.Forms.ToolStripMenuItem menu_detach;
        private System.Windows.Forms.ToolStripMenuItem menu_backup;
        private System.Windows.Forms.ToolStripMenuItem menu_restore;
        private System.Windows.Forms.ToolStripMenuItem menu_refresh;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblDate;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.ToolStripStatusLabel lbl_statusbar_text;
        private System.Windows.Forms.Timer dateTimeTimer;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_view;
        private System.Windows.Forms.ToolStripMenuItem menuViewIcon;
        private System.Windows.Forms.ToolStripMenuItem menuViewList;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menu_new;
        private System.Windows.Forms.ToolStripMenuItem menu_delete;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusStrip;
        private System.Windows.Forms.ToolStripButton tsbExecute;
        private System.Windows.Forms.ToolStripMenuItem menuDatabaseProperty;
        private System.Windows.Forms.ToolStripButton btnInstallUpdate;
        private Ookii.Dialogs.VistaFolderBrowserDialog folderBrowserDialogUpdateFiles;
    }
}

