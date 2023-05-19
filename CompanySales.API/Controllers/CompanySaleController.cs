using AutoMapper;
using CompanySales.Application.DTOs;
using CompanySales.Application.Interfaces;
using CompanySales.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace CompanySales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanySaleController : ControllerBase
    {
        private readonly IVendedorService _vendedorService;
        private readonly IItemService _itemService;
        private readonly IVendaService _vendaService;
        private readonly IMapper _mapper;
        public CompanySaleController(IVendedorService vendedorService, IItemService itemService, IVendaService vendaService, IMapper mapper)
        {
            _vendedorService = vendedorService;
            _itemService = itemService;
            _vendaService = vendaService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("BuscarVendedorPorId:{id}")]
        public async Task<IActionResult> BuscarVendedorPorId(int id)
        {
            var vendedor = await _vendedorService.BuscarVendedorPorId(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            return Ok(vendedor);
        }

        [HttpGet]
        [Route("BuscarItemPorId:{id}")]
        public async Task<IActionResult> BuscarItemPorId(int id)
        {
            var item = await _itemService.BuscarItemPorId(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet]
        [Route("BuscarVendaPorId:{id}")]
        public async Task<ActionResult> BuscarVendaPorId(int id)
        {
            var venda = await _vendaService.Buscar(id);
            if (venda == null)
            {
                throw new Exception("A venda não existe");
            }
            var clienteDTO = _mapper.Map<VendaDTO>(venda);
            return Ok(clienteDTO);
        }

        [HttpPost]
        [Route("AdicionarVendedor")]
        public async Task<ActionResult<VendedorModel>> AdicionarVendedor([FromBody] VendedorModel vendedorModel)
        {
            var vendedor = await _vendedorService.AdicionarVendedor(vendedorModel);            
            return CreatedAtAction(nameof(BuscarVendedorPorId), new { id = vendedor.Id }, vendedor);

        }

        [HttpPost]
        [Route("AdicionarItem")]
        public async Task<ActionResult<ItemModel>> AdicionarItem([FromBody] ItemModel itemModel)
        {
            var item = await _itemService.AdicionarItem(itemModel);
            return CreatedAtAction(nameof(BuscarItemPorId), new { id = item.Id }, item);

        }
        [HttpPost]
        [Route("cadastrarVenda")]
        public async Task<ActionResult<VendaModel>> CadastrarVenda([FromBody] VendaModel vendaModel)
        {
            var venda = await _vendaService.cadastrarVenda(vendaModel);
            return CreatedAtAction(nameof(BuscarVendaPorId), new { id = venda.Id }, venda);

        }
    }
}
