
using System.Text;
using ThuVienNS;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

QLTV tv = new QLTV();

int command = 0;
int temp;

while (command != 4)
{
    Console.WriteLine("Nhấn 1 để thêm mới thẻ mượn");
    Console.WriteLine("Nhấn 2 để xóa thẻ mượn");
    Console.WriteLine("Nhấn 3 để hiện thông tin thẻ mượn");
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
                tv.ThemTheTV();
            }
            break;

        case 2:
            {
                string mapm = NhapLieu("mã phiếu mượn");
                tv.XoaThe(mapm);
            }
            break;
        case 3:
            {
                string mapm = NhapLieu("mã phiếu mượn");
                tv.ThongTinTheMuon(mapm);
            }
            break;
        default:
            { }
            break;
    }
}

string NhapLieu(string mes)
{
    Console.WriteLine("Nhập {0}", mes);
    return Console.ReadLine();
}



