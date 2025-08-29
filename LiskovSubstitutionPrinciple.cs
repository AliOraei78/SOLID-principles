/* 
Liskov Substitution Principle: 
A derived class must be usable in place of its parent class 
without causing errors or conflicts.
*/

public abstract class Task
{
    public int Id { get; set; }
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
