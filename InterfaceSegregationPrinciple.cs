/*
Interface Segregation Principle (ISP):
Clients should not be forced to depend on interfaces they do not use.
Interfaces should be small, focused and specific to the needs of the client classes
*/

// ------------------------------ Violation example ------------------------------
public interface IWorker
{
      void Feel();
      void Eat();
      void Run();
      void Analyze();
}

public class Human: IWorker
{
    public void Feel(){...}
    public void Eat(){...}
    public void Run(){...}
    public void Analyze(){...}
}

public class Robot: IWorker
{
    public void Feel()
    {
        throw new Exception("robots don't feel"); // Robot class implemented methods it doesn't use
    }
    public void Eat()
    {
        throw new Exception("robots don't eat"); // these methods should be defined in another interface
    }
    public void Run(){...}
    public void Analyze(){...}
}




// ------------------------------ Fixed example ------------------------------
public interface IWorker
{
      void Run();
      void Analyze();
}

public interface IAlive
{
      void Feel();
      void Eat();
}

public class Human: IWorker, IAlive
{
    public void Feel(){...}
    public void Eat(){...}
    public void Run(){...}
    public void Analyze(){...}
}

public class Robot: IWorker
{
    //Robot class implemented the methods it uses
    public void Run(){...}
    public void Analyze(){...}
}