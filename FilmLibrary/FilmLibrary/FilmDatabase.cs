using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace FilmLibrary
{
    public static class FilmDatabase
    {
        public static SqlConnection GetConnection()
        {
            string connStr = @"Data Source=BARTOSZOCIEPKA\SQLEXPRESS;Initial Catalog=Films3;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            return conn;
        }

        public static void AddFilm(string filmTitle, string filmDescription, string filmDirector, string filmGenres)
        {
            //string insStmt = "INSERT INTO FILMS(Title, Description, Director, Genres) Values (@filmTitle, @filmDescription, @filmDirector, @FilmGenres)";
            //SqlConnection conn = GetConnection();
            //SqlCommand insCmd = new SqlCommand(insStmt, conn);
            //insCmd.Parameters.AddWithValue("@filmTitle", filmTitle);
            //insCmd.Parameters.AddWithValue("@filmDescription", filmDescription);
            //insCmd.Parameters.AddWithValue("@filmDirector", filmDirector);
            //insCmd.Parameters.AddWithValue("@filmGenres", filmsGenres);
            //try { conn.Open(); insCmd.ExecuteNonQuery(); }
            //catch (SqlException ex) { throw ex; }
            //finally { conn.Close(); }

            using (var ctx = new FilmsContextClass())
            {
                FILMS film = new FILMS() { Title = filmTitle, Description = filmDescription, Director = filmDirector, Genres = filmGenres };

                ctx.Films.Add(film);
                ctx.SaveChanges();
            }
        }

        public static List<FILMS> GetFilm()
        {
            List<FILMS> filmsList = new List<FILMS>();

            //SqlConnection conn = GetConnection();
            //string selStmt = "SELECT * FROM FILMS ORDER BY TITLE";
            //SqlCommand selCmd = new SqlCommand(selStmt, conn);
            //try
            //{
            //    conn.Open();
            //    SqlDataReader reader = selCmd.ExecuteReader();
            //    while(reader.Read())
            //    {
            //        FILMS film = new FILMS();
            //        film.Id = (int)reader["Id"];
            //        film.Title = reader["Title"].ToString();
            //        film.Description = reader["Description"].ToString();
            //        film.Director = reader["Director"].ToString();
            //        film.Genres = reader["Genres"].ToString();
            //        filmsList.Add(film);
            //    }
            //    reader.Close();

            //}
            //catch (SqlException ex) { throw ex; }
            //finally { conn.Close(); }
            //return filmsList;

            

            using (var context = new FilmsContextClass())
            {

                
                    foreach (var film in context.Films)
                    {
                        filmsList.Add(film);
                    }
                  
                


            }
            return filmsList;
        }

        public static void EditFilm(int filmId, string filmTitle, string filmDescription, string filmDirector, string filmsGenres)
        {
            string insStmt = "UPDATE FILMS SET Title = @filmTitle, Description = @filmDescription, Director = @filmDirector, Genres = @filmsGenres " + "WHERE Id = @filmId";
            SqlConnection conn = GetConnection();
            SqlCommand insCmd = new SqlCommand(insStmt, conn);
            insCmd.Parameters.Add("@filmId", SqlDbType.Int);
            insCmd.Parameters["@filmId"].Value = filmId;
            insCmd.Parameters.AddWithValue("@filmTitle", filmTitle);
            insCmd.Parameters.AddWithValue("@filmDescription", filmDescription);
            insCmd.Parameters.AddWithValue("@filmDirector", filmDirector);
            insCmd.Parameters.AddWithValue("@filmsGenres", filmsGenres);
            conn.Open(); insCmd.ExecuteNonQuery();
            
            conn.Close();
        }
    }
}
