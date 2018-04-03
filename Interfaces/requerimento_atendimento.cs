using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gerenciador_antt.Classes_Objetos;

namespace gerenciador_antt.Classes_Auxiliares
{
    public interface requerimento_atendimento
    {
        void atendimentoEscolhido(atendimento atendimento);
        void sinalizarEscolha_atendimento(bool escolhido);
    }
}
