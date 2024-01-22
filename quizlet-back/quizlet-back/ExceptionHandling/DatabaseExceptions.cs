namespace quizlet_back.ExceptionHandling
{
    public class DatabaseNotConnectedException: Exception
    {
        public DatabaseNotConnectedException()
        {

        }

        public DatabaseNotConnectedException(string message): base(message) { }

        public DatabaseNotConnectedException(string message, Exception ex): base(message, ex) {}
    }
}
