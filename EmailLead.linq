<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Quicken Loans\Core Framework\4.0.0.0\Rock.Framework.dll</Reference>
  <Namespace>System.Net.Mail</Namespace>
  <Namespace>System.Net.Mime</Namespace>
</Query>

void Main()
{
	 Lead l = new Lead();
	 l.FirstName = "Sally";
	 l.LastName = "Wiliamson";
	 l.City = "Detroit";
	 l.Email = "keith@keithelder.net";
	 l.State = "MI";
	 l.Zip = "12345";
	 l.LeadId = 123213123;
	 
	 EmailLeadNotifier email = new EmailLeadNotifier(l);
	 email.SendEmail();
	 email.SendSnailMail();
	 
}

public class Lead
{
	public readonly int LeadId;  // field
	
	// properties
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string Zip { get; set; }
	
	public Lead() // constructor
	{
		var r = new Random();
		LeadId = r.Next(1000,1000000);
	}
}

public class EmailLeadNotifier
{
	SmtpClient _client = new SmtpClient("mailrelay");
	Lead _lead;
	
	public EmailLeadNotifier(Lead lead)
	{
		_lead = lead;	
	}
	
	public void SendEmail()
	{
		var body = "Welcome to Boy Howdy " + _lead.FirstName + "!";
		MailMessage msg = new MailMessage("newlead@boyhowdyproductions.com", _lead.Email, "Welcome to Boy Howdy!", body);
		_client.Send(msg);
		Console.WriteLine ("Mail sent");
	}
	
	public void SendSnailMail()
	{
		var xml = Rock.Framework.Serialization.XmlObjectSerializer.ToXml(_lead);
		System.IO.File.AppendAllText(@"c:\temp\" + _lead.JacketNumber + ".xml", xml);
		MailMessage msg = new MailMessage("newlead@quickenloans.com", "keithelder@quickenloans.com", "New Lead from QL", "Please send our client the normal lead flyer.");
		msg.Attachments.Add(new Attachment(@"c:\temp\" + _lead.JacketNumber + ".xml"));
		_client.Send(msg);
		
	}
}