using SenaiInLock.WebApi.Domain;
using SenaiInLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiInLock.WebApi.Repository
{
    public class EstudioRepository : IEstudioRepository
    {

        private string stringConexao = "Data Source=.\\SqlExpress; initial catalog=InLock; User Id=sa;Pwd=sa@132";
        public void Atualizar(int id, EstudioDomain Estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string queryUpdate = "UPDATE Estudio SET EstudioNome = @EstudioNome WHERE IdEstudio = @ID";

                
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@EstudioNome", Estudio.EstudioNome);


                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
              
                string queryInsert = "INSERT INTO Estudio(EstudioNome) VALUES (@EstudioNome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@EstudioNome", novoEstudio.EstudioNome);

                    con.Open();
                  
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarEstudio()
        {
            List<EstudioDomain> estudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                
                string querySelectAll = "SELECT IdEstudio, EstudioNome FROM Estudio";

                
                con.Open();

                
                SqlDataReader rdr;

                
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                   
                    rdr = cmd.ExecuteReader();

                    
                    while (rdr.Read())
                    {
                        
                        EstudioDomain Estudio = new EstudioDomain
                        {
                            
                            IdEstudio = Convert.ToInt32(rdr[0]),

                            
                            EstudioNome = rdr["EstudioNome"].ToString()
                        };

                        
                        estudios.Add(Estudio);
                    }
                }
            }

            
            return estudios; 
        }
    }
}
