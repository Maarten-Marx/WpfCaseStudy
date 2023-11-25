using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfCaseStudy.Controllers;
using WpfCaseStudy.Schema;

namespace WpfCaseStudy.Windows.Pages;

public partial class OrderLineList
{
    public OrderLineList(int id)
    {
        InitializeComponent();

        _orderId = id;
        LoadEntries();
    }

    private readonly int _orderId;

    private readonly OrderLineDataController _orderLineDc = new();
    private readonly ClientDataController _clientDc = new();

    private void LoadEntries()
    {
        OrderLines.ItemsSource = _orderLineDc.GetWhere(l => l.OrderId == _orderId);
    }

    private void RefundEntry(OrderLine line, int amount)
    {
        _orderLineDc.UpdateWhere(
            l => l.Id == line.Id,
            l => l.Refunded += amount
        );
        _clientDc.UpdateWhere(
            c => c.Id == line.Order.ClientId,
            c => c.Credit += line.Product.ExportPrice * amount
        );
        LoadEntries();
    }

    private void OpenRefund(object sender, MouseButtonEventArgs e)
    {
        if ((sender as ListViewItem)?.DataContext is OrderLine line)
        {
            var refund = new Refund(line, RefundEntry);
            refund.ShowDialog();
        }
    }
}