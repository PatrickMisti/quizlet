namespace quizlet_back.Utilities
{
    public static class CancellationTokenExtention
    {
        public static CancellationToken OneSecond(this CancellationToken token)
        {
            var tokenSource = new CancellationTokenSource();
            tokenSource.CancelAfter(TimeSpan.FromSeconds(1));
            return tokenSource.Token;
        }
    }
}
