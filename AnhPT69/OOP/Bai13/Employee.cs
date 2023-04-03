using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static CompanyNS.Tool;

namespace CompanyNS
{
    class Certificate
    {
        public string CerID;
        public string CerName;
        public string CerRank;
        public string CerDate;

        public Certificate() { }
    }
    abstract class Employee
    {
        public string ID { set; get; }
        public string FullName;
        public string BirthDay;
        public string Phone;
        public string Email;
        public string EType;
        public int ECount;
        public List<Certificate> list;
        public Employee() 
        {
            list = new List<Certificate>();
        }

        public void assign(string iD, string fullName, string birthDay, string phone, string email, string eType, int eCount, List<Certificate> list)
        {
            ID = iD;
            FullName = fullName;
            BirthDay = birthDay;
            Phone = phone;
            Email = email;
            EType = eType;
            ECount = eCount;
            this.list = list;
        }

        public abstract void ShowMe();
        public abstract Employee AddEmployee(string etype);
        public bool CheckBirthDay(string birthday)
        {
            string format = "yyyy/MM/dd";
            DateTime dt;
            bool isValidFormat = DateTime.TryParseExact(birthday, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            
            return isValidFormat;
        }
        public bool CheckEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool isValidEmail = Regex.IsMatch(email, pattern);
            //Console.WriteLine(isValidEmail);
            return isValidEmail;
        }
        public bool CheckFullName(string fullname)
        {
            string pattern = @"^[a-zA-Z ]+$";
            bool isValidFullName = Regex.IsMatch(fullname, pattern);
            //Console.WriteLine(isValidFullName);
            return isValidFullName;
        }
        public bool CheckPhone(string phone)
        {
            string pattern = @"^[0-9 -]+$";
            bool isValidPhone = Regex.IsMatch(phone.ToString(), pattern);
            //Console.WriteLine(isValidPhone);
            return isValidPhone;
        }
        public void EnterCertificate()
        {
            string c = "y";
            do
            {
                Certificate cer = new Certificate();
                cer.CerID = EnterCom("certificateID"); 
                cer.CerName = EnterCom("certificateName");
                cer.CerRank = EnterCom("certificateRank");
                cer.CerDate = EnterCom("certificateDate");

                list.Add(cer);

                c = EnterCom("more certificate ? (y/n)");
            } while (c == "y"); 
        }
        public void Show()
        {
            ShowInfo("ID", ID);
            ShowInfo("Fullname", FullName);
            ShowInfo("Birthday", BirthDay);
            ShowInfo("Phone", Phone.ToString());
            ShowInfo("Email", Email);
            ShowInfo("Employee type", EType);
            ShowInfo("Employee count", ECount.ToString());
            foreach (Certificate i in list)
            {
                ShowInfo("CertificateID", i.CerID);
                ShowInfo("CertificateName", i.CerName);
                ShowInfo("CertificateRank", i.CerRank);
                ShowInfo("CertificateDate", i.CerDate);
            }    
        }
        public void EnterEmployee(string etype)
        {
            bool check = false;
            ID = EnterCom("ID");

            do
            {
                check = false;
                FullName = EnterCom("fullname");
                check = CheckFullName(FullName);
            } while (!check);

            do
            {
                check = false;
                BirthDay = EnterCom("birthday (yyy/MM/dd)");
                check = CheckBirthDay(BirthDay);
            } while (!check);

            do
            {
                check = false;
                Phone = EnterCom("number phone");
                check = CheckPhone(Phone);
            } while (!check);

            do
            {
                check = false;
                Email = EnterCom("email");
                check = CheckEmail(Email);
            } while (!check);

            EType = etype;
            ECount = int.Parse(EnterCom("employee count"));
            EnterCertificate();
        }

    }
    class Experience : Employee
    {
        public int ExpInYear;
        public string ProSkill;
        public Experience() { }
        public Experience(string iD, string fullName, string birthDay, string phone, string email, string eType, int eCount, List<Certificate> list, int expInYear, string proSkill)
        {
            assign(iD, fullName, birthDay, phone, email, eType, eCount, list);
            ExpInYear = expInYear;
            ProSkill = proSkill;
        }

        public override void ShowMe()
        {
            Show();
            ShowInfo("Experience year", ExpInYear.ToString());
            ShowInfo("Profesional skill", ProSkill);
        }
        public override Employee AddEmployee(string etype)
        {
            EnterEmployee(etype);
            ExpInYear = int.Parse(EnterCom("experience year"));
            ProSkill = EnterCom("profesional skill");
         
            return this;
        }
    }
    class Fresher : Employee
    {
        public string GDate;
        public string GRank;
        public string Education;
        public Fresher() { }
        public Fresher(string iD, string fullName, string birthDay, string phone, string email, string eType, int eCount, List<Certificate> list, string gdate, string grank, string edu)
        {
            assign(iD, fullName, birthDay, phone, email, eType, eCount, list);
            GDate = gdate;
            GRank = grank;
            Education = edu;
        }
        public override Employee AddEmployee(string etype)
        {
            EnterEmployee(etype);
            GDate = EnterCom("gradution date");
            GRank = EnterCom("gradution rank");
            Education = EnterCom("education school");

            return this;

        }
        public override void ShowMe()
        {
            Show();
            ShowInfo("Gradution date", GDate);
            ShowInfo("Gradution rank", GRank);
            ShowInfo("Education school", Education);
        }

    }
    class Intern : Employee
    {
        public string Majors;
        public string Semester;
        public string UName;
        public Intern() { }
        public Intern(string iD, string fullName, string birthDay, string phone, string email, string eType, int eCount, List<Certificate> list, string maj, string sem, string una)
        {
            assign(iD, fullName, birthDay, phone, email, eType, eCount, list);
            Majors = maj;
            Semester = sem;
            UName = una;
        }

