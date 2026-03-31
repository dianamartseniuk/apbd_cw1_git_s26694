using ApbdCw1Git;

List<TodoTask> tasks = new()
{
    new TodoTask("Buy groceries"),
    new TodoTask("Finish homework")
};

bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("=== TO DO APP ===");
    Console.WriteLine("1. Show tasks");
    Console.WriteLine("2. Add task");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");

    string? choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            ShowTasks(tasks);
            break;

        case "2":
            AddTask(tasks);
            break;

        case "0":
            isRunning = false;
            break;
        
        default:
        Console.WriteLine("Invalid option. Please choose 0, 1 or 2.");
        break;
    }

    Console.WriteLine();
}

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