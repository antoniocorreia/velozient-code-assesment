using VelozientDroneCodeChallenge.Domain.Entities;

namespace VelozientDroneCodeChallenge.Application.Interfaces;

public interface IOutputWriter
{
    void Write(string path, List<Trip> trips);
}
