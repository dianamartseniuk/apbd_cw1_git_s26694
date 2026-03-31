using apbd_cw1_git_s26694;

List<TodoTask> tasks = new()
{
    new TodoTask("Buy groceries"),
    new TodoTask("Finish homework")
};

bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("=== TO DO LIST APPLICATION ===");
    Console.WriteLine("1. Show tasks");
    Console.WriteLine("2. Add task");
    Console.WriteLine("3. Remove task");
    Console.WriteLine("4. Complete task");
    Console.WriteLine("5. Edit task");
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

        case "3":
            RemoveTask(tasks);
            break;

        case "4":
            CompleteTask(tasks);
            break;

        case "5":
            EditTask(tasks);
            break;
        
        default:
        Console.WriteLine("Invalid option. Please choose 0, 1, 2, 3, 4 or 5.");
        break;
    }

    Console.WriteLine();
}

static void ShowTasks(List<TodoTask> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("There are no tasks to display.");
        return;
    }

    Console.WriteLine("Tasks:");

    for (int i = 0; i < tasks.Count; i++)
    {
        string status = tasks[i].IsCompleted ? "[x]" : "[ ]";
        Console.WriteLine($"{i + 1}. {status} {tasks[i].Title}");
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

static void RemoveTask(List<TodoTask> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Task list is empty.");
        return;
    }

    Console.Write("Enter task number to remove: ");
    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int taskNumber))
    {
        Console.WriteLine("Invalid number.");
        return;
    }

    if (taskNumber < 1 || taskNumber > tasks.Count)
    {
        Console.WriteLine("Task number out of range.");
        return;
    }

    tasks.RemoveAt(taskNumber - 1);

    Console.WriteLine("Task removed successfully.");
}

static void CompleteTask(List<TodoTask> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Task list is empty.");
        return;
    }

    Console.Write("Enter task number to mark as completed: ");
    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int taskNumber))
    {
        Console.WriteLine("Invalid number.");
        return;
    }

    if (taskNumber < 1 || taskNumber > tasks.Count)
    {
        Console.WriteLine("Task number out of range.");
        return;
    }

    tasks[taskNumber - 1].IsCompleted = true;
    Console.WriteLine("Task marked as completed.");
}

static void EditTask(List<TodoTask> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Task list is empty.");
        return;
    }

    Console.Write("Enter task number to edit: ");
    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int taskNumber))
    {
        Console.WriteLine("Invalid number.");
        return;
    }

    if (taskNumber < 1 || taskNumber > tasks.Count)
    {
        Console.WriteLine("Task number out of range.");
        return;
    }

    Console.Write("Enter new task title: ");
    string? newTitle = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(newTitle))
    {
        Console.WriteLine("Task title cannot be empty.");
        return;
    }

    tasks[taskNumber - 1].Title = newTitle;
    Console.WriteLine("Task updated.");
}