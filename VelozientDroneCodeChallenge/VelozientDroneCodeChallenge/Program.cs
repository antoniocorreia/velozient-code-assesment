FileResult listOfDronesAndLocations = new InputReader().ReadFile("Assets/Input.txt");

var trips = new DeliveryScheduler().Execute(listOfDronesAndLocations);

new OutputWriter().Write("Assets/Output.txt", trips);