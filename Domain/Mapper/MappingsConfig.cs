using AutoMapper;

namespace Domain.Mapper
{
    public static class MappingsConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new ExampleClassProfile());
                c.AddProfile(new InterestRateProfile());
            });
            return config;
        }
    }
}
