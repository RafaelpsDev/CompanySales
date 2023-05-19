using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompanySales.Domain.Models
{
    public partial class ItemModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        [JsonIgnore]
        public virtual ICollection<VendaModel> Venda { get; set; }
    }
}
