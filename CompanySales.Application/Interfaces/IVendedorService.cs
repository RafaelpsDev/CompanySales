using CompanySales.Domain.Models;

namespace CompanySales.Application.Interfaces
{
    public interface IVendedorService
    {
        Task<VendedorModel> AdicionarVendedor(VendedorModel vendedorModel);
        Task<VendedorModel> BuscarVendedorPorId(int id);
    }
}
