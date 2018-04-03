using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    public class contato_cliente
    {
        //atributos
        int cod_contato_cliente_pk, 
            cod_cliente_fk,
            tipo_contato_fk,
            cod_atendente_fk;
        String texto_contato_cliente;
        String data_criacao_contato;

        #region GET SET
        public int getCod_contato_cliente_pk()
        {
            return cod_contato_cliente_pk;
        }
        public void setCod_contato_cliente_pk(int cod_contato_cliente_pk)
        {
            this.cod_contato_cliente_pk = cod_contato_cliente_pk;
        }
        public int getCod_cliente_fk()
        {
            return cod_cliente_fk;
        }
        public void setCod_cliente_fk(int cod_cliente_fk)
        {
            this.cod_cliente_fk = cod_cliente_fk;
        }
        public int getTipo_contato_fk()
        {
            return tipo_contato_fk;
        }
        public void setTipo_contato_fk(int tipo_contato_cliente_fk)
        {
            this.tipo_contato_fk = tipo_contato_cliente_fk;
        }
        public int getCod_atendente_fk()
        {
            return cod_atendente_fk;
        }
        public void setCod_atendente_fk(int cod_atendente_fk)
        {
            this.cod_atendente_fk = cod_atendente_fk;
        }
        public String getTexto_contato_cliente()
        {
            return texto_contato_cliente;
        }
        public void setTexto_contato_cliente(String texto_contato_cliente)
        {
            this.texto_contato_cliente = texto_contato_cliente;
        }
        public String getData_criacao_contato()
        {
            return data_criacao_contato;
        }
        public void setData_criacao_contato(String data_criacao_contato)
        {
            this.data_criacao_contato = data_criacao_contato;
        }
        #endregion 

        public contato_cliente Clone()
        {
            return (contato_cliente) this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            contato_cliente contato_clienteNovo = new contato_cliente();
            bool resultado = true;
            try
            {
                contato_clienteNovo = (contato_cliente)obj;
                if (!(contato_clienteNovo.getCod_contato_cliente_pk() == this.getCod_contato_cliente_pk()))
                { resultado = false; }
                if (!(contato_clienteNovo.getCod_cliente_fk() == this.getCod_cliente_fk()))
                { resultado = false; }
                if (!(contato_clienteNovo.getData_criacao_contato() == this.getData_criacao_contato()))
                { resultado = false; }
                if (!(contato_clienteNovo.getTexto_contato_cliente() == this.getTexto_contato_cliente()))
                { resultado = false; }
                if (!(contato_clienteNovo.getTipo_contato_fk() == this.getTipo_contato_fk()))
                { resultado = false; }
            }
            catch 
            {
                resultado = false;
            }
            return resultado;
        }
        public override int GetHashCode()
        { return base.GetHashCode(); }
    }
}
