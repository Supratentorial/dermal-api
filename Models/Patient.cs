using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

public class Patient
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public string Gender { get; set; }
    [Column(TypeName = "Date")]
    public DateTime BirthDate { get; set; }
    public List<Address> Addresses { get; set; }
    public HumanName Name { get; set; }
    public List<ContactPoint> Telecom { get; set; }
    public Practitioner GeneralPractitioner { get; set; }

    public ContactPoint GetEmail()
    {
        if (Telecom != null)
        {
            return Telecom.Where(t => t.System == "email").SingleOrDefault();
        }
        return null;
    }

    public Address GetResidentialAddress()
    {
        return Addresses.Where(a => a.Type == "residential").SingleOrDefault();
    }

    public Address GetPostalAddress()
    {
        return Addresses.Where(a => a.Type == "postal").SingleOrDefault();
    }

    public ContactPoint GetMobilePhone()
    {
        return Telecom.Where(t => t.System == "phone" && t.Use == "mobile").SingleOrDefault();
    }

    

    public string GetGivenNames()
    {
        if (Name != null)
        {
            return Name.Given;
        }
        return null;
    }

    public string GetFamilyName()
    {
        if (Name != null)
        {
            return Name.Family;
        }
        return null;
    }

    public string GetTitle()
    {
        if (Name != null)
        {
            return Name.Prefix;
        }
        return null;
    }

    public void SetTitle(string title) {
        if (Name != null) {
            Name.Prefix = title;
        }
    }
}