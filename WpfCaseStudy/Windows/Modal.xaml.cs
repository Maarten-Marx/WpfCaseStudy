using System.Windows;

namespace WpfCaseStudy.Windows;

public partial class Modal
{
    public Modal(string title, string content, string buttonContent = "Close")
    {
        InitializeComponent();
        Title = title;
        Content.Text = content;
        CloseButton.Content = buttonContent;
    }

    private void Close(object sender, RoutedEventArgs e)
    {
        Close();
    }
}