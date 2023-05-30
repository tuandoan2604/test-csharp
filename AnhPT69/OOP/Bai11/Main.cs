
using System.Text;
using SoPhucNS;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

SoPhuc x = new SoPhuc(2, 3);
SoPhuc y = new SoPhuc(4, 5);

SoPhuc result = new SoPhuc();
result.NhapSoPhuc();

Thread.Sleep(TimeSpan.FromSeconds(5));
result.HienThiSoPhuc();

Thread.Sleep(TimeSpan.FromSeconds(5));
result = x + y;
result.HienThiSoPhuc();

Thread.Sleep(TimeSpan.FromSeconds(5));
result = x * y;
result.HienThiSoPhuc();

Console.ReadKey();


