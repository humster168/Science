using System.Configuration;

namespace Science.MainProgram
{
    public static class ConfigSettings
    {
        public static string BlocksFolderPath
            => ConfigurationManager.AppSettings["BlocksFolderPath"];
    }
}