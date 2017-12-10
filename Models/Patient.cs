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
        if (Addresses != null)
        {
            return Addresses.Where(a => a.Type == "residential").SingleOrDefault();
        }
        return null;
    }

    public Address GetPostalAddress()
    {
        if (Addresses != null)
        {
            return Addresses.Where(a => a.Type == "postal").SingleOrDefault();
        }
        return null;
    }

    public ContactPoint GetMobilePhone()
    {
        if (Telecom != null)
        {
            return Telecom.Where(t => t.System == "phone" && t.Use == "mobile").SingleOrDefault();
        }
        return null;
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

    public void SetTitle(string title)
    {
        if (Name != null)
        {
            Name.Prefix = title;
        }
    }
}