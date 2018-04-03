using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    class tipo_pessoa
    {
        //atributos
        int cod_tipo_pessoa_pk;
        String nome_tipo_pessoa;

        //Get & set
        public int getCod_tipo_pessoa_pk()
        {
            return cod_tipo_pessoa_pk;
        }
        public void setCod_tipo_pessoa_pk(int cod_tipo_pessoa_pk)
        {
            this.cod_tipo_pessoa_pk = cod_tipo_pessoa_pk;
        }
        public String getNome_tipo_pessoa()
        {
            return nome_tipo_pessoa;
        }
        public void setNome_tipo_pessoa(String nome_tipo_pessoa)
        {
            this.nome_tipo_pessoa = nome_tipo_pessoa;
        }
        //Get & set
    }
}