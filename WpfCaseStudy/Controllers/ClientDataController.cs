using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfCaseStudy.Schema;

namespace WpfCaseStudy.Controllers;

public class ClientDataController: DataController<Client>
{
    public ClientDataController()
    {
        Table = App.Db.Clients;
    }

    public override List<Client> GetWhere(Func<Client, bool> where) => Table
        .Include(o => o.Orders)
        .ThenInclude(o => o.OrderLines)
        .ThenInclude(l => l.Product)
        .Where(where)
        .ToList();
}