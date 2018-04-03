using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    class problema
    {
        //atributos
        int cod_problema_pk,
            cod_responsavel_fk,
            cod_atendimento_fk;
        String descricao_problema,
            observacao_problema,
            titulo_problema;
        String data_criacao_problema;
        Char estado_ativo_problema;

        public int getCod_problema_pk()
        {
            return cod_problema_pk;
        }
        public void setCod_problema_pk(int cod_problema_pk)
        {
            this.cod_problema_pk = cod_problema_pk;
        }
        public int getCod_responsavel_fk()
        {
            return cod_responsavel_fk;
        }
        public void setCod_responsavel_fk(int cod_responsavel_fk)
        {
            this.cod_responsavel_fk = cod_responsavel_fk;
        }
        public int getCod_atendimento_fk()
        {
            return cod_atendimento_fk;
        }
        public void setCod_atendimento_fk(int cod_atendimento_fk)
        {
            this.cod_atendimento_fk = cod_atendimento_fk;
        }
        public String getDescricao_problema()
        {
            return descricao_problema;
        }
        public void setDescricao_problema(String descricao_problema)
        {
            this.descricao_problema = descricao_problema;
        }
        public String getObservacao_problema()
        {
            return observacao_problema;
        }
        public void setObservacao_problema(String observacao_problema)
        {
            this.observacao_problema = observacao_problema;
        }
        public String getTitulo_problema()
        {
            return titulo_problema;
        }
        public void setTitulo_problema(String titulo_problema)
        {
            this.titulo_problema = titulo_problema;
        }
        public String getData_criacao_problema()
        {
            return data_criacao_problema;
        }
        public void setData_criacao_problema(String data_criacao_problema)
        {
            this.data_criacao_problema = data_criacao_problema;
        }
        public char getEstado_ativo_problema()
        {
            return estado_ativo_problema;
        }
        public void setEstado_ativo_problema(char estado_ativo_problema)
        {
            this.estado_ativo_problema = estado_ativo_problema;
        }

    }
}
