using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    public class endereco_cliente
    {
        //atributos
        int cod_endereco_cliente_pk,
            cod_tipo_endereco_fk,
            cod_atendente_fk,
            cod_cliente_fk;
        String texto_endereco_cliente;
        String data_criacao_endereco; //datetime

        #region GET SET
        public int getCod_endereco_cliente_pk()
        {
            return cod_endereco_cliente_pk;
        }
        public void setCod_endereco_cliente_pk(int cod_endereco_cliente_pk)
        {
            this.cod_endereco_cliente_pk = cod_endereco_cliente_pk;
        }
        public int getCod_tipo_endereco_fk()
        {
            return cod_tipo_endereco_fk;
        }
        public void setCod_tipo_endereco_fk(int cod_tipo_endereco_fk)
        {
            this.cod_tipo_endereco_fk = cod_tipo_endereco_fk;
        }
        public int getCod_atendente_fk()
        {
            return cod_atendente_fk;
        }
        public void setCod_atendente_fk(int cod_atendente_fk)
        {
            this.cod_atendente_fk = cod_atendente_fk;
        }
        public int getCod_cliente_fk()
        {
            return cod_cliente_fk;
        }
        public void setCod_cliente_fk(int cod_cliente_fk)
        {
            this.cod_cliente_fk = cod_cliente_fk;
        }
        public String getTexto_endereco_cliente()
        {
            return texto_endereco_cliente;
        }
        public void setTexto_endereco_cliente(String texto_endereco_cliente)
        {
            this.texto_endereco_cliente = texto_endereco_cliente;
        }
        public String getData_criacao_endereco()
        {
            return data_criacao_endereco;
        }
        public void setData_criacao_endereco(String data_criacao_endereco)
        {
            this.data_criacao_endereco = data_criacao_endereco;
        }
        #endregion

        public endereco_cliente Clone()
        {
            return (endereco_cliente)this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            endereco_cliente endereco_clienteNovo = new endereco_cliente();
            bool resultado = true;
            try
            {
                endereco_clienteNovo = (endereco_cliente)obj;
                if (!(endereco_clienteNovo.getCod_endereco_cliente_pk() == this.getCod_endereco_cliente_pk()))
                { resultado = false; }
                if (!(endereco_clienteNovo.getCod_cliente_fk() == this.getCod_cliente_fk()))
                { resultado = false; }
                if (!(endereco_clienteNovo.getData_criacao_endereco() == this.getData_criacao_endereco()))
                { resultado = false; }
                if (!(endereco_clienteNovo.getTexto_endereco_cliente() == this.getTexto_endereco_cliente()))
                { resultado = false; }
                if (!(endereco_clienteNovo.getCod_tipo_endereco_fk() == this.getCod_tipo_endereco_fk()))
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
