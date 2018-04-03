using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    public class pagamento
    {
        //atributos
        int cod_pagamento_pk,
            cod_atendente_fk,
            cod_meio_pgto_fk;
        Double valor_pagamento;
        Double troco_pagamento;
        String data_criacao_pagamento;
        String data_alteracao_pagamento;
        String observacao_pagamento;
        Char estado_ativo_pagamento;

        public int getCod_pagamento_pk()
        {
            return cod_pagamento_pk;
        }
        public void setCod_pagamento_pk(int cod_pagamento_pk)
        {
            this.cod_pagamento_pk = cod_pagamento_pk;
        }
        public int getCod_atendente_fk()
        {
            return cod_atendente_fk;
        }
        public void setCod_atendente_fk(int cod_atendente_fk)
        {
            this.cod_atendente_fk = cod_atendente_fk;
        }
        public int getCod_meio_pgto_fk()
        {
            return cod_meio_pgto_fk;
        }
        public void setCod_meio_pgto_fk(int cod_meio_pgto_fk)
        {
            this.cod_meio_pgto_fk = cod_meio_pgto_fk;
        }
        public Double getValor_pagamento()
        {
            return valor_pagamento;
        }
        public void setValor_pagamento(Double valor_pagamento)
        {
            this.valor_pagamento = valor_pagamento;
        }
        public Double getTroco_pagamento()
        {
            return troco_pagamento;
        }
        public void setTroco_pagamento(Double troco_pagamento)
        {
            this.troco_pagamento = troco_pagamento;
        }
        public String getData_criacao_pagamento()
        {
            return data_criacao_pagamento;
        }
        public void setData_criacao_pagamento(String data_criacao_pagamento)
        {
            this.data_criacao_pagamento = data_criacao_pagamento;
        }
        public String getData_alteracao_pagamento()
        {
            return data_alteracao_pagamento;
        }
        public void setData_alteracao_pagamento(String data_alteracao_pagamento)
        {
            this.data_alteracao_pagamento = data_alteracao_pagamento;
        }
        public String getObservacao_pagamento()
        {
            return observacao_pagamento;
        }
        public void setObservacao_pagamento(String observacao_pagamento)
        {
            this.observacao_pagamento = observacao_pagamento;
        }
        public char getEstado_ativo_pagamento()
        {
            return estado_ativo_pagamento;
        }
        public void setEstado_ativo_pagamento(char estado_ativo_pagamento)
        {
            this.estado_ativo_pagamento = estado_ativo_pagamento;
        }
    }
}