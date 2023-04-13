using Pratices;
using System.Text;

Console.WriteLine(Sample2.b);
Console.WriteLine(SampleChild.b);

Sample2.b = 3;
Console.WriteLine(SampleChild.b);

Sample2 sm = new Sample2();
Console.WriteLine(sm.a);

/*List < Score > ScoreList = new List<Score>()
{
      new Score() {name = "Math", term = 2018, score = 6.5},
      new Score() {name = "Programing", term = 2019, score = 7.5},
      new Score() {name = "Mechanical", term = 2020, score = 7},
      new Score() {name = "Electricity", term = 2021, score = 8},

};

Regular std1 = new Regular("id1", "Anh", "2000-12-31", "2018", 7.8, ScoreList);

//std1.ShowInfo();

Regular std2 = new Regular(std1);
//std2.ShowInfo();

InService std3 = new InService("id3", "Ba", "2000-11-30", "2018", 8.8, ScoreList, "UK");

//std3.ShowInfo();

InService std4 = new InService(std3);

//std4.ShowInfo();

List<Student> students = new List<Student>{std1,  std2, std3, std4};*/

//Department dp = new Department() { Name = "IT"};
//Console.WriteLine( dp.AvgTerm(2018));
//Console.WriteLine(dp.SumRegular());
//dp.MaxInputScore();
//dp.ListInService("TN");
//dp.ListScoreHigher8(2018);
//dp.Sort();
//dp.GroupYearStart();
//dp.MaxAvg();



Sample sp = new Sample();
Console.WriteLine(Sample.pi);