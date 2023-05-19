using CompanySales.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompanySales.Domain.Models
{
    public class VendaModel
    {        
        public int Id { get; set; }
        public DateTime DataDaVenda { get; set; } = DateTime.Now;
        public Guid IdPedido { get; set; }
        public int IdItem { get; set; }
        public int IdVendedor { get; set; }
        public StatusEnum StatusVenda { get; set; } = StatusEnum.AguardandoPagamento;
        [JsonIgnore]
        public VendedorModel Vendedor { get; set; }
        [JsonIgnore]
        public ItemModel Item { get; set; }        

    }
}
