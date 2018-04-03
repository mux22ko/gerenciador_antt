-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 25-Jun-2015 às 22:24
-- Versão do servidor: 5.6.17
-- PHP Version: 5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `gerenciador_antt`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_alerta`
--

CREATE TABLE IF NOT EXISTS `tab_alerta` (
  `cod_alerta_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_atendente_fk` int(11) NOT NULL,
  `cod_cliente_fk` int(11) NOT NULL COMMENT 'cod do cliente',
  `titulo_alerta` varchar(200) COLLATE utf8_bin NOT NULL,
  `tipo_alerta` char(1) COLLATE utf8_bin NOT NULL,
  `descricao_alerta` text COLLATE utf8_bin,
  `observacao_alerta` int(11) DEFAULT NULL,
  `estado_ativo_alerta` char(1) COLLATE utf8_bin NOT NULL DEFAULT 's' COMMENT 's= sim n = nao',
  `data_criacao_alerta` datetime NOT NULL,
  PRIMARY KEY (`cod_alerta_pk`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_atendente`
--

CREATE TABLE IF NOT EXISTS `tab_atendente` (
  `cod_atendente_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cpf_atendente` varchar(11) COLLATE utf8_bin NOT NULL,
  `rg_atendente` varchar(11) COLLATE utf8_bin NOT NULL,
  `nome_atendente` varchar(100) COLLATE utf8_bin NOT NULL,
  `apelido_atendente` varchar(30) COLLATE utf8_bin DEFAULT '',
  `email_atendente` varchar(100) COLLATE utf8_bin DEFAULT '',
  `tel_atendente` varchar(30) COLLATE utf8_bin DEFAULT '',
  `cel_atendente` varchar(30) COLLATE utf8_bin DEFAULT '',
  `observacao_atendente` text COLLATE utf8_bin,
  `usuario_atendente` varchar(50) COLLATE utf8_bin NOT NULL,
  `senha_atendente` varchar(50) COLLATE utf8_bin NOT NULL,
  `estado_ativo_atendente` char(1) COLLATE utf8_bin NOT NULL DEFAULT 's' COMMENT 's = sim n = nao',
  `data_criacao_atendente` datetime NOT NULL,
  PRIMARY KEY (`cod_atendente_pk`),
  UNIQUE KEY `cpf_at` (`cpf_atendente`,`rg_atendente`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=2 ;

--
-- Extraindo dados da tabela `tab_atendente`
--

INSERT INTO `tab_atendente` (`cod_atendente_pk`, `cpf_atendente`, `rg_atendente`, `nome_atendente`, `apelido_atendente`, `email_atendente`, `tel_atendente`, `cel_atendente`, `observacao_atendente`, `usuario_atendente`, `senha_atendente`, `estado_ativo_atendente`, `data_criacao_atendente`) VALUES
(1, '53815664683', '4756877902', 'Matheus Moraes', 'Teteu', 'matheus@gmail.com', '19368564678', '9978857541', 'Tanquilão!', 'matheus', '12345', 's', '2015-07-02 09:50:00');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_atendimento`
--

CREATE TABLE IF NOT EXISTS `tab_atendimento` (
  `cod_atendimento_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_responsavel_fk` int(11) DEFAULT NULL COMMENT 'codigo do resposnavel pelo cliente',
  `cod_atendente_fk` int(11) NOT NULL COMMENT 'codigo do atendente',
  `cod_cliente_fk` int(11) NOT NULL COMMENT 'codigo do cliente',
  `estado_pago_atendimento` char(1) COLLATE utf8_bin NOT NULL DEFAULT 'n' COMMENT 's=sim n=nao',
  `estado_finalizado_atendimento` char(1) COLLATE utf8_bin NOT NULL DEFAULT 'n' COMMENT 's=sim n=nao',
  `estado_ativo_atendimento` char(1) COLLATE utf8_bin NOT NULL DEFAULT 's' COMMENT 's=sim n=nao',
  `data_criacao_atendimento` datetime NOT NULL,
  `observacao_atendimento` text COLLATE utf8_bin,
  PRIMARY KEY (`cod_atendimento_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=5 ;

--
-- Extraindo dados da tabela `tab_atendimento`
--

INSERT INTO `tab_atendimento` (`cod_atendimento_pk`, `cod_responsavel_fk`, `cod_atendente_fk`, `cod_cliente_fk`, `estado_pago_atendimento`, `estado_finalizado_atendimento`, `estado_ativo_atendimento`, `data_criacao_atendimento`, `observacao_atendimento`) VALUES
(1, 3, 1, 0, 's', 'n', 's', '2015-06-22 16:08:03', ''),
(2, 0, 1, 2, 's', 'n', 's', '2015-06-23 11:27:30', 'Bao'),
(3, 3, 1, 0, 's', 'n', 's', '2015-06-25 11:25:03', '');

--
-- Acionadores `tab_atendimento`
--
DROP TRIGGER IF EXISTS `depoisDeInsert_atendimento`;
DELIMITER //
CREATE TRIGGER `depoisDeInsert_atendimento` AFTER INSERT ON `tab_atendimento`
 FOR EACH ROW INSERT INTO tab_dbg_atendimento (
    cod_atendimento_fk, 
    valor_atendimento_epoca,
    cod_atendente_epoca,
    data_criacao
    ) VALUES (
        NEW.cod_atendimento_pk,
        (SELECT SUM(valor_combinado_item_atendimento) FROM tab_item_atendimento TIA WHERE TIA.cod_atendimento_FK = NEW.cod_atendimento_pK),
        NEW.cod_atendente_fk,
        NOW())
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_cliente`
--

CREATE TABLE IF NOT EXISTS `tab_cliente` (
  `cod_cliente_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_atendente_fk` int(11) NOT NULL,
  `cod_tipo_pessoa_fk` int(11) DEFAULT NULL,
  `data_cadastro_cliente` datetime NOT NULL,
  `data_nascimento_cliente` date DEFAULT NULL,
  `cpfCnpj_cliente` varchar(18) COLLATE utf8_bin DEFAULT NULL,
  `rgIe_cliente` varchar(15) COLLATE utf8_bin DEFAULT NULL,
  `rntrc_cliente` varchar(12) COLLATE utf8_bin DEFAULT NULL,
  `nome_cliente` varchar(100) COLLATE utf8_bin NOT NULL,
  `apelido_cliente` varchar(30) COLLATE utf8_bin DEFAULT NULL,
  `obs_cliente` text COLLATE utf8_bin,
  `estado_ativo_cliente` char(1) COLLATE utf8_bin NOT NULL DEFAULT 's' COMMENT 's=sim n=nao',
  PRIMARY KEY (`cod_cliente_pk`),
  UNIQUE KEY `cod_cliente_pk` (`cod_cliente_pk`),
  KEY `cod_cliente_pk_2` (`cod_cliente_pk`),
  KEY `cod_cliente_pk_3` (`cod_cliente_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=9 ;

--
-- Extraindo dados da tabela `tab_cliente`
--

INSERT INTO `tab_cliente` (`cod_cliente_pk`, `cod_atendente_fk`, `cod_tipo_pessoa_fk`, `data_cadastro_cliente`, `data_nascimento_cliente`, `cpfCnpj_cliente`, `rgIe_cliente`, `rntrc_cliente`, `nome_cliente`, `apelido_cliente`, `obs_cliente`, `estado_ativo_cliente`) VALUES
(1, 1, 1, '2015-06-19 16:36:02', '2014-11-18', '72574425251', '7467876854', '68634336563', 'Joélson Bezerra Nunes', 'Nene', 'Pessoa boa!', 's'),
(2, 1, 1, '2015-06-22 16:04:27', '1987-05-13', '60678534853', '5486786754', '68768769776', 'Marcos Feliciano Nunes', 'Neco', '', 's'),
(3, 1, 1, '2015-06-25 11:10:13', '1997-06-10', '71313551350', '3543453543', '89564678954', 'Marconde Morales', '', 'Sim legal!', 's'),
(4, 1, 2, '2015-06-25 11:12:02', '1996-06-14', '75275956000103', '535355665566', '23432432432', 'Saraievo Bentolino .me', 'TransAzucar', '', 's'),
(5, 1, 1, '2015-06-25 11:13:52', '1995-01-09', '71553633083', '4545544515', '87686486483', 'Ven laore', 'lala', '', 's'),
(6, 1, 2, '2015-06-25 11:15:36', '1960-01-01', '41198625000197', '596535635665', '73748484848', 'Teobaldo Servero.ME', 'Transcorinthuians', '', 's'),
(7, 1, 1, '2015-06-25 16:05:45', '1991-07-16', '21373875658', '4878476575', '54345626546', 'Marcio Candido', 'Jolezo', 'New', 's'),
(8, 1, 1, '2015-06-25 16:06:56', '1985-03-16', '49353381053', '8678676873', '33453453453', 'Pedro Bó', 'pbo', '', 's');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_contato_cliente`
--

CREATE TABLE IF NOT EXISTS `tab_contato_cliente` (
  `cod_contato_cliente_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_cliente_fk` int(11) NOT NULL DEFAULT '0',
  `tipo_contato_fk` int(11) NOT NULL DEFAULT '0',
  `cod_atendente_fk` int(11) NOT NULL DEFAULT '0',
  `texto_contato_cliente` varchar(50) COLLATE utf8_bin NOT NULL,
  `data_criacao_contato` datetime NOT NULL,
  PRIMARY KEY (`cod_contato_cliente_pk`),
  UNIQUE KEY `cod_contato_cliente_pk_2` (`cod_contato_cliente_pk`),
  KEY `cod_contato_cliente_pk` (`cod_contato_cliente_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=9 ;

--
-- Extraindo dados da tabela `tab_contato_cliente`
--

INSERT INTO `tab_contato_cliente` (`cod_contato_cliente_pk`, `cod_cliente_fk`, `tipo_contato_fk`, `cod_atendente_fk`, `texto_contato_cliente`, `data_criacao_contato`) VALUES
(1, 1, 2, 1, '19999998774', '2015-06-19 16:36:02'),
(2, 2, 3, 1, '19997878916', '2015-06-22 16:04:27'),
(3, 3, 1, 1, 'mm.mrl@gmail.com', '2015-06-25 11:10:13'),
(4, 4, 3, 1, '99745454212', '2015-06-25 11:12:02'),
(5, 5, 4, 1, '1965656454', '2015-06-25 11:13:52'),
(6, 6, 5, 1, '1946573573', '2015-06-25 11:15:36'),
(7, 7, 4, 1, '555555555', '2015-06-25 16:05:45'),
(8, 8, 3, 1, '54545645645', '2015-06-25 16:06:56');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_contato_responsavel`
--

CREATE TABLE IF NOT EXISTS `tab_contato_responsavel` (
  `cod_contato_responsavel_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_responsavel_fk` int(11) NOT NULL DEFAULT '0',
  `tipo_contato_fk` int(11) NOT NULL DEFAULT '0',
  `cod_atendente_fk` int(11) NOT NULL DEFAULT '0',
  `texto_contato_responsavel` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `data_criacao_contato` datetime NOT NULL,
  PRIMARY KEY (`cod_contato_responsavel_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Extraindo dados da tabela `tab_contato_responsavel`
--

INSERT INTO `tab_contato_responsavel` (`cod_contato_responsavel_pk`, `cod_responsavel_fk`, `tipo_contato_fk`, `cod_atendente_fk`, `texto_contato_responsavel`, `data_criacao_contato`) VALUES
(1, 2, 5, 1, '(19)3945-6665', '2015-06-19 16:51:51'),
(2, 2, 1, 1, 'manoel_ceo@gmail.com', '2015-06-19 16:51:51'),
(3, 3, 1, 1, 'carlper@gmail.com', '2015-06-19 16:54:55'),
(4, 4, 1, 1, 'jasse@comjopssa.com.br', '2015-06-22 16:06:42');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_dbg_atendimento`
--

CREATE TABLE IF NOT EXISTS `tab_dbg_atendimento` (
  `cod_dbg_atendimento` int(11) NOT NULL AUTO_INCREMENT,
  `cod_atendimento_fk` int(11) NOT NULL,
  `valor_atendimento_epoca` double NOT NULL,
  `cod_atendente_epoca` int(11) NOT NULL,
  `data_criacao` datetime NOT NULL,
  PRIMARY KEY (`cod_dbg_atendimento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_dbg_pagamento_atendimento`
--

CREATE TABLE IF NOT EXISTS `tab_dbg_pagamento_atendimento` (
  `cod_dbg_pagamento_atendimento` int(11) NOT NULL AUTO_INCREMENT,
  `cod_atendimento_fk` double NOT NULL,
  `cod_pagamento_fk` double NOT NULL,
  `estado_atendimento_pago` char(1) COLLATE utf8_bin NOT NULL,
  `estado_dado` char(1) COLLATE utf8_bin NOT NULL COMMENT 'N = novo A = antigo',
  `data_movimentacao` datetime NOT NULL,
  `valor_fatia_pagamento` double NOT NULL,
  `operacao` char(1) COLLATE utf8_bin NOT NULL COMMENT 'u = update i = insert d = delete',
  PRIMARY KEY (`cod_dbg_pagamento_atendimento`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=15 ;

--
-- Extraindo dados da tabela `tab_dbg_pagamento_atendimento`
--

INSERT INTO `tab_dbg_pagamento_atendimento` (`cod_dbg_pagamento_atendimento`, `cod_atendimento_fk`, `cod_pagamento_fk`, `estado_atendimento_pago`, `estado_dado`, `data_movimentacao`, `valor_fatia_pagamento`, `operacao`) VALUES
(1, 1, 3, 's', 'a', '2015-06-23 11:21:00', 3.56, 'u'),
(2, 1, 3, 'n', 'n', '2015-06-23 11:21:00', 2, 'u'),
(3, 1, 3, 'n', 'a', '2015-06-23 11:21:20', 2, 'u'),
(4, 1, 3, 's', 'n', '2015-06-23 11:21:20', 3.56, 'u'),
(5, 1, 1, 's', 'n', '2015-06-23 11:31:34', 1, 'i'),
(6, 1, 1, 's', 'a', '2015-06-23 11:31:43', 1, 'd'),
(7, 1, 1, 's', 'a', '2015-06-23 11:59:34', 15, 'd'),
(8, 1, 3, 'n', 'a', '2015-06-23 12:02:23', 3.56, 'd'),
(9, 2, 3, 'n', 'n', '2015-06-23 12:02:23', 5, 'i'),
(10, 1, 1, 's', 'n', '2015-06-23 12:04:35', 18.56, 'i'),
(11, 3, 4, 's', 'n', '2015-06-25 11:31:40', 23.56, 'i'),
(12, 2, 5, 's', 'n', '2015-06-25 11:32:03', 54.45, 'i'),
(13, 3, 4, 'n', 'a', '2015-06-25 11:38:21', 23.56, 'u'),
(14, 3, 4, 's', 'n', '2015-06-25 11:38:21', 5.56, 'u');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_documento`
--

CREATE TABLE IF NOT EXISTS `tab_documento` (
  `cod_documento_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_item_atendimento_fk` int(11) NOT NULL COMMENT 'codigo do item de atendimento',
  `descricao_documento` text COLLATE utf8_bin,
  `local_documento` varchar(500) COLLATE utf8_bin DEFAULT NULL,
  `observacao_documento` text COLLATE utf8_bin,
  `estado_ativo_documento` char(1) COLLATE utf8_bin NOT NULL DEFAULT 's' COMMENT 's=sim n=nao',
  `cod_atendente_fk` int(11) NOT NULL,
  PRIMARY KEY (`cod_documento_pk`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_endereco_cliente`
--

CREATE TABLE IF NOT EXISTS `tab_endereco_cliente` (
  `cod_endereco_cliente_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_tipo_endereco_fk` int(11) NOT NULL,
  `cod_atendente_fk` int(11) NOT NULL COMMENT 'quem fez o registro',
  `cod_cliente_fk` int(11) NOT NULL,
  `texto_endereco_cliente` text COLLATE utf8_bin NOT NULL,
  `data_criacao_endereco` datetime NOT NULL COMMENT 'data da craição do registro',
  PRIMARY KEY (`cod_endereco_cliente_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=9 ;

--
-- Extraindo dados da tabela `tab_endereco_cliente`
--

INSERT INTO `tab_endereco_cliente` (`cod_endereco_cliente_pk`, `cod_tipo_endereco_fk`, `cod_atendente_fk`, `cod_cliente_fk`, `texto_endereco_cliente`, `data_criacao_endereco`) VALUES
(1, 1, 1, 1, 'Endereço: Casemiro Souza, nº45\r\nBairro: Itapuã\r\nComplemento: Segundo Barracão\r\nCidade: São Paulo\r\nCEP: 13972-244\r\n', '2015-06-19 16:36:02'),
(2, 1, 1, 2, 'Endereço: Coronel Juscelino, nº45\r\nBairro: Tamaré \r\nComplemento: Casa\r\nCidade: Juvenus/SP\r\nCEP: 19279-563\r\n', '2015-06-22 16:04:27'),
(3, 2, 1, 3, 'Endereço: Vitascine, n º34\r\nBairro: Itpueva\r\nComplemento: casa \r\nCidade: Saraiva/SP\r\nCEP: 19687-984\r\n', '2015-06-25 11:10:13'),
(4, 2, 1, 4, 'Endereço: Zambunba, nº56\r\nBairro: Carioca\r\nComplemento: casa \r\nCidade: Paraiso/SP\r\nCEP: 12198-789\r\n', '2015-06-25 11:12:02'),
(5, 1, 1, 5, 'Endereço: Farinzeres, nº5677\r\nBairro: Peralto\r\nComplemento: barracao\r\nCidade: Fernandes/SC\r\nCEP: 15678-877', '2015-06-25 11:13:52'),
(6, 2, 1, 6, 'Endereço: Paricipeces, nº56\r\nBairro: Pegoraldo\r\nComplemento: casa\r\nCidade: Itapura/SP\r\nCEP: 12379-454\r\n', '2015-06-25 11:15:36'),
(7, 1, 1, 7, 'Endereço: Yalto, nº56\r\nBairro: Zoraio\r\nComplemento: casa \r\nCidade: Itapeva\r\nCEP: 13876-456\r\n', '2015-06-25 16:05:45'),
(8, 1, 1, 8, 'Endereço: Grotos de bortas, nº56\r\nBairro: Jubeba\r\nComplemento: casa \r\nCidade: Valkyr/DF\r\nCEP: 15767-896\r\n', '2015-06-25 16:06:56');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_endereco_responsavel`
--

CREATE TABLE IF NOT EXISTS `tab_endereco_responsavel` (
  `cod_endereco_responsavel_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_tipo_endereco_fk` int(11) NOT NULL,
  `cod_atendente_fk` int(11) NOT NULL COMMENT 'quem fez o registro',
  `cod_responsavel_fk` int(11) NOT NULL,
  `data_criacao_endereco` datetime NOT NULL COMMENT 'data da craição do registro',
  `texto_endereco_responsavel` text,
  PRIMARY KEY (`cod_endereco_responsavel_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Extraindo dados da tabela `tab_endereco_responsavel`
--

INSERT INTO `tab_endereco_responsavel` (`cod_endereco_responsavel_pk`, `cod_tipo_endereco_fk`, `cod_atendente_fk`, `cod_responsavel_fk`, `data_criacao_endereco`, `texto_endereco_responsavel`) VALUES
(1, 1, 1, 1, '2015-06-19 09:46:29', 'Endereço: Avenda Camburipu\r\nBairro: Dramantina\r\nComplemento: casa\r\nCidade: São Paulo\r\nCEP: 14669-589\r\n'),
(2, 1, 1, 2, '2015-06-19 16:51:51', 'Endereço: França, nº56\r\nBairro: Barroso\r\nComplemento: Casa\r\nCidade: São Paulo\r\nCEP: 19676-846\r\n'),
(3, 2, 1, 3, '2015-06-19 16:54:55', 'Endereço:  Paredes Brancas, nº65\r\nBairro: Solaço\r\nComplemento: Loja \r\nCidade: Mendes/MG\r\nCEP: 18374-487\r\n'),
(4, 1, 1, 4, '2015-06-22 16:06:42', 'Endereço: Kossawva, n90\r\nBairro: Fratzki\r\nComplemento: casa \r\nCidade: Juracema/SP\r\nCEP: 13857-185\r\n');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_envio_correios_documento`
--

CREATE TABLE IF NOT EXISTS `tab_envio_correios_documento` (
  `cod_envio_correios_documento` int(11) NOT NULL AUTO_INCREMENT,
  `cod_cliente_fk` int(11) NOT NULL,
  `cod_endereco_cliente_fk` int(11) NOT NULL,
  `cod_atendiemnto_fk` int(11) NOT NULL,
  `codigo_rastreio_envio_correios_documento` varchar(20) COLLATE utf8_bin NOT NULL,
  `titulo_envio_correios_documento` int(11) DEFAULT NULL,
  `descricao_envio_correios_documento` int(11) DEFAULT NULL,
  `cod_atendente_fk` int(11) NOT NULL,
  `data_criacao_envio_correios_documento` date NOT NULL,
  PRIMARY KEY (`cod_envio_correios_documento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_item_atendimento`
--

CREATE TABLE IF NOT EXISTS `tab_item_atendimento` (
  `cod_item_atendimento_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_servico_fk` int(11) NOT NULL COMMENT 'codigo do servico',
  `cod_atendente_fk` int(11) NOT NULL COMMENT 'quem fez o registro',
  `detalhe_item_atendimento` text COLLATE utf8_bin,
  `valor_combinado_item_atendimento` double NOT NULL COMMENT 'valor acordado no dia do atendimento',
  `data_criacao_item_atendimento` datetime NOT NULL COMMENT 'data de criacao do regstro',
  `cod_atendimento_fk` int(11) NOT NULL,
  PRIMARY KEY (`cod_item_atendimento_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=6 ;

--
-- Extraindo dados da tabela `tab_item_atendimento`
--

INSERT INTO `tab_item_atendimento` (`cod_item_atendimento_pk`, `cod_servico_fk`, `cod_atendente_fk`, `detalhe_item_atendimento`, `valor_combinado_item_atendimento`, `data_criacao_item_atendimento`, `cod_atendimento_fk`) VALUES
(1, 1, 1, 'sem borda de metal', 23.56, '2015-06-22 16:08:03', 1),
(2, 1, 1, 'sem borda de metal', 23.56, '2015-06-23 11:27:30', 2),
(3, 2, 1, 'sem plastico', 35.89, '2015-06-23 11:27:30', 2),
(5, 1, 1, 'sem borda de metal', 5.56, '2015-06-25 11:33:08', 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_meio_pgto`
--

CREATE TABLE IF NOT EXISTS `tab_meio_pgto` (
  `cod_meio_pgto_pk` int(11) NOT NULL AUTO_INCREMENT,
  `nome_meio_pgto` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  PRIMARY KEY (`cod_meio_pgto_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=3 ;

--
-- Extraindo dados da tabela `tab_meio_pgto`
--

INSERT INTO `tab_meio_pgto` (`cod_meio_pgto_pk`, `nome_meio_pgto`) VALUES
(1, 'Dinheiro'),
(2, 'Cheque');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_pagamento`
--

CREATE TABLE IF NOT EXISTS `tab_pagamento` (
  `cod_pagamento_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_atendente_fk` int(11) NOT NULL,
  `cod_meio_pgto_fk` int(11) NOT NULL,
  `valor_pagamento` double NOT NULL,
  `data_criacao_pagamento` datetime NOT NULL,
  `observacao_pagamento` text COLLATE utf8_bin,
  `estado_ativo_pagamento` char(1) COLLATE utf8_bin NOT NULL DEFAULT 's' COMMENT 's=sim n=nao',
  `troco_pagamento` double NOT NULL,
  `data_alteracao_pagamento` datetime NOT NULL,
  PRIMARY KEY (`cod_pagamento_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=6 ;

--
-- Extraindo dados da tabela `tab_pagamento`
--

INSERT INTO `tab_pagamento` (`cod_pagamento_pk`, `cod_atendente_fk`, `cod_meio_pgto_fk`, `valor_pagamento`, `data_criacao_pagamento`, `observacao_pagamento`, `estado_ativo_pagamento`, `troco_pagamento`, `data_alteracao_pagamento`) VALUES
(1, 1, 1, 50, '2015-06-22 16:53:45', '', 's', 31.44, '2015-06-23 12:04:35'),
(2, 1, 1, 5, '2015-06-22 17:22:28', '', 's', 0, '2015-06-23 11:15:30'),
(3, 1, 1, 5, '2015-06-22 17:23:16', '', 's', 1.44, '2015-06-23 12:02:23'),
(4, 1, 1, 31, '2015-06-25 11:31:40', '', 's', 25.44, '2015-06-25 11:59:26'),
(5, 1, 1, 60, '2015-06-25 11:32:03', '', 's', 5.55, '2015-06-25 11:32:03');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_pagamento_atendimento`
--

CREATE TABLE IF NOT EXISTS `tab_pagamento_atendimento` (
  `cod_pagamento_atendimento_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_pagamento_fk` int(11) NOT NULL,
  `cod_atendimento_fk` int(11) NOT NULL,
  `valor_fatia_pagamento` double NOT NULL,
  PRIMARY KEY (`cod_pagamento_atendimento_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Junção de pagamentos e atendimentos' AUTO_INCREMENT=9 ;

--
-- Extraindo dados da tabela `tab_pagamento_atendimento`
--

INSERT INTO `tab_pagamento_atendimento` (`cod_pagamento_atendimento_pk`, `cod_pagamento_fk`, `cod_atendimento_fk`, `valor_fatia_pagamento`) VALUES
(2, 2, 1, 5),
(5, 3, 2, 5),
(6, 1, 1, 18.56),
(7, 4, 3, 5.56),
(8, 5, 2, 54.45);

--
-- Acionadores `tab_pagamento_atendimento`
--
DROP TRIGGER IF EXISTS `depoisDeDelete_pagamento_atendimento`;
DELIMITER //
CREATE TRIGGER `depoisDeDelete_pagamento_atendimento` AFTER DELETE ON `tab_pagamento_atendimento`
 FOR EACH ROW IF(
   (SELECT SUM(tpa.valor_fatia_pagamento)
   FROM tab_pagamento_atendimento tpa, tab_pagamento tp
   WHERE (tpa.cod_atendimento_fk = OLD.cod_atendimento_fk) 
   AND (tp.estado_ativo_pagamento = 's') AND (tp.cod_pagamento_pk = tpa.cod_pagamento_fk))
   >= 
   (SELECT SUM(tia.valor_combinado_item_atendimento) 
    FROM tab_item_atendimento tia 
    WHERE (tia.cod_atendimento_fk = OLD.cod_atendimento_fk))
    ) 
    THEN
    
insert into tab_dbg_pagamento_atendimento(
    cod_atendimento_fk, 
    cod_pagamento_fk,
    estado_atendimento_pago,
    estado_dado,
    valor_fatia_pagamento,
    operacao,
    data_movimentacao)
values(OLD.cod_atendimento_fK,
       OLD.cod_pagamento_fK,(
    SELECT ta.estado_pago_atendimento FROM tab_atendimento ta
    WHERE cod_atendimento_pk = OLD.cod_atendimento_fK LIMIT 1
    ), 
    'a',OLD.valor_fatia_pagamento,'d',NOW());

UPDATE tab_atendimento ta SET ta.estado_pago_atendimento = 's' WHERE cod_atendimento_pk = OLD.cod_atendimento_fK;

ELSE

insert into tab_dbg_pagamento_atendimento(
    cod_atendimento_fk, 
    cod_pagamento_fk,
    estado_atendimento_pago,
    estado_dado,
    valor_fatia_pagamento,
    operacao,
    data_movimentacao)
values(OLD.cod_atendimento_fK,
       OLD.cod_pagamento_fK,(
    SELECT ta.estado_pago_atendimento FROM tab_atendimento ta
    WHERE cod_atendimento_pk = OLD.cod_atendimento_fK LIMIT 1
    ), 
    'a',OLD.valor_fatia_pagamento,'d',NOW());

UPDATE tab_atendimento ta SET ta.estado_pago_atendimento = 'n' WHERE cod_atendimento_pk = OLD.cod_atendimento_fK;

END IF
//
DELIMITER ;
DROP TRIGGER IF EXISTS `depoisDeInsert_pagamento_atendimento`;
DELIMITER //
CREATE TRIGGER `depoisDeInsert_pagamento_atendimento` AFTER INSERT ON `tab_pagamento_atendimento`
 FOR EACH ROW IF(
   (SELECT SUM(tpa.valor_fatia_pagamento)
   FROM tab_pagamento_atendimento tpa, tab_pagamento tp
   WHERE (tpa.cod_atendimento_fk = NEW.cod_atendimento_fk) 
   AND (tp.estado_ativo_pagamento = 's') AND (tp.cod_pagamento_pk = tpa.cod_pagamento_fk))
   >= 
   (SELECT SUM(tia.valor_combinado_item_atendimento) 
    FROM tab_item_atendimento tia 
    WHERE (tia.cod_atendimento_fk = NEW.cod_atendimento_fk))
    ) 
    THEN    

UPDATE tab_atendimento ta SET ta.estado_pago_atendimento = 's' WHERE cod_atendimento_pk = NEW.cod_atendimento_fK;

insert into tab_dbg_pagamento_atendimento(
    cod_atendimento_fk, 
    cod_pagamento_fk,
    estado_atendimento_pago,
    estado_dado,
     valor_fatia_pagamento,
    operacao,
    data_movimentacao)
values(NEW.cod_atendimento_fK,
       NEW.cod_pagamento_fK,(
    SELECT ta.estado_pago_atendimento FROM tab_atendimento ta
    WHERE cod_atendimento_pk = NEW.cod_atendimento_fK LIMIT 1
    ),'n',NEW.valor_fatia_pagamento,'i',NOW());

ELSE

UPDATE tab_atendimento ta SET ta.estado_pago_atendimento = 'n' WHERE cod_atendimento_pk = NEW.cod_atendimento_fK;

insert into tab_dbg_pagamento_atendimento(
    cod_atendimento_fk, 
    cod_pagamento_fk,
    estado_atendimento_pago,
    estado_dado,
     valor_fatia_pagamento,
    operacao,
    data_movimentacao)
values(NEW.cod_atendimento_fK,
       NEW.cod_pagamento_fK,(
    SELECT ta.estado_pago_atendimento FROM tab_atendimento ta
    WHERE cod_atendimento_pk = NEW.cod_atendimento_fK LIMIT 1
    ),'n',NEW.valor_fatia_pagamento,'i',NOW());

END IF
//
DELIMITER ;
DROP TRIGGER IF EXISTS `depoisDeUpdate_pagemento_atendimento`;
DELIMITER //
CREATE TRIGGER `depoisDeUpdate_pagemento_atendimento` AFTER UPDATE ON `tab_pagamento_atendimento`
 FOR EACH ROW IF(
   (SELECT SUM(tpa.valor_fatia_pagamento)
   FROM tab_pagamento_atendimento tpa, tab_pagamento tp
   WHERE (tpa.cod_atendimento_fk = NEW.cod_atendimento_fk) 
   AND (tp.estado_ativo_pagamento = 's') AND (tp.cod_pagamento_pk = tpa.cod_pagamento_fk))
   >= 
   (SELECT SUM(tia.valor_combinado_item_atendimento) 
    FROM tab_item_atendimento tia 
    WHERE (tia.cod_atendimento_fk = OLD.cod_atendimento_fk))
    ) 
    THEN
    
insert into tab_dbg_pagamento_atendimento(
    cod_atendimento_fk, 
    cod_pagamento_fk,
    estado_atendimento_pago,
    estado_dado,
    valor_fatia_pagamento,
    operacao,
    data_movimentacao)
values(OLD.cod_atendimento_fK,
       OLD.cod_pagamento_fK,(
    SELECT ta.estado_pago_atendimento FROM tab_atendimento ta
    WHERE cod_atendimento_pk = OLD.cod_atendimento_fK LIMIT 1
    ), 
    'a',OLD.valor_fatia_pagamento,'u',NOW());

UPDATE tab_atendimento ta SET ta.estado_pago_atendimento = 's' WHERE cod_atendimento_pk = OLD.cod_atendimento_fK;

insert into tab_dbg_pagamento_atendimento(
    cod_atendimento_fk, 
    cod_pagamento_fk,
    estado_atendimento_pago,
    estado_dado,
     valor_fatia_pagamento,
    operacao,
    data_movimentacao)
values(NEW.cod_atendimento_fK,
       NEW.cod_pagamento_fK,(
    SELECT ta.estado_pago_atendimento FROM tab_atendimento ta
    WHERE cod_atendimento_pk = NEW.cod_atendimento_fK LIMIT 1
    ), 
    'n',NEW.valor_fatia_pagamento,'u',NOW());
ELSE

insert into tab_dbg_pagamento_atendimento(
    cod_atendimento_fk, 
    cod_pagamento_fk,
    estado_atendimento_pago,
    estado_dado,
    valor_fatia_pagamento,
    operacao,
    data_movimentacao)
values(OLD.cod_atendimento_fK,
       OLD.cod_pagamento_fK,(
    SELECT ta.estado_pago_atendimento FROM tab_atendimento ta
    WHERE cod_atendimento_pk = OLD.cod_atendimento_fK LIMIT 1
    ),'a',OLD.valor_fatia_pagamento,'u',NOW());

UPDATE tab_atendimento ta SET ta.estado_pago_atendimento = 'n' WHERE cod_atendimento_pk = OLD.cod_atendimento_fK;

insert into tab_dbg_pagamento_atendimento(
    cod_atendimento_fk, 
    cod_pagamento_fk,
    estado_atendimento_pago,
    estado_dado,
     valor_fatia_pagamento,
    operacao,
    data_movimentacao)
values(NEW.cod_atendimento_fK,
       NEW.cod_pagamento_fK,(
    SELECT ta.estado_pago_atendimento FROM tab_atendimento ta
    WHERE cod_atendimento_pk = NEW.cod_atendimento_fK LIMIT 1
    ),'n',NEW.valor_fatia_pagamento,'u',NOW());

END IF
//
DELIMITER ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_problema`
--

CREATE TABLE IF NOT EXISTS `tab_problema` (
  `cod_problema_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_atendente_fk` int(11) NOT NULL,
  `cod_atendimento_fk` int(11) NOT NULL,
  `descricao_problema` text COLLATE utf8_bin,
  `observacao_problema` text COLLATE utf8_bin,
  `titulo_problema` varchar(200) COLLATE utf8_bin NOT NULL,
  `data_criacao_problema` datetime NOT NULL,
  `estado_ativo_problema` char(1) COLLATE utf8_bin NOT NULL DEFAULT 's' COMMENT 's=sim n=nao',
  PRIMARY KEY (`cod_problema_pk`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_responsavel`
--

CREATE TABLE IF NOT EXISTS `tab_responsavel` (
  `cod_responsavel_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_tipo_responsavel_fk` int(11) NOT NULL,
  `cod_atendente_fk` int(11) NOT NULL,
  `cod_tipo_pessoa_fk` int(11) NOT NULL,
  `nome_responsavel` varchar(100) COLLATE utf8_bin NOT NULL,
  `apelido_responsavel` varchar(50) COLLATE utf8_bin NOT NULL,
  `rgIe_responsavel` varchar(15) COLLATE utf8_bin NOT NULL,
  `cpfCnpj_responsavel` varchar(18) COLLATE utf8_bin NOT NULL,
  `data_cadastro_responsavel` datetime NOT NULL,
  `estado_ativo_responsavel` char(1) COLLATE utf8_bin NOT NULL DEFAULT 's' COMMENT 's=sim n=nao',
  `data_nascimento_responsavel` date DEFAULT NULL,
  `obs_responsavel` text COLLATE utf8_bin,
  PRIMARY KEY (`cod_responsavel_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin ROW_FORMAT=COMPACT AUTO_INCREMENT=5 ;

--
-- Extraindo dados da tabela `tab_responsavel`
--

INSERT INTO `tab_responsavel` (`cod_responsavel_pk`, `cod_tipo_responsavel_fk`, `cod_atendente_fk`, `cod_tipo_pessoa_fk`, `nome_responsavel`, `apelido_responsavel`, `rgIe_responsavel`, `cpfCnpj_responsavel`, `data_cadastro_responsavel`, `estado_ativo_responsavel`, `data_nascimento_responsavel`, `obs_responsavel`) VALUES
(1, 1, 1, 2, 'Robervall .ltda', 'Despachante União', '134897987878', '39628683000161', '2015-06-19 09:46:29', 's', '1990-01-01', 'despachante liberal!\r\n'),
(2, 2, 1, 2, 'Pedro Gallizone. sa', 'Galivex Trans', '609809866456', '68556847000190', '2015-06-19 16:51:51', 's', '1965-02-01', 'Agregados da mrecedez'),
(3, 2, 1, 1, 'Carlos Pereira', 'Pepe', '8364863669', '96410664478', '2015-06-19 16:54:55', 's', '1998-09-02', 'DOno de um caminhao'),
(4, 2, 1, 2, 'Joao sargento.ltda', 'TransJossa', '384545882885', '73584482000148', '2015-06-22 16:06:42', 's', '2000-11-04', '');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_servico`
--

CREATE TABLE IF NOT EXISTS `tab_servico` (
  `cod_tab_servico_pk` int(11) NOT NULL AUTO_INCREMENT,
  `cod_atendente_fk` int(11) NOT NULL COMMENT 'quem fez o registro',
  `data_criacao_servico` datetime NOT NULL COMMENT 'data de criacao do registro',
  `estado_ativo_servico` char(1) COLLATE utf8_bin NOT NULL DEFAULT 's' COMMENT 's=sim n=nao',
  `valor_servico` double NOT NULL,
  `nome_servico` text COLLATE utf8_bin,
  `descricao_servico` text COLLATE utf8_bin,
  `data_ultima_alteracao_servico` datetime NOT NULL COMMENT 'ultima alteração update',
  PRIMARY KEY (`cod_tab_servico_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=3 ;

--
-- Extraindo dados da tabela `tab_servico`
--

INSERT INTO `tab_servico` (`cod_tab_servico_pk`, `cod_atendente_fk`, `data_criacao_servico`, `estado_ativo_servico`, `valor_servico`, `nome_servico`, `descricao_servico`, `data_ultima_alteracao_servico`) VALUES
(1, 1, '2014-12-10 15:26:49', 's', 23.56, 'Carteirinha ANTT', 'sem borda de metal', '2014-12-18 05:19:32'),
(2, 1, '2014-12-16 08:18:38', 's', 35.89, 'Placa Homologada', 'sem plastico', '2014-12-19 03:19:22');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_tipo_contato`
--

CREATE TABLE IF NOT EXISTS `tab_tipo_contato` (
  `cod_tipo_contato_pk` int(11) NOT NULL AUTO_INCREMENT,
  `nome_tipo_contato` varchar(50) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`cod_tipo_contato_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=6 ;

--
-- Extraindo dados da tabela `tab_tipo_contato`
--

INSERT INTO `tab_tipo_contato` (`cod_tipo_contato_pk`, `nome_tipo_contato`) VALUES
(1, 'Email'),
(2, 'Celular Empresarial'),
(3, 'Celular Pessoal'),
(4, 'Telefone Fixo Pessoal'),
(5, 'Telefone Fixo Empresarial');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_tipo_endereco`
--

CREATE TABLE IF NOT EXISTS `tab_tipo_endereco` (
  `cod_tipo_endereco_pk` int(11) NOT NULL AUTO_INCREMENT,
  `nome_tipo_endereco` varchar(50) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`cod_tipo_endereco_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=3 ;

--
-- Extraindo dados da tabela `tab_tipo_endereco`
--

INSERT INTO `tab_tipo_endereco` (`cod_tipo_endereco_pk`, `nome_tipo_endereco`) VALUES
(1, 'Comercial'),
(2, 'Particular');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_tipo_pessoa`
--

CREATE TABLE IF NOT EXISTS `tab_tipo_pessoa` (
  `cod_tipo_pessoa_pk` int(11) NOT NULL AUTO_INCREMENT,
  `nome_tipo_pessoa` varchar(20) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`cod_tipo_pessoa_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=3 ;

--
-- Extraindo dados da tabela `tab_tipo_pessoa`
--

INSERT INTO `tab_tipo_pessoa` (`cod_tipo_pessoa_pk`, `nome_tipo_pessoa`) VALUES
(1, 'Pessoa Física'),
(2, 'Pessoa Jurídica');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tab_tipo_responsavel`
--

CREATE TABLE IF NOT EXISTS `tab_tipo_responsavel` (
  `cod_tipo_responsavel_pk` int(11) NOT NULL AUTO_INCREMENT,
  `nome_tipo_responsavel` varchar(50) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`cod_tipo_responsavel_pk`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_bin AUTO_INCREMENT=3 ;

--
-- Extraindo dados da tabela `tab_tipo_responsavel`
--

INSERT INTO `tab_tipo_responsavel` (`cod_tipo_responsavel_pk`, `nome_tipo_responsavel`) VALUES
(1, 'Despachante'),
(2, 'Transportadora');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
