using ExemploStrategy.Domain.Dtos;

namespace ExemploStrategy.Services.Responses;

public class GetFilmeByIdResponse : BaseResponseExemploStrategy
{
    public FilmeDto Filme { get; set; }
}
