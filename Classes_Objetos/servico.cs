using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    class servico
    {
        //atributos
        int cod_tab_servico_pk,
            cod_atendente_fk;
        String descricao_servico,
               nome_servico;
        String data_criacao_servico,
            data_ultima_alteracao_servico;
        Char estado_ativo_servico;
        Double valor_servico;

        //Get & Set	
        public int getCod_tab_servico_pk()
        {
            return cod_tab_servico_pk;
        }
        public void setCod_tab_servico_pk(int cod_tab_servico_pk)
        {
            this.cod_tab_servico_pk = cod_tab_servico_pk;
        }
        public int getCod_atendente_fk()
        {
            return cod_atendente_fk;
        }
        public void setCod_atendente_fk(int cod_atendente_fk)
        {
            this.cod_atendente_fk = cod_atendente_fk;
        }
        public String getDescricao_servico()
        {
            return descricao_servico;
        }
        public void setDescricao_servico(String descricao_servico)
        {
            this.descricao_servico = descricao_servico;
        }
        public String getNome_servico()
        {
            return nome_servico;
        }
        public void setNome_servico(String nome_servico)
        {
            this.nome_servico = nome_servico;
        }
        public String getData_criacao_servico()
        {
            return data_criacao_servico;
        }
        public void setData_criacao_servico(String data_criacao_servico)
        {
            this.data_criacao_servico = data_criacao_servico;
        }
        public String getData_ultima_alteracao_servico()
        {
            return data_ultima_alteracao_servico;
        }
        public void setData_ultima_alteracao_servico(String data_ultima_alteracao_servico)
        {
            this.data_ultima_alteracao_servico = data_ultima_alteracao_servico;
        }
        public char getEstado_ativo_servico()
        {
            return estado_ativo_servico;
        }
        public void setEstado_ativo_servico(char estado_ativo_servico)
        {
            this.estado_ativo_servico = estado_ativo_servico;
        }
        public Double getValor_servico()
        {
            return valor_servico;
        }
        public void setValor_servico(Double valor_servico)
        {
            this.valor_servico = valor_servico;
        }
        //Get & Set	
    }
}
