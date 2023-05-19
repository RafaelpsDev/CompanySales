using CompanySales.Application.Interfaces;
using CompanySales.Domain.Models;
using CompanySales.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CompanySales.Infrastructure.Repositories
{    
    public class VendedorRepository : IVendedorRepository
    {
        private readonly CompanySalesContext _context;
        public VendedorRepository(CompanySalesContext context)
        {
            _context = context;
        }

        public async Task<VendedorModel> AdicionarVendedor(VendedorModel vendedorModel)
        {
            await _context.Vendedores.AddAsync(vendedorModel);
            await _context.SaveChangesAsync();
            return vendedorModel;
        }

        public async Task<VendedorModel> BuscarVendedorPorId(int id)
        {
            var vendedor = await _context.Vendedores.FirstOrDefaultAsync(v => v.Id == id);
            return vendedor;
        }
    }
}
