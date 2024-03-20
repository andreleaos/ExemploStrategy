using ExemploStrategy.Domain.Dtos;
using ExemploStrategy.Domain.Inputs;

namespace ExemploStrategy.Services.Requests;
public class CreateFilmeRequest : IExemploStrategyInput
{
    public FilmeDto Filme { get; set; }
}
