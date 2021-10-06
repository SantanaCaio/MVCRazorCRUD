using MVCRazorCRUD.Context;
using MVCRazorCRUD.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRazorCRUD.Models
{
    public class Aluno : UsuarioBase , IAluno 
    {
        public string Escolaridade { get; set; }

        public Aluno AlterarAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public Aluno BuscarPorId(int id)
        {
            var connection = Conexao.GetConnect();
            connection.Open();

            var query = "select * from alunos where alunoId = @id";

            var command = new SqlCommand(query, connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            var dataSet = new DataSet();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet);

            var rows = dataSet.Tables[0].Rows;

            List<Aluno> listaAlunos = new List<Aluno>();

            foreach(DataRow item in rows)
            {
                var colunas = item.ItemArray;

                Aluno aluno = new Aluno();


                aluno.Id = int.Parse(colunas[0].ToString());
                aluno.Nome = colunas[1].ToString();
                aluno.Email = colunas[2].ToString();
                aluno.Endereco = colunas[3].ToString();
                aluno.Telefone = colunas[4].ToString();
                aluno.Escolaridade = colunas[5].ToString();

                listaAlunos.Add(aluno);
            }
            connection.Close();

            return listaAlunos;

        }

        public Aluno CadastrarAluno(Aluno aluno)
        {
            try
            {
                var connection = Conexao.GetConnect();
                connection.Open();
                var query = "insert into Alunos (alunoNome, AlunoEmail, alunoEndereco, alunoTelefone, alunoEscolaridade) values (@nome, @email, @end, @tel, @esc)";

                var command = new SqlCommand(query, connection);

                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = aluno.Nome;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = aluno.Email;
                command.Parameters.Add("@end", SqlDbType.VarChar).Value = aluno.Endereco;
                command.Parameters.Add("@tel", SqlDbType.VarChar).Value = aluno.Telefone;
                command.Parameters.Add("@esc", SqlDbType.VarChar).Value = aluno.Escolaridade;

                command.ExecuteNonQuery();

                connection.Close();
                return aluno;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Aluno> ListarAluno()
        {
            try
            {
            //Conexao
            var connection = Conexao.GetConnect();
            connection.Open();
            //query
            var query = "select * from alunos";
            var command = new SqlCommand(query, connection);
            var dataSet = new DataSet();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(dataSet);

            var rows = dataSet.Tables[0].Rows;

            List<Aluno> listaDeAlunos = new List<Aluno>();

            foreach(DataRow item in rows)
            {
                Aluno aluno = new Aluno();
                var colunas = item.ItemArray;
                aluno.Id = int.Parse(colunas[0].ToString());
                aluno.Nome = colunas[1].ToString();
                aluno.Email = colunas[2].ToString();
                aluno.Endereco = colunas[3].ToString();
                aluno.Telefone = colunas[4].ToString();
                aluno.Escolaridade = colunas[5].ToString();

                listaDeAlunos.Add(aluno);
            }

            connection.Close();
            return listaDeAlunos;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void RemoverAluno(int id)
        {
            var connection = Conexao.GetConnect();
            connection.Open();
            var query = "delete from alunos where alunoId = @id";
            var command = new SqlCommand(query, connection);

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            //Aqui execulta a quey no banco de dados

            command.ExecuteNonQuery();
        }

        Aluno IAluno.RemoverAluno(int id)
        {
            throw new NotImplementedException();
        }


    }
}
