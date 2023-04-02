
using System.Text;
using CompanyNS;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

*//*string iD = "123";
string fullName = "Anh";
string birthDay = "2000/10/25";
string phone = "0912551690";
string email = "a@a.com";
int eCount = 1;
List<Certificate> list = new List<Certificate>() { new Certificate() };
int expInYear = 3;
string proSkill = "coder";
Experience exp = new Experience(iD, fullName, birthDay, phone, email, "Experience", eCount, list, expInYear, proSkill);


string gdate = "2023/5/4";
string grank = "good";
string edu = "BK";
Fresher fre = new Fresher("321", fullName, birthDay, phone, email, "Fresher", eCount, list, gdate, grank, edu);

string maj = "cdt";
string sem = "2";
string una = "HN";
Intern intern = new Intern("231", fullName, birthDay, phone, email, "Intern", eCount, list, maj, sem, una);*//*

//ex.AddEmployee();
Management mn = new Management();
*//*mn.ShowExperience();
mn.ShowFresher();
mn.ShowIntern();

mn.CreateEmployee();
mn.ShowEmployeeInfo();
mn.ModifyInfo();
mn.RemoveEmployee();*//*

int command = 0;

while (command != 8)
{
    Console.WriteLine("Nhấn 1 để thêm mới nhân viên");
    Console.WriteLine("Nhấn 2 để hiện thông tin nhân viên");
    Console.WriteLine("Nhấn 3 để sửa thông tin nhân viên");
    Console.WriteLine("Nhấn 4 để xóa nhân viên");
    Console.WriteLine("Nhấn 5 để hiển thị exp");
    Console.WriteLine("Nhấn 6 để hiển thị fre");
    Console.WriteLine("Nhấn 7 để hiển thị intern");
    Console.WriteLine("Nhấn 8 để thoát");
    command = int.Parse(Console.ReadLine());
    if (command > 8 && command < 1)
    {
        Console.WriteLine("Bạn đã nhập sai, hãy nhập lại");
        continue;
    }

    switch (command)
    {
        case 1:
            {
                mn.CreateEmployee();
            }
            break;
        case 2:
            {
                mn.ShowEmployeeInfo();
            }
            break;
        case 3:
            {
                mn.ModifyInfo();
            }
            break;
        case 4:
            {
                mn.RemoveEmployee();
            }
            break;
        case 5:
            {
                mn.ShowExperience();
            }
            break;
        case 6:
            {
                mn.ShowFresher();
            }
            break;
        case 7:
            {
                mn.ShowIntern();
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



