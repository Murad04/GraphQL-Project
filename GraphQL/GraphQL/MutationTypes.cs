using GraphQL.Data;
using GraphQL.GraphQL.Commands;
using GraphQL.GraphQL.Platforms;
using GraphQL.Models;

namespace GraphQL.GraphQL
{
    public class MutationTypes
    {
        [UseDbContext(typeof(AppDBContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, [ScopedService] AppDBContext context)
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

        [UseDbContext(typeof(AppDBContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, [ScopedService] AppDBContext context)
        {
            var command = new Command
            {
                HowTo = input.howTo,
                CommandLine = input.commandLine,
                PlatformID = input.platformID,
            };

            context.Commands.Add(command);
            await context.SaveChangesAsync();

            return new AddCommandPayload(command);
        }

    }
}
