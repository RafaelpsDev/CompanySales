using CompanySales.Application.Interfaces;
using CompanySales.Domain.Enums;
using CompanySales.Domain.Models;

namespace CompanySales.Application.Services
{
    public class VendaService : IVendaService
    {
        private IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }
        public async Task<VendaModel> Atualizar(VendaModel vendaModel, int id)
        {
            VendaModel vendaAtualizar = await _vendaRepository.Buscar(id);
            if (vendaAtualizar == null)
                throw new Exception($"A venda: {id} não existe!");

            if (vendaAtualizar.StatusVenda == StatusEnum.AguardandoPagamento)
            {
                if (vendaModel.StatusVenda != StatusEnum.PagamentoAprovado && vendaModel.StatusVenda != StatusEnum.Cancelada)
                {
                    throw new Exception("A venda esta com o status de Aguardando Pagamento, por favor escolha 'Pagamento Aprovado' ou 'Cancelada'!");
                }
            }
            if (vendaAtualizar.StatusVenda == StatusEnum.PagamentoAprovado)
            {
                if (vendaModel.StatusVenda != StatusEnum.EnviadoParaTransportadora && vendaModel.StatusVenda != StatusEnum.Cancelada)
                {
                    throw new Exception("A venda esta com o status de Pagamento Aprovado, por favor escolha 'Enviar para Transportadora' ou 'Cancelada'!");
                }
            }
            if (vendaAtualizar.StatusVenda == StatusEnum.EnviadoParaTransportadora)
            {
                if (vendaModel.StatusVenda != StatusEnum.Entregue)
                {
                    throw new Exception("A venda esta com o status de Enviar para Transportadora, por favor escolha 'Entrgue'!");
                }
            }
            await _vendaRepository.AlterarStatusVenda(vendaAtualizar);
            return vendaAtualizar;
        }

        public async Task<VendaModel> Buscar(int id)
        {
            var venda = await _vendaRepository.Buscar(id);
            if (venda == null)
            {
                return null;
            }

            return venda;
            
        }

        public async Task<VendaModel> cadastrarVenda(VendaModel vendaModel)
        {
            await _vendaRepository.CadastrarVenda(vendaModel);
            return vendaModel;

        }

        
    }
}
