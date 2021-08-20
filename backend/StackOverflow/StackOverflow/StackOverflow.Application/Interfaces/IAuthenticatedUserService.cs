using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
    }
}
