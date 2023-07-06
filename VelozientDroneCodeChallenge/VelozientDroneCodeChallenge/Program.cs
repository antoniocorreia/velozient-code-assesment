using Microsoft.Extensions.DependencyInjection;
using VelozientDroneCodeChallenge.Application.Interfaces;

namespace VelozientDroneCodeChallenge.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        ServiceProvider serviceProvider = GetServiceProvider();

        var inputReader = serviceProvider.GetRequiredService<IInputReader>();
        var deliveryScheduler = serviceProvider.GetRequiredService<IScheduler>();
        var outputWriter = serviceProvider.GetRequiredService<IOutputWriter>();

        FileResult listOfDronesAndLocations = inputReader.ReadFile("Assets/Input.txt");

        var trips = deliveryScheduler.Execute(listOfDronesAndLocations);

        outputWriter.Write("Assets/Output.txt", trips);
    }

    private static ServiceProvider GetServiceProvider()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddScoped<IInputReader, InputReader>()
            .AddScoped<IOutputWriter, OutputWriter>()
            .AddScoped<IScheduler, DeliveryScheduler>();
        
        return serviceCollection.BuildServiceProvider();
    }

}

