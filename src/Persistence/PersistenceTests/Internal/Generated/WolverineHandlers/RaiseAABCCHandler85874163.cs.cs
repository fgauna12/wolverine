// <auto-generated/>
#pragma warning disable
using Wolverine.Marten.Publishing;

namespace Internal.Generated.WolverineHandlers
{
    // START: RaiseAABCCHandler85874163
    public class RaiseAABCCHandler85874163 : Wolverine.Runtime.Handlers.MessageHandler
    {
        private readonly Wolverine.Marten.Publishing.OutboxedSessionFactory _outboxedSessionFactory;

        public RaiseAABCCHandler85874163(Wolverine.Marten.Publishing.OutboxedSessionFactory outboxedSessionFactory)
        {
            _outboxedSessionFactory = outboxedSessionFactory;
        }



        public override async System.Threading.Tasks.Task HandleAsync(Wolverine.Runtime.MessageContext context, System.Threading.CancellationToken cancellation)
        {
            var raiseAABCC = (PersistenceTests.Marten.RaiseAABCC)context.Envelope.Message;
            await using var documentSession = _outboxedSessionFactory.OpenSession(context);
            var eventStore = documentSession.Events;
            
            // Loading Marten aggregate
            var eventStream = await eventStore.FetchForWriting<PersistenceTests.Marten.LetterAggregate>(raiseAABCC.LetterAggregateId, cancellation).ConfigureAwait(false);

            (var outgoing1, var outgoing2) = PersistenceTests.Marten.RaiseLetterHandler.Handle(raiseAABCC, eventStream.Aggregate);
            
            // Outgoing, cascaded message
            await context.EnqueueCascadingAsync(outgoing1).ConfigureAwait(false);

            if (outgoing2 != null)
            {
                
                // Capturing any possible events returned from the command handlers
                eventStream.AppendMany(outgoing2);

            }

            await documentSession.SaveChangesAsync(cancellation).ConfigureAwait(false);
        }

    }

    // END: RaiseAABCCHandler85874163
    
    
}

