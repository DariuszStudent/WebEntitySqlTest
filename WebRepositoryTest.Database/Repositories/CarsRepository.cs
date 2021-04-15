using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebRepositoryTest.Database
{
    public class CarsRepository : BaseRepository<Car>, ICarsRepository
    {
        protected override DbSet<Car> DbSet => mDbContext.Cars;

        public CarsRepository(WebRepositoryTestDbContext dbContext) : base(dbContext) { }

        public void UpdateCar(Car car)
        {
            var foundCar = DbSet.Where(x => x.Name == car.Name).FirstOrDefault();
            if (foundCar == null)
            {
                DbSet.Add(car);
                SaveChanges();
                return;
            }

            foundCar.Color = car.Color;
        }

        public Car GetSettingByName(string name)
        {
            var foundCar = DbSet.Where(x => x.Name == name).FirstOrDefault();

            return foundCar;
        }

        public void DoSomething()
        {
            var foundSetting = DbSet.Where(x => x.Name == "Porshe").FirstOrDefault();     // wyszukujemy pierwszy 
            var foundSetting2 = DbSet.Where(x => x.CarId > 3 && x.CarId < 6).ToList(); // zakres, ale wyciągamy wszystko
            var foundSetting3 = DbSet.Where(x => x.CarId > 3 && x.CarId < 6).Select(x => x.Name); //zakres, ale bierze tylko Name
            var foundSetting4 = DbSet.Where(x => x.CarId > 3 && x.CarId < 6).Select(x => new
            {
                Name = x.Name,
                Color = x.Color,
                Engine = x.Engine,
                // możemy też tu od razu coś stowrzyć i dodać Predkosc = x.KM + x.jdksajd,

            }); //bierze Name, Color i Engine, nie zwraca CarId, bo po co :)

            var list = foundSetting4.ToList();

            var foundSetting5 = DbSet.Where(x => x.CarId > 3 && x.CarId < 6).OrderBy(x => x.Engine).ToList(); //sortujemy po silniku

            var foundSetting6 = DbSet.Where(x => x.CarId > 3 && x.CarId < 6).FirstOrDefault(); // zwracamy pierwszy obiekt

            var foundSetting7 = DbSet.Where(x => x.CarId > 2 && x.CarId < 5).Take(2); // bierzemy 2 pierwsze obiekty

            var foundSetting8 = DbSet.Where(x => x.CarId > 2 && x.CarId < 5).Skip(1); // omijamy pierwszy element


            var foundSetting9 = DbSet.Where(x => x.CarId > 2 && x.CarId < 5).Skip(1)
                .Select(x => x.Engine)
                .OrderBy(x => x)
                .Take(1)
                .ToList(); // łączymy
        }
    }
}
