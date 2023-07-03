FileResult listOfDronesAndLocations = InputReader.ReadFile("Assets/Input.txt");

var trips = new DeliveryScheduler().Execute(listOfDronesAndLocations);

OutputWriter.Write("Assets/Output.txt", trips);