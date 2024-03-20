using ExemploStrategy.Domain.Inputs;
using ExemploStrategy.Domain.Interfaces;
using ExemploStrategy.Domain.Outputs;
using ExemploStrategy.Services.Requests;
using ExemploStrategy.Services.Responses;

namespace ExemploStrategy.Services.Strategies;

public class UpdateFilmeStrategy : BaseStrategy<UpdateFilmeResponse>, IExemploStrategy
{
    private readonly IFilmeService _filmeService;

    public UpdateFilmeStrategy(IFilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    public IExemploStrategyOutput Execute(IExemploStrategyInput request)
    {
        try
        {
            if (request == null)
                return WithError($"{nameof(request)} é requerida");

            if (!(request is UpdateFilmeRequest input))
                return WithError($"{nameof(request)} é requerida");

            _filmeService.Update(input.Filme);
            var response = new UpdateFilmeResponse() { IsSuccess = true };
            return response;
        }
        catch (Exception ex)
        {
            var error = ex.Message;
            return WithError(error);
        }
    }
}
