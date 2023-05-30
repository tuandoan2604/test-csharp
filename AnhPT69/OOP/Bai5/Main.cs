
using System.Text;
using KhachSanNS;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

KhachSan ks = new KhachSan();

int command = 0;
int temp;

while (command != 4)
{
    Console.WriteLine("Nhấn 1 để thêm mới khách");
    Console.WriteLine("Nhấn 2 để xóa khách");
    Console.WriteLine("Nhấn 3 để tính tiền");
    Console.WriteLine("Nhấn 4 để thoát");
    command = int.Parse(Console.ReadLine());
    if (command > 4 || command < 1)
    {
        Console.WriteLine("Bạn đã nhập sai, hãy nhập lại");
        continue;
    }

    switch (command)
    {
        case 1:
            {
                ks.ThemKhach();
            }
            break;

        case 2:
            {
                Console.WriteLine("Nhập cccd của khác cần xóa:");
                int cccd = int.Parse(Console.ReadLine());
                ks.XoaTheoCCCD(cccd);
            }
            break;
        case 3:
            {
                Console.WriteLine("Nhập cccd của khác cần tính tiền:");
                int cccd = int.Parse(Console.ReadLine());
                ks.TinhTien(cccd);
            }
            break;
        default:
            { }
            break;
    }
}




