using ExemploStrategy.Domain.Outputs;

namespace ExemploStrategy.Services.Strategies;
public class BaseStrategy<T> where T : class, IExemploStrategyOutput
{
    protected virtual T WithSuccess(params string[] info)
    {
        var response = Activator.CreateInstance(typeof(T)) as T;
        response.Info = info;
        response.IsSuccess = true;
        return response;
    }

    protected virtual T WithError(params string[] errors)
    {
        var response = Activator.CreateInstance(typeof(T)) as T;
        response.Errors = errors;
        response.IsSuccess = false;
        return response;
    }
}
