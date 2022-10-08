using System.Diagnostics;
using EFCoreOptimizations;
using Microsoft.EntityFrameworkCore;


TooManyQueries();

static void TooManyQueries()
{
    var stopWatch = Stopwatch.StartNew();
    using var db = new CatsDbContext();
    var owners = db.Owners
        .Where(o => o.Name.Contains('1'))
        .Include(o=>o.Cats)
        .ToList();
        
    foreach (var owner in owners)
    {
        var cats = db.Cats
            .Where(c =>c.Name.Contains('1'))
            .ToList();
    }

    Console.WriteLine(stopWatch.Elapsed);
    Console.ReadLine();
}