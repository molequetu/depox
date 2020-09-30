using Autofac;
using depox.Core.Entities;
using depox.Core.Events;
using depox.Infrastructure;
using depox.Infrastructure.DomainEvents;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using Xunit;

namespace depox.UnitTests.Core.DomainEvents
{
    public class DomainEventDispatcherShould
    {
        [Fact]
        public void NotReturnAnEmptyListOfAvailableHandlers()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DefaultInfrastructureModule(isDevelopment: true));
            builder.RegisterType<NullLoggerFactory>().As<ILoggerFactory>().SingleInstance();
            builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>)).SingleInstance();
            var container = builder.Build();

            var domainEventDispatcher = new DomainEventDispatcher(container);
            var toDoItemCompletedEvent = new ToDoItemCompletedEvent(new ToDoItem());

            var handlersForEvent = domainEventDispatcher.GetWrappedHandlers(toDoItemCompletedEvent);

            Assert.NotEmpty(handlersForEvent);
        }
    }
}
