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
	Student s = new Student();
	s.FirstName = "Keith";
	s.LastName = "Elder";
	s.BirthDate = DateTime.Now;
	
	Students.InsertOnSubmit(s);
	SubmitChanges();
	Students.DeleteOnSubmit(s);
	SubmitChanges();
}

// Define other methods and classes here
