using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    class envio_correios_documento
    {
        //atributos
        int cod_envio_correios_documento,
            cod_cliente_fk,
            cod_endereco_cliente_fk,
            cod_atendiemnto_fk;
        String codigo_rastreio_envio_correios_documento,
            titulo_envio_correios_documento,
            descricao_envio_correios_documento;
        public int getCod_envio_correios_documento()
        {
            return cod_envio_correios_documento;
        }
        public void setCod_envio_correios_documento(int cod_envio_correios_documento)
        {
            this.cod_envio_correios_documento = cod_envio_correios_documento;
        }
        public int getCod_cliente_fk()
        {
            return cod_cliente_fk;
        }
        public void setCod_cliente_fk(int cod_cliente_fk)
        {
            this.cod_cliente_fk = cod_cliente_fk;
        }
        public int getCod_endereco_cliente_fk()
        {
            return cod_endereco_cliente_fk;
        }
        public void setCod_endereco_cliente_fk(int cod_endereco_cliente_fk)
        {
            this.cod_endereco_cliente_fk = cod_endereco_cliente_fk;
        }
        public int getCod_atendiemnto_fk()
        {
            return cod_atendiemnto_fk;
        }
        public void setCod_atendiemnto_fk(int cod_atendiemnto_fk)
        {
            this.cod_atendiemnto_fk = cod_atendiemnto_fk;
        }
        public String getCodigo_rastreio_envio_correios_documento()
        {
            return codigo_rastreio_envio_correios_documento;
        }
        public void setCodigo_rastreio_envio_correios_documento(
                String codigo_rastreio_envio_correios_documento)
        {
            this.codigo_rastreio_envio_correios_documento = codigo_rastreio_envio_correios_documento;
        }
        public String getTitulo_envio_correios_documento()
        {
            return titulo_envio_correios_documento;
        }
        public void setTitulo_envio_correios_documento(
                String titulo_envio_correios_documento)
        {
            this.titulo_envio_correios_documento = titulo_envio_correios_documento;
        }
        public String getDescricao_envio_correios_documento()
        {
            return descricao_envio_correios_documento;
        }
        public void setDescricao_envio_correios_documento(
                String descricao_envio_correios_documento)
        {
            this.descricao_envio_correios_documento = descricao_envio_correios_documento;
        }
 
    }
}