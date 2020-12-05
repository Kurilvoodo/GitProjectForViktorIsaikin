using AutoMapper;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Authors;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.BasePrintEditions;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Books;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Login;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.NewspaperIssues;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Newspapers;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Patents;
using Rokolabs.Task5.ThreeLayerLibrary.WebUI.Models.ViewModels.Users;

namespace Rokolabs.Task5.ThreeLayerLibrary.WebUI.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Config { get; private set; }


        public static void RegisterMaps()
        {
            Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, ReadUserVM>()
                .ForMember(dest => dest.Role, src => src.Ignore());
                cfg.CreateMap<ReadUserVM, User>()
                    .ForMember(dest => dest.Password, src => src.Ignore())
                    .ForMember(dest => dest.RoleId, src => src.Ignore());
                cfg.CreateMap<User, HashedLoginVM>();
                cfg.CreateMap<HashedLoginVM, User>()
                .ForMember(dest => dest.Id, src => src.Ignore())
               .ForMember(dest => dest.RoleId, src => src.Ignore());

                cfg.CreateMap<PrintEdition, ReadBasePrintEditionVM>()
                .Include<Book, ReadBookVM>()
                .Include<Newspaper, ReadNewspaperVM>()
                .Include<Patent, ReadPatentVM>();

                cfg.CreateMap<Book, ReadBookVM>()
                .ForMember(dest => dest.IdAuthor, src => src.Ignore());
                cfg.CreateMap<CreateBookVM, Book>()
                .ForMember(dest => dest.Id, src => src.Ignore())
                .ForMember(dest => dest.AuthorsId, src => src.Ignore());

                cfg.CreateMap<EditBookVM, Book>();

                cfg.CreateMap<Book, EditBookVM>()
                .ForMember(dest => dest.IdAuthor, src => src.Ignore());

                cfg.CreateMap<Newspaper, ReadNewspaperVM>();
                cfg.CreateMap<CreateNewspaperVM, Newspaper>()
                    .ForMember(dest => dest.Id, src => src.Ignore())
                    .ForMember(dest => dest.NewspaperIssues, src => src.Ignore())
                    .ForMember(dest => dest.currentNewspaperIssue, src => src.Ignore());

                cfg.CreateMap<NewspaperIssue, ReadNewspaperIssueVM>();

                cfg.CreateMap<CreateNewspaperIssueVM, NewspaperIssue>()
                    .ForMember(dest => dest.Id, src => src.Ignore());

                cfg.CreateMap<EditNewspaperIssueVM, NewspaperIssue>()
                    .ForMember(dest => dest.NewspaperId, src => src.Ignore());
                cfg.CreateMap<NewspaperIssue, EditNewspaperIssueVM>();

                cfg.CreateMap<Patent, ReadPatentVM>();
                cfg.CreateMap<CreatePatentVM, Patent>()
                    .ForMember(dest => dest.Id, src => src.Ignore())
                    .ForMember(dest => dest.AuthorsId, src => src.Ignore());

                cfg.CreateMap<EditPatentVM, Patent>();

                cfg.CreateMap<Patent, EditPatentVM>();
                cfg.CreateMap<ReadAuthorVM, Author>();
                cfg.CreateMap<Author, ReadAuthorVM>()
                .ForMember(dest => dest.FullName, src => src.Ignore());
                cfg.CreateMap<CreateAuthorVM, Author>()
                .ForMember(dest => dest.Id, src => src.Ignore());
                cfg.CreateMap<Author, CreateAuthorVM>();

                cfg.CreateMap<EditUserVM, User>()
                .ForMember(dest => dest.Password, src => src.Ignore())
                .ForMember(dest => dest.RoleId, src => src.Ignore());
                cfg.CreateMap<User, EditUserVM>()
                .ForMember(dest => dest.Role, src => src.Ignore());



            });
            Config.AssertConfigurationIsValid();

        }
    }
}