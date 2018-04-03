using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using gerenciador_antt.Formularios;
using System.Drawing;
using Transitions;
using System.Threading;

namespace gerenciador_antt.Classes_Auxiliares
{
    class utilidades
    {
        #region TRATAMENTO DE VALORES
        public static String captarDate_dtpckr(DateTimePicker dtpck)
        {
            String resultado = "";
            resultado = dtpck.Value.Year + "-" + dtpck.Value.Month + "-" + dtpck.Value.Day;
            return resultado;
        }
        public static String captarDate_banco(String date)
        {
            String resultado = "";
            resultado = date.Substring(0, 2) + "/" + date.Substring(3, 2) + "/" + date.Substring(6, 4);
            return resultado;
        }
        public static DateTime captarDatetime_banco_paraDatetime(String data)
        {
            DateTime dataAlterada = new DateTime();
            try
            {
                dataAlterada =new DateTime(
                    Convert.ToInt32(data.Substring(6, 4)),Convert.ToInt32(data.Substring(3, 2)),Convert.ToInt32(data.Substring(0, 2)),Convert.ToInt32(data.Substring(11, 2)),Convert.ToInt32(data.Substring(14, 2)),Convert.ToInt32(data.Substring(17, 2)));
                return dataAlterada;
            }
            catch (Exception erro)
            {                
                MessageBox.Show("Data Erro:"+erro.Message);
                dataAlterada = new DateTime();
                return dataAlterada;
            }
        }
        public static Char verificarTipoPessoa_rbtn(RadioButton pessoaFisica, RadioButton pessoaJuridica)
        {
            if ((pessoaFisica.Checked)&&(pessoaJuridica.Checked==false))
            {
                return 'f';
            }
            else
            {
                return 'j';
            }
        }
        public static Char verificarTipoPessoa_doBanco(int tipo)
        {
            switch (tipo)
            {
                case 1:
                return 'f';
                case 2:
                return 'j';
                default:
                return ' ';
            }
        }        
        public static String captarContatoMascarado_confomeTipoContato(int cod_contato, String contato_semMascara)
        {            
            MaskedTextBox mascarado = new MaskedTextBox();
            try
            {
                int selecionado = cod_contato;                                
                switch (selecionado)
                {
                    case 2:
                    case 3:
                        mascarado.Mask = "(99)9999-99999";
                        break;
                    case 1:
                        mascarado.Mask = "";
                        break;
                    case 4:
                    case 5:
                        mascarado.Mask = "(99)9999-9999";
                        break;
                }
            }
            catch
            {
                //nada             
            }
            mascarado.Text = contato_semMascara;
            return mascarado.Text;
        }
        public static void selecionarMascara_confomeContato_msktxt(int cod_contato, MaskedTextBox mascarado)
        {
            //ids do banco que são selecionados no cbx!
            try
            {
                int selecionado = cod_contato;
                switch (selecionado)
                {
                    case 2:
                    case 3:
                        mascarado.Mask = "(99)9999-99999";
                        break;
                    case 1:
                        mascarado.Mask = "";
                        break;
                    case 4:
                    case 5:
                        mascarado.Mask = "(99)9999-9999";
                        break;
                }
            }
            catch
            {
                //nada             
            }
        }
        public static String captarCnpjCpfMascarado_confomeTipoPessoa(int tipo, String valorSemMascara)
        {
            MaskedTextBox mskd = new MaskedTextBox();
            if (utilidades.verificarTipoPessoa_doBanco(tipo).Equals('f'))
            { 
                mskd.Text=valorSemMascara;
                mskd.Mask="999,999,999-99";
                return mskd.Text;
            }
            else
            {
                mskd.Text=valorSemMascara;
                mskd.Mask="99,999,999/9999-99";
                return mskd.Text;
            }
        }
        public static String captarRntrcMascarado(String valorSemMascara)
        {
            MaskedTextBox mskd = new MaskedTextBox();           
            mskd.Text = valorSemMascara;
            mskd.Mask = "AAA-00000000";
            return mskd.Text;
        }
        public static String captarIeRgMascarado_confomeTipoPessoa(int tipo, String valorSemMascara)
        {
            MaskedTextBox mskd = new MaskedTextBox();
            if (utilidades.verificarTipoPessoa_doBanco(tipo).Equals('f'))
            {
                mskd.Text = valorSemMascara;
                mskd.Mask = "00,000,000-00";
                return mskd.Text;
            }
            else
            {
                mskd.Text = valorSemMascara;
                mskd.Mask = "000,000,000,000";
                return mskd.Text;
            }
        }
        public static String captarValorMascarado_semMascara(MaskedTextBox mascarado)
        {
            String mascara = mascarado.Mask;
            mascarado.Mask = "";
            String resultado = mascarado.Text;
            mascarado.Mask = mascara;
            return resultado.TrimStart().TrimEnd();
        }        
        public static bool verificarSelecionouUmResultado_dtgvw(DataGridView dtg)
        {
            //numero alusivo que não existe, pois é row index negativa!
            int numeroRow=-5;
            int colunasVisiveis = 0;
            foreach (DataGridViewColumn i in dtg.Columns)
            {
                if(i.Visible)
                {
                    colunasVisiveis++;
                }
            }
            int cont = 0;
            if (dtg.SelectedCells.Count == colunasVisiveis)
            {
               foreach(DataGridViewCell i in dtg.SelectedCells)
                {
                    cont++;
                    if (cont == 1)
                    {
                        //celula primeira: seto como parametro pros outro!
                        numeroRow = i.RowIndex;
                    }
                    else 
                    {
                        //testa se cada celula esta na mesma linha, senao retorna false!
                        if (i.RowIndex != numeroRow)
                        {
                            return false;
                        }
                    }
                   
                }
                return true;
            }
            return false;
        }
        public static String verificarTotalmentePagoBanco_paraExibicao(Char escolha)
        {
            switch(escolha)
            {
                case 's':
                    return "Pago";
                    
                case 'n':
                    return "Devendo";
                
                default:
                    return "";
            }
        }
        public static String captarValorMonetarioValido_paraExibicao(String valor)
        {
            try
            {
                Convert.ToDouble(valor.Replace(",", "."));
                if ((valor.Replace(",", ".").Split('.').Last().Length) < 2)
                {
                    valor = (Convert.ToDouble(valor.Replace(".", ","))).ToString().Replace(".", ",");
                }
                else
                {
                    valor = (Convert.ToDouble(valor.Replace(".", ","))).ToString().Replace(".", ",");
                }
                if ((valor.Replace(",", ".").Split('.').Count()) == 1)
                {
                        valor = valor + ",00";
                }
                return valor;
            }
            catch
            {
                return "0,00";
            }
        }
        public static int captarAlturaEspacoDoTexto(String texto, int tamanhodaTextoFonte)
        {
            TextBox txt = new TextBox();
            txt.Text = texto;
            return ((txt.Lines.Count() + 1) * Convert.ToInt32(tamanhodaTextoFonte));
        }
        public static Double calcularTroco(Double valorRecebido, Double valorAtendimento)
        {
            try
            {                
                Double resultado = Math.Round((valorRecebido - valorAtendimento), 2);
                return resultado;
            }
            catch 
            {
                throw new Exception("Erro de processo no cálculo do troco");
            } 
        }
        #endregion
       // falta takar maskara nodtgrivw
        #region TAREFAS
        public static bool checarConfigEfeitoInterface()
        {
            if (Properties.Settings.Default.efeitoInterface)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        public static void colocarTexto_observacoes(TextBox campoTexto)
        {
            //primeira etapa se tem a palavra chave de observações!
            if (!campoTexto.Text.Equals("Observações..."))
            {
                //deiferente da palavra chave de observações!
                campoTexto.ForeColor = Color.Black;
                if ((campoTexto.Text.Equals(String.Empty)) && (campoTexto.Focused == false))
                {
                    campoTexto.Text = "Observações...";
                    campoTexto.ForeColor = Color.LightSlateGray;
                }
                else 
                { }
            }
            else
            {
                //igual a palavra chave de observações!
                campoTexto.ForeColor = Color.LightSlateGray;

                //segunda etapa se ta focada pra alteração!
                if (campoTexto.Focused == true)
                {
                    campoTexto.Text = String.Empty;
                    campoTexto.ForeColor = Color.Black;
                }
                else
                {}
            }
            
        }
        public static bool checarDataIgual(DateTime menor, DateTime maior)
        {
            if (menor.Equals(maior))
            {
                return true;
            }
            else
            {
                return false;
            }
        }        
        public static Control verificarExistenciaControle_mesmoTipo(Control controle, Panel painel)
        {
            foreach (Control i in painel.Controls)
            {
                if (i.GetType() == controle.GetType())
                {
                    return i;
                }
            }
            return null;
        }
        public static void carregarConteudoPrincipal(Form formCliente, Panel painelConteudos, bool permitirDuplicata, Control controleAlvo)
        {
            //***************adiciono ou capto um ja carregado**********
            //Elementos base
            Control ctrlNaTela = null;
            Control ctrlForaTela = null;
            int vetorEspacoDentro = 0;
            //só é possivel manter uma tela do mesmo tipo na tela!
            if (permitirDuplicata == false)
            {
                //verifica a inexistencia de controle do mesmo tipo do controleAlvo a ser adicionado!
                if (verificarExistenciaControle_mesmoTipo(controleAlvo, painelConteudos) == null)
                {
                    //escondo!
                    controleAlvo.Visible = false;
                    //adiciono!
                    painelConteudos.Controls.Add(controleAlvo);
                }
                else
                {
                    //existindo, ele repega o controleAlvo ja recebido por parametro!
                    controleAlvo = verificarExistenciaControle_mesmoTipo(controleAlvo, painelConteudos);
                }
            }
            //é liberado carregar quantas telas forem necessarias na tela!
            else
            {
                //escondo!
                controleAlvo.Visible = false;
                //adiciono!
                painelConteudos.Controls.Add(controleAlvo);
            }
            //***********************Encontrá-lo e joga-lo na tela!************************************
            int contador = 0;
            //Percorro cada controle no painel vendo o tipo!
            foreach (Control i in painelConteudos.Controls)
            {
                contador++;
                //Encontrou!
                if ((i.GetType() == controleAlvo.GetType()))
                {
                    i.BringToFront();                   
                    i.Size = new Size(painelConteudos.Size.Width, painelConteudos.Size.Height);
                    i.Location = new Point(Convert.ToInt32((-1 * painelConteudos.Size.Width)), Convert.ToInt32((painelConteudos.Size.Height - i.Size.Height) / 2));
                    uc_identificacao identficacao;
                    identficacao = (uc_identificacao)controleAlvo;
                    //pega o primeiro controleAlvo ativo se existir!
                    try
                    {
                        if (ctrlForaTela.Controls.Count > 0)
                        {
                            identficacao = (uc_identificacao)ctrlForaTela;
                            Control ctr = (Control)identficacao.getControleAbas();
                            identficacao = (uc_identificacao)ctr.Controls[0];
                        }
                    }
                    catch { }
                    conteudos_dinamicos identCliente = (conteudos_dinamicos)formCliente;
                    identCliente.alterar_titulo_descricao_tela(identficacao.getTitulo(), identficacao.getDescricao());
                    //ver plz se tem aba aberta e pegar o nomedela.
                    i.Visible = false;
                }
            }
            //******************verifico quem esta fora e dentro da tela********************
            int cont = 1;
            foreach (Control i in painelConteudos.Controls)
            {
                //se for o primeiro e ja estiver fora da tela!
                if ((cont == 1) && (i.Left < painelConteudos.Left))
                {
                    ctrlForaTela = i;
                    if (painelConteudos.Controls.Count == 1)
                    {
                        break;
                    }
                }
                else
                {
                    //se for segundo controleAlvo e ja estiver fora da tela!
                    if ((cont == 2) && (i.Left < painelConteudos.Left))
                    {
                        ctrlForaTela = i;
                    }
                    else
                    {
                        //se for terceiro controleAlvo!
                        if (cont == 3)
                        {
                            break;
                        }
                        else
                        //se não for terceiro controleAlvo!
                        {
                            ctrlNaTela = i;

                        }
                    }
                }
                cont++;
            }
            //*******************fazer a mudança de quem esta dentro da tela pelo de fora****************
            if (!((ctrlForaTela == null) || (ctrlNaTela == null)))
            {
                int pontoEsquerdoDoFormEscondido = (ctrlForaTela.Width*-1);
                int espacinhoDentroForm = Convert.ToInt32(painelConteudos.Left) + vetorEspacoDentro;
                ctrlNaTela.SendToBack();
                ctrlForaTela.BringToFront();                
                //Filtro de configuração de efeito!
                if (checarConfigEfeitoInterface())
                {
                    Transition t = new Transition(new TransitionType_EaseInEaseOut(1000));
                    t.add(ctrlNaTela, "Left", -1 * ctrlNaTela.Width);
                    t.add(ctrlForaTela, "Left", espacinhoDentroForm);
                    t.run();
                }
                else
                {
                    ctrlNaTela.Left = pontoEsquerdoDoFormEscondido;
                    ctrlForaTela.Left = espacinhoDentroForm;                    
                }
                uc_identificacao identficacao;
                identficacao = (uc_identificacao)ctrlForaTela;
                //pega o primeiro controleAlvo ativo se existir!
                try
                {
                    if (ctrlForaTela.Controls.Count > 0)
                    {
                        identficacao = (uc_identificacao)ctrlForaTela;
                        Control ctr = (Control)identficacao.getControleAbas();
                        identficacao = (uc_identificacao)ctr.Controls[0];
                    }
                }
                catch { }
                conteudos_dinamicos identCliente = (conteudos_dinamicos)formCliente;
                identCliente.alterar_titulo_descricao_tela(identficacao.getTitulo(), identficacao.getDescricao());
                ctrlForaTela.Visible = true;
                ctrlNaTela.Visible = true;
            }
            else
            {
                if (((ctrlForaTela != null) && (ctrlNaTela == null)))
                {
                    int pontoEsquerdoDoFormEscondido = ctrlForaTela.Width;
                    int espacinhoDentroForm = Convert.ToInt32(painelConteudos.Left) + vetorEspacoDentro;
                    ctrlForaTela.BringToFront();
                    //Filtro de configuração de efeito!
                    if (checarConfigEfeitoInterface())
                    {
                        Transition t = new Transition(new TransitionType_EaseInEaseOut(1000));
                        t.add(ctrlForaTela, "Left", espacinhoDentroForm);
                        t.run();
                    }
                    else
                    {
                        ctrlForaTela.Left = espacinhoDentroForm;
                    }
                    uc_identificacao identficacao;
                    identficacao = (uc_identificacao)ctrlForaTela;
                    //pega o primeiro controleAlvo ativo se existir!
                    try
                    {
                        if (ctrlForaTela.Controls.Count > 0)
                        {
                            identficacao = (uc_identificacao)ctrlForaTela;
                            Control ctr = (Control)identficacao.getControleAbas();
                            identficacao = (uc_identificacao)ctr.Controls[0];
                        }
                    }
                    catch
                    { }
                    conteudos_dinamicos identCliente = (conteudos_dinamicos)formCliente;
                    identCliente.alterar_titulo_descricao_tela(identficacao.getTitulo(), identficacao.getDescricao());
                    ctrlForaTela.Visible = true;
                }
            }            
        }
        public static void carregarConteudoUControle(UserControl userControlCliente, Panel painelConteudos, bool permitirDuplicata, Control controleAlvo)
        {
            //************Adição do controle no painel******************
            //confirmo o tamanho do painel!
            painelConteudos.Size = new Size(Screen.GetBounds(userControlCliente.Parent.Parent).Width - 138, painelConteudos.Size.Height);
            //Elementos base
            Control ctrlNaTela = null;
            Control ctrlForaTela = null;
            //só é possivel manter uma tela do mesmo tipo na tela!
            if (permitirDuplicata == false)
            {
                //verifica a inexistencia de controle do mesmo tipo do controleAlvo a ser adicionado!
                if (verificarExistenciaControle_mesmoTipo(controleAlvo, painelConteudos) == null)
                {
                    //escondo!
                    controleAlvo.Visible = false;
                    //adiciono!
                    painelConteudos.Controls.Add(controleAlvo);
                }
                else
                {
                    //existindo, ele repega o controleAlvo ja recebido por parametro!
                    controleAlvo = verificarExistenciaControle_mesmoTipo(controleAlvo, painelConteudos);
                }
            }
            //é liberado carregar quantas telas forem necessarias na tela!
            else
            {
                //escondo!
                controleAlvo.Visible = false;
                //adiciono!
                painelConteudos.Controls.Add(controleAlvo);
            }
            //*************************Encontrá-lo e joga-lo na tela!************************
            int contador = 1;
            //Percorro cada controle no painel vendo o tipo!
            foreach (Control i in painelConteudos.Controls)
            {                
                //Encontrou um igual ao tipo pela ordem de chegada!
                if ((i.GetType() == controleAlvo.GetType()))
                {
                    //escondo
                    i.Visible = false;
                    //trago ao topo da ordem!
                    i.BringToFront();
                    //encaixo no painel
                    i.Size = new Size(painelConteudos.Size.Width, painelConteudos.Size.Height);
                    //fora da tela
                    i.Location = new Point(Convert.ToInt32((-1 * painelConteudos.Size.Width)), Convert.ToInt32((painelConteudos.Size.Height - i.Size.Height) / 2));
                    uc_identificacao identficacao;
                    identficacao = (uc_identificacao)i;
                    //pega o primeiro controleAlvo ativo se existir!
                    try
                    {
                        if (ctrlForaTela.Controls.Count > 0)
                        {
                            identficacao = (uc_identificacao)ctrlForaTela;
                            Control ctr = (Control)identficacao.getControleAbas();
                            identficacao = (uc_identificacao)ctr.Controls[0];
                        }
                    }
                    catch { }
                    conteudos_dinamicos identCliente = (conteudos_dinamicos)userControlCliente;
                    identCliente.alterar_titulo_descricao_tela(identficacao.getTitulo(), identficacao.getDescricao());
                    //ver plz se tem aba aberta e pegar o nomedela.                    
                }
                contador++;
            }
            //*****************identificar quem é que está na tela e fora dela*******************
            int cont = 1;
            foreach (Control i in painelConteudos.Controls)
            {
                //se for o primeiro e ja estiver fora da tela!
                if ((cont == 1) && (i.Left < painelConteudos.Left - 138))
                {
                    ctrlForaTela = i;
                    if (painelConteudos.Controls.Count == 1)
                    {
                        break;
                    }
                }
                else
                {
                    //se for segundo controleAlvo e ja estiver fora da tela!
                    if ((cont == 2) && (i.Left < painelConteudos.Left - 138))
                    {
                        ctrlForaTela = i;
                    }
                    else
                    {
                        //se for terceiro controleAlvo!
                        if (cont == 3)
                        {
                            break;
                        }
                        else
                        //se não for terceiro controleAlvo!
                        {
                            ctrlNaTela = i;

                        }
                    }
                }
                cont++;
            }
            //*************fazer a mudança de quem esta fora pelo de dentro da tela*************
            if (!((ctrlForaTela == null) || (ctrlNaTela == null)))
            {
                int pontoEsquerdoDoFormEscondido = ctrlForaTela.Width*-1;
                int espacinhoDentroForm = Convert.ToInt32(painelConteudos.Left - 138);
                ctrlNaTela.SendToBack();
                ctrlForaTela.BringToFront();
                //Filtro de configuração de efeito!
                if (checarConfigEfeitoInterface())
                {
                    Transition t = new Transition(new TransitionType_EaseInEaseOut(1000));
                    t.add(ctrlNaTela, "Left", pontoEsquerdoDoFormEscondido);
                    t.add(ctrlForaTela, "Left", espacinhoDentroForm);
                    t.run();
                }
                else
                {
                    ctrlNaTela.Left = pontoEsquerdoDoFormEscondido;
                    ctrlForaTela.Left = espacinhoDentroForm;
                }
                uc_identificacao identficacao;
                identficacao = (uc_identificacao)ctrlForaTela;
                //pega o primeiro controleAlvo ativo se existir!
                try
                {
                    if (ctrlForaTela.Controls.Count > 0)
                    {
                        identficacao = (uc_identificacao)ctrlForaTela;
                        Control ctr = (Control)identficacao.getControleAbas();
                        identficacao = (uc_identificacao)ctr.Controls[0];
                    }
                }
                catch { }
                conteudos_dinamicos identCliente = (conteudos_dinamicos)userControlCliente;
                identCliente.alterar_titulo_descricao_tela(identficacao.getTitulo(), identficacao.getDescricao());
                ctrlForaTela.Visible = true;
                ctrlNaTela.Visible = true;
            }
            else
            {
                if (((ctrlForaTela != null) && (ctrlNaTela == null)))
                {
                    int pontoEsquerdoDoFormEscondido = ctrlForaTela.Width;
                    int espacinhoDentroForm = Convert.ToInt32(painelConteudos.Left - 138);
                    ctrlForaTela.BringToFront();
                     //Filtro de configuração de efeito!
                    if (checarConfigEfeitoInterface())
                    {
                        Transition t = new Transition(new TransitionType_EaseInEaseOut(1000));
                        t.add(ctrlForaTela, "Left", espacinhoDentroForm);
                        t.run();
                    }
                    else
                    {
                        ctrlForaTela.Left = espacinhoDentroForm;
                    }
                    uc_identificacao identficacao;
                    identficacao = (uc_identificacao)ctrlForaTela;
                    //pega o primeiro controleAlvo ativo se existir!
                    try
                    {
                        if (ctrlForaTela.Controls.Count > 0)
                        {
                            identficacao = (uc_identificacao)ctrlForaTela;
                            Control ctr = (Control)identficacao.getControleAbas();
                            identficacao = (uc_identificacao)ctr.Controls[0];
                        }
                    }
                    catch
                    { }
                    conteudos_dinamicos identCliente = (conteudos_dinamicos)userControlCliente;
                    identCliente.alterar_titulo_descricao_tela(identficacao.getTitulo(), identficacao.getDescricao());
                    ctrlForaTela.Visible = true;
                }
            }            
        }
        public static void fecharEstaJanela_peloPaiDinamico(Control tela)
        {
            conteudos_dinamicos pai = (conteudos_dinamicos)tela.Parent.Parent;
            pai.fecharConteudoCarregado(tela);
        }
        public static void carregar_telaCarregando(Control telaAtual, int mensagemOpcao)
        {
            telaAtual.Controls.Add(new Uc_tela_carregando(mensagemOpcao));
        }
        public static void remover_telaCarregando(Control telaAtual)
        {
            foreach(Control i in telaAtual.Controls)
            {
                if (i.GetType() == typeof(Uc_tela_carregando))
                {
                    telaAtual.Controls.Remove(i);
                }
            }            
        }
        public static void selcionarCorrespondente_porValor(ComboBox combo, int valor)
        {
            try
            {
                int i = 0;
                for (i = 0; i < combo.Items.Count; i++)
                {
                    combo.SelectedItem = combo.Items[i];
                    if (Convert.ToInt32(combo.SelectedValue) == valor)
                    {
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Não consegui identificar o correspondente na caixa de opções: "+combo.GetHashCode());
            }
        }
        public static void alternarConteudosCarregadosUC(UserControl userControlCliente, Panel painelConteudos)
        {
            painelConteudos.Size = new Size(Screen.GetBounds(userControlCliente.Parent.Parent).Width - 138, painelConteudos.Size.Height);
            Array conteudos = new Control[painelConteudos.Controls.Count];
            Control ctrlNaTela = null;
            Control ctrlForaTela = null;
            int cont = 1;
            foreach (Control i in painelConteudos.Controls)
            {
                if (cont == 1)
                {
                    ctrlNaTela = i;
                }
                if (cont == 2)
                {
                    ctrlForaTela = i;
                }
                if (cont == 3)
                {
                    break;
                }
                cont++;       
            }
            if (!((ctrlForaTela == null) || (ctrlNaTela == null)))
            {
                int pontoEsquerdoDoFormEscondido = ctrlForaTela.Width * -1;
                int espacinhoDentroForm = Convert.ToInt32(painelConteudos.Left - 138);
                ctrlForaTela.Visible = true;
                ctrlNaTela.SendToBack();
                ctrlForaTela.BringToFront();
                //Filtro de configuração de efeito!
                if (checarConfigEfeitoInterface())
                {
                    Transition t = new Transition(new TransitionType_EaseInEaseOut(1000));
                    t.add(ctrlNaTela, "Left", pontoEsquerdoDoFormEscondido);
                    t.add(ctrlForaTela, "Left", espacinhoDentroForm);
                    t.run();
                }
                else 
                {
                    ctrlNaTela.Left = pontoEsquerdoDoFormEscondido;
                    ctrlForaTela.Left = espacinhoDentroForm;                    
                }
                conteudos_dinamicos identCliente = (conteudos_dinamicos)userControlCliente;
                uc_identificacao ui = (uc_identificacao)ctrlForaTela;
                identCliente.alterar_titulo_descricao_tela(ui.getTitulo(), ui.getDescricao());
            }
}
        public static void alternarConteudosCarregadosPrincipal(Form formCliente, Panel painelConteudos)
        {
            Array conteudos = new Control[painelConteudos.Controls.Count];
            Control ctrlNaTela = null;
            Control ctrlForaTela = null;
            int cont = 1;
            foreach (Control i in painelConteudos.Controls)
            {
                if (cont == 1)
                {
                    ctrlNaTela = i;
                }
                if (cont == 2)
                {
                    ctrlForaTela = i;
                }
                if (cont == 3)
                {
                    break;
                }
                cont++;
            }
            if (!((ctrlForaTela == null) || (ctrlNaTela == null)))
            {
                int pontoEsquerdoDoFormEscondido = ctrlForaTela.Width * -1;
                int espacinhoDentroForm = Convert.ToInt32(painelConteudos.Left);
                ctrlForaTela.Visible = true;
                ctrlNaTela.SendToBack();
                ctrlForaTela.BringToFront();
                //Filtro de configuração de efeito!
                if (checarConfigEfeitoInterface())
                {
                    Transition t = new Transition(new TransitionType_EaseInEaseOut(1000));
                    t.add(ctrlNaTela, "Left", pontoEsquerdoDoFormEscondido);
                    t.add(ctrlForaTela, "Left", espacinhoDentroForm);
                    t.run();
                }
                else
                {
                    ctrlNaTela.Left = pontoEsquerdoDoFormEscondido;
                    ctrlForaTela.Left = espacinhoDentroForm;
                }
                conteudos_dinamicos identCliente = (conteudos_dinamicos)formCliente;
                uc_identificacao ui = (uc_identificacao)ctrlForaTela;
                identCliente.alterar_titulo_descricao_tela(ui.getTitulo(), ui.getDescricao());
            }
        }
        public static void fecharConteudoCarregadoUC(Control controle, Panel painelConteudos) 
        {
            //fechando uma área!
            Array conteudos = new Control[painelConteudos.Controls.Count];
            Control ctrlNaTela = null;
            Control ctrlForaTela = null;
            painelConteudos.Controls.CopyTo(conteudos, 0);
            int cont = 0;
            foreach (Control i in painelConteudos.Controls)
            {
                if (cont == 0)
                {
                    ctrlNaTela = controle;
                }
                if (cont == 1)
                {
                    ctrlForaTela = i;
                }
                if (cont == 2)
                {
                    break;
                }
                cont++;
            }
            if (!((ctrlForaTela == null) || (ctrlNaTela == null)))
            {
                int pontoEsquerdoDoFormEscondido = ctrlForaTela.Width;
                int espacinhoDentroForm = Convert.ToInt32(painelConteudos.Left - 138);
                ctrlNaTela.SendToBack();
                ctrlForaTela.BringToFront();
                 //Filtro de configuração de efeito!
                if (checarConfigEfeitoInterface())
                {
                    Transition t = new Transition(new TransitionType_EaseInEaseOut(1000));
                    t.add(ctrlNaTela, "Left", -1 * ctrlNaTela.Width);
                    t.add(ctrlForaTela, "Left", espacinhoDentroForm);
                    t.run();
                }
                else
                {
                   ctrlNaTela.Left=(-1 * ctrlNaTela.Width);
                   ctrlForaTela.Left = espacinhoDentroForm;
                }
            }
            ctrlNaTela.Dispose();
        }
        public static void fecharConteudoCarregadoForm(Control controle, Panel painelConteudos)
        {
            //fechando uma área!
            Array conteudos = new Control[painelConteudos.Controls.Count];
            Control ctrlNaTela = null;
            Control ctrlForaTela = null;
            painelConteudos.Controls.CopyTo(conteudos, 0);
            int cont = 1;
            foreach (Control i in painelConteudos.Controls)
            {
                if (cont == 1)
                {
                    ctrlNaTela = controle;
                }
                if (cont == 2)
                {
                    ctrlForaTela = i;
                }
                if (cont == 3)
                {
                    break;
                }
                cont++;
            }
            if (!((ctrlForaTela == null) || (ctrlNaTela == null)))
            {
                int pontoEsquerdoDoFormEscondido = ctrlForaTela.Width;
                int espacinhoDentroForm = Convert.ToInt32(painelConteudos.Left);
                ctrlNaTela.SendToBack();
                ctrlForaTela.BringToFront();
                //Filtro de configuração de efeito!
                if (checarConfigEfeitoInterface())
                {
                    Transition t = new Transition(new TransitionType_EaseInEaseOut(1000));
                    t.add(ctrlNaTela, "Left", -1 * ctrlNaTela.Width);
                    t.add(ctrlForaTela, "Left", espacinhoDentroForm);
                    t.run();
                }
                else
                {
                    ctrlNaTela.Left = (-1 * ctrlNaTela.Width);
                    ctrlForaTela.Left = espacinhoDentroForm;
                }
            }
            ctrlNaTela.Dispose();
        }        
        #endregion
    }
}