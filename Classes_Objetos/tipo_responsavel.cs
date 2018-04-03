using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    class tipo_responsavel
    {
        //atributos
        int cod_tipo_responsavel_pk;
        String nome_tipo_responsavel;

        //Get & set
        public int getCod_tipo_responsavel_pk()
        {
            return cod_tipo_responsavel_pk;
        }
        public void setCod_tipo_responsavel_pk(int cod_tipo_responsavel_pk)
        {
            this.cod_tipo_responsavel_pk = cod_tipo_responsavel_pk;
        }
        public String getNome_tipo_responsavel()
        {
            return nome_tipo_responsavel;
        }
        public void setNome_tipo_responsavel(String nome_tipo_responsavel)
        {
            this.nome_tipo_responsavel = nome_tipo_responsavel;
        }
    }
}