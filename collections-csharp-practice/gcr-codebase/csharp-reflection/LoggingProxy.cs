using System;
using System.Reflection;

// 1️ Define the interface
interface IGreeting
{
    void SayHello(string name);
}

// 2️ Implement the interface
class GreetingService : IGreeting
{
    public void SayHello(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
}

// 3Create a dynamic logging proxy
class LoggingProxy<T> : DispatchProxy
{
    public T Target { get; set; }

    protected override object Invoke(MethodInfo method, object[] args)
    {
        // Log before method execution
        Console.WriteLine($"[LOG] Calling method: {method.Name}");

        // Call actual method
        return method.Invoke(Target, args);
    }
}

// 4️ Proxy factory
class ProxyFactory
{
    public static T Create<T>(T target)
    {
        object proxy = Create<T, LoggingProxy<T>>();
        ((LoggingProxy<T>)proxy).Target = target;
        return (T)proxy;
    }
}

// 5️Test the proxy
class LoggingProxy
{
    static void Main()
    {
        IGreeting greetingService = new GreetingService();

        // Create proxy
        IGreeting proxy = ProxyFactory.Create<IGreeting>(greetingService);

        // Method call is intercepted
        proxy.SayHello("Aditya");
    }
}
