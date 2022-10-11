namespace EFCoreOptimizations.Features.Delete;

public static class Delete
{
    
   public static void DeleteSlow()
    {
        using var db = new CatsDbContext();
        var cat = db.Cats.Find(3);
        db.Remove(cat);
        db.SaveChanges();
    }

   public  static void DeleteOptimized()
    {
        using var db = new CatsDbContext();
        var cat = new Cat{Id = 4};
        db.Remove(cat);
        db.SaveChanges();
    }
}