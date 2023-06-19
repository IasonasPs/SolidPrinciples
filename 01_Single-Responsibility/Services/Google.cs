using System.Diagnostics;

public static class Google
{
    public static void Search(string text)
    {
        var openEdge = new ProcessStartInfo
        {
            FileName = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
            Arguments = "http://google.com/search?q=" + text,
            WindowStyle = ProcessWindowStyle.Minimized,
            CreateNoWindow = false,
        };
        var x = Process.Start(openEdge);
    }
}