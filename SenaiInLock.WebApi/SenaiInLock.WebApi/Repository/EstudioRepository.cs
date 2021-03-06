﻿using SenaiInLock.WebApi.Domain;
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

        private string stringConexao = "Server=DESKTOP-JEVSFEK\\SQLEXPRESS;Database=InLock;Integrated Security=True;"; 
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

        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string querySelectById = "SELECT IdEstudio, EstudioNome FROM Estudio WHERE IdEstudio = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    
                    cmd.Parameters.AddWithValue("@ID", id);

                    
                    rdr = cmd.ExecuteReader();

                   
                    if (rdr.Read())
                    {
                        
                        EstudioDomain estudio = new EstudioDomain
                        {
                            
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            EstudioNome = rdr["EstudioNome"].ToString()
                        };

                       
                        return estudio;
                    }

                    
                    return null;
                }
            }
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

                    con.Open();

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
