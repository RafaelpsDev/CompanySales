using CompanySales.Application.Interfaces;
using CompanySales.Domain.Models;
using CompanySales.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CompanySales.Infrastructure.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly CompanySalesContext _context;
        public VendaRepository(CompanySalesContext context)
        {
            _context = context;
        }

        public async Task<VendaModel> Buscar(int id)
        {
            VendaModel venda = await _context.Vendas.Include(v => v.Vendedor).Include(v => v.Item).FirstOrDefaultAsync(v => v.Id == id);
            return venda;
        }

        public async Task<VendaModel> CadastrarVenda(VendaModel vendaModel)
        {
            await _context.Vendas.AddAsync(vendaModel);
            await _context.SaveChangesAsync();
            return vendaModel;
        }
        public async Task<VendaModel> AlterarStatusVenda(VendaModel vendaModel)
        {
            VendaModel venda = new VendaModel();
            venda.DataDaVenda = vendaModel.DataDaVenda;
            venda.IdPedido = vendaModel.IdPedido;
            venda.IdItem = vendaModel.IdItem;
            venda.IdVendedor = vendaModel.IdVendedor;
            venda.StatusVenda = vendaModel.StatusVenda;
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync();
            return venda;
        }
    }
}
