using AutoMapper;

namespace GetHired.Common.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}