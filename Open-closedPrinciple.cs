/* 
Open-Closed Principle:
A class or function should be open for extension, but closed for modification. 
Abstraction and inheritance allow adding new behavior without changing existing code.
*/

// ------------------------------ Violation Example: Requires modification for each new vehicle type ------------------------------
public class Car
{
    public int Wheels { get; set; }
    public int Passengers { get; set; }
    public bool IsElectrical { get; set; }
}

public class Bus
{
    public int Wheels { get; set; }
    public int Passengers { get; set; }
    public double InsuranceCost { get; set; }
}

public class TotalTransportationCost
{
    public double TotalCost(object[] vehicles)
    {
        double cost = 0;

        foreach (var v in vehicles)
        {
            if (v is Car car)
            {
                if (car.IsElectrical)
                {
                    cost += car.Passengers * 500;
                }
                else
                {
                    cost += car.Passengers * 1000;
                }
            }
            else if (v is Bus bus)
            {
                cost += (bus.Passengers * 200) + bus.InsuranceCost;
            }
        }

        return cost;
    }
}




/* ------------------------------ Fixed Example: Open for extension, closed for modification ------------------------------ */
public abstract class Vehicle
{
    public int Wheels { get; set; }
    public int Passengers { get; set; }

    public abstract double Cost();
}

public class Car : Vehicle
{
    public bool IsElectrical { get; set; }

    public override double Cost()
    {
        return IsElectrical ? Passengers * 500 : Passengers * 1000;
    }
}

public class Bus : Vehicle
{
    public double InsuranceCost { get; set; }

    public override double Cost()
    {
        return (Passengers * 200) + InsuranceCost;
    }
}

public class TransportationCost
{
    public double TotalCost(Vehicle[] vehicles)
    {
        double totalCost = 0;

        foreach (var v in vehicles)
        {
            totalCost += v.Cost();
        }

        return totalCost;
    }
}
