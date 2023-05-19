using CompanySales.Application.Interfaces;
using CompanySales.Domain.Models;
using CompanySales.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySales.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly CompanySalesContext _context;
        public ItemRepository(CompanySalesContext context)
        {
            _context = context;
        }

        public async Task<ItemModel> AdicionarItem(ItemModel itemModel)
        {
            await _context.Itens.AddAsync(itemModel);
            await _context.SaveChangesAsync();
            return itemModel;
        }

        public async Task<ItemModel> BuscarItemPorId(int id)
        {
            var item = await _context.Itens.FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }        
    }
}
