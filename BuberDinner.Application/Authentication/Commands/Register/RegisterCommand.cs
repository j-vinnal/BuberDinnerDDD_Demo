using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

// Data we need : what command returns
public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password)
    : IRequest<ErrorOr<AuthenticationResult>>;