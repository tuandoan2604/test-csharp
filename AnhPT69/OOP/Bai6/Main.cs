
using System.Text;
using HocSinhNS;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

Truong tr = new Truong();

int command = 0;
int temp;

while (command != 5)
{
    Console.WriteLine("Nhấn 1 để thêm mới lớp");
    Console.WriteLine("Nhấn 2 để thêm mới học sinh vào lớp");
    Console.WriteLine("Nhấn 3 để tìm kiếm theo tuổi");
    Console.WriteLine("Nhấn 4 để hiện số lượng tìm kiếm");
    Console.WriteLine("Nhấn 5 để thoát");
    command = int.Parse(Console.ReadLine());
    if (command > 5 && command < 1)
    {
        Console.WriteLine("Bạn đã nhập sai, hãy nhập lại");
        continue;
    }

    switch (command)
    {
        case 1:
            {
                tr.ThemLop();
            }
            break;

        case 2:
            {
                Console.WriteLine("Nhập tên lớp:");
                string tenlop = Console.ReadLine();
                tr.ThemHSVaoLop(tenlop);
            }
            break;
        case 3:
            {
                Console.WriteLine("Nhập tuổi cần tìm:");
                int tuoi = int.Parse(Console.ReadLine());
                tr.TimKiemHS(tuoi);
            }
            break;
        case 4:
            {
                Console.WriteLine("Nhập tuổi:"); int tuoi = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhập quê quán:"); string que = Console.ReadLine();
                tr.TimKiemSoLuong(tuoi, que);
            }
            break;
        default:
            { }
            break;
    }
}




