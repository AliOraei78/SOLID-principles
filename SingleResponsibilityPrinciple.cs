/* 
Single Responsibility Principle (SRP): 
A class or function should have only one responsibility related to its purpose. 
A class should only change if the changes relate to its single responsibility
This improves flexibility and makes changes easier to manage.
*/

// ------------------------------ Violation Example ------------------------------
public class Actor
{
    // Related
    public bool IsActing()
    {
        // Return if is acting
        return true;
    }

    // Not Actor's responsibility
    public void SendJobOffer()
    {
        //Send job offer
    }
}




// ------------------------------ Fixed Example ------------------------------
public class Actor
{
    public bool IsActing()
    {
        //Return if is acting
        return true;
    }
}

public class JobService
{
    public void SendJobOffer(Actor actor)
    {
        // Send job offer
    }
}




// ------------------------------ Violation Example ------------------------------
public class TransactionService
{
    private readonly DbContext _dbContext;

    public TransactionService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SaveTransaction(string transactionHash)
    {
        var transaction = new Transaction(transactionHash);
        _dbContext.Add(transaction);
        _dbContext.SaveChanges();

        // Not related, should be handled separately
        SendAlert(new Alert { TransactionHash = transactionHash });
    }

    public void SendAlert(Alert alert)
    {
        // Send alert
    }
}




// ------------------------------ Fixed Example ------------------------------
public class TransactionService
{
    private readonly DbContext _dbContext;

    public TransactionService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SaveTransaction(string transactionHash)
    {
        var transaction = new Transaction(transactionHash);
        _dbContext.Add(transaction);
        _dbContext.SaveChanges();
    }
}

public class AlertService
{
    public void SendAlert(Alert alert)
    {
        // Send alert
    }
}
