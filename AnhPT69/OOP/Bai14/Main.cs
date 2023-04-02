
using System.Text;
using UniNS;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

Recruit re = new Recruit();

int command = 0;

while (command != 4)
{
    Console.WriteLine("Nhấn 1 để hiển thị thông tin");
    Console.WriteLine("Nhấn 2 để tuyển dụng");
    Console.WriteLine("Nhấn 3 để hiển thị tên, số điện thoại");
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
                re.ShowInfoName();
            }
            break;
        case 2:
            {
                re.Recuitment();
            }
            break;
        case 3:
            {
                re.ShowEntireNamePhone();
            }
            break;
    }
}

string NhapLieu(string mes)
{
    Console.Write("Nhập {0}:", mes);
    return Console.ReadLine();
}



