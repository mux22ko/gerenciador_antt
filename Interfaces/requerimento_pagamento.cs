using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gerenciador_antt.Classes_Objetos;

namespace gerenciador_antt.Classes_Auxiliares
{
    public interface requerimento_pagamento
    {
        void pagamentoEscolhido(pagamento pagamento);
        void sinalizarEscolha_pagamento(bool escolhido);
    }
}
