using WpfCaseStudy.Controllers;

namespace WpfCaseStudy.Windows.Pages;

public partial class ProductList
{
    public ProductList()
    {
        InitializeComponent();

        LoadEntries();
    }

    private readonly ProductDataController _dc = new();

    private void LoadEntries()
    {
        Products.ItemsSource = _dc.GetAll();
    }
}