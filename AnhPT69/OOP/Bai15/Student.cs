using Pratices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Pratices
{
    internal class Score
    {
        private string _Name;
        private int _Term;
        private double _Score;
        public string name
        {
            set { _Name = value; }
            get { return _Name; }
        }
        public int term
        { 
            set { _Term = value; }
            get { return _Term; }
        }

        public double score
        {
            set { _Score = value; }
            get { return _Score; }
        }
    }
    abstract class Student 
    {
        private string _StudentID;
        private string _Name;
        private string _Birthday;
        private string _YearStart;
        private double _InputScore;
        List<Score> _ScoreList;

        public string StudentID
        {
            get => _StudentID;
        }
        public string YearStart
        {
            get => _YearStart;
        }
        public double InputScore
        {
            get => _InputScore;
        }
        public List<Score> ScoreList
        {
            get => _ScoreList;
        }
        public Student(string studentID, string name, string birthday, string yearStart, double inputScore, List<Score> scoreList)
        {
            _StudentID = studentID;
            _Name = name;
            _Birthday = birthday;
            _YearStart = yearStart;
            _InputScore = inputScore;
            _ScoreList = scoreList;
        }

        public Student(Student std)
        {
            _StudentID = std._StudentID;
            _Name = std._Name;
            _Birthday = std._Birthday;
            _YearStart = std._YearStart;
            _InputScore = std._InputScore;
            _ScoreList = std._ScoreList;
        }

        public Student() 
        {
            _StudentID = string.Empty;
            _Name = string.Empty;
            _Birthday = string.Empty;
            _YearStart = string.Empty;
            _InputScore = 0;
            _ScoreList = new List<Score>();
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{_StudentID} - {_Name} - {_Birthday} - {_YearStart} - {_InputScore} ");
            _ScoreList.ForEach(sl => Console.WriteLine($"{sl.name} - {sl.term} - {sl.score}"));
        }


    }

    internal class Regular : Student
    {
        public Regular()
        {
        }

        public Regular(string studentID, string name, string birthday, string yearStart, double inputScore, List<Score> scoreList) : base(studentID, name, birthday, yearStart, inputScore, scoreList)
        {
        }

        public Regular(Regular regular) : base(regular)
        {
            
        }
    }

    internal class InService : Student 
    {
        private string _LocationLinked;
        public string LocationLinked
        {
            get => _LocationLinked;
        }

        public InService()
        {
            _LocationLinked = string.Empty;
        }
        public InService(string studentID, string name, string birthday, string yearStart, double inputScore, List<Score> scoreList, string locationLinked) : base(studentID, name, birthday, yearStart, inputScore, scoreList)
        {
            _LocationLinked = locationLinked;
        }
        public InService(InService ins) : base(ins)
        {
            _LocationLinked = ins._LocationLinked;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine(_LocationLinked);
        }
    }

    internal class Department
    {
        public string Name;
        List<Student> Students;
        public Department() 
        {
            Name = string.Empty;

            List<Score> ScoreList = new List<Score>()
            {
                  new Score() {name = "Math", term = 2018, score = 6.5},
                  new Score() {name = "Programing", term = 2018, score = 7.5},
                  new Score() {name = "Mechanical", term = 2019, score = 7},
                  new Score() {name = "Electricity", term = 2021, score = 7},

            };

            List<Score> ScoreList1 = new List<Score>()
            {
                  new Score() {name = "Math", term = 2018, score = 9},
                  new Score() {name = "Programing", term = 2018, score = 8},
                  new Score() {name = "Mechanical", term = 2019, score = 8.5},
                  new Score() {name = "Electricity", term = 2021, score = 8.5},

            };

            List<Score> ScoreList2 = new List<Score>()
            {
                  new Score() {name = "Math", term = 2018, score = 8},
                  new Score() {name = "Programing", term = 2018, score = 8},
                  new Score() {name = "Mechanical", term = 2019, score = 9},
                  new Score() {name = "Electricity", term = 2021, score = 9},

            };

            Students = new List<Student>()
            {
                new Regular("id1", "Anh", "2000-12-31", "2018", 7.8, ScoreList),
                new InService("id2", "Chien", "2000-2-25", "2019", 5.8, ScoreList2, "HN"),
                new Regular("id3", "Ba", "2000-1-25", "2020", 8.8, ScoreList1), 
                new InService("id4", "Dat", "2000-3-25", "2018", 9.0, ScoreList, "TN"),
            };
        }
        public void Input()
        {
            try
            {
                string TypeStd = Enter("Regular or InService Student ? (reg/ins)");

                if (TypeStd != "reg" && TypeStd != "ins")
                    throw new Exception("Error student type");

                string ID = Enter("ID");
                string Name = Enter("Name");
                string Birthday = Enter("Birthday");
                string YearStart = Enter("YearStart");
                double InputScore = double.Parse(Enter("InputScore"));
                List<Score> ScoreList = new List<Score>();

                Console.WriteLine("Input score in each term");
                while (true)
                {
                    string n = Enter("name");
                    int t = int.Parse(Enter("term"));
                    double s = double.Parse(Enter("score"));
                    Score sc = new Score() {name = n, term = t, score = s };
                    ScoreList.Add(sc);
                    string check = Enter("Continue ? (y/n)");
                    if (check == "n")
                        break;
                }

                if (TypeStd == "reg")
                {
                    Regular reg = new Regular(ID, Name, Birthday, YearStart, InputScore, ScoreList);
                    Students.Add(reg);
                }
                else if (TypeStd == "ins")
                {
                    string loclinked = Enter("LocationLinked");
                    InService ins = new InService(ID, Name, Birthday, YearStart, InputScore, ScoreList, loclinked);
                    Students.Add(ins);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            

        }
        public void Output()
        {
            Console.WriteLine(Name);
            foreach (Student student in Students) 
            {
                student.ShowInfo();
            }
        }
        public bool IsRegular()
        {
            string id = Enter("ID");
            Student std = Students.Find(std => std.StudentID == id);

            return std is Regular;
        }
        public double AvgTerm(string id, int term)
        {
            Student std = Students.Find(std => std.StudentID == id);

            List<Score> scorelist = std.ScoreList.FindAll(s => s.term == term);

            double avg = scorelist.Average(s => s.score);

            return avg;
        }
        public int SumRegular()
        {
            int sum = 0;
            foreach (Student std in Students) 
            {
                if (std is Regular)
                {
                    sum++;
                }    
            }
            return sum;
        }
        public void MaxInputScore()
        {
            Student max = new Regular();

            foreach (Student std in Students)
            {
                if (max.InputScore < std.InputScore)
                {
                    max = std;
                }  
            }

            max.ShowInfo();
        }
        public List<Student> ListInService(string loclinked)
        {
            List<Student> list = new List<Student>();

            InService index = new InService();

            foreach (Student std in Students)
            {
                if (std is Regular)
                {
                    continue;
                }    

                index = (InService) std;

                if (index.LocationLinked == loclinked)
                {
                    list.Add(std);
                    std.ShowInfo();
                }    
            }

            return list;
        }
        public List<Student> ListScoreHigher8(int term)
        {
            List<Student> list = new List<Student>();

            foreach (Student std in Students)
            {
                double avg = AvgTerm(std.StudentID, term);
                
                if (avg > 8)
                {
                    list.Add(std);
                    std.ShowInfo();
                }    
            }

            return list;
        }
        public void MaxAvg()
        {
            Student student = new Regular();
            double highest_avg = 0;

            foreach (Student std in Students)
            { 
                Dictionary<int, double> sum = new Dictionary<int, double>();
                Dictionary<int, int> number = new Dictionary<int, int>();

                foreach (Score s in std.ScoreList)
                {
                    if (sum.ContainsKey(s.term))
                    {
                        sum[s.term]+= s.score;
                        number[s.term]++;
                    }
                    else
                    {
                        sum.Add(s.term, s.score);
                        number.Add(s.term, 1);
                    }
                }

                double avg = 0;
                
                foreach (var entry in sum)
                {
                    avg = entry.Value / number[entry.Key];

                    if (highest_avg < avg )
                    {
                        highest_avg = avg;

                        if (student.StudentID != std.StudentID)
                        {
                            student = std;
                        }
                    }    
                }    
                    
            }   
            
            student.ShowInfo();
            Console.WriteLine("with avg score : " + highest_avg);
        }
        public void Sort()
        {
            Students.Sort(new ITypeYearComparator());
            Students.ForEach(s => s.ShowInfo());
        }
        public Dictionary<string,int> GroupYearStart()
        {
            Dictionary<string, int> listyear = new Dictionary<string, int>(); 
            foreach (Student std in Students)
            {
                if (listyear.ContainsKey(std.YearStart))
                {
                    listyear[std.YearStart]++;
                }
                else
                {
                    listyear.Add(std.YearStart, 1);
                }    

            }
            
            foreach (var entry in listyear) 
            {
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }

            return listyear;
        }
        
        private string Enter(string title)
        {
            Console.Write($"{title}: ");
            return Console.ReadLine();
        }
    }

    class ITypeYearComparator : IComparer<Student> 
    {
        public int Compare(Student x, Student y)
        {
            if (x is not Regular && y is Regular)
            {
                return 1;
            }
            else if (x is Regular && y is not Regular)
            {
                return -1;
            }
            else
            {
                int year_x = int.Parse(x.YearStart);
                int year_y = int.Parse(y.YearStart);
                if (year_x > year_y)
                {
                    return -1;
                }
                else if (year_x < year_x)
                {
                    return 1;
                }
                else
                { 
                    return 0; 
                }
            }
        }
    }
    public abstract class car
    {
        static int pro
        {
            get; set;
        }
        static car() { }
    }

}

#region

/*
public: within class, derived class (same assembly), non-derived class (same assembly), derived class (different assembly), non-derived class (differen assembly)
protected internal: not non-derived class (diff)

*/


#endregion
