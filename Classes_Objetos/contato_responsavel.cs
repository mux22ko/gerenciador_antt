using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    public class contato_responsavel
    {
        //atributos
        int cod_contato_responsavel_pk, 
            cod_responsavel_fk,
            tipo_contato_fk,
            cod_atendente_fk;
        String texto_contato_responsavel;
        String data_criacao_contato;

        #region GET SET
        public int getCod_contato_responsavel_pk()
        {
            return cod_contato_responsavel_pk;
        }
        public void setCod_contato_responsavel_pk(int cod_contato_responsavel_pk)
        {
            this.cod_contato_responsavel_pk = cod_contato_responsavel_pk;
        }
        public int getCod_responsavel_fk()
        {
            return cod_responsavel_fk;
        }
        public void setCod_responsavel_fk(int cod_responsavel_fk)
        {
            this.cod_responsavel_fk = cod_responsavel_fk;
        }
        public int getTipo_contato_fk()
        {
            return tipo_contato_fk;
        }
        public void setTipo_contato_fk(int tipo_contato_responsavel_fk)
        {
            this.tipo_contato_fk = tipo_contato_responsavel_fk;
        }
        public int getCod_atendente_fk()
        {
            return cod_atendente_fk;
        }
        public void setCod_atendente_fk(int cod_atendente_fk)
        {
            this.cod_atendente_fk = cod_atendente_fk;
        }
        public String getTexto_contato_responsavel()
        {
            return texto_contato_responsavel;
        }
        public void setTexto_contato_responsavel(String texto_contato_responsavel)
        {
            this.texto_contato_responsavel = texto_contato_responsavel;
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

        public contato_responsavel Clone()
        {
            return (contato_responsavel)this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            contato_responsavel contato_responsavelNovo = new contato_responsavel();
            bool resultado = true;
            try
            {
                contato_responsavelNovo = (contato_responsavel)obj;
                if (!(contato_responsavelNovo.getCod_contato_responsavel_pk() == this.getCod_contato_responsavel_pk()))
                { resultado = false; }
                if (!(contato_responsavelNovo.getCod_responsavel_fk() == this.getCod_responsavel_fk()))
                { resultado = false; }
                if (!(contato_responsavelNovo.getData_criacao_contato() == this.getData_criacao_contato()))
                { resultado = false; }
                if (!(contato_responsavelNovo.getTexto_contato_responsavel() == this.getTexto_contato_responsavel()))
                { resultado = false; }
                if (!(contato_responsavelNovo.getTipo_contato_fk() == this.getTipo_contato_fk()))
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
