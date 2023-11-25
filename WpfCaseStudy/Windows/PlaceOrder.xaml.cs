using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfCaseStudy.Controllers;
using WpfCaseStudy.Schema;

namespace WpfCaseStudy.Windows;

public partial class PlaceOrder
{
    public PlaceOrder(Action<Client, List<OrderLine>> onSave)
    {
        InitializeComponent();

        _onSave = onSave;

        LoadEntries();
        Clients.SelectedIndex = 0;
    }

    private readonly Action<Client, List<OrderLine>> _onSave;

    private readonly ClientDataController _clientDc = new();

    private readonly ProductDataController _productDc = new();

    private readonly ObservableCollection<OrderLine> _orderedProducts = new();

    private void LoadEntries()
    {
        Clients.ItemsSource = _clientDc.GetAll();
        Products.ItemsSource = _productDc
            .GetWhere(p => { return _orderedProducts.All(l => l.ProductId != p.Id); })
            .OrderBy(p => p.Name);
        OrderLines.ItemsSource = _orderedProducts.OrderBy(l => l.Product.Name);
    }

    private void SetAmount(object sender, MouseButtonEventArgs _)
    {
        if ((sender as ListViewItem)?.DataContext is Product product)
        {
            var setAmount = new SetAmount(product, amount =>
            {
                if (amount > 0)
                {
                    var line = new OrderLine(0, product.Id, amount) { Product = product };
                    _orderedProducts.Add(line);
                }

                LoadEntries();
            });

            setAmount.ShowDialog();
        }
    }

    private void ChangeAmount(object sender, MouseButtonEventArgs _)
    {
        if ((sender as ListViewItem)?.DataContext is OrderLine line)
        {
            var setAmount = new SetAmount(line.Product, amount =>
            {
                _orderedProducts.Remove(line);
                if (amount > 0)
                {
                    line.Amount = amount;
                    _orderedProducts.Add(line);
                }

                LoadEntries();
            });

            setAmount.ShowDialog();
        }
    }

    private void Save(object _, RoutedEventArgs __)
    {
        if (Clients.SelectedItem is Client client && _orderedProducts.Any())
        {
            _onSave(client, _orderedProducts.ToList());
            Close();
        }
    }
}