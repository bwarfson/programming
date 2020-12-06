using System;

namespace solid_interface_segregation_principle_ex1
{
    public class MultiFunctionalCar : IVehicle
    {
        public void Drive()
    {
        //actions to start driving car
        Console.WriteLine("Drive a multifunctional car");
    }
    public void Fly()
    {
        //actions to start flying
        Console.WriteLine("Fly a multifunctional car");
    }
    }
}