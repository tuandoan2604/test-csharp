
using System.Text;
using GiaoVienNS;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

CBGV cb = new CBGV();

int command = 0;
int temp;

while (command != 5)
{
    Console.WriteLine("Nhấn 1 để thêm mới cán bộ giáo viên");
    Console.WriteLine("Nhấn 2 để xóa cán bộ giáo viên");
    Console.WriteLine("Nhấn 3 để nhập lương thưởng");
    Console.WriteLine("Nhấn 4 để tính lương thưởng");
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
                cb.ThemCBGV();
            }
            break;

        case 2:
            {
                string magv = NhapLieu("mã giáo viên");
                cb.XoaCBGV(magv);
            }
            break;
        case 3:
            {
                string magv = NhapLieu("mã giáo viên");
                cb.NhapLuong(magv);
            }
            break;
        case 4:
            {
                string magv = NhapLieu("mã giáo viên");
                cb.TinhLuong(magv);
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



