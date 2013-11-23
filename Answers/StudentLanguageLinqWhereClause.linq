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
	var q = (from s in Students 
	where (from f in Languages
	       where f.StudentId == s.StudentId
		   select f.Content).Count() != 0
    select new {
	   FirstName = s.FirstName,
	   LastName = s.LastName,
	   Language = from f in Languages
	       where f.StudentId == s.StudentId
		   select f.Content
	});
	
	
	
   q.Dump();
}

// Define other methods and classes here
