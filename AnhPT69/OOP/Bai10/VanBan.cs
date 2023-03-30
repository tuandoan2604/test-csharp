using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanBanNS
{
    internal class VanBan
    {
        public string str;
        public VanBan() { }
        public VanBan(string _st)
        {
            str = _st;
        }
        public uint DemSoTu()
        {
            uint dem = (uint)str.Count();
            return dem;
        }
        public uint DemKyTu(string c) 
        {
            uint dem = 0;
            foreach (char ch in str) 
            {
                dem = (ch == char.Parse(c.ToUpper()) || ch == char.Parse(c.ToLower())) ? dem + 1 : dem;
            }
            return dem;
        }
        public string ChuanHoa() 
        {
            string[] words = str.Split(new char[] {' ', '*'}, StringSplitOptions.RemoveEmptyEntries);
            str = string.Join(" ", words);

            return str;
        }
    }
}
