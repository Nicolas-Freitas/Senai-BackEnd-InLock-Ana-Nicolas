using SenaiInLock.WebApi.Domain;
using SenaiInLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiInLock.WebApi.Repository
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Server=DESKTOP-JEVSFEK\\SQLEXPRESS;Database=InLock;Integrated Security=True;";

        public JogosDomain BuscarPorId(int id)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectById = "select IdJogo, NomeJogo, Descricao, Estudio.EstudioNome,Preco, DataLanc, Estudio.IdEstudio from Jogos inner join Estudio on Jogos.IdEstudio = Estudio.IdEstudio where IdJogo like @ID; ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogosDomain jogo = new JogosDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"])

                            ,
                            NomeJogo = rdr["NomeJogo"].ToString()

                            ,
                            Descricao = rdr["Descricao"].ToString()
                            ,
                            Preco = Convert.ToSingle(rdr["Preco"])
                            ,
                            DataLanc = Convert.ToDateTime(rdr["DataLanc"])

                            ,
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"])

                            ,
                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"])

                                ,
                                EstudioNome = rdr["EstudioNome"].ToString()
                            }
                        };

                        return jogo;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Jogos(NomeJogo, Descricao, Preco, DataLanc, IdEstudio) VALUES (@NomeJogo, @Descricao, @Preco, @DataLanc, @IdEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@NomeJogo", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@Preco", novoJogo.Preco);
                    cmd.Parameters.AddWithValue("@DataLanc", novoJogo.DataLanc);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Deletar(int id)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM Jogos WHERE IdJogo = @ID";


                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> ListarJogos()
        {

            List<JogosDomain> jogos = new List<JogosDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "select IdJogo, NomeJogo, Descricao, Estudio.EstudioNome,Preco, DataLanc, Estudio.IdEstudio from Jogos inner join Estudio on Jogos.IdEstudio = Estudio.IdEstudio; ";

                con.Open();


                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {

                    rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {

                        JogosDomain jogo = new JogosDomain
                        {
                            IdJogo = Convert.ToInt32(rdr[0])

                            ,
                            NomeJogo = rdr["NomeJogo"].ToString()

                            ,
                            Descricao = rdr["Descricao"].ToString()
                            ,
                            Preco = Convert.ToSingle(rdr["Preco"])
                            ,
                            DataLanc = Convert.ToDateTime(rdr["DataLanc"])

                            ,
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"])

                            ,
                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"])

                                ,
                                EstudioNome = rdr["EstudioNome"].ToString()
                            }
                        };

                        jogos.Add(jogo);
                    }
                }
            }

            return jogos;
        }
    }
}