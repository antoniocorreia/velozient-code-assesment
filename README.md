# velozient-code-assesment

## Solution 
The algorithm schedules the delivery of packages using drones, maximizing the capacity of each drone while minimizing the number of trips required to deliver all packages. 
The locations with lighter packages are prioritized to be delivered first.

A detailed description of DeliveryScheduler:

The [`DeliveryScheduler`](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Application/Services/DeliveryScheduler.cs) class implements the `IScheduler` interface and contains a method called `Execute` that takes a [`FileResult`](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Application/Model/FileResult.cs) object as input and returns a list of `Trip` objects.

- Retrieve the list of drones and locations from the `FileResult` object.
- Sort the drones in descending order based on their maximum weight.
- Sort the locations in ascending order based on their package weight.
- Initialize an empty list of trips to store the trips made by the drones.
- Calculate the total weight of all packages by summing up the package weights of all locations.
- Enter a loop that continues until all packages have been delivered `(totalPackages > 0)`.
- Iterate over each drone in the sorted list of drones.
- Initialize the remaining weight of the drone as its maximum weight.
- Calculate the trip code for the drone by counting the number of existing trips made by the drone.
- Create a new `Trip` object for the drone using the drone and the trip code.
- Iterate over each location in the sorted list of locations where the package weight is greater than 0.
- Check if the package weight of the location is less than or equal to the remaining weight of the drone.
  - If it is, deduct the package weight from the remaining weight of the drone, deduct the package weight from the total packages, add the location to the drone's trip, and mark the location's package weight as 0.
- If the remaining weight of the drone becomes 0, break out of the inner loop since the drone cannot carry any more packages.
- Add the completed drone trip to the list of trips.
- Check if all packages have been delivered (totalPackages <= 0), and if so, break out of the outer loop.
- Return the list of trips.

## Architecture 
I've chosen to use Clean Architecture principles and patterns that aim to achieve separation of concerns, maintainability, and testability. It promotes a modular and decoupled design, allowing for flexibility and easier maintenance in the long term. Here's a brief description of the solution components (See image):
- The Domain project contains the entities Drone, Location, and Trip.
- The Infrastructure project contains all the code related to file manipulation [`InputReader`](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Infrastructure/File/InputReader.cs), [`OutputWriter`](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Infrastructure/File/OutputWriter.cs), and parsing [`DroneParser`](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Infrastructure/File/Parser/DroneParser.cs) and [`LocationParser`](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Infrastructure/File/Parser/DroneParser.cs).
- The Application project contains the business logic, you can check the [exceptions](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Application/Exceptions), [interfaces](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Application/Interfaces), [model](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Application/Model), and [service](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Application/Services).
- The Unit tests project, - using xUnit and Fluent assertions I've created a couple of tests for [Files](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Tests/FileTests), [Parses](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Tests/ParseTests), and [Services](VelozientDroneCodeChallenge/VelozientDroneCodeChallenge.Tests/ServiceTests).

![image](https://github.com/antoniocorreia/velozient-code-assesment/assets/1815134/178641c1-fbef-43b2-9a24-761d9109a081)



## Technical Dependencies and Libraries 
- .NET6
- Visual Studio Community 2022 Version 17.6.1
- Fluent Assertions (https://fluentassertions.com/)
- xUnit (https://xunit.net/)
- Microsoft.Extensions.DependencyInjection


You can run the project using Visual Studio with the above version, make sure your startup project is the ConsoleApp. 
Also, take advantage of the IDE to run all the tests.

![image](https://github.com/antoniocorreia/velozient-code-assesment/assets/1815134/fb0703cb-f4ff-49e9-8cc6-cdf8c9c36e0f)


After running the project the console will display a log of the execution that looks like this

![image](https://github.com/antoniocorreia/velozient-code-assesment/assets/1815134/8bb3e65f-5d78-415c-a2d4-a9abd9e85f59)


and the `Output.txt` file should be located at `VelozientDroneCodeChallenge.ConsoleApp/bin/Debug/net6.0/Assets/output.txt`

![image](https://github.com/antoniocorreia/velozient-code-assesment/assets/1815134/8bd9b4c5-e133-43a4-bcdc-09ab92d7b005)



