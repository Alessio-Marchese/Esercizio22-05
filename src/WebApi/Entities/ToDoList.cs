﻿using System.Runtime.CompilerServices;

namespace webapi.Entities;

public class ToDoList : AuditableBaseEntity<Guid>
{ 
    public string Title { get; set; }
    public bool IsDone { get; set; }
    public List<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();

    protected ToDoList()
    {

    }

    private ToDoList(Guid id, string title) : base(id)
    {
        Title = title;
    }

    public static ToDoList Create(string title)
    {
        return new ToDoList(Guid.NewGuid(), title);
    }

    public ToDoItem AddToDoItem(string text)
    {
        var toDoItem = ToDoItem.Create(text, this.Id);
        toDoItem.CreatedBy = "Alessio";
        toDoItem.Created = DateTime.UtcNow;
        ToDoItems.Add(toDoItem);
        return toDoItem;
    }
}
