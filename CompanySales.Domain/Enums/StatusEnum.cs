using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySales.Domain.Enums
{
    public enum StatusEnum
    {
        [Description("Aguardando Pagamento")]
        AguardandoPagamento = 1,
        [Description("Pagamento Aprovado")]
        PagamentoAprovado = 2,
        [Description("Enviado para a Transportadora")]
        EnviadoParaTransportadora = 3,
        Entregue = 4,
        Cancelada = 5
    }
}
