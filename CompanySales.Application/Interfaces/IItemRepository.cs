using CompanySales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySales.Application.Interfaces
{
    public interface IItemRepository
    {
        Task<ItemModel> AdicionarItem(ItemModel itemModel);
        Task<ItemModel> BuscarItemPorId(int id);
    }
}
