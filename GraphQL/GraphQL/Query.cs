using GraphQL.Data;
using GraphQL.Models;

namespace GraphQL.GraphQL
{
    public class Query
    {
        public IQueryable<Platform> GetPlatforms([Service] AppDBContext context)
        {
            return context.Platforms;
        }
    }
}
