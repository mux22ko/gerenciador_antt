using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    class documento
    {
        //atributos
        int cod_documento_pk,
            cod_item_atendimento_fk;
            String descricao_documento,
                local_documento,
                observacao_documento;
            Char estado_ativo_documento;

            public int getCod_documento_pk()
            {
                return cod_documento_pk;
            }
            public void setCod_documento_pk(int cod_documento_pk)
            {
                this.cod_documento_pk = cod_documento_pk;
            }
            public int getCod_item_atendimento_fk()
            {
                return cod_item_atendimento_fk;
            }
            public void setCod_item_atendimento_fk(int cod_item_atendimento_fk)
            {
                this.cod_item_atendimento_fk = cod_item_atendimento_fk;
            }
            public String getDescricao_documento()
            {
                return descricao_documento;
            }
            public void setDescricao_documento(String descricao_documento)
            {
                this.descricao_documento = descricao_documento;
            }
            public String getLocal_documento()
            {
                return local_documento;
            }
            public void setLocal_documento(String local_documento)
            {
                this.local_documento = local_documento;
            }
            public String getObservacao_documento()
            {
                return observacao_documento;
            }
            public void setObservacao_documento(String observacao_documento)
            {
                this.observacao_documento = observacao_documento;
            }
            public char getEstado_ativo_documento()
            {
                return estado_ativo_documento;
            }
            public void setEstado_ativo_documento(char estado_ativo_documento)
            {
                this.estado_ativo_documento = estado_ativo_documento;
            }

    }
}
