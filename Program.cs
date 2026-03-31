using ApbdCw1Git;

List<TodoTask> tasks = new()
{
    new TodoTask("Buy groceries"),
    new TodoTask("Finish homework")
};

ShowTasks(tasks);
AddTask(tasks);
ShowTasks(tasks);

static void ShowTasks(List<TodoTask> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Task list is empty.");
        return;
    }

    Console.WriteLine("Tasks:");

    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {tasks[i].Title}");
    }
}

static void AddTask(List<TodoTask> tasks)
{
    Console.Write("Enter task title: ");
    string? title = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(title))
    {
        Console.WriteLine("Task title cannot be empty.");
        return;
    }

    tasks.Add(new TodoTask(title));
    Console.WriteLine("Task added.");
}