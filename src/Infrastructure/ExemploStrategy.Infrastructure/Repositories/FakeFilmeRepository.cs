using ExemploStrategy.Domain.Entities;
using ExemploStrategy.Domain.Interfaces;

namespace ExemploStrategy.Infrastructure.Repositories;
public class FakeFilmeRepository : IFilmeRepository
{
    private static List<Filme> _filmes = null;

    public FakeFilmeRepository()
    {
        _filmes = new List<Filme>();
        LoadData();
    }

    private void LoadData()
    {
        _filmes.Add(new Filme { Id = 1, Nome = "Matrix", Genero = "Ação", Ano = 1999 });
        _filmes.Add(new Filme { Id = 2, Nome = "Vingadores", Genero = "Ação", Ano = 2014 });
        _filmes.Add(new Filme { Id = 3, Nome = "Dr.Estranho", Genero = "Ação", Ano = 2016 });
        _filmes.Add(new Filme { Id = 4, Nome = "Liga da Justiça", Genero = "Ação", Ano = 2017 });
        _filmes.Add(new Filme { Id = 5, Nome = "Batman Vs Superman", Genero = "Ação", Ano = 2015 });
    }

    public void Create(Filme entity)
    {
        _filmes.Add(entity);
    }

    public void Delete(int id)
    {
        var filme = GetById(id);
        if (filme != null)
            _filmes.Remove(filme);
    }

    public List<Filme> GetAll()
    {
       var result = _filmes.OrderBy(p => p.Nome).ToList();
        return result;
    }

    public Filme GetById(int id)
    {
        var result =_filmes.FirstOrDefault(p => p.Id == id);
        return result;
    }

    public void Update(Filme entity)
    {
        var itemPesquisa = GetById(entity.Id);
        if (itemPesquisa != null)
        {
            _filmes.Remove(itemPesquisa);
            _filmes.Add(entity);
        }
    }
}
