using GraphQL.Data;
using GraphQL.Models;

namespace GraphQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDBContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatforms([ScopedService] AppDBContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDBContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommands([ScopedService] AppDBContext context)
        {
            return context.Commands;
        }
    }
}
