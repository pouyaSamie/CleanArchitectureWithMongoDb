using Domain.Entities;
using Domain.Events;
using MediatR;
using Mongo.Repository.Abstraction;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand : IRequest<Guid>
{
    public Guid ListId { get; init; }  

    public string? Title { get; init; }
}

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Guid>
{
    private readonly IRepository<TodoItem> _todoItemRepository;


    public CreateTodoItemCommandHandler(IRepository<TodoItem> todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;

    }

    public async Task<Guid> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            ListId = request.ListId,
            Title = request.Title,
            Done = false
        };

        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _todoItemRepository.Add(entity);
        return entity.Id;
    }
}
