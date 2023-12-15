using System.Windows;

namespace WpfCaseStudy.Windows.Pages;

public partial class HomePage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private void OpenOrdersList(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new OrderList());
    }

    private void OpenClientList(object sender, RoutedEventArgs e)
    {
        NavigationService?.Navigate(new ClientList());
    }
}