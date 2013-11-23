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
	var q = from s in Students
			select s;
			
			q.Dump();
			
	var lang = from l in Languages
			select l;
			
	lang.Dump();
}

// Define other methods and classes here
