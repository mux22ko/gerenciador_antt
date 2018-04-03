using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    class tipo_endereco
    {
        //atributos
        int cod_tipo_endereco_pk;
        String nome_tipo_endereco;

        //Get & set
        public int getCod_tipo_endereco_pk()
        {
            return cod_tipo_endereco_pk;
        }
        public void setCod_tipo_endereco_pk(int cod_tipo_endereco_pk)
        {
            this.cod_tipo_endereco_pk = cod_tipo_endereco_pk;
        }
        public String getNome_tipo_endereco()
        {
            return nome_tipo_endereco;
        }
        public void setNome_tipo_endereco(String nome_tipo_endereco)
        {
            this.nome_tipo_endereco = nome_tipo_endereco;
        }
        //Get & set
    }
}