using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    public class atendimento
    {
        //atributos
        int cod_atendimento_pk, 
           cod_responsavel_fk,
           cod_atendente_fk,
           cod_cliente_fk;
        String observacao_atendimento;
        String data_criacao_atendimento;
        Char estado_pago_atendimento,
            estado_finalizado_atendimento,
            estado_ativo_atendimento;
       
        public int getCod_atendente_fk()
        {
            return cod_atendente_fk;
        }
        public void setCod_atendente_fk(int cod_atendente_fk)
        {
            this.cod_atendente_fk = cod_atendente_fk;
        }
        public int getCod_atendimento_pk()
        {
            return cod_atendimento_pk;
        }
        public void setCod_atendimento_pk(int cod_atendimento_pk)
        {
            this.cod_atendimento_pk = cod_atendimento_pk;
        }
        public int getCod_responsavel_fk()
        {
            return cod_responsavel_fk;
        }
        public void setCod_responsavel_fk(int cod_responsavel_fk)
        {
            this.cod_responsavel_fk = cod_responsavel_fk;
        }
        public int getCod_cliente_fk()
        {
            return cod_cliente_fk;
        }
        public void setCod_cliente_fk(int cod_cliente_fk)
        {
            this.cod_cliente_fk = cod_cliente_fk;
        }
        public String getObservacao_atendimento()
        {
            return observacao_atendimento;
        }
        public void setObservacao_atendimento(String observacao_atendimento)
        {
            this.observacao_atendimento = observacao_atendimento;
        }
        public String getData_criacao_atendimento()
        {
            return data_criacao_atendimento;
        }
        public void setData_criacao_atendimento(String data_criacao_atendimento)
        {
            this.data_criacao_atendimento = data_criacao_atendimento;
        }
        public char getEstado_pago_atendimento()
        {
            return estado_pago_atendimento;
        }
        public void setEstado_pago_atendimento(char estado_pago_atendimento)
        {
            this.estado_pago_atendimento = estado_pago_atendimento;
        }
        public char getEstado_finalizado_atendimento()
        {
            return estado_finalizado_atendimento;
        }
        public void setEstado_finalizado_atendimento(char estado_finalizado_atendimento)
        {
            this.estado_finalizado_atendimento = estado_finalizado_atendimento;
        }
        public char getEstado_ativo_atendimento()
        {
            return estado_ativo_atendimento;
        }
        public void setEstado_ativo_atendimento(char estado_ativo_atendimento)
        {
            this.estado_ativo_atendimento = estado_ativo_atendimento;
        }
    }
}