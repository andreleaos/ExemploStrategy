using ExemploStrategy.Domain.Inputs;

namespace ExemploStrategy.Services.Requests;
public class GetFilmeByIdRequest : IExemploStrategyInput
{
    public int Id { get; set; }
}
