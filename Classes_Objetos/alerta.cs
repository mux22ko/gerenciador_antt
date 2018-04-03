using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    class alerta
    {
        //atributos
        int cod_alerta_pk,
            cod_responsavel_fk,
            cod_cliente_fk;
        String titulo_alerta,
            descricao_alerta,
            observacao_alerta;
        String data_criacao_alerta;
        char tipo_alerta,
            estado_ativo_alerta;   

        //Get & Set
        public int getCod_alerta_pk()
        {
            return cod_alerta_pk;
        }
        public void setCod_alerta_pk(int cod_alerta_pk)
        {
            this.cod_alerta_pk = cod_alerta_pk;
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
        public String getTitulo_alerta()
        {
            return titulo_alerta;
        }
        public void setTitulo_alerta(String titulo_alerta)
        {
            this.titulo_alerta = titulo_alerta;
        }
        public String getDescricao_alerta()
        {
            return descricao_alerta;
        }
        public void setDescricao_alerta(String descricao_alerta)
        {
            this.descricao_alerta = descricao_alerta;
        }
        public String getObservacao_alerta()
        {
            return observacao_alerta;
        }
        public void setObservacao_alerta(String observacao_alerta)
        {
            this.observacao_alerta = observacao_alerta;
        }
        public String getData_criacao_alerta()
        {
            return data_criacao_alerta;
        }
        public void setData_criacao_alerta(String data_criacao_alerta)
        {
            this.data_criacao_alerta = data_criacao_alerta;
        }
        public char getTipo_alerta()
        {
            return tipo_alerta;
        }
        public void setTipo_alerta(char tipo_alerta)
        {
            this.tipo_alerta = tipo_alerta;
        }
        public char getEstado_ativo_alerta()
        {
            return estado_ativo_alerta;
        }
        public void setEstado_ativo_alerta(char estado_ativo_alerta)
        {
            this.estado_ativo_alerta = estado_ativo_alerta;
        }
        //Get & Set
    }
}