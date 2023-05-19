using CompanySales.Application.Interfaces;
using CompanySales.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CompanySales.Application.Services
{
    public class VendedorService : IVendedorService
    {
        private readonly IVendedorRepository _repository;
        public VendedorService(IVendedorRepository repository)
        {
            _repository = repository;            
        }

        public async Task<VendedorModel> AdicionarVendedor(VendedorModel vendedorModel)
        {
            await _repository.AdicionarVendedor(vendedorModel);            
            return vendedorModel;
        }

        public async Task<VendedorModel> BuscarVendedorPorId(int id)
        {
            var vendedor = await _repository.BuscarVendedorPorId(id);
            if (vendedor == null) 
            { 
                return null;
            }
            return vendedor;
        }
    }
}
