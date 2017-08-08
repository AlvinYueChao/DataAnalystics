using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAnalysis.Models
{
    public class DetailHandler
    {
        private String cs = ConfigurationManager.ConnectionStrings["Stock"].ConnectionString;

        public Detail ReturnResult(String sql)
        {
            Detail result = new Detail();
            using(var connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                while (reader.Read())
                {
                    result.ID = reader.GetInt32(0);
                    result.EXP = reader.GetString(1);
                    result.Symbol = reader.GetString(2);
                    result.Name = reader.GetString(3);
                    result.LastSale = reader.GetDouble(4);
                    result.MarketCap = reader.GetString(5);
                    result.IPOyear = reader.GetDouble(6);
                    result.Sector = reader.GetString(7);
                    result.Industry = reader.GetString(8);
                    result.SummaryQuote = reader.GetString(9);
                }
            }
            return result;
        }

        public Detail GetDetailBySymbol(String symbol)
        {
            String sql = String.Format("select * from Details where Symbol = '{0}'", symbol);
            return ReturnResult(sql);
        }
    }
}