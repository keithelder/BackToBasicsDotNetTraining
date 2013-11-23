<Query Kind="Program">
  <Connection>
    <ID>ed692a1f-3b9f-47f2-ad32-75e73d78b1b0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Training</Database>
  </Connection>
</Query>

void Main()
{
//	
//	var q = (from s in Students
//				from l in s.Languages
//				group l by l.Content into g
//				select new {Language=g.First(), Count=g.Count()}).OrderByDescending(x => x.Count);
//	q.Dump();	


	var q = (from s in Students
				from l in s.Languages
				group l by l.Content into g
				select g.First().Content).FirstOrDefault();
	q.Dump();
	
}

// Define other methods and classes here
