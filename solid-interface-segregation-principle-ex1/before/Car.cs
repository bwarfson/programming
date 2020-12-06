namespace solid_interface_segregation_principle_ex1
{
    public class Car : IVehicle
    {
        public void Drive()
        {
            //actions to drive a car
            Console.WriteLine("Driving a car");
        }
        public void Fly()
        {
            throw new NotImplementedException();
        }
    }
}