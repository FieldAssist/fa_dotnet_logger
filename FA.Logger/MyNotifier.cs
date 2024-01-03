using FA.Logger.Providers.Base;

namespace FA.Logger
{
    public class MyNotifier : IMyNotifier
    {
        private readonly INotifyProvider _notifyProvider;

        public MyNotifier(INotifyProvider notifyProvider)
        {
            _notifyProvider = notifyProvider;
        }

        /// <summary>
        /// Notify message
        /// </summary>
        /// <param name="message"></param>
        /// <exception cref="NullReferenceException"></exception>
        public async Task Notify(string message)
        {
            try
            {
                await _notifyProvider.Log(message);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }
    }
}
