using System;
using System.Windows;
using System.Windows.Controls;
using WpfCaseStudy.Schema;

namespace WpfCaseStudy.Windows;

public partial class SetAmount
{
    public SetAmount(Product product, Action<int> onSave)
    {
        InitializeComponent();
        Product.Text = $"Product: {product.Name}";
        Stock.Text = $"Stock: {product.Stock}";

        _product = product;
        _onSave = onSave;
    }

    private readonly Product _product;

    private readonly Action<int> _onSave;

    private void ValidateInput(object sender, TextChangedEventArgs e)
    {
        var content = (sender as TextBox)?.Text;
        if (!int.TryParse(content, out var num) || num > _product.Stock || num < 0)
        {
            InvalidInput.Visibility = Visibility.Visible;
        }
        else
        {
            InvalidInput.Visibility = Visibility.Hidden;
        }
    }

    private void Set(object _, RoutedEventArgs __)
    {
        if (int.TryParse(OrderAmount.Text, out var ordered))
        {
            _onSave(ordered);
            Close();
        }
    }
}