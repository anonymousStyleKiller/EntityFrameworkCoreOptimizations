namespace EFCoreOptimizations.Features.ChangeTracking;

public class Audit
{
    public void ChangeTracking()
    {
        using var db = new CatsDbContext();
        var cat = db.Cats.FirstOrDefault(i=>i.Age == 2022);
        cat.Name = "New Cat";
        db.SaveChanges();
    }
}