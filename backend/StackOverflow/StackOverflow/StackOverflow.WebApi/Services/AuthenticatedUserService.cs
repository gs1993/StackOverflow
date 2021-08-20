﻿using Microsoft.AspNetCore.Http;
using StackOverflow.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StackOverflow.WebApi.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
        }

        public string UserId { get; }
    }
}
