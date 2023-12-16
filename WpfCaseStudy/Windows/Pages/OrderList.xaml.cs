using System.Collections.Generic;
using System.Linq;
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
    private readonly ClientDataController _clientDc = new();
    private readonly ProductDataController _productDc = new();

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
            _productDc.UpdateWhere(
                p => p.Id == l.ProductId,
                p => p.Stock -= l.Amount
            );
            
            l.OrderId = order.Id;
        }

        _orderLineDc.Add(lines.ToArray());

        _clientDc.UpdateWhere(
            c => c.Id == client.Id,
            c => c.Credit -= lines.Sum(l => l.TotalPrice)
        );

        LoadEntries();
    }

    private void OpenNewOrder(object sender, RoutedEventArgs e)
    {
        var placeOrder = new PlaceOrder(PlaceOrder);
        placeOrder.ShowDialog();
    }
}