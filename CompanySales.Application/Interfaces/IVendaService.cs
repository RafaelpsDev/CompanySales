using CompanySales.Domain.Models;

namespace CompanySales.Application.Interfaces
{
    public interface IVendaService
    {
        Task<VendaModel> cadastrarVenda(VendaModel vendaModel);
        Task<VendaModel> Buscar(int id);
        Task<VendaModel> Atualizar(VendaModel vendaModel, int id);
    }
}
