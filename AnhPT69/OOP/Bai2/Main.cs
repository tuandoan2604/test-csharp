

using QuanLySachNS;
using System.Text;


Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;


QuanLySach qls = new QuanLySach();

int command = 0;
string temp = "";

while (command != 5)
{
    Console.WriteLine("Nhấn 1 để thêm mới tài liệu");
    Console.WriteLine("Nhấn 2 để xóa tài liệu theo mã tài liệu");
    Console.WriteLine("Nhấn 3 để hiển thị thông tin tất cả tài liệu");
    Console.WriteLine("Nhấn 4 để tìm kiếm tài liệu theo loại");
    Console.WriteLine("Nhấn 5 để thoát");
    command = int.Parse(Console.ReadLine());
    if (command > 5 || command < 1)
    {
        Console.WriteLine("Bạn đã nhập sai, hãy nhập lại");
        continue;
    }

    switch (command)
    {
        case 1:
            {
                qls.ThemMoi();
                Console.WriteLine("-----------------------------");
            }
            break;

        case 2:
            {
                Console.Write("Nhập mã tài liệu cần xóa: "); temp = Console.ReadLine();
                qls.XoaTaiLieu(temp);
            }
            break;

        case 3:
            {
                qls.HienThiTaiLieu();
            }
            break;
        case 4:
            {
                Console.Write("Nhập loại tài liệu cần tìm kiếm: "); temp = Console.ReadLine();
                qls.HienThiTaiLieu(qls.TimKiemTheoLoai(temp));
            }
            break;

        default:
            { }
            break;
    }
}




