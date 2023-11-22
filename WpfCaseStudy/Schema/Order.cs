using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WpfCaseStudy.Schema;

public class Order
{
    public Order(string clientId)
    {
        ClientId = clientId;
        PlacedOn = DateTime.Now;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string ClientId { get; set; }
    public virtual Client Client { get; set; } = null!;

    public DateTime PlacedOn { get; set; }

    public List<OrderLine> OrderLines { get; set; } = new();

    public double TotalPrice => OrderLines.Sum(line => line.TotalPrice);
    public double NumberOfLines => OrderLines.Count;
}