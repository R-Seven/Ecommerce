﻿using BuildSchool.MvcSolution.OnlineStore.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Dapper;

namespace BuildSchool.MvcSolution.OnlineStore.Repository
{
    public class MemberRepository
    {
        public void Create(Members model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=Commerce; integrated security=true");
            var sql = "INSERT INTO Members VALUES (@MemberID, @Password, @Name, @Phone, @Address, @Email)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@Name", model.Name);
            command.Parameters.AddWithValue("@Phone", model.Phone);
            command.Parameters.AddWithValue("@Address", model.Address);
            command.Parameters.AddWithValue("@Email", model.Email);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Members model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=Commerce; integrated security=true");
            var sql = "UPDATE Members SET Password=@Password, Name=@Name, Phone=@Phone, Address=@Address, Email=@Email WHERE MemberID = @MemberID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@Name", model.Name);
            command.Parameters.AddWithValue("@Phone", model.Phone);
            command.Parameters.AddWithValue("@Address", model.Address);
            command.Parameters.AddWithValue("@Email", model.Email);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(Members model)
        {
            SqlConnection connection = new SqlConnection(
                "data source=.; database=Commerce; integrated security=true");
            var sql = "DELETE FROM Members WHERE MemberID = @MemberID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@MemberID", model.MemberID);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Members FindById(string MemberID)
        {
            IDbConnection connection = new SqlConnection(
                "data source=.; database=Commerce; integrated security=true");

            var result = connection.Query<Members>("SELECT * FROM Members WHERE MemberID = @MemberID", new { MemberID });
            Members member = null;
            foreach(var item in result)
            {
                member = item;
            }
            return member;


            //SqlConnection connection = new SqlConnection(
            //    "data source=.; database=Commerce; integrated security=true");
            //var sql = "SELECT * FROM Members WHERE MemberID = @MemberID";

            //SqlCommand command = new SqlCommand(sql, connection);

            //command.Parameters.AddWithValue("@MemberID", MemberID);

            //connection.Open();

            //var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //var properties = typeof(Members).GetProperties();
            //Members member = null;

            //while (reader.Read())
            //{
            //    member = new Members();
            //    member =  DbReaderModelBinder<Members>.Bind(reader);
            //}

            //reader.Close();

            //return member;
        }

        public IEnumerable<Members> GetAll()
        {
            IDbConnection connection = new SqlConnection(
                "data source=.; database=Commerce; integrated security=true");

            var result = connection.Query<Members>("SELECT * FROM Members");
            var members = new List<Members>();
            foreach(var item in result)
            {
                members.Add(item);
            }
            return members;

            //SqlConnection connection = new SqlConnection(
            //    "data source=.; database=Commerce; integrated security=true");
            //var sql = "SELECT * FROM Members";

            //SqlCommand command = new SqlCommand(sql, connection);
            //connection.Open();

            //var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            //var properties = typeof(Members).GetProperties();
            //var members = new List<Members>();

            //while (reader.Read())
            //{
            //    var member = new Members();
            //    member = DbReaderModelBinder<Members>.Bind(reader);
            //    members.Add(member);
            //}

            //reader.Close();

            //return members;

        }
    }
}
