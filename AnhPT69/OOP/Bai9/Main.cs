
using System.Text;
using TienDienNS;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

BienLai bl = new BienLai();

int command = 0;
int temp;

while (command != 6)
{
    Console.WriteLine("Nhấn 1 để thêm mới khách hàng");
    Console.WriteLine("Nhấn 2 để nhập chỉ số công tơ");
    Console.WriteLine("Nhấn 3 để sửa thông tin khách hàng");
    Console.WriteLine("Nhấn 4 để xóa khách hàng");
    Console.WriteLine("Nhấn 5 để tính tiền điện");
    Console.WriteLine("Nhấn 6 để thoát");
    command = int.Parse(Console.ReadLine());
    if (command > 6 && command < 1)
    {
        Console.WriteLine("Bạn đã nhập sai, hãy nhập lại");
        continue;
    }

    switch (command)
    {
        case 1:
            {
                bl.ThemKH();
            }
            break;
        case 2:
            {
                string mact = NhapLieu("mã công tơ");
                bl.NhapChiSo(mact);
            }
            break;
        case 3:
            {
                string mact = NhapLieu("mã công tơ");
                bl.SuaKH(mact);
            }
            break;
        case 4:
            {
                string mact = NhapLieu("mã công tơ");
                bl.XoaKH(mact);
            }
            break;
        case 5:
            {
                string mact = NhapLieu("mã công tơ");
                bl.TienDien(mact);
            }
            break;
        default:
            { }
            break;
    }
}

string NhapLieu(string mes)
{
    Console.Write("Nhập {0}", mes);
    return Console.ReadLine();
}



