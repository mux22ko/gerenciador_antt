using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    public class endereco_responsavel
    {
        //atributos
        int cod_endereco_responsavel_pk,
            cod_tipo_endereco_fk,
            cod_atendente_fk,
            cod_responsavel_fk;
        String texto_endereco_responsavel;
        String data_criacao_endereco; //datetime

        #region GET SET
        public int getCod_endereco_responsavel_pk()
        {
            return cod_endereco_responsavel_pk;
        }
        public void setCod_endereco_responsavel_pk(int cod_endereco_responsavel_pk)
        {
            this.cod_endereco_responsavel_pk = cod_endereco_responsavel_pk;
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
        public int getCod_responsavel_fk()
        {
            return cod_responsavel_fk;
        }
        public void setCod_responsavel_fk(int cod_responsavel_fk)
        {
            this.cod_responsavel_fk = cod_responsavel_fk;
        }
        public String getTexto_endereco_responsavel()
        {
            return texto_endereco_responsavel;
        }
        public void setTexto_endereco_responsavel(String texto_endereco_responsavel)
        {
            this.texto_endereco_responsavel = texto_endereco_responsavel;
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

        public endereco_responsavel Clone()
        {
            return (endereco_responsavel)this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            endereco_responsavel endereco_responsavelNovo = new endereco_responsavel();
            bool resultado = true;
            try
            {
                endereco_responsavelNovo = (endereco_responsavel)obj;
                if (!(endereco_responsavelNovo.getCod_endereco_responsavel_pk() == this.getCod_endereco_responsavel_pk()))
                { resultado = false; }
                if (!(endereco_responsavelNovo.getCod_responsavel_fk() == this.getCod_responsavel_fk()))
                { resultado = false; }
                if (!(endereco_responsavelNovo.getData_criacao_endereco() == this.getData_criacao_endereco()))
                { resultado = false; }
                if (!(endereco_responsavelNovo.getTexto_endereco_responsavel() == this.getTexto_endereco_responsavel()))
                { resultado = false; }
                if (!(endereco_responsavelNovo.getCod_tipo_endereco_fk() == this.getCod_tipo_endereco_fk()))
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
