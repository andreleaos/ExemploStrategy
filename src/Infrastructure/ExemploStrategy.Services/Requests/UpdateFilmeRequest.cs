using ExemploStrategy.Domain.Dtos;
using ExemploStrategy.Domain.Inputs;

namespace ExemploStrategy.Services.Requests;
public class UpdateFilmeRequest : IExemploStrategyInput
{
    public FilmeDto Filme { get; set; }

}
