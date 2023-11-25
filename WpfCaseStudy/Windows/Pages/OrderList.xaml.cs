
using System.Windows.Controls;
using System.Windows.Input;
using WpfCaseStudy.Controllers;
using WpfCaseStudy.Schema;

namespace WpfCaseStudy.Windows.Pages;

public partial class OrderList
{
    public OrderList()
    {
        InitializeComponent();
        
        LoadEntries();
    }

    private readonly OrderDataController _dc = new();

    private void LoadEntries()
    {
        Orders.ItemsSource = _dc.GetAll();
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