using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    class tipo_contato
    {
        //atributos
        int cod_tipo_contato_pk;
        String nome_tipo_contato;

        //Get & set
        public int getCod_tipo_contato_pk()
        {
            return cod_tipo_contato_pk;
        }
        public void setCod_tipo_contato_pk(int cod_tipo_contato_pk)
        {
            this.cod_tipo_contato_pk = cod_tipo_contato_pk;
        }
        public String getNome_tipo_contato()
        {
            return nome_tipo_contato;
        }
        public void setNome_tipo_contato(String nome_tipo_contato)
        {
            this.nome_tipo_contato = nome_tipo_contato;
        }
        //Get & set
    }
}