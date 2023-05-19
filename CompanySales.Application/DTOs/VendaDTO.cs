using CompanySales.Domain.Enums;
using CompanySales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CompanySales.Application.DTOs
{
    public class VendaDTO
    {
        public int Id { get; set; }
        public DateTime DataDaVenda { get; set; }
        public Guid IdPedido { get; set; }
        public StatusEnum StatusVenda { get; set; }
        public VendedorDTO Vendedor { get; set; }        
        public ItemDTO Item { get; set; }
    }
}
