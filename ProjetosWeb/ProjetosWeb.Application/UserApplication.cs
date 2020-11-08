using ProjetosWeb.Domain.Entities;
using ProjetosWeb.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosWeb.Application
{
    public class UserApplication
    {
        private IUserRepository userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Guid Inserir(User user)
        {
            try
            {
                if(string.IsNullOrEmpty(user.Email))
                {
                    throw new ApplicationException("Email não informado");
                }

                user.Id = Guid.NewGuid();

                userRepository.Inserir(user);

                return user.Id;

            } catch (Exception e)
            {
                throw e;
            }
        }

        public Guid Alterar(User user)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Email))
                {
                    throw new ApplicationException("Email não informado");
                }

                userRepository.Alterar(user);

                return user.Id;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Excluir(Guid id)
        {
            try
            {
                if (Guid.Empty == id)
                {
                    throw new ApplicationException("O id deve ser informado");
                }

                userRepository.Excluir(id);

                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User Selecionar(Guid id)
        {
            try
            {
                if (Guid.Empty == id)
                {
                    throw new ApplicationException("O id deve ser informado");
                }

                var user = userRepository.Selecionar(id);

                return user;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<User> SelecionarTodos()
        {
            try
            {
                var users = userRepository.selecionarTodos();

                return users;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
