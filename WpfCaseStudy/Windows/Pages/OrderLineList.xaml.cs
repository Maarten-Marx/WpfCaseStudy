using System.Collections.Generic;
using System.Windows;
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

    private readonly OrderLineDataController _dc = new();

    private void LoadEntries()
    {
        OrderLines.ItemsSource = _dc.GetWhere(l => l.OrderId == _orderId);
    }
}