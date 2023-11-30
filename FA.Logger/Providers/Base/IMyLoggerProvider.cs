namespace FA.Logger.Providers.Base
{
    public interface IMyLoggerProvider
    {
        /// <summary>
        /// Logs to discord
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Log(string message);
    }
}
