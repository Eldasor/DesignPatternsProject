
namespace BotGUI
{
    [Serializable]
    internal class ImproperValueException : Exception
    {
        // this should be thrown any time a value is assigned to a trade
        // that doesn't make any sense, like negative dollars or over 100%
        // of cash on hand
        public ImproperValueException()
        {
        }

        public ImproperValueException(string? message) : base(message)
        {
        }

        public ImproperValueException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}