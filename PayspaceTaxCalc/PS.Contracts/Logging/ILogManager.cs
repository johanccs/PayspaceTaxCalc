﻿namespace PS.Contracts.Logging
{
    public interface ILogManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
