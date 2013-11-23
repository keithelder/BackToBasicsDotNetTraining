<Query Kind="Program">
  <Connection>
    <ID>9e42b051-f928-4ca0-bd62-77aae325acdc</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Northwind</Database>
  </Connection>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// use async and await and TPL (task parre? library)

 async void Main()
{
	Stopwatch watch = new Stopwatch();
	watch.Start();
	var data  = await GetStudentData();
	var info = await CalculateLanguageInfo(data);
	info.Dump();
	
	Console.WriteLine (info.Language + " is the winner with " + info.Count + " students");
	
	watch.Stop();
	watch.Dump();
	

}

public class LanguageInfo
{
	public string Language { get; set; }
	public int Count { get; set; }
}

public async Task<LanguageInfo> CalculateLanguageInfo(List<Student> students)
{
	var q = (from s in students
				from l in s.KnownLanguages
				group l by l into g
				select new LanguageInfo {Language=g.First(), Count=g.Count()}).OrderByDescending(x => x.Count).FirstOrDefault();
	return q;		
}		

// Define other methods and classes here
public class Student
{
	public int Age { get; set; }
	public string Name { get; set; }
	public List<string> KnownLanguages {get; set; }
	
	public Student()
	{
		KnownLanguages = new List<string>();
	}
}

public async Task<List<Student>> GetStudentData()
{
	List<Student> list = new List<Student>();
	list.Add(new Student() { Age=12, Name = "Keith Elder", KnownLanguages={"C#", "F#", "Bash", "Perl", "PHP" }});
	list.Add(new Student() { Age=22, Name = "Frank Smith", KnownLanguages={"Bash", "JavaScript", "PHP" }});
	list.Add(new Student() { Age=32, Name = "Sally Jessy", KnownLanguages={"Perl", "PHP" }});
	list.Add(new Student() { Age=42, Name = "Chris Flabergaster", KnownLanguages={"Bash", "Perl", "PHP" }});
	list.Add(new Student() { Age=52, Name = "Ramez FreeDinner", KnownLanguages={"PHP" }});
	list.Add(new Student() { Age=62, Name = "Sam I-AM", KnownLanguages={"Progress", "Bash", "Perl", "PHP" }});
	list.Add(new Student() { Age=72, Name = "Sweet Pickles", KnownLanguages={"JavaScript", "Perl", "PHP" }});

	return list;
}