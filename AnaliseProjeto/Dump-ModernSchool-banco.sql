-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: modernschool
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `alunoavaliacao`
--

DROP TABLE IF EXISTS `alunoavaliacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alunoavaliacao` (
  `idPessoa` int unsigned NOT NULL,
  `idAvaliacao` int unsigned NOT NULL,
  `nota` decimal(10,2) NOT NULL DEFAULT '0.00',
  `dataEntrega` datetime NOT NULL,
  `arquivo` blob NOT NULL,
  PRIMARY KEY (`idPessoa`,`idAvaliacao`),
  KEY `fk_PessoaAvaliacao_Avaliacao1_idx` (`idAvaliacao`),
  KEY `fk_PessoaAvaliacao_Pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_PessoaAvaliacao_Avaliacao1` FOREIGN KEY (`idAvaliacao`) REFERENCES `avaliacao` (`id`),
  CONSTRAINT `fk_PessoaAvaliacao_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alunoavaliacao`
--

LOCK TABLES `alunoavaliacao` WRITE;
/*!40000 ALTER TABLE `alunoavaliacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `alunoavaliacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alunocomunicacao`
--

DROP TABLE IF EXISTS `alunocomunicacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alunocomunicacao` (
  `idPessoa` int unsigned NOT NULL,
  `idComunicacao` int unsigned NOT NULL,
  PRIMARY KEY (`idPessoa`,`idComunicacao`),
  KEY `fk_PessoaComunicacao_Comunicacao1_idx` (`idComunicacao`),
  KEY `fk_PessoaComunicacao_Pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_PessoaComunicacao_Comunicacao1` FOREIGN KEY (`idComunicacao`) REFERENCES `comunicacao` (`id`),
  CONSTRAINT `fk_PessoaComunicacao_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alunocomunicacao`
--

LOCK TABLES `alunocomunicacao` WRITE;
/*!40000 ALTER TABLE `alunocomunicacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `alunocomunicacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `anoletivo`
--

DROP TABLE IF EXISTS `anoletivo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `anoletivo` (
  `anoLetivo` int unsigned NOT NULL,
  `idEscola` int unsigned NOT NULL,
  `dataInicio` date NOT NULL,
  `dataFim` date NOT NULL,
  PRIMARY KEY (`anoLetivo`),
  KEY `fk_AnoLetivo_Escola1_idx` (`idEscola`),
  CONSTRAINT `fk_AnoLetivo_Escola1` FOREIGN KEY (`idEscola`) REFERENCES `escola` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `anoletivo`
--

LOCK TABLES `anoletivo` WRITE;
/*!40000 ALTER TABLE `anoletivo` DISABLE KEYS */;
INSERT INTO `anoletivo` VALUES (1,1,'2022-05-02','2022-12-31');
/*!40000 ALTER TABLE `anoletivo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `avaliacao`
--

DROP TABLE IF EXISTS `avaliacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `avaliacao` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `dataEntrega` datetime NOT NULL,
  `horarioEntrega` datetime NOT NULL,
  `tipoDeAtividade` enum('PROVA','PROJETO') DEFAULT NULL,
  `peso` smallint DEFAULT NULL,
  `avaliativo` tinyint(1) DEFAULT NULL,
  `idTurma` int NOT NULL,
  `idComponente` int unsigned NOT NULL,
  `idPeriodo` int unsigned NOT NULL,
  PRIMARY KEY (`id`,`horarioEntrega`),
  KEY `fk_Avaliacao_Turma1_idx` (`idTurma`),
  KEY `fk_Avaliacao_Componente1_idx` (`idComponente`),
  KEY `fk_Avaliacao_Periodo1_idx` (`idPeriodo`),
  CONSTRAINT `fk_Avaliacao_Componente1` FOREIGN KEY (`idComponente`) REFERENCES `componente` (`id`),
  CONSTRAINT `fk_Avaliacao_Periodo1` FOREIGN KEY (`idPeriodo`) REFERENCES `periodo` (`id`),
  CONSTRAINT `fk_Avaliacao_Turma1` FOREIGN KEY (`idTurma`) REFERENCES `turma` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avaliacao`
--

LOCK TABLES `avaliacao` WRITE;
/*!40000 ALTER TABLE `avaliacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `avaliacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cargo`
--

DROP TABLE IF EXISTS `cargo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cargo` (
  `idCargo` int NOT NULL,
  `descricao` varchar(45) NOT NULL,
  PRIMARY KEY (`idCargo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cargo`
--

LOCK TABLES `cargo` WRITE;
/*!40000 ALTER TABLE `cargo` DISABLE KEYS */;
INSERT INTO `cargo` VALUES (1,'Professor'),(2,'administrador ');
/*!40000 ALTER TABLE `cargo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `componente`
--

DROP TABLE IF EXISTS `componente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `componente` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(40) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `componente`
--

LOCK TABLES `componente` WRITE;
/*!40000 ALTER TABLE `componente` DISABLE KEYS */;
INSERT INTO `componente` VALUES (1,'matematica'),(2,'Portugues'),(3,'Geografia');
/*!40000 ALTER TABLE `componente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comunicacao`
--

DROP TABLE IF EXISTS `comunicacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comunicacao` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `enviarAlunos` tinyint NOT NULL,
  `enviarResponsaveis` tinyint NOT NULL,
  `mensagem` varchar(500) NOT NULL,
  `idTurma` int NOT NULL,
  `idComponente` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Comunicacao_Turma1_idx` (`idTurma`),
  KEY `fk_Comunicacao_Componente1_idx` (`idComponente`),
  CONSTRAINT `fk_Comunicacao_Componente1` FOREIGN KEY (`idComponente`) REFERENCES `componente` (`id`),
  CONSTRAINT `fk_Comunicacao_Turma1` FOREIGN KEY (`idTurma`) REFERENCES `turma` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comunicacao`
--

LOCK TABLES `comunicacao` WRITE;
/*!40000 ALTER TABLE `comunicacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `comunicacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `curriculo`
--

DROP TABLE IF EXISTS `curriculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `curriculo` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `escolaridade` char(1) NOT NULL,
  `anoFaixa` varchar(4) NOT NULL,
  `anoLetivo` smallint DEFAULT NULL,
  `idGoverno` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Curriculo_Governo1_idx` (`idGoverno`),
  CONSTRAINT `fk_Curriculo_Governo1` FOREIGN KEY (`idGoverno`) REFERENCES `governo` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `curriculo`
--

LOCK TABLES `curriculo` WRITE;
/*!40000 ALTER TABLE `curriculo` DISABLE KEYS */;
/*!40000 ALTER TABLE `curriculo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `diariodeclasse`
--

DROP TABLE IF EXISTS `diariodeclasse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `diariodeclasse` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `dataShow` tinyint(1) DEFAULT NULL,
  `livros` tinyint(1) DEFAULT NULL,
  `livrosSeduc` tinyint(1) DEFAULT NULL,
  `resumoAula` varchar(100) DEFAULT NULL,
  `idTurma` int NOT NULL,
  `idComponente` int unsigned NOT NULL,
  `idProfessor` int unsigned NOT NULL,
  `tipoAula` enum('C','A') NOT NULL DEFAULT 'C',
  PRIMARY KEY (`id`),
  KEY `fk_DiarioDeClasse_Turma1_idx` (`idTurma`),
  KEY `fk_DiarioDeClasse_Componente1_idx` (`idComponente`),
  KEY `fk_DiarioDeClasse_Pessoa1_idx` (`idProfessor`),
  CONSTRAINT `fk_DiarioDeClasse_Componente1` FOREIGN KEY (`idComponente`) REFERENCES `componente` (`id`),
  CONSTRAINT `fk_DiarioDeClasse_Pessoa1` FOREIGN KEY (`idProfessor`) REFERENCES `pessoa` (`id`),
  CONSTRAINT `fk_DiarioDeClasse_Turma1` FOREIGN KEY (`idTurma`) REFERENCES `turma` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diariodeclasse`
--

LOCK TABLES `diariodeclasse` WRITE;
/*!40000 ALTER TABLE `diariodeclasse` DISABLE KEYS */;
/*!40000 ALTER TABLE `diariodeclasse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `escola`
--

DROP TABLE IF EXISTS `escola`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `escola` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `Nome` varchar(70) NOT NULL,
  `cnpj` char(14) NOT NULL,
  `rua` varchar(50) DEFAULT NULL,
  `bairro` varchar(40) DEFAULT NULL,
  `numero` smallint DEFAULT NULL,
  `idGoverno` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Nome_UNIQUE` (`Nome`),
  KEY `fk_Escola_Prefeitura_idx` (`idGoverno`),
  CONSTRAINT `fk_Escola_Prefeitura` FOREIGN KEY (`idGoverno`) REFERENCES `governo` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `escola`
--

LOCK TABLES `escola` WRITE;
/*!40000 ALTER TABLE `escola` DISABLE KEYS */;
INSERT INTO `escola` VALUES (1,'MATHEUS DA CRUZ SOUZA','11111111111111','Maria soares da silveira','centro',63,1);
/*!40000 ALTER TABLE `escola` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `frequenciaaluno`
--

DROP TABLE IF EXISTS `frequenciaaluno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `frequenciaaluno` (
  `idPessoa` int unsigned NOT NULL,
  `idDiarioDeClasse` int unsigned NOT NULL,
  `faltas` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`idPessoa`,`idDiarioDeClasse`),
  KEY `fk_PessoaDiarioDeClasse_DiarioDeClasse1_idx` (`idDiarioDeClasse`),
  KEY `fk_PessoaDiarioDeClasse_Pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_PessoaDiarioDeClasse_DiarioDeClasse1` FOREIGN KEY (`idDiarioDeClasse`) REFERENCES `diariodeclasse` (`id`),
  CONSTRAINT `fk_PessoaDiarioDeClasse_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `frequenciaaluno`
--

LOCK TABLES `frequenciaaluno` WRITE;
/*!40000 ALTER TABLE `frequenciaaluno` DISABLE KEYS */;
/*!40000 ALTER TABLE `frequenciaaluno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `governo`
--

DROP TABLE IF EXISTS `governo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `governo` (
  `id` int NOT NULL AUTO_INCREMENT,
  `municipio` varchar(50) NOT NULL,
  `Estado` varchar(50) NOT NULL,
  `dependenciaAdministrativa` enum('M','E') NOT NULL DEFAULT 'M',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `governo`
--

LOCK TABLES `governo` WRITE;
/*!40000 ALTER TABLE `governo` DISABLE KEYS */;
INSERT INTO `governo` VALUES (1,'Campo do Brito','SE','M'),(2,'Itabaiana','SE','E'),(53,'Lagarto','SE','M');
/*!40000 ALTER TABLE `governo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `governoservidor`
--

DROP TABLE IF EXISTS `governoservidor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `governoservidor` (
  `idCargo` int NOT NULL,
  `dataInicio` date NOT NULL,
  `dataFim` date DEFAULT NULL,
  `status` enum('A','I') DEFAULT NULL,
  `idGoverno` int NOT NULL,
  `idPessoa` int unsigned NOT NULL,
  PRIMARY KEY (`idGoverno`,`idPessoa`),
  KEY `fk_GovernoServidor_Cargo1_idx` (`idCargo`),
  KEY `fk_GovernoServidor_Pessoa1_idx` (`idPessoa`),
  CONSTRAINT `fk_GovernoServidor_Cargo1` FOREIGN KEY (`idCargo`) REFERENCES `cargo` (`idCargo`),
  CONSTRAINT `fk_GovernoServidor_Governo1` FOREIGN KEY (`idGoverno`) REFERENCES `governo` (`id`),
  CONSTRAINT `fk_GovernoServidor_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `governoservidor`
--

LOCK TABLES `governoservidor` WRITE;
/*!40000 ALTER TABLE `governoservidor` DISABLE KEYS */;
INSERT INTO `governoservidor` VALUES (1,'2022-11-23',NULL,'A',1,3);
/*!40000 ALTER TABLE `governoservidor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gradehorario`
--

DROP TABLE IF EXISTS `gradehorario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gradehorario` (
  `id` int NOT NULL,
  `idComponente` int unsigned NOT NULL,
  `idTurma` int NOT NULL,
  `diaSemana` enum('SEG','TER') NOT NULL,
  `horaInicio` varchar(4) DEFAULT NULL,
  `horaFim` varchar(4) DEFAULT NULL,
  `idProfessor` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_ComponenteTurma_Turma1_idx` (`idTurma`),
  KEY `fk_ComponenteTurma_Componente1_idx` (`idComponente`),
  KEY `fk_GradeHorario_Pessoa1_idx` (`idProfessor`),
  CONSTRAINT `fk_ComponenteTurma_Componente1` FOREIGN KEY (`idComponente`) REFERENCES `componente` (`id`),
  CONSTRAINT `fk_ComponenteTurma_Turma1` FOREIGN KEY (`idTurma`) REFERENCES `turma` (`id`),
  CONSTRAINT `fk_GradeHorario_Pessoa1` FOREIGN KEY (`idProfessor`) REFERENCES `pessoa` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gradehorario`
--

LOCK TABLES `gradehorario` WRITE;
/*!40000 ALTER TABLE `gradehorario` DISABLE KEYS */;
INSERT INTO `gradehorario` VALUES (1,1,1,'SEG','7','9',5),(2,1,1,'SEG','10','12',5),(3,2,1,'SEG','8','20',5);
/*!40000 ALTER TABLE `gradehorario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `habilidade`
--

DROP TABLE IF EXISTS `habilidade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `habilidade` (
  `idHabilidade` int unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(100) NOT NULL,
  `idObjetoDeConhecimento` int unsigned NOT NULL,
  PRIMARY KEY (`idHabilidade`),
  KEY `fk_Habilidade_ObjetoDeConhecimento1_idx` (`idObjetoDeConhecimento`),
  CONSTRAINT `fk_Habilidade_ObjetoDeConhecimento1` FOREIGN KEY (`idObjetoDeConhecimento`) REFERENCES `objetodeconhecimento` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `habilidade`
--

LOCK TABLES `habilidade` WRITE;
/*!40000 ALTER TABLE `habilidade` DISABLE KEYS */;
/*!40000 ALTER TABLE `habilidade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `objetodeconhecimento`
--

DROP TABLE IF EXISTS `objetodeconhecimento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `objetodeconhecimento` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(100) NOT NULL,
  `idUnidadeTematica` int unsigned NOT NULL,
  `sequenciaProposta` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_ObjetoDeConhecimento_UnidadeTematica1_idx` (`idUnidadeTematica`),
  CONSTRAINT `fk_ObjetoDeConhecimento_UnidadeTematica1` FOREIGN KEY (`idUnidadeTematica`) REFERENCES `unidadetematica` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `objetodeconhecimento`
--

LOCK TABLES `objetodeconhecimento` WRITE;
/*!40000 ALTER TABLE `objetodeconhecimento` DISABLE KEYS */;
/*!40000 ALTER TABLE `objetodeconhecimento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `objetodeconhecimentodiariodeclasse`
--

DROP TABLE IF EXISTS `objetodeconhecimentodiariodeclasse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `objetodeconhecimentodiariodeclasse` (
  `idObjetoDeConhecimento` int unsigned NOT NULL,
  `idDiarioDeClasse` int unsigned NOT NULL,
  PRIMARY KEY (`idObjetoDeConhecimento`,`idDiarioDeClasse`),
  KEY `fk_ObjetoDeConhecimentoDiarioDeClasse_DiarioDeClasse1_idx` (`idDiarioDeClasse`),
  KEY `fk_ObjetoDeConhecimentoDiarioDeClasse_ObjetoDeConhecimento1_idx` (`idObjetoDeConhecimento`),
  CONSTRAINT `fk_ObjetoDeConhecimentoDiarioDeClasse_DiarioDeClasse1` FOREIGN KEY (`idDiarioDeClasse`) REFERENCES `diariodeclasse` (`id`),
  CONSTRAINT `fk_ObjetoDeConhecimentoDiarioDeClasse_ObjetoDeConhecimento1` FOREIGN KEY (`idObjetoDeConhecimento`) REFERENCES `objetodeconhecimento` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `objetodeconhecimentodiariodeclasse`
--

LOCK TABLES `objetodeconhecimentodiariodeclasse` WRITE;
/*!40000 ALTER TABLE `objetodeconhecimentodiariodeclasse` DISABLE KEYS */;
/*!40000 ALTER TABLE `objetodeconhecimentodiariodeclasse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `periodo`
--

DROP TABLE IF EXISTS `periodo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `periodo` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(30) NOT NULL,
  `dataInicio` date DEFAULT NULL,
  `dataFim` date DEFAULT NULL,
  `anoLetivo` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Periodo_AnoLetivo1_idx` (`anoLetivo`),
  CONSTRAINT `fk_Periodo_AnoLetivo1` FOREIGN KEY (`anoLetivo`) REFERENCES `anoletivo` (`anoLetivo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `periodo`
--

LOCK TABLES `periodo` WRITE;
/*!40000 ALTER TABLE `periodo` DISABLE KEYS */;
/*!40000 ALTER TABLE `periodo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(70) NOT NULL,
  `cpf` char(11) NOT NULL,
  `idade` smallint DEFAULT NULL,
  `rua` varchar(50) DEFAULT NULL,
  `bairro` varchar(40) DEFAULT NULL,
  `numero` smallint unsigned DEFAULT NULL,
  `dataNascimento` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (3,'Teste','88888888888',25,'dafadfas','centro',77,'0001-01-01'),(5,'MATHEUS DA CRUZ SOUZA','55555555555',21,'dafadfas','dfadvdv',63,'0001-01-01'),(6,'Souza','00000000000',25,'jose campos','centro',87,'0001-01-01'),(20,'Souza','77777777777',30,'Maria soares da silveira','centro',63,'0001-01-01');
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoacomunicacao`
--

DROP TABLE IF EXISTS `pessoacomunicacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoacomunicacao` (
  `idPessoa` int unsigned NOT NULL,
  `idComunicacao` int unsigned NOT NULL,
  PRIMARY KEY (`idPessoa`,`idComunicacao`),
  KEY `fk_PessoaComunicacao_Comunicacao2_idx` (`idComunicacao`),
  KEY `fk_PessoaComunicacao_Pessoa2_idx` (`idPessoa`),
  CONSTRAINT `fk_PessoaComunicacao_Comunicacao2` FOREIGN KEY (`idComunicacao`) REFERENCES `comunicacao` (`id`),
  CONSTRAINT `fk_PessoaComunicacao_Pessoa2` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoacomunicacao`
--

LOCK TABLES `pessoacomunicacao` WRITE;
/*!40000 ALTER TABLE `pessoacomunicacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `pessoacomunicacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `turma`
--

DROP TABLE IF EXISTS `turma`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `turma` (
  `id` int NOT NULL AUTO_INCREMENT,
  `anoLetivo` int unsigned NOT NULL,
  `turma` varchar(50) NOT NULL,
  `vagas` int unsigned NOT NULL,
  `vagasDisponiveis` int NOT NULL,
  `sala` varchar(20) DEFAULT NULL,
  `escolaridade` enum('F','I','M') NOT NULL DEFAULT 'F',
  `status` enum('A','F') NOT NULL DEFAULT 'A',
  PRIMARY KEY (`id`),
  KEY `fk_Turma_AnoLetivo1_idx` (`anoLetivo`),
  CONSTRAINT `fk_Turma_AnoLetivo1` FOREIGN KEY (`anoLetivo`) REFERENCES `anoletivo` (`anoLetivo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turma`
--

LOCK TABLES `turma` WRITE;
/*!40000 ALTER TABLE `turma` DISABLE KEYS */;
INSERT INTO `turma` VALUES (1,1,'A2',50,50,'01','I','A');
/*!40000 ALTER TABLE `turma` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidadetematica`
--

DROP TABLE IF EXISTS `unidadetematica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unidadetematica` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `descricao` varchar(100) NOT NULL,
  `anoLetivo` smallint DEFAULT NULL,
  `idCurriculo` int unsigned NOT NULL,
  `idComponente` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_UnidadeTematica_Curriculo1_idx` (`idCurriculo`),
  KEY `fk_UnidadeTematica_Componente1_idx` (`idComponente`),
  CONSTRAINT `fk_UnidadeTematica_Componente1` FOREIGN KEY (`idComponente`) REFERENCES `componente` (`id`),
  CONSTRAINT `fk_UnidadeTematica_Curriculo1` FOREIGN KEY (`idCurriculo`) REFERENCES `curriculo` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidadetematica`
--

LOCK TABLES `unidadetematica` WRITE;
/*!40000 ALTER TABLE `unidadetematica` DISABLE KEYS */;
/*!40000 ALTER TABLE `unidadetematica` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'modernschool'
--

--
-- Dumping routines for database 'modernschool'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-23 21:54:51
