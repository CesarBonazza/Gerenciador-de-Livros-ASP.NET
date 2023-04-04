using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class LivroService : ILivroService
    {
        private readonly AtDbContext _atDbContext;
        public LivroService(AtDbContext atDbContext)
        {
            _atDbContext = atDbContext;
        }

        public void AdicionarLivro(Livro livro)
        {
            _atDbContext.Livro.Add(livro);
            _atDbContext.SaveChanges();
        }

        public void EditarLivro(Livro livro)
        {
            _atDbContext.Livro.Update(livro);
            _atDbContext.SaveChanges();
        }

        public void ExcluirLivro(int Id)
        {
            var livro = _atDbContext.Livro.First(L => L.Id == Id);
            _atDbContext.Livro.Remove(livro);
            _atDbContext.SaveChanges();
        }

        public IList<Livro> GetAll()
        {
            return _atDbContext.Livro.ToList();
        }

        public Livro GetLivro(int Id)
        {
            return _atDbContext.Livro.First(Livro => Livro.Id == Id);
        }
    }
}
