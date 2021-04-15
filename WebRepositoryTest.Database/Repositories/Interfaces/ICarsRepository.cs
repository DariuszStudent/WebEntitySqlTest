using System.Collections.Generic;

namespace WebRepositoryTest.Database
{
    public interface ICarsRepository
    {
        List<Car> GetAll();
        void UpdateCar(Car car);
        Car GetSettingByName(string name);
        void SaveChanges();
        void DoSomething();
    }
}
