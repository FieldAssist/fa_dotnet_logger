namespace FA.Logger.Providers.Base
{
    public interface INotifyProvider
    {
        /// <summary>
        /// Creates log and sends to telegram
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Log(string message);
    }
}
