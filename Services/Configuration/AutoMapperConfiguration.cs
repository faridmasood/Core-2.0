using AutoMapper;

namespace LearningCore.Services.Configuration
{
    public class AutoMapperConfiguration
    {
        public void ConfigureObjectMappings()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<LearningCore.DataModels.TodoLabel, ServiceModels.LabelServiceModel>()
                    .ForMember(dest=> dest.TodoServiceModels, opt=> opt.MapFrom(src=>src.TodoItems));
                config.CreateMap<LearningCore.DataModels.TodoItem, ServiceModels.TodoServiceModel>()
                    .ForMember(dest => dest.LabelServiceModelId, opt => opt.MapFrom(src => src.LabelId))
                    .ForMember(dest => dest.LabelServiceModel, opt => opt.MapFrom(src => src.Label));


                // reverse mapping
                config.CreateMap<ServiceModels.LabelServiceModel, LearningCore.DataModels.TodoLabel>();
                config.CreateMap<ServiceModels.TodoServiceModel, LearningCore.DataModels.TodoItem>();
            });
        }
    }
}
