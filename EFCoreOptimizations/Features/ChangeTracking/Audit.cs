using Microsoft.EntityFrameworkCore;

namespace EFCoreOptimizations.Features.ChangeTracking;

public static class Audit
{
    public static void NoTracking()
    {
        using var db = new CatsDbContext();
        var cat = db.Cats.AsNoTracking().
            FirstOrDefault();
        cat.Name = "New Cat";
        Console.WriteLine($"{db.ChangeTracker.Entries().Count()}");
        db.SaveChanges();
    }
}