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
        public abstract void EnterStudent(string gradelevel);
        public void ShowGeneral()
        {
            ShowScren("Fullname", fullName);
            ShowScren("Birthday", doB);
            ShowScren("Sex", sex);
            ShowScren("Phone Number", phoneNumber);
            ShowScren("Universiry Name", universityName);
            ShowScren("Grade Level", gradeLevel);
        }
        public void EnterGeneral(string gradelevel)
        {
            ExceptionFullName();
            ExceptionDOB();
            ExceptionPhoneNumber();
            /*try
            {  */
            sex = EnterData("sex");
            universityName = EnterData("university name");
            gradeLevel = gradelevel;
            /*}
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            */
        }
        private void ExceptionFullName()
        {
            /*try
            {*/
                fullName = EnterData("fullname");
                if (fullName.Length < 10 && fullName.Length < 50)
                {
                    fullName = "";
                    throw new Exception("Invalid fullname length");
                }
            /*}
            catch
            {
                //Console.WriteLine(ex.Message);
            }*/
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
            /*try
            {*/
                phoneNumber = EnterData("phone number");

                if (!Regex.IsMatch(phoneNumber, @"^(090|098|091|031|035|038)\d{7}$"))
                {
                    phoneNumber = "";
                    throw new Exception("Invalid phone number format");
                }
            /*}
            catch 
            {
                //Console.WriteLine(ex.Message);
            }*/
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

        public override void EnterStudent(string gradelevel)
        {
            EnterGeneral(gradelevel);
            gpa = double.Parse(EnterData("gpa"));
            bestRewardName = EnterData("best reward name");
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

        public override void EnterStudent(string gradelevel)
        {
            EnterGeneral(gradelevel);
            englishScore = int.Parse(EnterData("english score"));
            entryTestScore = double.Parse(EnterData("entry test score"));
        }
    }
    class Recruit
    {
        List<Student> students;
        public Recruit()
        {
            students = new List<Student>()
            {
                new GoodStudent("Anh", "23/12/2000", "Male", "0905837459", "BK", "Good", 2.5, "No"),
                new NormalStudent("Le", "17/7/2000", "Female", "0385837115", "BK", "Normal", 560, 9.8),
                new NormalStudent("Thao", "11/9/2000", "Female", "0385137169", "BK", "Normal", 590, 6.8),
                new GoodStudent("Huyen", "24/12/2000", "Female", "0915826459", "BK", "Good", 2.58, "No"),
                new GoodStudent("Chien", "25/11/2000", "Male", "0905885459", "BK", "Good", 2.59, "No"),
                new NormalStudent("Hai", "15/2/2000", "Male", "0355837169", "BK", "Normal", 550, 7.8),
                new NormalStudent("Uyen", "31/8/2000", "Female", "0381537169", "BK", "Normal", 650, 9.8),                
                new NormalStudent("Bao", "11/3/2000", "Male", "0909037169", "BK", "Normal", 750, 7.8),
                new NormalStudent("Dao", "10/12/2000", "Male", "0901437169", "BK", "Normal", 550, 7.8),
                new GoodStudent("Hung", "17/1/2000", "Male", "0905837169", "BK", "Good", 2.98, "No"),
                new GoodStudent("Dat", "10/2/2000", "Male", "0904237459", "BK", "Good", 2.98, "No"),
                new NormalStudent("Hau", "27/6/2000", "Male", "0909137169", "BK", "Normal", 350, 7.8),
                new GoodStudent("Yen", "23/3/2000", "Male", "0905833659", "BK", "Good", 2.76, "No"),
                new GoodStudent("Chinh", "26/2/2000", "Female", "0915893459", "BK", "Good", 2.90, "No"),
                new GoodStudent("Trang", "3/6/2000", "Female", "0985831559", "BK", "Good", 2.90, "No"),
                new GoodStudent("An", "23/12/2000", "Female", "0315517459", "BK", "Good", 2.83, "No"),
                new GoodStudent("Bac", "13/9/2000", "Female", "0315518759", "BK", "Good", 2.83, "No"),
                new GoodStudent("Chien", "15/2/2000", "Female", "0315517959", "BK", "Good", 2.55, "No"),
                new GoodStudent("Anh", "19/1/2000", "Male", "0315512559", "BK", "Good", 2.91, "No"),
            };
        }
        public void NewStudent()
        {
            string gradelevel = EnterData("grade level (Good/Normal)");
            if (gradelevel == "Good") 
            {
                GoodStudent gstd = new GoodStudent();
                gstd.EnterStudent(gradelevel);

                students.Add(gstd);
            }
            else if (gradelevel == "Normal")
            {
                NormalStudent nstd = new NormalStudent();
                nstd.EnterStudent(gradelevel);

                students.Add(nstd);
            }
            else 
            {
                Console.WriteLine("Wrong, please try again");
            }
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
                    id++;
                    Student temp = glist[i];
                    Console.WriteLine($"id: {id} | Fullname: {temp.fullName} | GPA: {glist[i].gpa}");
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


