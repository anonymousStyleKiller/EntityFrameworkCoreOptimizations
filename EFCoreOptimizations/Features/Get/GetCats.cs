using System.Diagnostics;

namespace EFCoreOptimizations.Features.Get;

public static class GetCats
{
   public static void GetData()
    {
        var stopWatch = Stopwatch.StartNew();
        using (var db = new CatsDbContext())
        {
            var cats = db.Cats
                .Where(o => o.Name.Contains("1"))
                .ToList();
        }

        Console.WriteLine(stopWatch.Elapsed);
    }

}