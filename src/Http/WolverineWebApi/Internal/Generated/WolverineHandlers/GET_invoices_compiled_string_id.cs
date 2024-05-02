// <auto-generated/>
#pragma warning disable
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;
using Wolverine.Marten.Publishing;
using Wolverine.Runtime;

namespace Internal.Generated.WolverineHandlers
{
    // START: GET_invoices_compiled_string_id
    public class GET_invoices_compiled_string_id : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;
        private readonly Wolverine.Marten.Publishing.OutboxedSessionFactory _outboxedSessionFactory;
        private readonly Wolverine.Runtime.IWolverineRuntime _wolverineRuntime;

        public GET_invoices_compiled_string_id(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions, Wolverine.Marten.Publishing.OutboxedSessionFactory outboxedSessionFactory, Wolverine.Runtime.IWolverineRuntime wolverineRuntime) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
            _outboxedSessionFactory = outboxedSessionFactory;
            _wolverineRuntime = wolverineRuntime;
        }



        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            var messageContext = new Wolverine.Runtime.MessageContext(_wolverineRuntime);
            // Building the Marten session
            await using var documentSession = _outboxedSessionFactory.OpenSession(messageContext);
            if (!System.Guid.TryParse((string)httpContext.GetRouteValue("id"), out var id))
            {
                httpContext.Response.StatusCode = 404;
                return;
            }


            
            // The actual HTTP request handler execution
            var compiledStringQuery = WolverineWebApi.Marten.InvoicesEndpoint.GetCompiledString(id);

            var result_of_QueryAsync = await documentSession.QueryAsync<WolverineWebApi.Marten.Invoice, string>(compiledStringQuery, httpContext.RequestAborted).ConfigureAwait(false);
            await Wolverine.Http.HttpHandler.WriteString(httpContext, result_of_QueryAsync.ToString()).ConfigureAwait(false);
        }

    }

    // END: GET_invoices_compiled_string_id
    
    
}
