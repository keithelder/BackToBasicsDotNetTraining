<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Quicken Loans\Core Framework\4.0.0.0\Rock.Framework.dll</Reference>
  <Namespace>System.Net.Mail</Namespace>
</Query>

void Main()
{
	Lead l = new Lead();
	l.City = "Detroit";
	l.FirstName = "Keith";
	l.LastName = "Elder";
	l.EmailAddress = "keithelder@quickenloans.com";
	l.State = "MI";
	l.Zip = "12345";
	l.LeadType = LeadType.Schwab;
	
	
	if(l.LeadType == LeadType.USAA)
	l.Dump();
	
//	EmailLeadNotifier email = new EmailLeadNotifier(l);
//	
//	//email.SendEmail();
//	email.SendSnailMail();
}

// Define other methods and classes here

// Entities / POCOS Plain Old C#/CLR Object
public class Lead : IPerson
{
	public Guid JacketNumber { get; private set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string Zip { get; set; }
	public string EmailAddress { get; set; }
	public LeadType LeadType { get; set; }
	
	public Lead()
	{
		JacketNumber = Guid.NewGuid();
	}
}

public interface IPerson : IEmailAddress
{
	Guid JacketNumber {get; }
	string FirstName { get; set; }
	string LastName { get; set; }
	string City { get; set; }
	string State { get; set; }
	string Zip { get; set; }
	string EmailAddress { get; set; }

}

public enum LeadType
{
	Caddilac,
	Schwab,
	USAA
}

public static class LeadExtensions
{
	public static bool IsValid(this Lead l)
	{
		if(!String.IsNullOrEmpty(l.FirstName)  && !String.IsNullOrEmpty(l.LastName) && Rock.Framework.Validation.ClientData.ValidateEmailAddressFormat(l.EmailAddress)) return true;
		return false;
	}
}

public interface IEmailAddress {
	string EmailAddress { get; set; }
}

public class Notifier<T> where T: IPerson
{
	SmtpClient _client = new SmtpClient("mailrelay");
	T _lead;
	
	public Notifier(T l)
	{
		_lead = l;
	}
	
	public void SendEmail()
	{
		var body = "Welcome " + _lead.FirstName + " to Quicken Loans!";
		MailMessage msg = new MailMessage("newlead@quickenloans.com", _lead.EmailAddress, "Welcome To QL!", body);
		_client.Send(msg);
		Console.WriteLine ("Email Sent!");
	}
	
	public void SendSnailMail()
	{
		var xml = Rock.Framework.Serialization.XmlObjectSerializer.ToXml(_lead);
		File.WriteAllText(@"c:\temp\" + _lead.JacketNumber + ".xml", xml);
		
		MailMessage msg = new MailMessage("newload@ql.com", "keithelder@quickenloans.com", "New Load from QL", "Please send standard flyer to new client.");
		
		var attachment = new Attachment(@"c:\temp\" + _lead.JacketNumber + ".xml");
		
		msg.Attachments.Add(attachment);
		_client.Send(msg);
	}

}











