
using System.Text;
using UniNS;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

Recruit re = new Recruit();

int command = 0;

while (command != 5)
{
    Console.WriteLine("Nhấn 1 để thêm mới sinh viên");
    Console.WriteLine("Nhấn 2 để hiển thị thông tin");
    Console.WriteLine("Nhấn 3 để tuyển dụng");
    Console.WriteLine("Nhấn 4 để hiển thị tên, số điện thoại");
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
                try
                {
                    re.NewStudent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            break;
        case 2:
            {
                re.ShowInfoName();
            }
            break;
        case 3:
            {
                re.Recuitment();
            }
            break;
        case 4:
            {
                re.ShowEntireNamePhone();
            }
            break;
    }
    if (command != 5) { Console.ReadLine(); }
}

string NhapLieu(string mes)
{
    Console.Write("Nhập {0}:", mes);
    return Console.ReadLine();
}



