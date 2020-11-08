using ProjetosWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosWeb.Domain.Repository
{
    public interface IUserRepository
    {
        void Inserir(User user);
        void Excluir(Guid id);
        void Alterar(User user);
        User Selecionar(Guid id);

        List<User> selecionarTodos();
    }
}
