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

        public IList<Stock> GetStocksByThreeParams(String symbol, string startDateTime, string endDateTime)
        {
            var startDate = startDateTime.Substring(0, 8);
            var startTime = startDateTime.Substring(8);
            var endDate = endDateTime.Substring(0, 8);
            var endTime = endDateTime.Substring(8);   
            String sql = String.Format("select * from Stocks where Symbol = '{0}' and Date >= {1} and Date <= {2} and Time >= {3} and Time <= {4}", symbol, startDate, endDate, startTime, endTime);
            IList<Stock> result = ReturnResult(sql);
            return result;
        }

        public IList<Stock> GetStocksByTwoParams(String symbol, int date)
        {
            String sql = String.Format("select * from Stocks where Symbol = '{0}' and Date = {1}", symbol, date);
            IList<Stock> result = ReturnResult(sql);
            return result;
        }

        public IList<Stock> GetStocksByDateTime(String dateTime)
        {
            var date = dateTime.Substring(0, 8);
            var time = dateTime.Substring(8);
            String sql = string.Format("select * from Stocks where Date = '{0}' and Time = {1}", date, time);
            IList<Stock> result = ReturnResult(sql);
            return result;
        }
    }
}