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
    }
}