        public override Employee AddEmployee(string etype)
        {
            EnterEmployee(etype);
            Majors = EnterCom("major");
            Semester = EnterCom("semester");
            UName = EnterCom("university name");

            return this;
        }
        public override void ShowMe()
        {
            Show();
            ShowInfo("Majors", Majors);
            ShowInfo("Semester", Semester);
            ShowInfo("UName", UName);
        }

    }
    class Management
    {
        List<Employee> list;

        public Management() 
        {
            list = new List<Employee>();   
        }
        public Management(Experience exp, Fresher fre, Intern intern)
        {
            list = new List<Employee>() { exp, fre, intern};
        }
        public void CreateEmployee()
        {
            string type = EnterCom("employee type (exp/fre/int)");

            if (type == "exp")
            {
                Experience exp = new Experience();
                exp = (Experience)exp.AddEmployee("Experience");
                list.Add(exp);
            }
            else if (type == "fre")
            {
                Fresher fre = new Fresher();
                fre = (Fresher)fre.AddEmployee("Fresher");
                list.Add(fre);
            }
            else if (type == "int")
            {
                Intern intern = new Intern();
                intern = (Intern)intern.AddEmployee("Intern");
                list.Add(intern);
            }
            else
            {
                Console.WriteLine("Enter syntax wrong");
            }    
            
        }
        public void ModifyInfo()
        {
            string id = EnterCom("id for modify");
            (int i, bool check) = SearchID(id);
            if (check)
            {
                string type = list[i].EType;
                if (type == "Experience")
                {
                    Experience exp = new Experience();
                    exp = (Experience)list[i];
                    list[i] = exp.AddEmployee(type);
                }
                else if (type == "Fresher")
                {
                    Fresher fre = new Fresher();
                    fre = (Fresher)list[i];
                    list[i] = fre.AddEmployee(type);
                }
                else
                {
                    Intern intern = new Intern();
                    intern = (Intern)list[i];
                    list[i] = intern.AddEmployee(type);
                }
            }
            else
                ShowInfo("Unknown id", id);
        }
        public void RemoveEmployee()
        {
            string id = EnterCom("id for remove");
            (int i, bool check) = SearchID(id);
            if (check)
            { 
                list.RemoveAt(i);
                ShowInfo("Removed employee has id", id);
            }
            else
                ShowInfo("Unknown id", id);
        }
        public void ShowEmployeeInfo()
        {
            string id = EnterCom("id for show information");
            (int i, bool check) = SearchID(id);
            if (check)
            {
                string type = list[i].EType;

                if (type == "Experience")
                {
                    Experience exp = new Experience();
                    exp = (Experience)list[i];
                    exp.ShowMe();
                }
                else if (type == "Fresher")
                {
                    Fresher fre = new Fresher();
                    fre = (Fresher)list[i];
                    fre.ShowMe();
                }
                else
                {
                    Intern intern = new Intern();
                    intern = (Intern)list[i];
                    intern.ShowMe();
                }
                
            }
            else
                ShowInfo("Unknown id", id);
        }
        public void ShowExperience()
        {
            List<Employee> ls = new List<Employee>();

            foreach (Employee e in list)
            {
                if (e.EType == "Experience")
                {
                    ls.Add(e);
                }
            }

            Experience temp = new Experience();

            foreach (Employee em in ls)
            {
                temp = (Experience)(em);
                temp.ShowMe();
            }
        }
        public void ShowFresher()
        {
            List<Employee> ls = new List<Employee>();

            foreach (Employee e in list)
            {
                if (e.EType == "Fresher")
                {
                    ls.Add(e);
                }
            }

            Fresher temp = new Fresher();

            foreach (Employee em in ls)
            {
                temp = (Fresher)(em);
                temp.ShowMe();
            }
        }
        public void ShowIntern()
        {
            List<Employee> ls = new List<Employee>();

            foreach (Employee e in list)
            {
                if (e.EType == "Intern")
                {
                    ls.Add(e);
                }
            }

            Intern temp = new Intern();

            foreach (Employee em in ls)
            {
                temp = (Intern)(em);
                temp.ShowMe();
            }
        }
        public Tuple<int, bool> SearchID(string id)
        {
            int i = 0;
            bool check = false;
            for (i = 0; i < list.Count; i++)
            {
                if (list[i].ID == id)
                {
                    check = true;
                    break;
                }
            }
            return Tuple.Create(i, check);
        }
    }
    class Tool
    {
        public static void ShowInfo(string title, string content)
        {
            Console.WriteLine($"{title}: {content}");
        }
        public static string EnterCom(string mes)
        {
            Console.Write("Enter {0}:", mes);
            return Console.ReadLine();
        }
    }
    
}
