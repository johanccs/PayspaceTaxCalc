using NLog;
using PS.Contracts.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Infrastructure.Logging
{
    public class Logger : ILogManager
    {
        #region Fields

        private static ILogger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Methods

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }

        #endregion
    }
}
