/* 
Single Responsibility Principle: 
A class or function should have only one responsibility related to its purpose. 
This improves flexibility and makes changes easier to manage.
*/

// Flase Example
public class Actor
{
    //Related
    public bool IsActing()
    {
        //Return if is acting
    }

    //Not Actor's responsibility
    public void SendJobOffer()
    {
        //Send job offer
    }
}

//Fixed Example
public class Actor
{
    public bool IsActing()
    {
        //Return if is acting
    }
}

public class JobService
{
    public void SendJobOffer(Actor actor)
    {
        //Send job offer
    }
}


//False Example
public class TransactionService
{
    private readonly DbContext _dbContext;

    public TransactionService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SaveTransaction(string taHash)
    {
        var transaction = new Transaction(taHash);
        _dbContext.Add(transaction);
        _dbContext.SaveChanges();

        //Not related, should be handled separately
        SendAlert(new Alert { TransactionHash = taHash });
    }

    public void SendAlert(Alert alert)
    {
        //Send alert
    }
}


//Fixed Example
public class TransactionService
{
    private readonly DbContext _dbContext;

    public TransactionService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SaveTransaction(string taHash)
    {
        var transaction = new Transaction(taHash);
        _dbContext.Add(transaction);
        _dbContext.SaveChanges();
    }
}

public class AlertService
{
    public void SendAlert(Alert alert)
    {
        //Send alert
    }
}
