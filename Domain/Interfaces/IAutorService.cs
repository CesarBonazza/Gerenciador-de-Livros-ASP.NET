using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAutorService
    {
        IList<Autor> GetAll();
        void AdicionarAutor(Autor autor);
        void ExcluirAutor(int Id);
        void EditarAutor(Autor autor);
        Autor GetAutor(int Id);
    }
}
