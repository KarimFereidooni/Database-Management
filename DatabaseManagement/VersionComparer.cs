using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeroAndOne.Sql
{
    public class VersionComparer : System.Collections.IComparer
    {
        private static VersionComparer _Instance;
        public static VersionComparer Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new VersionComparer();
                return _Instance;
            }
        }
        public int Compare(object x, object y)
        {
            Version xVersion = new Version(x.ToString());
            Version yVersion = new Version(y.ToString());
            return xVersion.CompareTo(yVersion);
        }
    }
}
