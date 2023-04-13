using System;

namespace OOP10
{
    class VanBan
    {
        public string s;
        public VanBan() { }
        public VanBan(string st) {
            s = st;      
        }
        public int DemSoTu()
        {
            return s.Length;
        }
        public int SoLuongKyTuA()
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++) {
                if (s[i] == char.Parse("A") || s[i] == char.Parse("a") )
                {
                    count++;
                }
            }
            return count;
        }
        public void ChuanHoaVanBan()
        {
            string s1 = s.Substring(0, s.Length / 2).Trim();
            string s2 = s.Substring(s.Length / 2).Trim();
            s = s1 + " " + s2;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            VanBan ban = new VanBan(" hello  world ");
            ban.ChuanHoaVanBan();
            Console.WriteLine(ban.s);
        }
    }
}
