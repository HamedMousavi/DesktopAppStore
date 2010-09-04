﻿using System;
using System.Data.SqlClient;
using System.Data;
using DomainModel.Abstract;



namespace DomainModel.Repository.Sql
{
    public class Users : IUsersRepository
    {
        string ConnectionString { get; set; }


        public Users(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }


        public bool Authenticate(string username, string password)
        {
            bool userIsValid = false;
            string query =
                "DECLARE @UserId BIGINT" +
                " SET @UserId = -1" +
                " SELECT @UserId = UserId" +
                " FROM Users" +
                " WHERE (UserName = @UserName OR EmailAddress = @UserName)" +
                " IF (@@ERROR = 0 AND @UserId > 0) " +
                " BEGIN" +
                "   IF ( EXISTS (SELECT IsApproved FROM UsersCredentials WHERE UserId = @UserId AND Password = @Password) ) " +
                "   BEGIN" +
                "       SELECT 1" +
                "   END" +
                " END" +
                " SELECT 0";

            using (SqlConnection cnn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@UserName", username));
                    cmd.Parameters.Add(new SqlParameter("@Password", password));
                    cnn.Open();

                    object queryRes = cmd.ExecuteScalar();
                    if (queryRes != null)
                    {
                        if (Convert.ToInt32(queryRes) == 1) userIsValid = true;
                    }

                    cnn.Close();
                }
            }

            return userIsValid;
        }


        public bool Exists(string Email)
        {
            bool exists = false;
            string query =
                "IF ( EXISTS (SELECT UserId FROM Users WHERE EmailAddress = @Email) ) " +
                " BEGIN" +
                "   SELECT 1" +
                " END" +
                "   SELECT 0";

            using (SqlConnection cnn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@Email", Email));
                    cnn.Open();

                    object queryRes = cmd.ExecuteScalar();
                    if (queryRes != null)
                    {
                        if (Convert.ToInt32(queryRes) == 1) exists = true;
                    }

                    cnn.Close();
                }
            }

            return exists;
        }


        public bool CreateUser(string Email, string Password)
        {
            bool bRes = false;
            string query =
                "DECLARE @UserId BIGINT " +
                "DECLARE @RES BIT " +
                "SET @UserId = -1 " +
                "SET @RES = 0 " +
                "INSERT INTO Users " +
                "(UserName, EmailAddress, MembershipDate) " +
                "VALUES (@UserName, @EmailAddress, @MembershipDate); " +
                "SELECT @UserId = SCOPE_IDENTITY(); " +
                "IF (@@ERROR = 0 AND @UserId > 0)  " +
                "	BEGIN " +
                "		INSERT INTO UsersCredentials " +
                "		(UserId, [Password], IsApproved, IsLocked, CredentialMailCount) " +
                "		VALUES (@UserId, @Password, 0, 0, 0); " +
                "		IF (@@ERROR = 0) " +
                "		BEGIN " +
                "			SET @RES = 1;" +
                "		END " +
                "	END " +
                "SELECT @RES; ";


            using (SqlConnection cnn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@UserName", Email));
                    cmd.Parameters.Add(new SqlParameter("@EmailAddress", Email));
                    cmd.Parameters.Add(new SqlParameter("@MembershipDate", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    cnn.Open();

                    object queryRes = cmd.ExecuteScalar();
                    if (queryRes != null)
                    {
                        if (Convert.ToInt32(queryRes) == 1) bRes = true;
                    }

                    cnn.Close();
                }
            }

            return bRes;
        }


        public string GetUserName(string Email)
        {
            string userName = string.Empty;
            string query =
                " SELECT UserName" +
                " FROM Users" +
                " WHERE (EmailAddress = @Email)";

            using (SqlConnection cnn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@Email", Email));
                    cnn.Open();

                    object queryRes = cmd.ExecuteScalar();
                    if (queryRes != null)
                    {
                        userName = Convert.ToString(queryRes);
                    }

                    cnn.Close();
                }
            }

            return userName;
        }

    }
}
