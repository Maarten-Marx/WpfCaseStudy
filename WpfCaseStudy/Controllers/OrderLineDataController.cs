using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfCaseStudy.Schema;

namespace WpfCaseStudy.Controllers;

public class OrderLineDataController: DataController<OrderLine>
{
    public OrderLineDataController()
    {
        Table = App.Db.OrderLines;
    }

    public override List<OrderLine> GetWhere(Func<OrderLine, bool> where) => Table
        .Include(l => l.Order)
        .Include(l => l.Product)
        .Where(where)
        .ToList();
}