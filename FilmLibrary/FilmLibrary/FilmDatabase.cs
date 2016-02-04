﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

        public static void AddFilm(string filmTitle, string filmDescription, string filmDirector, string filmsGenres)
        {
            string insStmt = "INSERT INTO FILMS(Title, Description, Director, Genres) Values (@filmTitle, @filmDescription, @filmDirector, @FilmGenres)";
            SqlConnection conn = GetConnection();
            SqlCommand insCmd = new SqlCommand(insStmt, conn);
            insCmd.Parameters.AddWithValue("@filmTitle", filmTitle);
            insCmd.Parameters.AddWithValue("@filmDescription", filmDescription);
            insCmd.Parameters.AddWithValue("@filmDirector", filmDirector);
            insCmd.Parameters.AddWithValue("@filmGenres", filmsGenres);
            try { conn.Open(); insCmd.ExecuteNonQuery(); }
            catch (SqlException ex) { throw ex; }
            finally { conn.Close(); }
        }

        public static List<Films> GetFilm()
        {
            List<Films> filmsList = new List<Films>();
            SqlConnection conn = GetConnection();
            string selStmt = "SELECT * FROM FILMS ORDER BY TITLE";
            SqlCommand selCmd = new SqlCommand(selStmt, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = selCmd.ExecuteReader();
                while(reader.Read())
                {
                    Films film = new Films();
                    film.FilmId = (int)reader["Id"];
                    film.FilmTitle = reader["Title"].ToString();
                    film.FilmDescription = reader["Description"].ToString();
                    film.FilmDirector = reader["Director"].ToString();
                    film.FilmGenres = reader["Genres"].ToString();
                    filmsList.Add(film);
                }
                reader.Close();

            }
            catch (SqlException ex) { throw ex; }
            finally { conn.Close(); }
            return filmsList;
        }

        public static void EditFilm(int filmId, string filmTitle, string filmDescription, string filmDirector, string filmsGenres)
        {
            string insStmt = "UPDATE FILMS SET Title='" + filmTitle + "', Description='" + filmDescription + "', Director='" + filmDirector + "', Genres='" + filmsGenres + "' WHERE Id='" + filmId + "'";
            SqlConnection conn = GetConnection();
            SqlCommand insCmd = new SqlCommand(insStmt, conn);
            try { conn.Open(); insCmd.ExecuteNonQuery(); }
            catch (SqlException ex) { throw ex; }
            finally { conn.Close(); }
        }
    }
}
