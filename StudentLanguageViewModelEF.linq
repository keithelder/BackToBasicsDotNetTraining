<Query Kind="Program">
  <Connection>
    <ID>2fbd83c3-4c6c-4d52-8fbf-a608daba4886</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\Temp\los\src\LOS.Web\bin\LOS.Web.dll</CustomAssemblyPath>
    <CustomTypeName>LOS.Web.Models.TrainingEntities</CustomTypeName>
    <AppConfigPath>C:\Temp\los\src\LOS.Web\Web.config</AppConfigPath>
  </Connection>
</Query>

void Main()
{
	var q = (from s in Students
			join l in Languages on s.StudentId equals l.StudentId
			into ids
			where s.Languages.Count > 1
			select new StudentLanguageViewModel { 
						FirstName=s.FirstName, 
						Languages= (from id in ids select id.Language1).Distinct()
						});
			
			
			q.Dump();
}

// Define other methods and classes here
