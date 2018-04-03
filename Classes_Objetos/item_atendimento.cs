using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    public class item_atendimento
    {
        //atributos
        int cod_item_atendimento_pk,
            cod_servico_fk,
            cod_atendimento_fk,
            cod_atendente_fk;
        String detalhe_item_atendimento;
        Double valor_combinado_item_atendimento;
        String data_criacao_item;
        
        public int getCod_atendimento_fk()
        {
            return cod_atendimento_fk;
        }
        public void setCod_atendimento_fk(int cod_atendimento_fk)
        {
            this.cod_atendimento_fk = cod_atendimento_fk;
        }

        public int getCod_item_atendimento_pk()
        {
            return cod_item_atendimento_pk;
        }
        public void setCod_item_atendimento_pk(int cod_item_atendimento_pk)
        {
            this.cod_item_atendimento_pk = cod_item_atendimento_pk;
        }
        public int getCod_servico_fk()
        {
            return cod_servico_fk;
        }
        public void setCod_servico_fk(int cod_servico_fk)
        {
            this.cod_servico_fk = cod_servico_fk;
        }
        public int getCod_atendente_fk()
        {
            return cod_atendente_fk;
        }
        public void setCod_atendente_fk(int cod_atendente_fk)
        {
            this.cod_atendente_fk = cod_atendente_fk;
        }
        public String getDetalhe_item_atendimento()
        {
            return detalhe_item_atendimento;
        }
        public void setDetalhe_item_atendimento(String detalhe_item_atendimento)
        {
            this.detalhe_item_atendimento = detalhe_item_atendimento;
        }
        public Double getValor_combinado_item_atendimento()
        {
            return valor_combinado_item_atendimento;
        }
        public void setValor_combinado_item_atendimento(Double valor_combinado_item_atendimento)
        {
            this.valor_combinado_item_atendimento = valor_combinado_item_atendimento;
        }
        public String getData_criacao_item()
        {
            return data_criacao_item;
        }
        public void setData_criacao_item(String data_criacao_item)
        {
            this.data_criacao_item = data_criacao_item;
        }
        public item_atendimento Clone()
        {
            return (item_atendimento)this.MemberwiseClone();
        }
    }
}
