using Company.Project.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Project.Application.Common.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private Stopwatch Timer { get; }
        private ILogger<TRequest> Logger { get; }
        private ICurrentUserService CurrentUserService { get; }

        public RequestPerformanceBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            Timer = new Stopwatch();
            Logger = logger;
            CurrentUserService = currentUserService;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Timer.Start();

            var response = await next();

            Timer.Stop();

            if (Timer.ElapsedMilliseconds > 500)
            {
                var name = typeof(TRequest).Name;

                Logger.LogWarning("Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
                    name, Timer.ElapsedMilliseconds, CurrentUserService.GetUserId(), request);
            }

            return response;
        }
    }
}
