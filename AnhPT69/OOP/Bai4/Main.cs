
using System.Text;
using NguoiNS;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;


KhuPho kp = new KhuPho();

int command = 0;
int temp;

while (command != 3)
{
    Console.WriteLine("Nhấn 1 để thêm mới thông tin khu phố");
    Console.WriteLine("Nhấn 2 để hiện thông tin");
    Console.WriteLine("Nhấn 3 để thoát");
    command = int.Parse(Console.ReadLine());
    if (command > 3 || command < 1)
    {
        Console.WriteLine("Bạn đã nhập sai, hãy nhập lại");
        continue;
    }

    switch (command)
    {
        case 1:
            {
                kp.ThemGD();
            }
            break;

        case 2:
            {
                kp.ThongTinKP();
            }
            break;
        default:
            { }
            break;
    }
}




