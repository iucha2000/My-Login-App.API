﻿using My_Login_App.API.Interfaces;
using My_Login_App.API.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace My_Login_App.API.Packages
{
    public class PKG_CARDS : PKG_BASE, IPKG_BASE<CardRequest, CardResponse>
    {
        public PKG_CARDS(IConfiguration configuration) : base(configuration)
        {
        }

        public void AddEntity(CardRequest card)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_IURI_CARDS.add_card";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_title", OracleDbType.Varchar2).Value = card.Title;
            cmd.Parameters.Add("v_description", OracleDbType.Varchar2).Value = card.Description;
            cmd.Parameters.Add("v_author", OracleDbType.Varchar2).Value = card.Author;
            cmd.Parameters.Add("v_status", OracleDbType.Varchar2).Value = card.Status;

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void UpdateEntity(int cardId, CardRequest card)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_IURI_CARDS.update_card";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = cardId;
            cmd.Parameters.Add("v_title", OracleDbType.Varchar2).Value = card.Title;
            cmd.Parameters.Add("v_description", OracleDbType.Varchar2).Value = card.Description;
            cmd.Parameters.Add("v_author", OracleDbType.Varchar2).Value = card.Author;
            cmd.Parameters.Add("v_status", OracleDbType.Varchar2).Value = card.Status;

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void DeleteEntity(int id)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_IURI_CARDS.delete_card";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public CardResponse GetEntity(int id)
        {
            CardResponse card = null;
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_IURI_CARDS.get_card_by_id";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_id", OracleDbType.Int32).Value = id;
            cmd.Parameters.Add("v_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                card = new CardResponse()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Title = reader["title"].ToString(),
                    Description = reader["description"].ToString(),
                    Author = reader["author"].ToString(),
                    CreateDate = reader["createdate"].ToString(),
                    Status = reader["status"].ToString()
                };
            }

            conn.Close();

            return card;
        }

        public CardResponse GetEntityByProperty(string property)
        {
            throw new NotImplementedException();
        }

        public List<CardResponse> GetAllEntities()
        {
            List<CardResponse> cards = new List<CardResponse>();

            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = ConnStr;

            conn.Open();

            OracleCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            cmd.CommandText = "olerning.PKG_IURI_CARDS.get_all_cards";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("v_result", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CardResponse card = new CardResponse()
                {
                    Id = int.Parse(reader["id"].ToString()),
                    Title = reader["title"].ToString(),
                    Description = reader["description"].ToString(),
                    Author = reader["author"].ToString(),
                    CreateDate = reader["createdate"].ToString(),
                    Status = reader["status"].ToString()
                };

                cards.Add(card);
            }

            conn.Close();
            return cards;
        }
    }
}
