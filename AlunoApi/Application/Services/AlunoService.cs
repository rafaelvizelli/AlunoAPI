using AlunoAPI.Domain.Entities;
using AlunoAPI.Domain.Interfaces;

namespace AlunoAPI.Application.Services
{
    public class AlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public void Matricular(Aluno aluno)
        {
            if (string.IsNullOrWhiteSpace(aluno.FirstName))
                throw new Exception("O campo FirstName não pode ser vazio.");

            if (aluno.FirstName.Length > 50)
                throw new Exception("O campo FirstName deve ter no máximo 50 caracteres.");

            if (!aluno.Email.EndsWith("@faculdade.edu"))
                throw new Exception("O e-mail deve terminar com @faculdade.edu.");

            Aluno? existente = _repository.BuscarPorEmail(aluno.Email);
            if (existente != null)
                throw new Exception("Já existe um aluno cadastrado com este e-mail.");

            _repository.Salvar(aluno);
        }

        public List<Aluno> ListarTodos()
        {
            return _repository.ListarTodos();
        }
    }
}