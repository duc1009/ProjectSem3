using Dapper;
using Microsoft.Data.SqlClient;
using MyApp.Domain.ModelQueries;
using MyApp.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infra.Data.Queries
{
    public class BillQueries:IBillQueries
    {
        private readonly string _connectionString;
        public BillQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<BillDTO>> GetBill(BillQueryModel urlQuery)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                StringBuilder sb = new StringBuilder();
              
                    sb.Append("SELECT c.Id, c.Code,c.DatePay,c.DateBill,c.Status,o.Name as OfficalProfile ");
                sb.Append("FROM Bill as c ");              
                sb.Append("WHERE c.IsDeleted = 0 ");
               
                string query = sb.ToString();
                var result = await connection.QueryAsync<BillDTO>(query);
                foreach (var item in result)
                {
                    StringBuilder sb2 = new StringBuilder();
                    sb2.Append("SELECT d.Id,d.ClassId,d.BillId, c.Name as Class ");
                    sb2.Append("FROM Class as c ");
                    sb2.Append("INNER JOIN BillClass as d ON d.ClassId=c.Id ");
                    sb2.Append($"WHERE c.IsDeleted = 0 AND d.BillId= '{item.Id}' ");
                    var result2 = (await connection.QueryAsync<BillDetailDTO>(sb2.ToString()));                    
                }
                return result.ToList();
            }
        }

    }
}
