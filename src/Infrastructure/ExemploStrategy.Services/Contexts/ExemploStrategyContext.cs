using ExemploStrategy.Domain.Inputs;
using ExemploStrategy.Domain.Outputs;
using ExemploStrategy.Services.Strategies;

namespace ExemploStrategy.Services.Contexts;

public class ExemploStrategyContext
{
    private IExemploStrategy _strategy;
    private readonly Dictionary<Type, IExemploStrategy> _strategies;

    public ExemploStrategyContext(Dictionary<Type, IExemploStrategy> strategies)
    {
        _strategies = strategies;
    }

    public ExemploStrategyContext(IExemploStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IExemploStrategy strategy)
    {
        _strategy = strategy;   
    }

    public IExemploStrategyOutput Execute(IExemploStrategyInput request)
    {
        var result = GetStrategy(request).Execute(request);
        return result;
    }

    private IExemploStrategy GetStrategy(IExemploStrategyInput request)
    {
        if (_strategy != null)
            return _strategy;

        if (!_strategies.ContainsKey(request?.GetType()))
            throw new ArgumentException($"Estratégia não encontrada para o tipo {request.GetType()}");

        return _strategies[request.GetType()];
    }
}
