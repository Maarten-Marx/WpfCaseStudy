using System.Collections.Generic;
using System.Windows;
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

    private readonly OrderDataController _orderDc = new();
    private readonly OrderLineDataController _orderLineDc = new();

    private void LoadEntries()
    {
        Orders.ItemsSource = _orderDc.GetAll();
    }

    private void OpenOrder(object sender, MouseButtonEventArgs __)
    {
        if ((sender as ListViewItem)?.DataContext is Order order)
        {
            var orderLineList = new OrderLineList(order.Id);
            NavigationService?.Navigate(orderLineList);
        }
    }

    private void PlaceOrder(Client client, List<OrderLine> lines)
    {
        var order = new Order(client.Id);
        _orderDc.Add(order);

        foreach (var l in lines)
        {
            l.OrderId = order.Id;
        }

        _orderLineDc.Add(lines.ToArray());

        LoadEntries();
    }

    private void OpenNewOrder(object sender, RoutedEventArgs e)
    {
        var placeOrder = new PlaceOrder(PlaceOrder);
        placeOrder.ShowDialog();
    }
}