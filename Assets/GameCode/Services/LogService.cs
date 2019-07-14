using UnityEngine;

public interface ILogService
{
    void LogMessage(string message);
}

public class LogService : ILogService
{
    public void LogMessage(string message)
    {
        Debug.Log(message);
    }
}