using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    class pagamento_atendimento
    {
        //atributos
        int cod_pagamento_atendimento_pk,
            cod_pagamento_fk,
            cod_atendimento_fk;
        Double valor_fatia_pagamento;
        //Get & Set
        public int getCod_pagamento_atendimento_pk()
        {
            return cod_pagamento_atendimento_pk;
        }
        public void setCod_pagamento_atendimento_pk(int cod_pagamento_atendimento_pk)
        {
            this.cod_pagamento_atendimento_pk = cod_pagamento_atendimento_pk;
        }
        public int getCod_pagamento_fk()
        {
            return cod_pagamento_fk;
        }
        public void setCod_pagamento_fk(int cod_pagamento_fk)
        {
            this.cod_pagamento_fk = cod_pagamento_fk;
        }
        public int getCod_atendimento_fk()
        {
            return cod_atendimento_fk;
        }
        public void setCod_atendimento_fk(int cod_atendimento_fk)
        {
            this.cod_atendimento_fk = cod_atendimento_fk;
        }
        public Double getValor_fatia_pagamento()
        {
            return this.valor_fatia_pagamento;
        }
        public void setValor_fatia_pagamento(Double valor_fatia_pagamento)
        {
            this.valor_fatia_pagamento = valor_fatia_pagamento;
        }        
        //Get & Set
    }
}