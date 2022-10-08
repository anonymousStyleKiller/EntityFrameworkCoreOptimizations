using System.Diagnostics;
using EFCoreOptimizations;


TooManyQueries();

static void TooManyQueries()
{
    var stopWatch = Stopwatch.StartNew();
    using (var db = new CatsDbContext())
    {
        var owners = db.Owners
            .Where(o => o.Name.Contains("1"))
            .ToList();
        foreach (var owner in owners)
        {
            db.Entry(owner)
                .Collection(o=>o.Cats)
                .Load();
            
            var cats = db.Cats
                .Where(o => o.Name.Contains("1"))
                .ToList();
        }

        Console.WriteLine(stopWatch.Elapsed);
    }
}