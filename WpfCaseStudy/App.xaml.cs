using System;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WpfCaseStudy.Schema;
using WpfCaseStudy.Windows;

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

    public static void CreateMockData(object _, RoutedEventArgs __)
    {
        if (Db.Products.Any() || Db.Clients.Any())
        {
            new Modal("Error", "The database already contains entries.", "Ok").ShowDialog();
            return;
        }

        Db.Products.AddRange(
            new Product("Aspirin", 100, "123B456", 2.50, 5.00),
            new Product("Ibuprofen", 50, "789C012", 4.75, 8.99),
            new Product("Acetaminophen", 200, "456D789", 3.25, 6.50),
            new Product("Amoxicillin", 75, "012E345", 12.00, 24.99),
            new Product("Lisinopril", 120, "678F901", 6.50, 12.99),
            new Product("Atorvastatin", 90, "234G567", 9.25, 18.50),
            new Product("Metformin", 180, "901H234", 4.75, 9.99),
            new Product("Losartan", 30, "567I890", 11.50, 23.00),
            new Product("Omeprazole", 160, "345J678", 7.25, 14.75),
            new Product("Levothyroxine", 110, "012K345", 10.99, 21.99)
        );

        Db.Clients.AddRange(
            new Client("63421", "MediCare Pharmaceuticals", 800.25,
                "123 Health Street, Suite 456, Pharma City", "info@medicarepharma.com", "555-111-0001"),
            new Client("89502", "HealthGuard Labs", 600.75, "789 Wellness Avenue, Lab Building",
                "contact@healthguardlabs.com", "555-222-0002"),
            new Client("36789", "LifeCure Solutions", 950.50, "456 Cure Lane, Biotech Tower",
                "info@lifecuresolutions.com", "555-333-0003")
        );

        Db.SaveChanges();
    }
}