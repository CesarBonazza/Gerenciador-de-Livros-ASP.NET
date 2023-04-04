using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILivroService
    {
        IList<Livro> GetAll();
        void AdicionarLivro(Livro livro);
        void ExcluirLivro(int Id);
        void EditarLivro(Livro livro);
        Livro GetLivro(int Id);
    }
}
