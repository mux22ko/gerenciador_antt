using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gerenciador_antt.Classes_Objetos
{
    public class atendente
    {
        //atributos
        int cod_atendente_pk;
        String cpf_atendente,
            rg_atendente,
            nome_atendente,
            apelido_atendente,
            email_atendente, 
            tel_atendente,
            cel_atendente,
            observacao_atendente,
            usuario_atendente,
            senha_atendente;
        String data_criacao_atendente;
        Char estado_ativo_atendente;      
        //*Get/Set
        public int getCod_atendente_pk()
        {
            return cod_atendente_pk;
        }
        public void setCod_atendente_pk(int cod_atendente_pk)
        {
            this.cod_atendente_pk = cod_atendente_pk;
        }
        public String getCpf_atendente()
        {
            return cpf_atendente;
        }
        public void setCpf_atendente(String cpf_atendente)
        {
            this.cpf_atendente = cpf_atendente;
        }
        public String getRg_atendente()
        {
            return rg_atendente;
        }
        public void setRg_atendente(String rg_atendente)
        {
            this.rg_atendente = rg_atendente;
        }
        public String getNome_atendente()
        {
            return nome_atendente;
        }
        public void setNome_atendente(String nome_atendente)
        {
            this.nome_atendente = nome_atendente;
        }
        public String getApelido_atendente()
        {
            return apelido_atendente;
        }
        public void setApelido_atendente(String apelido_atendente)
        {
            this.apelido_atendente = apelido_atendente;
        }
        public String getEmail_atendente()
        {
            return email_atendente;
        }
        public void setEmail_atendente(String email_atendente)
        {
            this.email_atendente = email_atendente;
        }
        public String getTel_atendente()
        {
            return tel_atendente;
        }
        public void setTel_atendente(String tel_atendente)
        {
            this.tel_atendente = tel_atendente;
        }
        public String getCel_atendente()
        {
            return cel_atendente;
        }
        public void setCel_atendente(String cel_atendente)
        {
            this.cel_atendente = cel_atendente;
        }
        public String getObservacao_atendente()
        {
            return observacao_atendente;
        }
        public void setObservacao_atendente(String observacao_atendente)
        {
            this.observacao_atendente = observacao_atendente;
        }
        public String getUsuario_atendente()
        {
            return usuario_atendente;
        }
        public void setUsuario_atendente(String usuario_atendente)
        {
            this.usuario_atendente = usuario_atendente;
        }
        public String getSenha_atendente()
        {
            return senha_atendente;
        }
        public void setSenha_atendente(String senha_atendente)
        {
            this.senha_atendente = senha_atendente;
        }
        public String getData_criacao_atendente()
        {
            return data_criacao_atendente;
        }
        public void setData_criacao_atendente(String data_criacao_atendente)
        {
            this.data_criacao_atendente = data_criacao_atendente;
        }
        public char getEstado_ativo_atendente()
        {
            return estado_ativo_atendente;
        }
        public void setEstado_ativo_atendente(char estado_ativo_atendente)
        {
            this.estado_ativo_atendente = estado_ativo_atendente;
        }  
        //*Get/Set
    }
}
