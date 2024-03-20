using ExemploStrategy.Domain.Inputs;
using ExemploStrategy.Domain.Outputs;

namespace ExemploStrategy.Services.Strategies;

public interface IExemploStrategy
{
    IExemploStrategyOutput Execute(IExemploStrategyInput request);
}
