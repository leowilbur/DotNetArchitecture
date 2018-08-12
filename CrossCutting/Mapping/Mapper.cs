using AgileMapper = AgileObjects.AgileMapper.Mapper;

namespace Solution.CrossCutting.Mapping
{
    public class Mapper : IMapper
    {
        public TSource Clone<TSource>(TSource source)
        {
            return AgileMapper.DeepClone(source);
        }

        public TDestination Map<TDestination>(object source)
        {
            return AgileMapper.Map(source).ToANew<TDestination>();
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return AgileMapper.Map(source).OnTo(destination);
        }
    }
}
