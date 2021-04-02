using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using api.Models;
using Microsoft.AspNetCore.Cors;
using System;



namespace api
{
    public class HandlePostData
    {

        public static ConnectionString myConnection = new ConnectionString();
        public static string cs = myConnection.cs;
        List<Posts> posts = new List<Posts>{};
        public IEnumerable<Posts> Get(){
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"SELECT * FROM posts ORDER BY timestamp DESC";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                posts.Add(new Posts(){Id=reader.GetInt32(0), Post=reader.GetString(1), Timestamp=reader.GetDateTime(2)});
            }
            return posts;
        }
        public void Post(Posts newPost){
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"INSERT INTO posts(id, post, timestamp) VALUES(default,'{newPost.Post}', default)";
            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }
        public Posts GetById(int id){
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"SELECT * FROM posts WHERE id = '{id}'";
            using var cmd = new MySqlCommand(stm, con);
            
            using MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            return new Posts(){Id=reader.GetInt32(0), Post=reader.GetString(1), Timestamp=reader.GetDateTime(2)};
        }
        public void Delete(int id){
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"DELETE FROM posts WHERE id = '{id}'";
            using var cmd = new MySqlCommand(stm, con);
            
            using MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
        }
        public void Put(Posts value) {
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = $@"UPDATE posts SET post = '{value.Post}' WHERE id = '{value.Id}'";
            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }
    }
}