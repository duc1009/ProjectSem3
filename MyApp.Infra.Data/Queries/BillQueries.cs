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
                sb.Append("SELECT * ");
                sb.Append("FROM Bill as c ");              
                sb.Append("WHERE c.IsDeleted = 0 ");               
                string query = sb.ToString();
                var result = await connection.QueryAsync<BillDTO>(query);
                foreach (var item in result)
                {
                    StringBuilder sb2 = new StringBuilder();
                    sb2.Append("SELECT * ");
                    sb2.Append("FROM BillDetail as d ");
                    sb2.Append($"WHERE d.BillId= '{item.Id}' ");
                    var result2 = (await connection.QueryAsync<BillDetailDTO>(sb2.ToString()));
                    item.BillDetails = result2.ToList();
                }
                return result.ToList();
            }
        }

    }
}
