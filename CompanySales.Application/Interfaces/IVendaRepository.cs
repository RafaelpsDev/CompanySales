using CompanySales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySales.Application.Interfaces
{
    public interface IVendaRepository
    {
        Task<VendaModel> Buscar(int id);
        Task<VendaModel> CadastrarVenda(VendaModel vendaModel);
        Task<VendaModel> AlterarStatusVenda(VendaModel vendaModel);
    }
}
