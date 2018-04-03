using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt
{
    interface uc_identificacao
    {
        String getTitulo();
        String getDescricao();        
        Object getControleAbas();
        int getModoAtual();
    }
}
