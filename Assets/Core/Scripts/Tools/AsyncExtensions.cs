using System.Threading;

public static class AsyncExtensions
{
    public static void Kill(this CancellationTokenSource source)
    {
        source.Cancel();
        source.Dispose();
    }
        
    public static CancellationTokenSource Rebirth(this CancellationTokenSource source)
    {
        source.Kill();
        return new CancellationTokenSource();
    }
}