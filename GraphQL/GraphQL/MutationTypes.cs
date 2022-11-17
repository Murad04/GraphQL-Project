using GraphQL.Data;
using GraphQL.GraphQL.Commands;
using GraphQL.GraphQL.Platforms;
using GraphQL.Models;
using HotChocolate.Subscriptions;

namespace GraphQL.GraphQL
{
    public class MutationTypes
    {
        [UseDbContext(typeof(AppDBContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(
            AddPlatformInput input,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken,
            [ScopedService] AppDBContext context)
        {
            var platform = new Platform
            {
                Name = input.Name,
                License = input.LicenseKey
            };
            context.Platforms.Add(platform);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

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
