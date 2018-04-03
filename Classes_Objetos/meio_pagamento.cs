using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    class meio_pagamento
    {
        //atributos
        int cod_meio_pgto_pk;
        String nome_meio_pgto;

        public int getCod_meio_pgto_pk()
        {
            return cod_meio_pgto_pk;
        }
        public void setCod_meio_pgto_pk(int cod_meio_pgto_pk)
        {
            this.cod_meio_pgto_pk = cod_meio_pgto_pk;
        }
        public String getNome_meio_pgto()
        {
            return nome_meio_pgto;
        }
        public void setNome_meio_pgto(String nome_meio_pgto)
        {
            this.nome_meio_pgto = nome_meio_pgto;
        }
    }
}
