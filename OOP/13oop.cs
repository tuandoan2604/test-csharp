using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace OOP13
{
    internal class Certificate
    {
        public int CertificatedID;
        public string CertificateName;
        public string CertificateRank;
        public string CertificatedDate;
        public Certificate(int _CertificatedID, string _CertificateName, string _CertificateRank, string _CertificatedDate)
        {
            CertificatedID = _CertificatedID;
            CertificateName = _CertificateName;
            CertificateRank = _CertificateRank;
            CertificatedDate = _CertificatedDate;
        }
    }
    internal abstract class Employee
    {
        static Employee()
        {
            Employee_count = 0;
        }
        public Employee() {
            Employee_count++;
        }
        public Employee(int _ID, string _FullName, string _Birthday, string _Phone, string _Email, int _Employee_type, List<Certificate> _certificates)
        {
            ID = _ID;
            FullName = _FullName;
            Birthday = _Birthday;
            Phone = _Phone;
            Email = _Email;
            Employee_type = _Employee_type;
            certificates = _certificates;
            Employee_count++;
        }
        public static int Employee_count;
        public List<Certificate> certificates;
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Employee_type { get; set; }
        public virtual void ShowInfo()
        {
            if (Employee_type == 0)
            {
                Console.WriteLine($"ID: {ID}, Full name: {FullName}, Birthday: {Birthday}, Phone: {Phone}, Email: {Email}, " +
                $"Employee_type: Experience ");
            }
            else if (Employee_type == 1)
            {
                Console.WriteLine($"ID: {ID}, Full name: {FullName}, Birthday: {Birthday}, Phone: {Phone}, Email: {Email}, " +
                $"Employee_type: Fresher ");
            }
            else if (Employee_type == 2)
            {
                Console.WriteLine($"ID: {ID}, Full name: {FullName}, Birthday: {Birthday}, Phone: {Phone}, Email: {Email}, " +
                $"Employee_type: Intern ");
            }
        }
        public abstract void ShowMe();
    }
    internal class Experience : Employee
    {
        public Experience(int _ExpInYear, string _ProSkill, int _ID, string _FullName, string _Birthday, string _Phone, string _Email, int _Employee_type, List<Certificate> _certificates) :
        base(_ID, _FullName, _Birthday, _Phone, _Email, _Employee_type, _certificates)
        {
            ExpInYear = _ExpInYear;
            ProSkill = _ProSkill;
        }
        public int ExpInYear { get; set; }
        public string ProSkill { get; set; }
        public override void ShowMe()
        {
            foreach (var item in certificates)
            {
                Console.WriteLine($"ID: {ID}, Full name: {FullName}, Birthday: {Birthday}, Phone: {Phone}, Email: {Email}, " +
                $"Employee_type: Experience, ExpInYear: {ExpInYear}, ProSkill: {ProSkill} ",
                $"CertificatedID: {item.CertificatedID}, CertificateName: {item.CertificateName}, CertificateRank: {item.CertificateRank}," +
                $"CertificatedDate: {item.CertificatedDate}");
            }
                
        }

    }
    internal class Fresher : Employee
    {
        public string Graduation_date { get; set; }
        public string Graduation_rank { get; set; }
        public string Education { get; set; }
        public Fresher(string _Graduation_date, string _Graduation_rank,string _Education, int _ID, string _FullName, string _Birthday, string _Phone, string _Email, int _Employee_type, List<Certificate> _certificates)
        :base(_ID, _FullName, _Birthday, _Phone, _Email, _Employee_type, _certificates)
        {
            Graduation_date = _Graduation_date;
            Graduation_rank = _Graduation_rank;
            Education = _Education;
        }
        public override void ShowMe()
        {
            foreach(var item in certificates){
                Console.WriteLine($"ID: {ID}, Full name: {FullName}, Birthday: {Birthday}, Phone: {Phone}, Email: {Email}, " +
                $"Employee_type: Experience, Graduation_date: {Graduation_date}, Graduation_rank: {Graduation_rank}, Education: {Education} ",
                $"CertificatedID: {item.CertificatedID}, CertificateName: {item.CertificateName}, CertificateRank: {item.CertificateRank}," +
                $"CertificatedDate: {item.CertificatedDate}");
            }
            
        }
    }
    internal class Intern : Employee
    {
        public string Majors { get; set; }
        public string Semester { get; set; }
        public string University_name { get; set; }
        public Intern(string _Majors, string _Semester, string _University_name, int _ID, string _FullName, string _Birthday, string _Phone, string _Email, int _Employee_type, List<Certificate> _certificates)
        : base(_ID, _FullName, _Birthday, _Phone, _Email, _Employee_type, _certificates)
        {
            Majors = _Majors;
            Semester = _Semester;
            University_name = _University_name;
        }
        public override void ShowMe()
        {
            foreach (var item in certificates)
            {
                Console.WriteLine($"ID: {ID}, Full name: {FullName}, Birthday: {Birthday}, Phone: {Phone}, Email: {Email}, " +
                $"Employee_type: Experience, Majors: {Majors}, Semester: {Semester}, University_name: {University_name}," +
                $"CertificatedID: {item.CertificatedID}, CertificateName: {item.CertificateName}, CertificateRank: {item.CertificateRank}," +
                $"CertificatedDate: {item.CertificatedDate}");
            }

        }
    }
    class BirthdayException : Exception
    {
        public BirthdayException(): base("wrong date of birth format"){
            
        }
    }
    class EmailException : Exception
    {
        public EmailException() : base("email format is wrong")
        {

        }
    }
    class NameException : Exception
    {
        public NameException() : base("name format is wrong")
        {

        }
    }
    class PhoneException : Exception
    {
        public PhoneException() : base("Phone format is wrong")
        {

        }
    }
    internal class ManagementEmployee
    {
        public List<Employee> employees = new List<Employee>();
        public ManagementEmployee()
        {
            employees = new List<Employee>();
        }
        public void AddEmployee(Employee e)
        {
            foreach(var item in employees)
            {
                if(item.ID == e.ID)
                {
                    throw new Exception("Duplicate ID employee");
                }
            }
            employees.Add(e);
        }
        public dynamic DownCasting(int ID)
        {
            foreach(var item in employees)
            {
                if(item.ID == ID)
                {
                    if(item is Experience)
                    {
                        return (Experience)item;
                    }
                    else if(item is Fresher)
                    {
                        return (Fresher)item;
                    }
                    else if(item is Intern)
                    {
                        return (Intern)item;
                    }
                }
            }
            return "";
        }
        public string CheckBirthday(string data)
        {
            Regex re = new Regex(@"^\d{2}-\d{2}-\d{4}$");
            if (re.IsMatch(data))
            {
                return data;
            }
            else
            {
                throw new BirthdayException();
            }
        }
        public string CheckFormatEmail(string data)
        {
            Regex re = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (re.IsMatch(data))
            {
                return data;
            }
            else
            {
                throw new EmailException();
            }
        }
        public string CheckFormatName(string data)
        {
            Regex re = new Regex(@"^[a-zA-Z]+\s+[a-zA-Z]+\s+[a-zA-Z]+$");
            if (re.IsMatch(data))
            {
                return data;
            }
            else
            {
                throw new NameException();
            }
        }
        public string CheckFormatPhone(string data)
        {
            Regex re = new Regex(@"^[0]{1}[1-9]{9}$");
            if (re.IsMatch(data))
            {
                return data;
            }
            else
            {
                throw new PhoneException();
            }
        }
        public void EditEmployee(int ID)
        {
            foreach(var item in employees)
            {
                if( item.ID == ID)
                {
                    if(DownCasting(ID) is Experience)
                    {
                        Console.WriteLine("Nhap vao so nam kinh nghiem:");
                        ((Experience)item).ExpInYear = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap ky nang chuyen mon:");
                        ((Experience)item).ProSkill = Console.ReadLine();
                        Console.WriteLine("Nhap lai ten cho nhan vien:");
                        ((Experience)item).FullName = CheckFormatName(Console.ReadLine());
                        Console.WriteLine("Nhap ngay sinh cua nhan vien:");
                        ((Experience)item).Birthday = CheckBirthday(Console.ReadLine());
                        Console.WriteLine("Nhap lai so dien thoai cua nhan vien:");
                        ((Experience)item).Phone = CheckFormatPhone(Console.ReadLine());
                        Console.WriteLine("Nhap lai email cua nhan vien:");
                        ((Experience)item).Email = CheckFormatEmail(Console.ReadLine());
                        Console.WriteLine("Nhap lai loai nhan vien:");
                        ((Experience)item).Employee_type = Int32.Parse(Console.ReadLine());
                        foreach(var item1 in item.certificates)
                        {
                            Console.WriteLine("Nhap ten chung chi:");
                            item1.CertificateName = Console.ReadLine();
                            Console.WriteLine("Nhap rank chung chi:");
                            item1.CertificateRank = Console.ReadLine();
                            Console.WriteLine("Nhap ngay chung chi");
                            item1.CertificatedDate = Console.ReadLine();
                        }
                    }
                    else if (DownCasting(ID) is Fresher)
                    {
                        Console.WriteLine("Nhap vao thoi gian tot nghiep:");
                        ((Fresher)item).Graduation_date = Console.ReadLine();
                        Console.WriteLine("Nhap xep loai tot nghiep:");
                        ((Fresher)item).Graduation_rank = Console.ReadLine();
                        Console.WriteLine("Nhap truong tot nghiep:");
                        ((Fresher)item).Education = Console.ReadLine();
                        Console.WriteLine("Nhap lai ten cho nhan vien:");
                        ((Fresher)item).FullName = CheckFormatName(Console.ReadLine());
                        Console.WriteLine("Nhap ngay sinh cua nhan vien:");
                        ((Fresher)item).Birthday = CheckBirthday(Console.ReadLine());
                        Console.WriteLine("Nhap lai so dien thoai cua nhan vien:");
                        ((Fresher)item).Phone = CheckFormatPhone(Console.ReadLine());
                        Console.WriteLine("Nhap lai email cua nhan vien:");
                        ((Fresher)item).Email = CheckFormatEmail(Console.ReadLine());
                        Console.WriteLine("Nhap lai loai nhan vien:");
                        ((Fresher)item).Employee_type = Int32.Parse(Console.ReadLine());
                        foreach (var item1 in item.certificates)
                        {
                            Console.WriteLine("Nhap ten chung chi:");
                            item1.CertificateName = Console.ReadLine();
                            Console.WriteLine("Nhap rank chung chi:");
                            item1.CertificateRank = Console.ReadLine();
                            Console.WriteLine("Nhap ngay chung chi");
                            item1.CertificatedDate = Console.ReadLine();
                        }
                    }
                    else if (DownCasting(ID) is Intern)
                    {
                        Console.WriteLine("Nhap vao chuyen nganh dang hoc:");
                        ((Intern)item).Majors = Console.ReadLine();
                        Console.WriteLine("Nhap vao hoc ky dang hoc:");
                        ((Intern)item).Semester = Console.ReadLine();
                        Console.WriteLine("Nhap vao ten truong dang hoc:");
                        ((Intern)item).University_name = Console.ReadLine();
                        Console.WriteLine("Nhap lai ten cho nhan vien:");
                        ((Intern)item).FullName = CheckFormatName(Console.ReadLine());
                        Console.WriteLine("Nhap ngay sinh cua nhan vien:");
                        ((Intern)item).Birthday = CheckBirthday(Console.ReadLine());
                        Console.WriteLine("Nhap lai so dien thoai cua nhan vien:");
                        ((Intern)item).Phone = CheckFormatPhone(Console.ReadLine());
                        Console.WriteLine("Nhap lai email cua nhan vien:");
                        ((Intern)item).Email = CheckFormatEmail(Console.ReadLine());
                        Console.WriteLine("Nhap lai loai nhan vien:");
                        ((Intern)item).Employee_type = Int32.Parse(Console.ReadLine());
                        foreach (var item1 in item.certificates)
                        {
                            Console.WriteLine("Nhap ten chung chi:");
                            item1.CertificateName = Console.ReadLine();
                            Console.WriteLine("Nhap rank chung chi:");
                            item1.CertificateRank = Console.ReadLine();
                            Console.WriteLine("Nhap ngay chung chi");
                            item1.CertificatedDate = Console.ReadLine();
                        }
                    }
                }
            }
        }
        public void DeleteByID(int ID)
        {
            foreach(var item in employees)
            {
                if(item.ID == ID)
                {
                    employees.Remove(item);
                }
            }
        } 
        public List<Intern> GetInternList()
        {
            List<Intern> list = new List<Intern>();
            foreach(var item in employees)
            {
                if(item is Intern)
                {
                    list.Add((Intern)item);
                }
            }
            return list;
        }
        public List<Experience> GetExperienceList()
        {
            List<Experience> list = new List<Experience>();
            foreach (var item in employees)
            {
                if (item is Experience)
                {
                    list.Add((Experience)item);
                }
            }
            return list;
        }
        public List<Fresher> GetFresherList()
        {
            List<Fresher> list = new List<Fresher>();
            foreach (var item in employees)
            {
                if (item is Fresher)
                {
                    list.Add((Fresher)item);
                }
            }
            return list;
        }
    }
    
    internal class Program
    {
        
        static void Main(string[] args)
        {
            ManagementEmployee m = new ManagementEmployee();
            m.AddEmployee(new Fresher("29/09/2030", "A", "Bach khoa", 1, "Nguyen Van A", "23/09/2003", "0956783456", "nguyena@gmail.com", 0,
                new List<Certificate>() { new Certificate(1, "Logic code", "A", "28/03/2009") }));
            m.DownCasting(1).ShowMe();
            m.EditEmployee(1);
            m.DownCasting(1).ShowMe();
        }
    }
}