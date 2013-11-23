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
                     join l in Languages on s.StudentId equals l.StudentId
                     select new 
                     {
                         FirstName = s.FirstName,
                         LastName = s.LastName,
							Language = 
                             (from lang in Languages
                            where lang.StudentId == s.StudentId
                             select lang.Content).ToList().Distinct()
                     }).ToList().Distinct();	
           q.Dump();
}

// Define other methods and classes here
