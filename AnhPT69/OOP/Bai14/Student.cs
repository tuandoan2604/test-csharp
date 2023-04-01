using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static UniNS.Tool;

namespace UniNS
{
    abstract class Student
    {
        public string fullName { get; set; }
        public string doB { set; get; }
        public string sex { set; get; }
        public string phoneNumber { set; get; }
        public string universityName { set; get; }
        public string gradeLevel { set; get; }
        public Student() { }
        public abstract void ShowMyInfo();
        public abstract void EnterStudent();
        public void ShowGeneral()
        {
            ShowScren("Fullname", fullName);
            ShowScren("Birthday", doB);
            ShowScren("Sex", sex);
            ShowScren("Phone Number", phoneNumber);
            ShowScren("Universiry Name", universityName);
            ShowScren("Grade Level", gradeLevel);
        }
        public void EnterGeneral()
        {
            ExceptionFullName();
            ExceptionDOB();
            ExceptionPhoneNumber();
            /*try
            {  */
            sex = EnterData("sex");
            universityName = EnterData("university name");
            gradeLevel = EnterData("grade level");
            /*}
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            */
        }
        private void ExceptionFullName()
        {
            try
            {
                fullName = EnterData("fullname");
                if (fullName.Length < 10 && fullName.Length < 50)
                {
                    fullName = "";
                    throw new Exception("Invalid fullname length");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void ExceptionDOB()
        {
            try
            {
                doB = EnterData("birthday");
                DateTime parsedDate = DateTime.ParseExact(doB, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                doB = "";
                throw new Exception("Invalid birthday format \"dd/MM/yyyy\"");
            }
        }
        private void ExceptionPhoneNumber()
        {
            try
            {
                phoneNumber = EnterData("phone number");

                if (!Regex.IsMatch(phoneNumber, @"^(090|098|091|031|035|038)\d{7}$"))
                {
                    phoneNumber = "";
                    throw new Exception("Invalid phone number format");
                }
                Console.WriteLine("Số điện thoại hợp lệ.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class GoodStudent : Student
    {
        public double gpa { set; get; }
        public string bestRewardName { set; get; }
        public GoodStudent() { }
        public GoodStudent(string _fullName, string _doB, string _sex, string _phoneNumber, string _universityName, string _gradeLevel, double _gpa, string _bestRewardName)
        {
            this.fullName = _fullName;
            this.doB = _doB;
            this.sex = _sex;
            this.phoneNumber = _phoneNumber;
            this.universityName = _universityName;
            this.gradeLevel = _gradeLevel;
            this.gpa = _gpa;
            this.bestRewardName = _bestRewardName;
        }

        public override void ShowMyInfo()
        {
            ShowGeneral();
            ShowScren("Gpa", gpa.ToString());
            ShowScren("Best Reward Name", bestRewardName);
        }

        public override void EnterStudent()
        {
            EnterGeneral();

        }
    }
    class NormalStudent : Student
    {
        public int englishScore { set; get; }
        public double entryTestScore { set; get; }
        public NormalStudent() { }
        public NormalStudent(string _fullName, string _doB, string _sex, string _phoneNumber, string _universityName, string _gradeLevel, int englishScore, double entryTestScore)
        {
            this.fullName = _fullName;
            this.doB = _doB;
            this.sex = _sex;
            this.phoneNumber = _phoneNumber;
            this.universityName = _universityName;
            this.gradeLevel = _gradeLevel;
            this.englishScore = englishScore;
            this.entryTestScore = entryTestScore;
        }

        public override void ShowMyInfo()
        {
            ShowGeneral();
            ShowScren("English Score Toeic", englishScore.ToString());
            ShowScren("Entry Test Score", entryTestScore.ToString());
        }

        public override void EnterStudent()
        {
            throw new NotImplementedException();
        }
    }
    class Recruit
    {
        List<Student> students;
        public Recruit()
        {
            students = new List<Student>()
            {
                new GoodStudent("Anh", "2000/12/23", "Male", "0905837459", "BK", "Good", 2.5, "No"),
                new GoodStudent("Ba", "2000/4/14", "Male", "0980483641", "HN", "Good", 2.55, "No"),
                new NormalStudent("Le", "2000/7/17", "Female", "0385837115", "BK", "Normal", 560, 7.9),
                new NormalStudent("Thao", "2000/9/11", "Female", "0385137169", "BK", "Normal", 590, 6.8),
                new GoodStudent("Huyen", "2000/12/24", "Female", "0915826459", "BK", "Good", 2.58, "No"),
                new GoodStudent("Chien", "2000/11/25", "Male", "0905885459", "BK", "Good", 2.59, "No"),
                new NormalStudent("Hai", "2000/2/15", "Male", "0355837169", "BK", "Normal", 550, 7.8),
                new NormalStudent("Uyen", "2000/8/31", "Female", "0381537169", "BK", "Normal", 650, 9.8),                
                new NormalStudent("Bao", "2000/3/11", "Male", "0909037169", "BK", "Normal", 550, 7.8),
                new NormalStudent("Dao", "2000/12/10", "Male", "0901437169", "BK", "Normal", 550, 7.8),
                new GoodStudent("Hung", "2000/1/17", "Male", "0905837169", "BK", "Good", 2.98, "No"),
                new GoodStudent("Dat", "2000/2/10", "Male", "0904237459", "BK", "Good", 2.98, "No"),
                new NormalStudent("Hau", "2000/6/27", "Male", "0909137169", "BK", "Normal", 350, 7.8),
                new GoodStudent("Yen", "2000/3/23", "Male", "0905833659", "BK", "Good", 2.76, "No"),
                new GoodStudent("Chinh", "2000/2/26", "Female", "0915893459", "BK", "Good", 2.90, "No"),
                new GoodStudent("Trang", "2000/6/3", "Female", "0985831559", "BK", "Good", 2.90, "No"),
                new GoodStudent("An", "2000/12/23", "Female", "0315517459", "BK", "Good", 2.83, "No"),
                new GoodStudent("Bac", "2000/9/13", "Female", "0315518759", "BK", "Good", 2.83, "No"),
                new GoodStudent("Chien", "2000/2/15", "Female", "0315517959", "BK", "Good", 2.55, "No"),
                new GoodStudent("Anh", "2000/1/19", "Male", "0315512559", "BK", "Good", 2.91, "No"),
            };
        }
        public void ShowInfoName()
        {
            string name = EnterData("Fullname");
            foreach(Student std in students) 
            {
                if (std.fullName == name)
                    std.ShowMyInfo();
            }
        }
        public void Recuitment()
        {
            int number = int.Parse(EnterData("number of recruit (11-15)"));
            if (number < 11 && number > 15) 
            {
                Console.WriteLine("Wrong input");
                return;
            }

            List<GoodStudent> glist = new List<GoodStudent>();
            List<NormalStudent> nlist = new List<NormalStudent>();

            GoodStudent good = new GoodStudent();
            NormalStudent normal = new NormalStudent();

            foreach (Student std in students)
            {
                if (std.gradeLevel == "Good")
                {
                    good = (GoodStudent) std;
                    glist.Add(good);
                }
                else
                {
                    normal = (NormalStudent) std;
                    nlist.Add(normal);
                }

            }

            int id = 0;

            if (glist.Count >= number)
            {
                glist.Sort(new IGpaNameComparer());

                for (int i = 0; i < number; i++)
                {
                    Student temp = glist[i];
                    Console.WriteLine($"Fullname: {temp.fullName} | GPA: {glist[i].gpa}");
                }
            }
            else
            {
                glist.Sort(new IGpaNameComparer());
                nlist.Sort(new IEntryEnglishComparer());

                for (int i = 0; i < glist.Count; i++)
                {
                    id++;
                    Student temp = glist[i];
                    Console.WriteLine($"id: {id} | Fullname: {temp.fullName} | GPA: {glist[i].gpa}");
                }

                int rest = number - glist.Count;
                for (int i = 0; i < rest; i++)
                {
                    id++;
                    Student temp = nlist[i];
                    Console.WriteLine($"id: {id} | Fullname: {temp.fullName} | EntryScore: {nlist[i].entryTestScore} | EnglishScore: {nlist[i].englishScore}");
                }
            }
        }
        public void ShowEntireNamePhone()
        {
            students.Sort(new INamePhoneComparer());

            foreach (Student std in students)
            {
                Console.WriteLine($"Fullname: {std.fullName} | Phonenumber: {std.phoneNumber}");
            }
        }

        class INamePhoneComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                int cmp = string.Compare(y.fullName, x.fullName);
                if (cmp != 0)
                {
                    return cmp;
                }

                return string.Compare(x.phoneNumber, y.phoneNumber);
            }
        }
        class IGpaNameComparer : IComparer<GoodStudent>
        {
            public int Compare(GoodStudent x, GoodStudent y)
            {
                if (x.gpa > y.gpa)
                {
                    return -1;
                }
                else if (x.gpa < y.gpa)
                {
                    return 1;
                }
                else
                {
                    return string.Compare(x.fullName, y.fullName);
                }
            }
        }
        class IEntryEnglishComparer : IComparer<NormalStudent>
        {
            public int Compare(NormalStudent x, NormalStudent y)
            {
                if (x.entryTestScore > y.entryTestScore)
                {
                    return -1;
                }
                else if (x.entryTestScore < y.entryTestScore)
                {
                    return 1;
                }
                else
                {
                    if (x.englishScore > y.englishScore)
                    {
                        return -1;
                    }
                    else if (x.englishScore < y.englishScore)
                    {
                        return 1;
                    }
                    else
                    {
                        return string.Compare(x.fullName, y.fullName);
                    }
                }
            }
        }      
    }
    class Tool
    {
        public static void ShowScren(string title, string content)
        {
            Console.WriteLine($"{title}: {content}");
        }
        public static string EnterData(string data)
        {
            Console.Write("Enter {0}:", data);
            return Console.ReadLine();
        }
    }
}


