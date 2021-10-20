using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace T2STakehome.Data {
    public class ContainerModel {

        [Required(ErrorMessage ="Informe um número para o container")]
        [RegularExpression("^[a-zA-Z]{4}\\d{7}$", ErrorMessage ="O número do container deve estar no formato ABCD1234567")]
        public string Numero { get; set; }

        [Required]
        public string IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public int Tipo { get; set; }
        public bool Vazio { get; set; }
        public string Categoria { get; set; }


        public static async Task<List<ContainerModel>> GetAll() {
            string sql = "select numContainer as Numero, co.idCliente as IdCliente, c.nome as NomeCliente, co.tipo, co.vazio, co.categoria from container co join cliente c on co.idCliente = c.idCliente";

            return await Database.executeQuery<ContainerModel, dynamic>(sql, new { });
        }

        public async Task inserir() {
            string sql = "insert into container(numContainer, idCliente, tipo, vazio, categoria) values (@numContainer, @idCliente, @tipo, @vazio, @categoria)";

            await Database.executeNonQuery(sql, new { numContainer = Numero, idCliente = IdCliente, tipo = Tipo, vazio = Vazio, categoria = Categoria });
        }

    }

}
