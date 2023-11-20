using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfCaseStudy.Schema;

public class Product
{
    public Product(string name, int stock, string storageLocation, double importPrice, double exportPrice)
    {
        Name = name;
        Stock = stock;
        StorageLocation = storageLocation;
        ImportPrice = importPrice;
        ExportPrice = exportPrice;
    }

    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public int Stock { get; set; }
    
    public string StorageLocation { get; set; }
    
    public double ImportPrice { get; set; }

    public double ExportPrice { get; set; }

    public List<OrderLine> OrderLines { get; set; } = new();
}