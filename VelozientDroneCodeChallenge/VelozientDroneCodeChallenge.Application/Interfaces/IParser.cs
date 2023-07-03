namespace VelozientDroneCodeChallenge.Application.Interfaces;

public interface IParser
{
    List<T> Parse<T>(IEnumerable<string> input);
}
