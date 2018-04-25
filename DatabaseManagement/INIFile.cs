using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DatabaseManagement
{
    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
    public class INIFile
    {
        private string _FilePath;
        public string FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                _FilePath = value;
            }
        }

        [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringW",
  SetLastError = true,
  CharSet = CharSet.Unicode, ExactSpelling = true,
  CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPrivateProfileString(
          string lpAppName,
          string lpKeyName,
          string lpDefault,
          string lpReturnString,
          int nSize,
          string lpFilename);

        [DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileStringW",
  SetLastError = true,
  CharSet = CharSet.Unicode, ExactSpelling = true,
  CallingConvention = CallingConvention.StdCall)]
        private static extern int WritePrivateProfileString(
          string lpAppName,
          string lpKeyName,
          string lpString,
          string lpFilename);

        //[DllImport("kernel32")]
        //private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        //[DllImport("kernel32")]
        //private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// INIFile Constructor.
        /// </summary>
        /// <param name="INIPath"></param>
        public INIFile(string FilePath)
        {
            this.FilePath = FilePath;
        }
        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <param name="Section"></param>
        /// Section name
        /// <param name="Key"></param>
        /// Key Name
        /// <param name="Value"></param>
        /// Value Name
        public bool WriteValue(string Section, string Key, string Value)
        {
            return WritePrivateProfileString(Section, Key, Value, this.FilePath) == 0 ? false : true;
        }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string ReadValue(string Section, string Key)
        {
            string returnString = new string(' ', 1024);
            GetPrivateProfileString(Section, Key, "", returnString, 1024, this.FilePath);
            return returnString.Split('\0')[0];
        }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string ReadValue(string Section, string Key, out int readCount)
        {
            string returnString = new string(' ', 1024);
            readCount = GetPrivateProfileString(Section, Key, "", returnString, 1024, this.FilePath);
            return returnString.Split('\0')[0];
        }
    }
}
