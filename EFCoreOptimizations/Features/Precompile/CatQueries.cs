using Microsoft.EntityFrameworkCore;

namespace EFCoreOptimizations.Features.Precompile;

public class CatQueries
{
    public static Func<CatsDbContext, int, IEnumerable<CatResult>> CatQuery =>
        EF.CompileQuery((CatsDbContext db, int age) => 
        db.Cats.Where(c=>
            c.BirthDate.Year ==2022&&
            c.Age < age
            ).Select(c=>new CatResult
        {
            Age = c.Age,
            Name = c.Name 
        }));
}