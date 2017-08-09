using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace DataAnalysis.Models
{
    public class PortfolioHandler
    {
    
        private string cs = ConfigurationManager.ConnectionStrings["Stock"].ConnectionString;

        public IList<Portfolio> ReturnResult(String sql)
        {
            IList<Portfolio> result = new List<Portfolio>();
            using (var cnn = new SqlConnection(cs))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                while (reader.Read())
                {
                    result.Add(new Portfolio
                    {
                        Symbol = reader.GetString(0),
                        High = reader.GetDouble(1),
                        Low = reader.GetDouble(2),
                        HighOpen=reader.GetDouble(3),
                        LowOpen = reader.GetDouble(4),
                        HighClose= reader.GetDouble(5),
                        LowClose = reader.GetDouble(6),


                    });
                }
            }
            return result;
        }

        public IList<Portfolio> GetPortfolioByFourParams(String id, int startdate, int enddate)
        {
            String sql = string.Format("select Symbol,MAX(High) as High, MIN(LOW) as Low , MAX([Open]) as HighOpen,MIN([Open]) as LowOpen, MAX([Close]) as HighClose,MIN([Close]) as LowClose from Stocks where Date >= {0} and Date<= {1} and Symbol in (select Symbol from[User] where Username = '{2}') Group by Symbol", startdate, enddate,id);
            IList<Portfolio> result = ReturnResult(sql);
            return result;
        }


    }
}