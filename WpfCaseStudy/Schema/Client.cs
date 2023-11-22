using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WpfCaseStudy.Schema;

public class Client
{
    public Client(string id, string name, double credit, string address, string tel, string email)
    {
        Id = id;
        Name = name;
        Credit = credit;
        Address = address;
        Tel = tel;
        Email = email;
    }

    [Key] public string Id { get; set; }
    public string Name { get; set; }
    public double Credit { get; set; }
    public string Address { get; set; }
    public string Tel { get; set; }
    public string Email { get; set; }

    public List<Order> Orders { get; set; } = new();
}