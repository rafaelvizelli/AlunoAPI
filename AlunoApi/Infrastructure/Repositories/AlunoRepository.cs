using AlunoAPI.Domain.Entities;
using AlunoAPI.Domain.Interfaces;

namespace AlunoAPI.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private static readonly List<Aluno> _banco = new();

        public void Salvar(Aluno aluno)
        {
            _banco.Add(aluno);
        }

        public Aluno? BuscarPorEmail(string email)
        {
            return _banco.FirstOrDefault(a => a.Email == email);
        }

        public List<Aluno> ListarTodos()
        {
            return _banco;
        }
    }
}