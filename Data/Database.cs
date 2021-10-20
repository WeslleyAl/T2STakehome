using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;

namespace T2STakehome.Data {
    public class Database {

        private static string connectionString = "Server=localhost;DataBase=t2s;Uid=root;pwd=pw123";

        public static async Task<List<T>> executeQuery<T, P>(string sql, P parametros) {

            using (IDbConnection con = new MySqlConnection(connectionString)) {

                var result = await con.QueryAsync<T>(sql, parametros);

                return result.ToList();

            }

        }

        public static async Task executeNonQuery<P>(string sql, P parametros) {

            using (IDbConnection con = new MySqlConnection(connectionString)) {

                await con.ExecuteAsync(sql, parametros);

            }

        }


    }
}
