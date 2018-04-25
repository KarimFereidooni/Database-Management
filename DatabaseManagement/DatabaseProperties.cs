using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseManagement
{
    public class DatabaseProperties
    {
        public DatabaseProperties(string DataName, string DataFileName, string DataFileGroup, string DataSize, string LogName, string LogFileName, string LogFileGroup, string LogSize)
        {
            this.DataName = DataName;
            this.DataFileName = DataFileName;
            this.DataFileGroup = DataFileGroup;
            this.DataSize = DataSize;

            this.LogName = LogName;
            this.LogFileName = LogFileName;
            this.LogFileGroup = LogFileGroup;
            this.LogSize = LogSize;
        }
        /// <summary>
        /// نام دیتابیس
        /// </summary>
        public string DataName { get; set; }
        /// <summary>
        /// نام فایل لوگ
        /// </summary>
        public string LogName { get; set; }
        /// <summary>
        /// فایل اصلی دیتابیس
        /// </summary>
        public string DataFileName { get; set; }
        /// <summary>
        /// فایل لوگ دیتابیس
        /// </summary>
        public string LogFileName { get; set; }
        public string DataFileGroup { get; set; }
        public string LogFileGroup { get; set; }
        /// <summary>
        /// حجم فایل اصلی دیتابیس
        /// </summary>
        public string DataSize { get; set; }
        /// <summary>
        /// حجم فایل لوگ دیتابیس
        /// </summary>
        public string LogSize { get; set; }
    }
}
