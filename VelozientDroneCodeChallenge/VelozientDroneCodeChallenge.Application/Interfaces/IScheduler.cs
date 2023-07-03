using VelozientDroneCodeChallenge.Application.Model;
using VelozientDroneCodeChallenge.Domain.Entities;

namespace VelozientDroneCodeChallenge.Application.Interfaces;

public interface IScheduler
{
    List<Trip> Execute(FileResult dronesAndLocations);
}
