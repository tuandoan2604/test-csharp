using System.Text;
using VanBanNS;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;


string st = "    this   is   my   content   about   exercise  a a ***** ";
VanBan vb = new VanBan(st);

Console.WriteLine(vb.DemSoTu());
Console.WriteLine(vb.DemKyTu("A"));
Console.WriteLine(vb.ChuanHoa());
//ket thuc