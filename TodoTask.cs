namespace apbd_cw1_git_s26694;

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