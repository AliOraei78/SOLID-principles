/*The Open-Closed Principle means that a class or function can be extended, 
but it must pass unit tests and should not be modified. Abstraction and inheritance can be used to avoid this conflict.*/

//For example:

public class Car 
{
    public int Wheels {get; set;}
    public int Passengers {get; set;}
    public bool IsElectrical {get; set;}
}

public class Bus 
{
    public int Wheels {get; set;}
    public int Passengers {get; set;}
    public double InsuranceCost {get; set;}
}

public class TotalTransportationCost 
{
    public double TotalCost(object[] objects) 
    {
        double cost = 0;
        Car objCar;
        Bus objBus;
        foreach(var object in objects)
        {
            if(object is Car)
            {
                if(object.IsElectrical is true)
                {
                    cost += object.Passengers * 500;
                }
                else
                {
                    cost += object.Passengers * 1000;
                }
            }
            else
            {
                cost += (object.Passengers * 200) + object.InsuranceCost;
            }
        }
        return cost;
    }
} 
/* TransportationCost needs to be modified every time a new vehicle is added to the class, 
because each vehicle might have different variables for calculating the transportation cost. */

public abstract class Vehicle 
{
    public int Wheels {get; set;}
    public int Passengers {get; set;}
    public abstract double Cost();   
}

public class Car : Vehicle
{
    public bool IsElectrical {get; set;}
    public override double Cost()
    {
        if(object.IsElectrical is true)
        {
            return cost = object.Passengers * 500;
        }
        else
        {
            return cost = object.Passengers * 1000;
        }        
    }
}

public class Bus : Vehicle
{
    public double InsuranceCost {get; set;}
    public override double Cost()
    {
        return cost = (object.Passengers * 200) + object.InsuranceCost;      
    } 
}

public class TransportationCost 
{
    public double TotalCost(Vehicle[] objects) 
    {
        double totalCost = 0;
        foreach(var object in objects)
        {
            totalCost += object.cost();
        }
        return totalCost;
    } 
} 

//Abstraction and inheritance are used in order to obey ocp