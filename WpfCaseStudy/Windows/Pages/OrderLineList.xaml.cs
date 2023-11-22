using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfCaseStudy.Schema;

namespace WpfCaseStudy.Windows.Pages;

public partial class OrderLineList
{
    public OrderLineList(int id)
    {
        InitializeComponent();
        RetrieveEntries(id);
        OrderLines.ItemsSource = Entries;
    }

    private List<OrderLine> Entries { get; set; } = new();

    private void RetrieveEntries(int id)
    {
        Entries = App.Db.OrderLines
            .Include(l => l.Product)
            .Where(l => l.OrderId == id)
            .ToList();
    }
}