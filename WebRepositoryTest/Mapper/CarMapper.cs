using AutoMapper;
using WebRepositoryTest.Database;

namespace WebRepositoryTest
{
    public class CarMapper
    {
        private IMapper mMapper;

        public CarMapper()
        {
            mMapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Car, CarDataModel>()
                //.ForMember(x => x.NameOfCar, x => x.MapFrom(y => x.Name)) // używamy jeśli mamy dwie różne nazwy w entities i datamodel
                      .ReverseMap();
            }).CreateMapper();
        }

        public CarDataModel Map(Car car)
        {
            return mMapper.Map<CarDataModel>(car);
        }

        public Car Map(CarDataModel carDataModel)
        {
            return mMapper.Map<Car>(carDataModel);
        }
    }
}
