using Ninject.Modules;
using Rokolabs.Task5.ThreeLayerLibrary.BLL;
using Rokolabs.Task5.ThreeLayerLibrary.BLL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.DAO;

namespace Rokolabs.Task5.ThreeLayerLibrary.Ioc
{
    internal class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            #region Dao bindings

            Bind<IBookDao>().To<BookDao>();
            Bind<IPatentDao>().To<PatentDao>();
            Bind<INewspaperDao>().To<NewspaperDao>();
            Bind<IAuthorDao>().To<AuthorDao>();
            Bind<IPrintEditionDao>().To<PrintEditionDao>();
            Bind<INewspaperIssueDao>().To<NewspaperIssueDao>();
            Bind<IUserDao>().To<UserDao>();
            Bind<IRoleDao>().To<RoleDao>();

            #endregion Dao bindings

            #region Logic Bindings

            Bind<IBookLogic>().To<BookLogic>();
            Bind<IPatentLogic>().To<PatentLogic>();
            Bind<INewspaperLogic>().To<NewspaperLogic>();
            Bind<IAuthorLogic>().To<AuthorLogic>();
            Bind<IPrintEditionLogic>().To<PrintEditionLogic>();
            Bind<INewspaperIssueLogic>().To<NewspaperIssueLogic>();
            Bind<IUserLogic>().To<UserLogic>();
            Bind<IRoleLogic>().To<RoleLogic>();

            #endregion Logic Bindings
        }
    }
}