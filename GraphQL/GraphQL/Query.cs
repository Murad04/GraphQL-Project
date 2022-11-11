using GraphQL.Data;
using GraphQL.Models;

namespace GraphQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDBContext))]
        public IQueryable<Platform> GetPlatforms([ScopedService] AppDBContext context)
        {
            return context.Platforms;
        }
    }
}
