using Eager;

public class Program
{
    public static void Main()
    {
        var servers = Servers.Singleton;

        Console.WriteLine(servers.AddServer("http://apple.com")); // True
        Console.WriteLine(servers.AddServer("https://explorer.com")); // True
        Console.WriteLine(servers.AddServer("ftp://axe.com")); // False
        Console.WriteLine(servers.AddServer("http://apple.com")); // False (дубликат)

        var httpServers = servers.GetHttpServers();
        var httpsServers = servers.GetHttpsServers();

        Console.WriteLine("HTTP Servers:");
        foreach (var server in httpServers)
        {
            Console.WriteLine(server);
        }

        Console.WriteLine("HTTPS Servers:");
        foreach (var server in httpsServers)
        {
            Console.WriteLine(server);
        }
    }
}