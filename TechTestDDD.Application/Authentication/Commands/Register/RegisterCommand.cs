﻿using ErrorOr;
using MediatR;
using TechTestDDD.Application.Authentication.Common;

namespace TechTestDDD.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName, 
        string LastName, 
        string Email, 
        string Password): IRequest<ErrorOr<AuthenticationResult>>;
}
