using System;

namespace solid_interface_segregation_principle_ex1.after
{
    public class Car : ICar
    {
        public void Drive()
        {
            //actions to drive a car
            Console.WriteLine("Driving a car");
        }
    }
}