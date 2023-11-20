using System;
using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WpfCaseStudy.Schema;

namespace WpfCaseStudy;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var facade = new DatabaseFacade(new DbData());
        facade.EnsureCreated();
    }

    private static readonly Lazy<DbData> DbConnection = new();

    public static DbData Db => DbConnection.Value;
}