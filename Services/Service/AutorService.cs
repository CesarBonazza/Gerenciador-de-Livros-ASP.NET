using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class AutorService : IAutorService
    {
        private readonly AtDbContext _atDbContext;
        public AutorService(AtDbContext atDbContext)
        {
            _atDbContext = atDbContext;
        }
        public IList<Autor> GetAll() 
        {
            return _atDbContext.Autor.ToList();
        }
        public void AdicionarAutor(Autor autor)
        {
            _atDbContext.Autor.Add(autor);
            _atDbContext.SaveChanges();
        }
        public void ExcluirAutor(int Id)
        {
            var autor = _atDbContext.Autor.First(A => A.Id == Id);
            _atDbContext.Autor.Remove(autor);
            _atDbContext.SaveChanges();
        }
        public void EditarAutor(Autor autor)
        {
            _atDbContext.Autor.Update(autor);
            _atDbContext.SaveChanges();
        }
        public Autor GetAutor(int Id)
        {
            return _atDbContext.Autor.First(Autor => Autor.Id == Id);
        }
    }
}
