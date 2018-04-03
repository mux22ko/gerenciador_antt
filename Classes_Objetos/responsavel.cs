using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    public class responsavel
    {
        //atributos
        int cod_responsavel_pk, 
	    cod_atendente_fk,
        cod_tipo_responsavel_responsavel_fk,
        cod_tipo_pessoa_fk;
        String cpfCnpj_responsavel,
            rgIe_responsavel,
            nome_responsavel,
            apelido_responsavel,
            obs_responsavel;
        Char estado_ativo_responsavel;
        String data_cadastro_responsavel;
        String data_nascimento_responsavel;

        public int getCod_responsavel_pk()
        {
            return cod_responsavel_pk;
        }
        public void setCod_responsavel_pk(int cod_responsavel_pk)
        {
            this.cod_responsavel_pk = cod_responsavel_pk;
        }
        public int getCod_tipo_pessoa_fk()
        {
            return cod_tipo_pessoa_fk;
        }
        public void setCod_tipo_pessoa_fk(int cod_tipo_pessoa_fk)
        {
            this.cod_tipo_pessoa_fk = cod_tipo_pessoa_fk;
        }
        public int getCod_tipo_responsavel_responsavel_fk()
        {
            return cod_tipo_responsavel_responsavel_fk;
        }
        public void setCod_tipo_responsavel_responsavel_fk(int cod_tipo_responsavel_responsavel_fk)
        {
            this.cod_tipo_responsavel_responsavel_fk = cod_tipo_responsavel_responsavel_fk;
        }
        public int getCod_atendente_fk()
        {
            return cod_atendente_fk;
        }
        public void setCod_atendente_fk(int cod_atendente_fk)
        {
            this.cod_atendente_fk = cod_atendente_fk;
        }
        public String getCpfCnpj_responsavel()
        {
            return cpfCnpj_responsavel;
        }
        public void setCpfCnpj_responsavel(String cpfCnpj_responsavel)
        {
            this.cpfCnpj_responsavel = cpfCnpj_responsavel;
        }
        public String getRgIe_responsavel()
        {
            return rgIe_responsavel;
        }
        public void setRgIe_responsavel(String rgIe_responsavel)
        {
            this.rgIe_responsavel = rgIe_responsavel;
        }       
        public String getNome_responsavel()
        {
            return nome_responsavel;
        }
        public void setNome_responsavel(String nome_responsavel)
        {
            this.nome_responsavel = nome_responsavel;
        }
        public String getApelido_responsavel()
        {
            return apelido_responsavel;
        }
        public void setApelido_responsavel(String apelido_responsavel)
        {
            this.apelido_responsavel = apelido_responsavel;
        }
        public String getObs_responsavel()
        {
            return obs_responsavel;
        }
        public void setObs_responsavel(String obs_responsavel)
        {
            this.obs_responsavel = obs_responsavel;
        }
        public Char getEstado_ativo_responsavel()
        {
            return estado_ativo_responsavel;
        }
        public void setEstado_ativo_responsavel(Char estado_ativo_responsavel)
        {
            this.estado_ativo_responsavel = estado_ativo_responsavel;
        }
        public String getData_cadastro_responsavel()
        {
            return data_cadastro_responsavel;
        }
        public void setData_cadastro_responsavel(String data_cadastro_responsavel)
        {
            this.data_cadastro_responsavel = data_cadastro_responsavel;
        }
        public String getData_nascimento_responsavel()
        {
            return data_nascimento_responsavel;
        }
        public void setData_nascimento_responsavel(String data_nascimento_responsavel)
        {
            try
            {
                this.data_nascimento_responsavel = data_nascimento_responsavel.Remove(10, 9);
            }
            catch
            {
                this.data_nascimento_responsavel = data_nascimento_responsavel;
            }
        }
    }
}
