using ExemploStrategy.Domain.Dtos;

namespace ExemploStrategy.Services.Responses;

public class GetByIdFilmeResponse : BaseResponseExemploStrategy
{
    public FilmeDto Filme { get; set; }
}
