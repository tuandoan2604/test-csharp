
using System.Text;
using PTGTNS;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

QLPTGT pt = new QLPTGT();

int command = 0;
int temp;

while (command != 4)
{
    Console.WriteLine("Nhấn 1 để thêm mới phương tiện");
    Console.WriteLine("Nhấn 2 để xóa phương tiện");
    Console.WriteLine("Nhấn 3 để tìm kiếm phương tiện");
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
                pt.ThemPT();
            }
            break;
        case 2:
            {
                int id = int.Parse(NhapLieu("id cần tìm"));
                pt.XoaPT(id);
            }
            break;
        case 3:
            {
                string hangxe = NhapLieu("hãng xe (nếu cần, hoặc enter)");
                string mauxe = NhapLieu("màu xe (nếu cần, hoặc enter)");
                pt.TimKiemPT(hangxe, mauxe);
            }
            break;
        default:
            { }
            break;
    }
}

string NhapLieu(string mes)
{
    Console.Write("Nhập {0}:", mes);
    return Console.ReadLine();
}



