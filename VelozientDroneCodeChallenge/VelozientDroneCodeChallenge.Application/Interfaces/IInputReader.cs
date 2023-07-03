using VelozientDroneCodeChallenge.Application.Model;

namespace VelozientDroneCodeChallenge.Application.Interfaces;

public interface IInputReader
{
    FileResult ReadFile(string path);
}
