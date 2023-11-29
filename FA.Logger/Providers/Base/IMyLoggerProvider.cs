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

        /// <summary>
        /// Saves log
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SaveLog(string message);
    }
}
