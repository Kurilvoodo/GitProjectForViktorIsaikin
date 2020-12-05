using Ninject;

namespace Rokolabs.Task5.ThreeLayerLibrary.Ioc
{
    public class NinjaDependencryResolver
    {
        private static NinjectBindings _bindings = new NinjectBindings();
        public static StandardKernel Kernel = new StandardKernel(_bindings);
    }
}