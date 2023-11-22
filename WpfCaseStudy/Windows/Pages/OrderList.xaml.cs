using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using WpfCaseStudy.Schema;

namespace WpfCaseStudy.Windows.Pages;

public partial class OrderList
{
    public OrderList()
    {
        InitializeComponent();
        RetrieveEntries();
        Orders.ItemsSource = Entries;
    }

    private List<Order> Entries { get; set; } = new();

    private void RetrieveEntries()
    {
        Entries = App.Db.Orders
            .Include(o => o.Client)
            .Include(o => o.OrderLines)
            .ThenInclude(l => l.Product)
            .ToList();
    }

    private void OpenOrder(object sender, MouseButtonEventArgs __)
    {
        if ((sender as ListViewItem)?.DataContext is Order order)
        {
            var orderLineList = new OrderLineList(order.Id);
            NavigationService?.Navigate(orderLineList);
        }
    }
}