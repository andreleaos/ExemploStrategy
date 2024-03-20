using ExemploStrategy.Domain.Inputs;
using ExemploStrategy.Domain.Interfaces;
using ExemploStrategy.Domain.Outputs;
using ExemploStrategy.Services.Requests;
using ExemploStrategy.Services.Responses;

namespace ExemploStrategy.Services.Strategies;
public class CreateFilmeStrategy : BaseStrategy<CreateFilmeResponse>, IExemploStrategy
{
    private readonly IFilmeService _filmeService;

    public CreateFilmeStrategy(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    public IExemploStrategyOutput Execute(IExemploStrategyInput request)
    {
        try
        {
            if (request == null)
                return WithError($"{nameof(request)} é requerida");

            if (!(request is CreateFilmeRequest input))
                return WithError($"{nameof(request)} é requerida");

            _filmeService.Create(input.Filme);
            var response = new CreateFilmeResponse() { IsSuccess = true };
            return response;
        }
        catch (Exception ex)
        {
            var error = ex.Message;
            return WithError(error);
        }
    }
}
