using System.Diagnostics;
using System.Linq.Expressions;
using EFCoreOptimizations;


GetData();

static void GetData()
{
    var stopWatch = Stopwatch.StartNew();
    using var db = new CatsDbContext();
    
    Expression<Func<Cat, bool>> predicate = (Cat) => false;
    
    var cats = db.Cats
        .ToList()
        .Where(o => o.Name.Contains('1'))
        .Select(c=>new CatResult
        {
           Name = c.Name,
           Age  = c.Age
        });

    foreach (var cat in cats)
    {
        Console.WriteLine(cat.Name);
    }
    
    Console.WriteLine(stopWatch.Elapsed);
    Console.ReadLine();
}