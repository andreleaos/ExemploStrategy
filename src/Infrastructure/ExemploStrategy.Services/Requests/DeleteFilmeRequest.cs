using ExemploStrategy.Domain.Inputs;

namespace ExemploStrategy.Services.Requests;

public class DeleteFilmeRequest : IExemploStrategyInput
{
    public int Id { get; set; }
}
