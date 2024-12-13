using MediatR;
using Work360.Services.Leaves.Application;
using Work360.Services.Leaves.Application.Commands;
using Work360.Services.Leaves.Application.Queries;
using Work360.Services.Leaves.Core.Entities;
using Work360.Services.Leaves.Infrastructure;
using Work360.Services.Leaves.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var serviceBusReceiver = app.Services.GetRequiredService<ServiceBusMessageReceiver>();
await serviceBusReceiver.StartAsync();

app.MapGet("/leave", async (ISender mediator, Guid id) => await mediator.Send(new GetLeave(id))).WithOpenApi()
    .WithName("GetLeave");

app.MapGet("/leaves", async (ISender mediator) => 
        await mediator.Send(new GetLeaves()))
    .WithOpenApi()
    .WithName("GetLeaves");

app.MapPost("/leave/add", async (ISender mediator, Employee employee, DateTime startDate, int duration) =>
        await mediator.Send(new CreateApplication(employee, startDate, duration)))
    .WithOpenApi()
    .WithName("AddLeave");

app.Run();

