using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;

namespace DatabaseManagement
{
    public class INISettingsProvider : SettingsProvider
    {
        public INISettingsProvider()
            : this("DatabaseManagementSetting.ini", "Program")
        {
        }

        public INISettingsProvider(string iniFileName, string section)
        {
            this.INIFileName = iniFileName;
            this.Section = section;
            this.INIFile = new DatabaseManagement.INIFile(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, iniFileName));
        }

        public override string ApplicationName
        {
            get { return System.Windows.Forms.Application.ProductName; }
            set { }
        }

        private string _INIFileName;
        public string INIFileName
        {
            get
            {
                return _INIFileName;
            }
            set
            {
                _INIFileName = value;
            }
        }

        private string _Section;
        public string Section
        {
            get
            {
                return _Section;
            }
            set
            {
                _Section = value;
            }
        }

        private DatabaseManagement.INIFile _INIFile;
        public DatabaseManagement.INIFile INIFile
        {
            get
            {
                return _INIFile;
            }
            set
            {
                _INIFile = value;
            }
        }

        public override void Initialize(string name, NameValueCollection col)
        {
            base.Initialize(this.ApplicationName, col);
        }

        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            foreach (SettingsPropertyValue item in collection)
            {
                if (item.IsDirty)
                    INIFile.WriteValue(this.Section, item.Name, item.SerializedValue.ToString());
            }
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            SettingsPropertyValueCollection values = new SettingsPropertyValueCollection();
            foreach (SettingsProperty item in collection)
            {
                SettingsPropertyValue value = new SettingsPropertyValue(item);
                value.IsDirty = false;
                int readCount;
                string s = INIFile.ReadValue(this.Section, item.Name, out readCount);
                if (readCount > 0)
                    value.SerializedValue = s;
                values.Add(value);
            }
            return values;
        }
    }
}
