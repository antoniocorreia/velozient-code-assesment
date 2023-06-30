using VelozientDroneCodeChallenge.Model;
using VelozientDroneCodeChallenge.Services.Delivery;
using VelozientDroneCodeChallenge.Services.File;



var dronesAndLocations = InputReader.ReadFile("filepath");

var result = DeliveryScheduler.Execute(dronesAndLocations);

OutputWriter.Write(result);