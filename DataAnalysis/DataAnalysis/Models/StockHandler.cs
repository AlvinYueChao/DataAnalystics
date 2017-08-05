﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataAnalysis.Models
{
    public class StockHandler
    {
        private string cs = @"Data Source =.\SQLEXPRESS; Initial Catalog = DataAnalysis.Models.DADbContext; Integrated Security = True";
        public IList<Stock> GetStocksByParams(String symbol, int date, int start, int end)
        {
            IList<Stock> result = new List<Stock>();
            using(var cnn = new SqlConnection(cs))
            {
                cnn.Open();
                String sql = string.Format("select * from Stocks where Symbol = '{0}' and Date = {1} and Time >= {2} and Time <= {3}", symbol, date, start, end);
                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                while (reader.Read())
                {
                    result.Add(new Stock { ID = reader.GetInt32(0),
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

                return result;
            }
        }
    }
}