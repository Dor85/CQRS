using Company.Project.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SystemTask = System.Threading.Tasks.Task;

namespace Company.Project.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private ILogger<TRequest> Logger { get; }
        private ICurrentUserService CurrentUserService { get; }
        public RequestLogger(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            Logger = logger;
            CurrentUserService = currentUserService;
        }
        public SystemTask Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            Logger.LogInformation("Request: {Name} {@UserId} {@Request}", name, CurrentUserService.GetUserId(), request);

            return SystemTask.CompletedTask;
        }
    }
}
