using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OOP14
{
    internal abstract class Biref
    {
        public string FullName;
        public string doB;
        public string sex;
        public string phoneNumber;
        public string universityName;
        public string gradeLevel;
        public Biref() { }
        public Biref(string _FullName, string _doB, string _sex, string _phoneNumber, string _universityName, string _gradeLevel)
        {
            this.FullName = _FullName;
            this.doB = _doB;
            this.sex = _sex;
            this.phoneNumber = _phoneNumber;
            this.universityName = _universityName;
            this.gradeLevel = _gradeLevel;
        }
        public abstract void ShowMyInfor();
    }
    internal class GoodStudent : Biref
    {
        public double gpa;
        public string bestRewardName;
        public GoodStudent() { }
        public GoodStudent(double _gpa, string _bestRewardName, string _FullName, string _doB, string _sex, string _phoneNumber, string _universityName, string _gradeLevel)
        : base(_FullName, _doB, _sex, _phoneNumber, _universityName, _gradeLevel)
        {
            gpa = _gpa;
            bestRewardName = _bestRewardName;
        }
        public override void ShowMyInfor()
        {
            Console.WriteLine($"Ho ten: {FullName}, Ngay than nam sinh: {doB}, Gioi tinh: {sex}, So dien thoai: {phoneNumber}," +
                $"Ten truong da hoc: {universityName}, Xep loai tot nghiep: {gradeLevel}, GPA: {gpa}, Hoc bong: {bestRewardName}");
        }
    }
    internal class Normalstudent : Biref
    {
        public int englishScore;
        public double entryTestScore;
        public Normalstudent() { }
        public Normalstudent(int _englishScore, double _entryTestScore, string _FullName, string _doB, string _sex, string _phoneNumber, string _universityName, string _gradeLevel)
        : base(_FullName, _doB, _sex, _phoneNumber, _universityName, _gradeLevel)
        {
            englishScore = _englishScore;
            entryTestScore = _entryTestScore;
        }
        public override void ShowMyInfor()
        {
            Console.WriteLine($"Ho ten: {FullName}, Ngay than nam sinh: {doB}, Gioi tinh: {sex}, So dien thoai: {phoneNumber}," +
                $"Ten truong da hoc: {universityName}, Xep loai tot nghiep: {gradeLevel}, Diem toeic: {englishScore}, Diem dau vao chuyen mon: {entryTestScore}");
        }
    }
    internal class InvalidFullNameException: Exception{
        public InvalidFullNameException(): base("wrong name format"){
            
        }
        
    }
    internal class InvalidDOBException: Exception
    {
        public InvalidDOBException(): base("worng datetime format"){

        }
    }
    internal class InvalidPhoneNumberException: Exception
    {
        public InvalidPhoneNumberException(): base("wrong phone format"){

        }
    }
    internal class ManagementStudent
    {
        public Biref[] students { get; set; }
        public List<GoodStudent> goods { get; set; }
        public List<Normalstudent> normals { get; set; }
        public List<GoodStudent> storages { get; set; }
        public ManagementStudent() {
            students = new Biref[15];
            goods = new List<GoodStudent>();
            normals = new List<Normalstudent>();
            storages = new List<GoodStudent>();
        }
        public string FormatName(string data)
        {
            Regex check = new Regex(@"^\w{10,50}$");
            if (check.IsMatch(data))
            {
                return data;
            }
            else
            {
                throw new InvalidFullNameException();
            }
        }
        public string FormatDate(string data)
        {
            Regex check = new Regex(@"^\d{2}/\d{2}/\d{4}$");
            if (check.IsMatch(data))
            {
                return data;
            }
            else
            {
                throw new InvalidDOBException();
            }
        }
        public string FormatPhone(string data)
        {
            Regex check = new Regex(@"^[090|098|091|031|035|038]+\d{7}$");
            if (check.IsMatch(data))
            {
                return data;
            }
            else
            {
                throw new InvalidPhoneNumberException();
            }
        }
        public void AddStudent(Biref b)
        {
            if (b is GoodStudent)
            {
                goods.Add((GoodStudent)b);
                
            }
            else if(b is Normalstudent) {
                normals.Add((Normalstudent)b);
            }
            if(goods.Count > 15)
            {
                goods.Sort(
                    (p1, p2) =>
                    {
                        if(p1.gpa > p2.gpa)
                        {
                            return -1;
                        }
                        else if(p1.gpa == p2.gpa)
                        {
                            if (p1.FullName.Split(" ")[p1.FullName.Split(" ").Length - 1][0] > p2.FullName.Split(" ")[p2.FullName.Split(" ").Length - 1][0])
                            {
                                return -1;
                            }
                            else if (p1.FullName.Split(" ")[p1.FullName.Split(" ").Length - 1][0] == p2.FullName.Split(" ")[p2.FullName.Split(" ").Length - 1][0])
                            {
                                return 0;
                            }
                            return 1;
                        }
                        return 1;
                    }   
                );
                for(int i = 0; i <= 14; i++)
                {
                    students[i] = goods[i];
                }
            }
            else if(goods.Count == 15)
            {
                for (int i = 0; i < goods.Count; i++)
                {
                    students[i] = goods[i];
                }
            }
            else if (goods.Count < 15 && goods.Count > 0)
            {
                for (int i = 0; i < goods.Count; i++) {
                    students[i] = goods[i];
                }
                if(goods.Count + normals.Count == 15)
                {
                    for(int i = 0; i < normals.Count; i++)
                    {
                        students[goods.Count + i] = normals[i];
                    }
                }
                else if(goods.Count + normals.Count > 15)
                {
                    normals.Sort((p1, p2) =>
                    {
                        if(p1.entryTestScore > p2.entryTestScore)
                        {
                            return -1;
                        }
                        else if(p1.entryTestScore == p2.entryTestScore){
                            if(p1.englishScore > p2.englishScore)
                            {
                                return -1;
                            }
                            else if(p1.englishScore == p2.englishScore){
                                if (p1.FullName.Split(" ")[p1.FullName.Split(" ").Length - 1][0] > p2.FullName.Split(" ")[p2.FullName.Split(" ").Length - 1][0])
                                {
                                    return -1;
                                }
                                else if (p1.FullName.Split(" ")[p1.FullName.Split(" ").Length - 1][0] == p2.FullName.Split(" ")[p2.FullName.Split(" ").Length - 1][0])
                                {
                                    return 0;
                                }
                                return 1;
                            }
                            return 0;
                        }
                        return 1;
                    });
                    for(int i = 0; i < normals.Count; i++)
                    {
                        if(students.Length < 15)
                        {
                            students[goods.Count + i]= normals[i];
                        }
                        
                    }
                    
                }
            }
            Console.WriteLine(students);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ManagementStudent m = new ManagementStudent();
            m.AddStudent(new GoodStudent(9.5, "hoc bong khuyen khich", "nguyen van a", "13/12/1234", "male", "0903456123", "bach khoa", "very good"));
            m.AddStudent(new GoodStudent(9.1, "hoc bong khuyen khich", "nguyen van b", "13/12/1234", "male", "0903456123", "bach khoa", "very good"));
            m.AddStudent(new GoodStudent(9.2, "hoc bong khuyen khich", "nguyen van c", "13/12/1234", "male", "0903456123", "bach khoa", "very good"));
            m.AddStudent(new GoodStudent(9.3, "hoc bong khuyen khich", "nguyen van d", "13/12/1234", "male", "0903456123", "bach khoa", "very good"));
            m.AddStudent(new GoodStudent(9.2, "hoc bong khuyen khich", "nguyen van e", "13/12/1234", "male", "0903456123", "bach khoa", "very good"));
            m.AddStudent(new GoodStudent(9.0, "hoc bong khuyen khich", "nguyen van f", "13/12/1234", "male", "0903456123", "bach khoa", "very good"));
            m.AddStudent(new GoodStudent(9.8, "hoc bong khuyen khich", "nguyen van g", "13/12/1234", "male", "0903456123", "bach khoa", "very good"));
            m.AddStudent(new GoodStudent(9.7, "hoc bong khuyen khich", "nguyen van h", "13/12/1234", "male", "0903456123", "bach khoa", "very good"));
            m.AddStudent(new GoodStudent(9.3, "hoc bong khuyen khich", "nguyen van i", "13/12/1234", "male", "0903456123", "bach khoa", "very good"));
            m.AddStudent(new GoodStudent(9.2, "hoc bong khuyen khich", "nguyen van j", "13/12/1234", "male", "0903456123", "bach khoa", "very good"));
            m.AddStudent(new GoodStudent(9.1, "hoc bong khuyen khich", "nguyen van k", "13/12/1234", "male", "0903456123", "bach khoa", "very good"));
            m.AddStudent(new Normalstudent(234, 9.5, "Nguyen C", "23/03/2002", "Female", "0904324567", "Bach khoa", "very good"));
            m.AddStudent(new Normalstudent(235, 9.2, "Nguyen B", "23/03/2002", "Female", "0904324567", "Bach khoa", "very good"));
            m.AddStudent(new Normalstudent(236, 9.1, "Nguyen D", "23/03/2002", "Female", "0904324567", "Bach khoa", "very good"));
            m.AddStudent(new Normalstudent(237, 9.4, "Nguyen E", "23/03/2002", "Female", "0904324567", "Bach khoa", "very good"));
            m.AddStudent(new Normalstudent(236, 9.1, "Nguyen F", "23/03/2002", "Female", "0904324567", "Bach khoa", "very good"));



        }
    }
}
