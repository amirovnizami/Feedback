using FeedbackSystem.Core.BranchAggregaet.Specifications;
using FeedbackSystem.Core.CategoryAggregate;
using FeedbackSystem.Core.CommentAggregate;
using FeedbackSystem.Core.FeedbackAgrregate;
using FeedbackSystem.Core.StatusAgrregate;
using FeedbackSystem.UseCases.Branches;
using FeedbackSystem.UseCases.Categories;
using FeedbackSystem.UseCases.Comments;
using FeedbackSystem.UseCases.Feedbacks;
using FeedbackSystem.UseCases.Statuses;

namespace FeedbackSystem.Web.Configurations;

public class MapperConfig
{
  public static void ConfigureMapper(IServiceCollection services)
  {
    services.AddAutoMapper(cfg =>
    {
      cfg.CreateMap<Branch, BranchDto>()
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));

      cfg.CreateMap<Category, CategoryDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

      cfg.CreateMap<Status, StatusDto>()
        .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.StatusName));
      cfg.CreateMap<Feedback, FeedbackDto>()
        .ForMember(dest => dest.firstName, opt => opt.MapFrom(src => src.FirstName))
        .ForMember(dest => dest.lastName, opt => opt.MapFrom(src => src.LastName))
        .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
        .ForMember(dest => dest.branchId, opt => opt.MapFrom(src => src.BranchId));
      cfg.CreateMap<Comment, CommentDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text));
    });
  }
}
