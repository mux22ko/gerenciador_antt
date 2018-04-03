using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using gerenciador_antt.Classes_Objetos;

namespace gerenciador_antt.Classes_Auxiliares
{
    public interface requerimento_cliente
    {
      void clienteEscolhido(cliente cliente);
      void sinalizarEscolha_cliente(bool escolhido);
    }
}
