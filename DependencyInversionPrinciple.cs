/*
Dependency Inversion Principle (DIP):
High-level modules/classes should not depend on low-level modules/classes/details, Both should depend on abstractions.
*/

// ------------------------------ Violation example ------------------------------
public class Car
{
    public void Pickup(int id){}
    public void Dropoff(int id){}
}

public class Order
{
    public int OrderId { get; set; }
    public void Control(Car car){...}
    public void CompleteOrder(Car car, int packageId)
    {
        car.Pickup(packageId);
        Control(car);
        car.Dropoff(packageId); 
        Console.WriteLine("Order completed!");
    } // Order class should be altered in any changes related to the Car class, it also can't change the vehicle type due to it's dependency.
}




// ------------------------------ Fixed example ------------------------------
public interface IVehicle // Interface helps flexibility using abstraction
{
    void Pickup(int id);
    void Dropoff(int id);
}

public class Car : IVehicle
{
    public void Pickup(int id) {}
    public void Dropoff(int id) {}
}

public class Motorcycle : IVehicle
{
    public void Pickup(int id) {}
    public void Dropoff(int id) {}
}

public class Order
{
    public readonly IVehicle _vehicle;

    public Order(IVehicle vehicle)
    {
        _vehicle = vehicle;
    }

    public int OrderId { get; set; }
    
    public void Control()
    {
        // ...
    }

    public void SendOrder(int packageId)
    {
        _vehicle.Pickup(packageId);
        Control();
        _vehicle.Dropoff(packageId);

        Console.WriteLine("Order completed!");
    }
}
