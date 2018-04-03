using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gerenciador_antt
{
    interface conteudos_dinamicos
    {
        void carregarConteudo_principal(Control controle, Boolean permitirExistenciaDuplicata);
        void alternarEntreConteudosCarregados();
        void fecharConteudoCarregado(Control controle);
        void alterar_titulo_descricao_tela(String titulo, String descricao);
        Panel getPainelConteudos();
    }
}
