/*Single Responsibility Principle means a class/function should have only one reponsibility related to it's purpose,
this will lead to better flexibility and management in case the class/function needs to change */

//For example(class):

public class Actor{
    public bool isActing(){} //related
    public sendJobOffer(){} //not related, it should be handled in the job class.
}

//For example(function):

public class TransactionService{
    DbContext _dbContext;
    public TransactionService(DbContext dbContext){
        _dbContext = dbContext;
    }
    public void SaveTransaction(string taHash){
        var transaction = new Transaction(taHash);
        _dbContext.Save(transaction);
        SendAlert(new Alert(){TransactionHash=taHash}); //not related, should be handled in the Alert class.
    }
    public bool SendAlert(Alert alert){
        ShowAlert(alert); 
    }
}