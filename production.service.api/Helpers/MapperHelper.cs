using AutoMapper;

namespace production.service.api.Helpers
{
    public static class MapperHelper
    {
        internal static T Map<T, Y>(T Destination, Y Source) where T : class where Y : class
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Y, T>());

            var mapper = config.CreateMapper();

            var returnModel = mapper.Map<Y, T>(Source);

            return returnModel;
        }
    }
}
