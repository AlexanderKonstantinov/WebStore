using System;
using NLog;
using NLog.Targets;

namespace WebStore.Helpers
{
    public enum DatabaseObjectError
    {
        NotFound,
        AlreadyExist,
        Unknown
    }
    /// <summary>
    /// Use for logging repository errors
    /// </summary>
    public static class Logger
    {
        private static readonly NLog.Logger logger;

        static Logger()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new FileTarget
            {
                FileName = "log.txt",
                Name = "logfile"
            };

            config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Debug, logfile));

            NLog.LogManager.Configuration = config;

            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Error logging to log.txt
        /// </summary>
        /// <param name="obj">Object that caused the error (Method ToString of object need override)</param>
        /// <param name="errorType">Error type</param>
        public static void Logging(object obj, DatabaseObjectError errorType = DatabaseObjectError.Unknown)
        {
            var error = 
                  errorType == DatabaseObjectError.NotFound ? "Не найден"
                : errorType == DatabaseObjectError.AlreadyExist ? "Уже существует"
                : "Неизвестная ошибка";

            //Потом добавлю рефлексию, если такое логирование вообще одобрят
            //не очень нравится как всё это выглядит
            logger.Debug($"{Environment.NewLine}***{Environment.NewLine}Type: {obj.GetType()}\tObject: {obj}\tError: {error}{Environment.NewLine}***{Environment.NewLine}{Environment.NewLine}");
        }
    }
}
