using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfCaseStudy.Schema;

public class OrderLine
{
    public OrderLine(int orderId, int productId, int amount)
    {
        OrderId = orderId;
        ProductId = productId;
        Amount = amount;
    }

    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int OrderId { get; set; }
    public virtual Order Order { get; set;  } = null!;

    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
    
    public int Amount { get; set; }
    public int Refunded { get; set; } = 0;

    public double TotalPrice => (Amount - Refunded) * Product.ExportPrice;
}