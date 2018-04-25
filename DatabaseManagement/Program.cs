using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseManagement
{
    static class Program
    {
        private static bool _ShowAllDatabases = true;
        public static bool ShowAllDatabases
        {
            get
            {
                return _ShowAllDatabases;
            }
            set
            {
                _ShowAllDatabases = value;
            }
        }
        static string _LoginName = "";
        public static string LoginName
        {
            set
            {
                _LoginName = value;
            }
            get
            {
                return _LoginName;
            }
        }
        static string _ConnectionString = "";
        public static string ConnectionString
        {
            set
            {
                _ConnectionString = value;
            }
            get
            {
                return _ConnectionString;
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm.Instance);
        }
    }
}
