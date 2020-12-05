using log4net;
using log4net.Config;

namespace Tools
{
    public class Logger
    {
        public static ILog Log { get; private set; }

        static Logger()
        {
            XmlConfigurator.Configure();
            //BasicConfigurator.Configure();
            Log = LogManager.GetLogger("Logger");
        }

        public static void Debug(string message)
        {
            Log.Debug(message);
        }

        public static void Info(string message)
        {
            Log.Info(message);
        }

        public static void Error(string message)
        {
            Log.Error(message);
        }

        public static void Fatal(string message)
        {
            Log.Fatal(message);
        }

        public static void Warning(string message)
        {
            Log.Warn(message);
        }
    }
}