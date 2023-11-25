using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WpfCaseStudy.Controllers;

public class DataController<T> where T : class
{
    protected DbSet<T> Table = null!;

    public virtual List<T> GetAll() => GetWhere(_ => true);

    public virtual List<T> GetWhere(Func<T, bool> where) => Table
        .Where(where)
        .ToList();

    public virtual void Add(params T[] entries)
    {
        Table.AddRange(entries);
        App.Db.SaveChanges();
    }

    public virtual void UpdateWhere(Func<T, bool> where, Action<T> update)
    {
        var entries = Table.Where(where).ToList();

        foreach (var entry in entries)
        {
            update(entry);
        }

        App.Db.SaveChanges();
    }

    public virtual void UpdateAll(Action<T> update) => UpdateWhere(_ => true, update);
}