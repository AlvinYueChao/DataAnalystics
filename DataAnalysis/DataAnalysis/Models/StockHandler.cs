using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataAnalysis.Models
{
    public class StockHandler
    {
        private String cs = ConfigurationManager.ConnectionStrings["Stock"].ConnectionString;

        public IList<Stock> ReturnResult(String sql)
        {
            IList<Stock> result = new List<Stock>();
            using (var cnn = new SqlConnection(cs))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                while (reader.Read())
                {
                    result.Add(new Stock
                    {
                        ID = reader.GetInt32(0),
                        Symbol = reader.GetString(1),
                        Date = reader.GetInt32(2),
                        Time = reader.GetInt32(3),
                        Open = reader.GetDouble(4),
                        High = reader.GetDouble(5),
                        Low = reader.GetDouble(6),
                        Close = reader.GetDouble(7),
                        Volume = reader.GetDouble(8),
                        SplitFactor = reader.GetInt32(9)
                    });
                }
            }
                return result;
        }

        public IList<Stock> GetStocksByFourParams(String symbol, int date, int start, int end)
        {      
            String sql = String.Format("select * from Stocks where Symbol = '{0}' and Date = {1} and Time >= {2} and Time <= {3}", symbol, date, start, end);
            IList<Stock> result = ReturnResult(sql);
            return result;
        }

        public IList<Stock> GetStocksByTwoParams(String symbol, int date)
        {
            String sql = String.Format("select * from Stocks where Symbol = '{0}' and Date = {1}", symbol, date);
            IList<Stock> result = ReturnResult(sql);
            return result;
        }

        public IList<Stock> GetStocksByTwoParams(int date, int time)
        {
            String sql = string.Format("select * from Stocks where Date = {0} and Time = {1} and Symbol in (select Symbol from [User])", date, time);
            IList<Stock> result = ReturnResult(sql);
            return result;
        }

        public bool InsertSymbol(String symbol)
        {
            bool result = true;
            using (var cnn = new SqlConnection(cs))
            {
                cnn.Open();
                String sql = string.Format("select * from [User] where Symbol = '{0}'", symbol);
                SqlCommand cmd = new SqlCommand(sql , cnn);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                if (reader.HasRows)
                {
                    result = false;
                    return result;
                }
                else
                {
                    reader.Close();
                    String insertsql = string.Format("insert into [User] values ('Analyst', '{0}')", symbol);
                    cmd = new SqlCommand(insertsql, cnn);
                    cmd.ExecuteNonQuery();
                }
                return result;
            }
        }
    }
}