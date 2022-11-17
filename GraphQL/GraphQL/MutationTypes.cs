using GraphQL.Data;
using GraphQL.GraphQL.Platforms;
using GraphQL.Models;

namespace GraphQL.GraphQL
{
    public class MutationTypes
    {
        [UseDbContext(typeof(AppDBContext))]
        public async Task<AddPlatformPayload> AddPlatformAsunc(AddPlatformInput input, [ScopedService] AppDBContext context)
        {
            var platform = new Platform
            {
                Name = input.Name,
                License = input.LicenseKey
            };
            context.Platforms.Add(platform);
            await context.SaveChangesAsync();

            return new AddPlatformPayload(platform);
        }
    }
}
