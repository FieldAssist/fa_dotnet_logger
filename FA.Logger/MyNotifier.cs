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
        public async void Notify(string message)
        {
            try
            {
                if (_notifyProvider != null)
                {
                    await _notifyProvider.Log(message);
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                throw;
            }
        }
    }
}
