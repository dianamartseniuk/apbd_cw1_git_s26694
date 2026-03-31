namespace ApbdCw1Git;

public class TodoTask
{
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    public TodoTask(string title)
    {
        Title = title;
        IsCompleted = false;
    }
}