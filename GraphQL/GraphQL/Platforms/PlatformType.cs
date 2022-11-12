using GraphQL.Data;
using GraphQL.Models;

namespace GraphQL.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has a CLI.");

            descriptor.Field(p => p.License).Ignore();

            descriptor
                .Field(p => p.Command)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDBContext>()
                .Description("This is the list of available commands for this platform");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDBContext context)
            {
                return context.Commands.Where(p => p.PlatformID == platform.ID);
            }
        }
    }
}
