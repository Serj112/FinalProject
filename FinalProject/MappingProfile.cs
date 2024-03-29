using AutoMapper;
using FinalProject.BLL.RequestModels;
using FinalProject.DLL.Models;

namespace FinalProject
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserRequest>();
            CreateMap<TagRequest, Tag>();
            CreateMap<Tag, TagRequest>();
            CreateMap<CommentRequest, Comment>();
            CreateMap<Comment, Comment>();
            CreateMap<ArticleRequest, Article>();
            CreateMap<Article, ArticleRequest>();
            CreateMap<RoleRequest, Role>();
            CreateMap<Role, RoleRequest>();
        }
    }
}