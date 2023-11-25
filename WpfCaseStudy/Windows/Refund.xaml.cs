using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfCaseStudy.Schema;

namespace WpfCaseStudy.Windows;

public partial class Refund
{
    public Refund(OrderLine line, Action<OrderLine, int> onRefund)
    {
        InitializeComponent();
        Product.Text = $"Product: {line.Product.Name}";
        Ordered.Text = $"Ordered: {line.Amount.ToString()}";
        Refunded.Text = $"Refunded: {line.Refunded.ToString()}";

        _line = line;
        _onRefund = onRefund;
    }

    private readonly OrderLine _line;
    private readonly Action<OrderLine, int> _onRefund;

    private void ValidateInput(object sender, TextChangedEventArgs _)
    {
        var content = (sender as TextBox)?.Text;
        if (!int.TryParse(content, out var num) || num > _line.Amount - _line.Refunded || num <= 0)
        {
            InvalidInput.Visibility = Visibility.Visible;
            SaveRefund.IsEnabled = false;
        }
        else
        {
            InvalidInput.Visibility = Visibility.Hidden;
            SaveRefund.IsEnabled = true;
        }
    }

    private void RefundOrder(object _, RoutedEventArgs __)
    {
        if (int.TryParse(RefundAmount.Text, out var refunded) &&
            refunded <= _line.Amount - _line.Refunded &&
            refunded > 0)
        {
            _onRefund(_line, refunded);
            Close();
        }
    }

    private void Cancel(object _, RoutedEventArgs __)
    {
        Close();
    }
}