
using TuyenSinhNS;
using System.Text;


Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;


TuyenSinh ts = new TuyenSinh();

int command = 0;
int temp;

while (command != 4)
{
    Console.WriteLine("Nhấn 1 để thêm mới thí sinh");
    Console.WriteLine("Nhấn 2 để hiện thông tin");
    Console.WriteLine("Nhấn 3 để tìm kiếm theo số báo danh");
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
                ts.ThemMoi();
                Console.WriteLine("-----------------------------");
            }
            break;

        case 2:
            {
                ts.HienThi();
            }
            break;

        case 3:
            {
                Console.Write("Nhập số báo danh cần tìm kiếm: "); temp = int.Parse(Console.ReadLine());
                ts.TimKiemSBD(temp);
            }
            break;
        default:
            { }
            break;
    }
}




