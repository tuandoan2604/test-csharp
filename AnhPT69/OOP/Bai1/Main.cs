// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using QLCBNS;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

QLCB qlcb = new QLCB();

int command = 0;
string _hoten = string.Empty;

while (command != 4)
{
    Console.WriteLine("Nhấn 1 để thêm cán bộ");
    Console.WriteLine("Nhấn 2 để tìm kiếm cán bộ theo tên");
    Console.WriteLine("Nhấn 3 để hiển thị danh sách toàn bộ cán bộ");
    Console.WriteLine("Nhấn 4 để thoát");
    command = int.Parse(Console.ReadLine());
    if (command > 4 && command < 1)
    {
        Console.WriteLine("Bạn đã nhập sai, hãy nhập lại");
        continue;
    }

    switch (command)
    {
        case 1:
            {
                qlcb.ThemCanBo();
                Console.WriteLine("-----------------------------");
            }
            break;

        case 2:
            {
                Console.Write("Nhập tên cán bộ cần tìm kiếm: "); _hoten = Console.ReadLine();
                qlcb.ThongTinCanBo(qlcb.TimKiemTheoHoTen(_hoten));
            }
            break;

        case 3:
            {
                qlcb.ThongTinCanBo();
            }
            break;

        default:
            { }
            break;
    }
}




