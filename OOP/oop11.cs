using System;

namespace OOP11
{
    class SoPhuc
    {
        public double phanThuc;
        public double phanAo;
        public SoPhuc() { }
        public SoPhuc(double _phanThuc, double _phanAo)
        {
            phanThuc = _phanThuc;
            phanAo = _phanAo;
        }
        public void NhapSoPhuc(double _phanthuc, double _phanao)
        {
            phanThuc = _phanthuc;
            phanAo = _phanao;
        } 
        public static SoPhuc operator + (SoPhuc a, SoPhuc b)
        {

            return new SoPhuc(a.phanThuc + b.phanThuc, a.phanAo+ b.phanAo);
        }
        public static SoPhuc operator * (SoPhuc a, SoPhuc b)
        {

            return new SoPhuc(a.phanThuc * b.phanThuc - a.phanAo * b.phanAo, a.phanThuc * b.phanAo + a.phanAo * b.phanThuc);
        }
        public void HienThiSoPhuc()
        {
            Console.WriteLine($"{phanThuc} + i.{phanAo}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SoPhuc a = new SoPhuc();
            a.NhapSoPhuc(1, 2);
            a.HienThiSoPhuc();
            SoPhuc b = new SoPhuc(2, 3);
            SoPhuc c = new SoPhuc(3, 4);
            SoPhuc d = b * c;
            d.HienThiSoPhuc();
        }
    }
}
