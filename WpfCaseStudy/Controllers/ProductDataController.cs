using WpfCaseStudy.Schema;

namespace WpfCaseStudy.Controllers;

public class ProductDataController: DataController<Product>
{
    public ProductDataController()
    {
        Table = App.Db.Products;
    }
}