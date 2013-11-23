<Query Kind="Program" />

void Main()
{
	List<Student> students = GetStudentData();
	// find the language that is known the best
	
	var q = (from s in students
			from l in s.KnownLanguages
			group l by l into g
			orderby g.Count() descending
			select new { 
						Name=g.First(), 
						Count=g.Count(),
						StudentNames = from f in students
										where f.KnownLanguages.Contains(g.First())
										select f.Name
			
			}).FirstOrDefault();
	q.Dump();
	
	
	
	 
//	    List<Product> products = GetProductList(); 
//  
//    var categoryCounts = 
//        from p in products 
//        group p by p.Category into g 
//        select new { Category = g.Key, ProductCount = g.Count() }; 
//  
   
	// find the language known the most
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

public List<Student> GetStudentData()
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