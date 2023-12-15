using WpfCaseStudy.Controllers;

namespace WpfCaseStudy.Windows.Pages;

public partial class ClientList
{
    public ClientList()
    {
        InitializeComponent();

        LoadEntries();
    }

    private readonly ClientDataController _dc = new();

    private void LoadEntries()
    {
        Clients.ItemsSource = _dc.GetAll();
    }
}