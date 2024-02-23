﻿using System;
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
        int GetById(string cpf);

        Task<string> GetByCargo(string email);
        Task<Pessoa> GetByEmail(string email);

    }
}
