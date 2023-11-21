using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WpfCaseStudy.Windows;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        if (Environment.GetEnvironmentVariable("dev") == "true")
        {
            var mockDataButton = new MenuItem { Header = "Add mock data" };
            mockDataButton.Click += App.CreateMockData;

            Menu.Items.Add(new MenuItem
            {
                Header = "Development",
                Items = { mockDataButton }
            });
        }
    }

    #region HelpMenu

    private void ShowAbout(object _, RoutedEventArgs __)
    {
        new Modal("About", """
                  Made by Maarten Marx
                  Student Nr. r0929437
                  """).ShowDialog();
    }

    private void OpenGitHubRepo(object _, RoutedEventArgs __)
    {
        new Process
        {
            StartInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = "https://github.com/Maarten-Marx/WpfCaseStudy"
            }
        }.Start();
    }

    #endregion
}