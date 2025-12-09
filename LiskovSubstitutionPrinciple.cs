/* 
Liskov Substitution Principle (LSP): 
A derived class must be usable in place of its parent class 
without causing errors or conflicts.
*/

// ------------------------------ Violation example ------------------------------
public abstract class Task
{
    private int Id { get; set; }
    public string Title { get; set; }

    public virtual void SetDescription(string description)
    {
        sql.SetDesc(description);
    }
}

public class BasicSubTask: Task
{
    private int ParentId { get; set; }
    public override void SetDescription(string description)
    {
        throw new NotSupportedException("BasicSubTasks do not have any description!");
    }
}

BasicSubTask basicSubTask = new BasicSubTask();
basicSubTask.SetDescription("Low priority"); //throws exception; This method should not exist on the base class if not all subclasses support it




// ------------------------------ Fixed example ------------------------------
public interface ISetDescription
{
    void SetDescription(string description);
}

public abstract class Task
{
    private int Id { get; set; }
    public string Title { get; set; }
}

public class BasicSubTask: Task
{
    private int ParentId { get; set; }
}

public class SubDetailedTasks: Task, ISetDescription
{
    private int ParentId { get; set; }
    public void SetDescription(string description)
    {
        sql.SetDesc(description);
    }
}

BasicSubTask basicSubTask = new BasicSubTask();

SubDetailedTasks subDetailedTasks = new SubDetailedTasks();
subDetailedTasks.SetDescription("Low priority"); //no exception




// ------------------------------ Example of a subclass that can substitute for its parent class without exceptions ------------------------------
public class Task
{
    private int Id { get; set; }
    public string Title { get; set; }

    public virtual void SaveTask(string title)
    {
        sql.Save(title);
    }
}

public class SubTask: Task
{
    public string Importance { get; set; }

    public override void SaveTask(string title)
    {
        if (string.IsNullOrEmpty(Importance))
        {
            Importance = "Urgent";
        }

        sql.Save(title, Importance);
    }
}

Task task = new SubTask(); //LSP: SubTask can replace Task
task.SaveTask("Gym");      // Works without errors