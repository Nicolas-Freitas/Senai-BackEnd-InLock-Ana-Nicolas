using SenaiInLock.WebApi.Domain;
using SenaiInLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiInLock.WebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV7\\SQLEXPRESS; initial catalog=InLock; User Id=sa;Pwd=sa@132";

        public UsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectById = "SELECT IdUsuario, Email FROM Usuario WHERE IdUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);


                    rdr = cmd.ExecuteReader();


                    if (rdr.Read())
                    {

                        UsuarioDomain usuario = new UsuarioDomain
                        {

                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString()
                        };


                        return usuario;
                    }


                    return null;
                }
            }
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO Usuario(Email, Senha) VALUES (@Email, @Senha)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Usuario WHERE IdUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> ListarUsuario()
        {
            List<UsuarioDomain> usuario = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectAll = "select IdUsuario, Email, TipoUsuario.Titulo, TipoUsuario.IdTipoUsuario from Usuario inner join TipoUsuario on Usuario.IdUsuario = TipoUsuario.IdTipoUsuario";


                con.Open();


                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {

                        UsuarioDomain usuarioDomain = new UsuarioDomain
                        {

                            IdUsuario = Convert.ToInt32(rdr[0]),


                            Email = rdr["Email"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                Titulo = rdr["Titulo"].ToString()
                            }

                        };


                        usuario.Add(usuarioDomain);
                    }
                }
            }


            return usuario;
        }


        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            // Define a conexão passando a string
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Define a query a ser executada no banco
                string querySelect = "select IdUsuario, Email, Senha, TipoUsuario.Titulo, TipoUsuario.IdTipoUsuario from Usuario inner join TipoUsuario on Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario where Email = @Email and Senha = @Senha";

                // Define o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define o valor dos parâmetros
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    // Abre a conexão com o banco
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto usuario 
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"])
                            ,
                            Email = rdr["Email"].ToString()
                            ,
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])
                            ,
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])
                                ,
                                Titulo = rdr["Titulo"].ToString()
                            }
                        };

                        // Retorna o usuario buscado
                        return usuario;
                    }
                }

                // Caso não encontre um email e senha correspondente, retorna null
                return null;
            }
        }


    }
}

