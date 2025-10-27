using AutoMapper;

namespace RMS.Common.Helper
{
    public class MapperHelper
    {
        private static IMapper GetMapper<TDestination, TSource>()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<TSource, TDestination>();
                cfg.AddProfile(new MappingProfile());
            });

            return config.CreateMapper();
        }
        public static TDestination Map<TDestination, TSource>(TSource entity)
        {
            var _mapper = GetMapper<TDestination, TSource>();
            return _mapper.Map<TDestination>(entity);
        }
        public static List<TDestination> MapList<TDestination, TSource>(List<TSource> entity)
        {
            var _mapper = GetMapper<TDestination, TSource>();
            return _mapper.Map<List<TSource>, List<TDestination>>(entity);
        }
    }
}
