using Ninject;
using Rokolabs.Task5.ThreeLayerLibrary.BLL;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.DAO;

namespace Rokolabs.Task5.ThreeLayerLibrary.NinjectConfig
{
    public class Config
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel
                .Bind<IAuthorDao>()
                .To<AuthorDao>()
                .InSingletonScope();
            kernel
                .Bind<IBookDao>()
                .To<BookDao>()
                .InSingletonScope();
            kernel
                .Bind<INewspaperDao>()
                .To<NewspaperDao>()
                .InSingletonScope();
            kernel
                .Bind<INewspaperIssueDao>()
                .To<NewspaperIssueDao>()
                .InSingletonScope();
            kernel
                .Bind<IPatentDao>()
                .To<PatentDao>()
                .InSingletonScope();
            kernel
                .Bind<IPrintEditionDao>()
                .To<PrintEditionDao>()
                .InSingletonScope();
            kernel
                 .Bind<IUserDao>()
                 .To<UserDao>()
                 .InSingletonScope();
            kernel.Bind<IRoleDao>()
                .To<RoleDao>()
                .InSingletonScope();
            kernel
                .Bind<IAuthorLogic>()
                .To<AuthorLogic>()
                .InSingletonScope();
            kernel
                .Bind<IBookLogic>()
                .To<BookLogic>()
                .InSingletonScope();
            kernel
                .Bind<INewspaperLogic>()
                .To<NewspaperLogic>()
                .InSingletonScope();
            kernel
                .Bind<INewspaperIssueLogic>()
                .To<NewspaperIssueLogic>()
                .InSingletonScope();
            kernel
                .Bind<IPatentLogic>()
                .To<PatentLogic>()
                .InSingletonScope();
            kernel
                .Bind<IPrintEditionLogic>()
                .To<PrintEditionLogic>()
                .InSingletonScope();
            kernel
                .Bind<IUserLogic>()
                .To<UserLogic>()
                .InSingletonScope();
            kernel.Bind<IRoleLogic>()
                .To<RoleLogic>()
                .InSingletonScope();
        }
    }
}