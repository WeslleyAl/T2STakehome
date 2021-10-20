using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T2STakehome.Data {

    public class ClienteModel {
        public string Id { get; set; }
        public string Nome { get; set; }

        public static async Task<List<ClienteModel>> GetAll() {
            string sql = "select idCliente as Id, nome as Nome from cliente";

            return await Database.executeQuery<ClienteModel, dynamic>(sql, new { });
        }

    }
}
