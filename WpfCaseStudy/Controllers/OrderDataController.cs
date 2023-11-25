using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfCaseStudy.Schema;

namespace WpfCaseStudy.Controllers;

public class OrderDataController: DataController<Order>
{
    public OrderDataController()
    {
        Table = App.Db.Orders;
    }

    public override List<Order> GetWhere(Func<Order, bool> where) => Table
        .Include(o => o.Client)
        .Include(o => o.OrderLines)
        .ThenInclude(l => l.Product)
        .Where(where)
        .ToList();
}