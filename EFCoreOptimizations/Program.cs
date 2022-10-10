using System.Diagnostics;
using EFCoreOptimizations;


var stopWatch = Stopwatch.StartNew();
DeleteSlow();
Console.WriteLine(stopWatch.Elapsed);


var stopWatch2 = Stopwatch.StartNew();
DeleteOptimized();
Console.WriteLine(stopWatch2.Elapsed);

static void GetData()
{
    var stopWatch = Stopwatch.StartNew();
    using (var db = new CatsDbContext())
    {
        var cats = db.Cats
            .Where(o => o.Name.Contains("1"))
            .ToList();
    }

    Console.WriteLine(stopWatch.Elapsed);
    Console.ReadLine();
}

static void DeleteSlow()
{
    using var db = new CatsDbContext();
    var cat = db.Cats.Find(3);
    db.Remove(cat);
    db.SaveChanges();
}

static void DeleteOptimized()
{
    using var db = new CatsDbContext();
    var cat = new Cat{Id = 4};
    db.Remove(cat);
    db.SaveChanges();
}