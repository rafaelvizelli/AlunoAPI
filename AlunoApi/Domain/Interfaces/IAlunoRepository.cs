using AlunoAPI.Domain.Entities;

namespace AlunoAPI.Domain.Interfaces
{
    public interface IAlunoRepository
    {
        void Salvar(Aluno aluno);
        Aluno? BuscarPorEmail(string email);
        List<Aluno> ListarTodos();
    }
}