using GraphQL.Data;
using GraphQL.Models;

namespace GraphQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command");

            descriptor
                .Field(c => c.Platform)
                .ResolveWith<Resolver>(c => c.GetPlatorm(default!, default!))
                .UseDbContext<AppDBContext>()
                .Description("This is the platform to which the command belongs");
        }

        private class Resolver
        {
            public Platform? GetPlatorm(Command command, [ScopedService] AppDBContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.ID == command.PlatformID);
            }
        }

    }
}
