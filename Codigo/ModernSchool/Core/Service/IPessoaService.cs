using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;

namespace Core.Service
{
    public interface IPessoaService
    {
        int Create(Pessoa pessoa);
        void Edit(Pessoa pessoa);
        void Delete(int id);
        Pessoa Get(int id);
        IEnumerable<Pessoa> GetAll();
        IEnumerable<PessoaProfessorDTO> GetAllProfessor();

        bool AdicionarCargo(Pessoa pessoa, int idCargo,int idGoverno);

        bool MatricularAlunoTurma(Alunoturma alunoTuram);
        /// <summary>
        /// Caso um aluno não esteja cadastrado no sistema ele vai ser cadastrado e matriculado na turma selecionada
        /// </summary>
        /// <param name="aluno"></param>
        /// <param name="idTurma"></param>
        /// <returns>True: se o aluno foi criado e cadastrado na turma
        ///          False: se ouuve falha
        /// </returns>
        /// 
        Pessoa GetAluno(int idEscola, string cpf);
        bool MatricularNovoAlunoTurma(Pessoa aluno, int idTurma);
        int GetById(string cpf);

        Task<string> GetByCargo(string email);
        Task<Pessoa> GetByEmail(string email);
        List<AlunoComponente> GetListasComponente(int idTurma);
        Alunoturma GetAlunoTurma(int idAluno);

        List<IndexAlunoTurmaDTO> GetAlunosTurma(int idTurma);

    }
}
