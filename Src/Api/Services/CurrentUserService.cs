using System;
using System.Collections.Generic;
using System.Security.Claims;
using Company.Project.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Company.Project.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private IHttpContextAccessor HttpContextAccessor { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
