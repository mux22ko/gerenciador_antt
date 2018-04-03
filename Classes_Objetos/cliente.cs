using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    public class cliente
    {
        //atributos
        int cod_cliente_pk, 
	    cod_atendente_fk,
        cod_tipo_pessoa_fk;
        String cpfCnpj_cliente,
            rgIe_cliente,
            rntrc_cliente,
            nome_cliente,
            apelido_cliente,
            obs_cliente;
        Char estado_ativo_cliente;
        String data_cadastro_cliente;
        String data_nascimento_cliente;

        public int getCod_cliente_pk()
        {
            return cod_cliente_pk;
        }
        public void setCod_cliente_pk(int cod_cliente_pk)
        {
            this.cod_cliente_pk = cod_cliente_pk;
        }
        public int getCod_tipo_pessoa_fk()
        {
            return cod_tipo_pessoa_fk;
        }
        public void setCod_tipo_pessoa_fk(int cod_tipo_pessoa_fk)
        {
            this.cod_tipo_pessoa_fk = cod_tipo_pessoa_fk;
        }
        public int getCod_atendente_fk()
        {
            return cod_atendente_fk;
        }
        public void setCod_atendente_fk(int cod_atendente_fk)
        {
            this.cod_atendente_fk = cod_atendente_fk;
        }
        public String getCpfCnpj_cliente()
        {
            return cpfCnpj_cliente;
        }
        public void setCpfCnpj_cliente(String cpfCnpj_cliente)
        {
            this.cpfCnpj_cliente = cpfCnpj_cliente;
        }
        public String getRgIe_cliente()
        {
            return rgIe_cliente;
        }
        public void setRgIe_cliente(String rgIe_cliente)
        {
            this.rgIe_cliente = rgIe_cliente;
        }
        public String getRntrc_cliente()
        {
            return rntrc_cliente;
        }
        public void setRntrc_cliente(String rntrc_cliente)
        {
            this.rntrc_cliente = rntrc_cliente;
        }
        public String getNome_cliente()
        {
            return nome_cliente;
        }
        public void setNome_cliente(String nome_cliente)
        {
            this.nome_cliente = nome_cliente;
        }
        public String getApelido_cliente()
        {
            return apelido_cliente;
        }
        public void setApelido_cliente(String apelido_cliente)
        {
            this.apelido_cliente = apelido_cliente;
        }
        public String getObs_cliente()
        {
            return obs_cliente;
        }
        public void setObs_cliente(String obs_cliente)
        {
            this.obs_cliente = obs_cliente;
        }
        public Char getEstado_ativo_cliente()
        {
            return estado_ativo_cliente;
        }
        public void setEstado_ativo_cliente(Char estado_ativo_cliente)
        {
            this.estado_ativo_cliente = estado_ativo_cliente;
        }
        public String getData_cadastro_cliente()
        {
            return data_cadastro_cliente;
        }
        public void setData_cadastro_cliente(String data_cadastro_cliente)
        {
            this.data_cadastro_cliente = data_cadastro_cliente;
        }
        public String getData_nascimento_cliente()
        {
            return data_nascimento_cliente;
        }
        public void setData_nascimento_cliente(String data_nascimento_cliente)
        {
            try
            {
                this.data_nascimento_cliente = data_nascimento_cliente.Remove(10, 9);
            }
            catch
            {
                this.data_nascimento_cliente = data_nascimento_cliente;
            }
        }
    }
}
