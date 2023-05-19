using CompanySales.Application.Interfaces;
using CompanySales.Domain.Models;

namespace CompanySales.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ItemModel> AdicionarItem(ItemModel itemModel)
        {
            await _itemRepository.AdicionarItem(itemModel);
            return itemModel;
        }

        public async Task<ItemModel> BuscarItemPorId(int id)
        {
            var item = await _itemRepository.BuscarItemPorId(id);
            if (item == null)
            {
                return null;
            }
            return item;
            
        }
    }
}
