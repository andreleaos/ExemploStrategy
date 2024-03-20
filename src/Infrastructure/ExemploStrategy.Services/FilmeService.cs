using ExemploStrategy.Domain.Conversors;
using ExemploStrategy.Domain.Dtos;
using ExemploStrategy.Domain.Interfaces;
using ExemploStrategy.Infrastructure.Repositories;

namespace ExemploStrategy.Services;
public class FilmeService : IFilmeService
{
    private readonly IFilmeRepository _repository;

    public FilmeService(IFilmeRepository repository)
    {
        _repository = repository;
    }

    public void Create(FilmeDto dto)
    {
        try
        {
            var entity = FilmeConversor.ConvertToEntity(dto);
            _repository.Create(entity);
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public void Delete(int id)
    {
        try
        {
            _repository.Delete(id);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<FilmeDto> GetAll()
    {
        try
        {
            var data = _repository.GetAll();
            var result = FilmeConversor.ConvertCollectionToDto(data);
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public FilmeDto GetById(int id)
    {
        try
        {
            var entity = _repository.GetById(id);
            var result = FilmeConversor.ConvertToDto(entity);
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Update(FilmeDto dto)
    {
        try
        {
            var entity = FilmeConversor.ConvertToEntity(dto);
            _repository.Update(entity);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
