using MVCRazorCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRazorCRUD.Interfaces
{
    interface IAluno
    {
        Aluno CadastrarAluno(Aluno aluno);
        List<Aluno> ListarAluno();
        Aluno AlterarAluno(Aluno aluno);
        Aluno BuscarPorId(int id);
    }
}
