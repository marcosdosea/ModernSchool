CREATE DATABASE  IF NOT EXISTS `modernschool` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `modernschool`;
-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: modernschool
-- ------------------------------------------------------
-- Server version	8.0.33

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alunoavaliacao`
--

DROP TABLE IF EXISTS `alunoavaliacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alunoavaliacao` (
  `idAluno` int unsigned NOT NULL,
  `idAvaliacao` int unsigned NOT NULL,
  `nota` decimal(10,2) NOT NULL DEFAULT '0.00',
  `dataEntrega` datetime NOT NULL,
  `arquivo` blob,
  PRIMARY KEY (`idAluno`,`idAvaliacao`),
  KEY `fk_PessoaAvaliacao_Avaliacao1_idx` (`idAvaliacao`),
  KEY `fk_PessoaAvaliacao_Pessoa1_idx` (`idAluno`),
  CONSTRAINT `fk_PessoaAvaliacao_Avaliacao1` FOREIGN KEY (`idAvaliacao`) REFERENCES `avaliacao` (`id`),
  CONSTRAINT `fk_PessoaAvaliacao_Pessoa1` FOREIGN KEY (`idAluno`) REFERENCES `pessoa` (`id`)
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
  `idAluno` int unsigned NOT NULL,
  `idComunicacao` int unsigned NOT NULL,
  PRIMARY KEY (`idAluno`,`idComunicacao`),
  KEY `fk_PessoaComunicacao_Comunicacao1_idx` (`idComunicacao`),
  KEY `fk_PessoaComunicacao_Pessoa1_idx` (`idAluno`),
  CONSTRAINT `fk_PessoaComunicacao_Comunicacao1` FOREIGN KEY (`idComunicacao`) REFERENCES `comunicacao` (`id`),
  CONSTRAINT `fk_PessoaComunicacao_Pessoa1` FOREIGN KEY (`idAluno`) REFERENCES `pessoa` (`id`)
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
-- Table structure for table `alunoturma`
--

DROP TABLE IF EXISTS `alunoturma`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alunoturma` (
  `idAluno` int unsigned NOT NULL,
  `idTurma` int NOT NULL,
  `status` enum('M','A','R','C') NOT NULL DEFAULT 'M' COMMENT 'M - MATRICULADO\nA - APROVADO\nR - REPROVADO\nC - CANCELADO',
  PRIMARY KEY (`idAluno`,`idTurma`),
  KEY `fk_PessoaTurma_Turma1_idx` (`idTurma`),
  KEY `fk_PessoaTurma_Pessoa1_idx` (`idAluno`),
  CONSTRAINT `fk_PessoaTurma_Pessoa1` FOREIGN KEY (`idAluno`) REFERENCES `pessoa` (`id`),
  CONSTRAINT `fk_PessoaTurma_Turma1` FOREIGN KEY (`idTurma`) REFERENCES `turma` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alunoturma`
--

LOCK TABLES `alunoturma` WRITE;
/*!40000 ALTER TABLE `alunoturma` DISABLE KEYS */;
/*!40000 ALTER TABLE `alunoturma` ENABLE KEYS */;
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
INSERT INTO `anoletivo` VALUES (2024,1,'2024-03-04','2024-04-01');
/*!40000 ALTER TABLE `anoletivo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(255) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `NormalizedName` varchar(255) DEFAULT NULL,
  `ConcurrencyStamp` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('4e41763d-d54c-472a-ab46-dadabb2d8859','PROFESSOR','PROFESSOR','fac5a197-97f3-47e9-b29e-479fa1e5ac80');
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) NOT NULL,
  `ProviderKey` varchar(255) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(255) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) NOT NULL,
  `RoleId` varchar(255) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('0f900e08-881c-41e0-8387-b2f8ea9c7eba','4e41763d-d54c-472a-ab46-dadabb2d8859'),('1dba7143-1e8d-4b4c-885f-46d50100be3f','4e41763d-d54c-472a-ab46-dadabb2d8859');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(255) DEFAULT NULL,
  `NormalizedUserName` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `NormalizedEmail` varchar(255) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('0f900e08-881c-41e0-8387-b2f8ea9c7eba','teste@gmail.com','teste@gmail.com',NULL,NULL,_binary '\0','AQAAAAEAACcQAAAAECfuURCq3/SlKumV6LoffVZ/PJ1E+pUg0ZkVLrPC8L2MTj5forpWexL8oTCEx3d1Ww==','U3ODHHNJ3VZU45UGMWA2AEOTBKWHODV3','b3896af2-a235-48ad-b81e-4feed9c28f65',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),('1dba7143-1e8d-4b4c-885f-46d50100be3f','matheus@gmail.com','MATHEUS@GMAIL.COM','matheus@gmail.com','MATHEUS@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAEH3HVe5oouyX1fGSSQfyqyV6VF8JfvQmzTcTA+a72F7fYKEKLb/Xj3J/gMKrsABgiA==','XLTQEMMOZDTHJ6TAK2MFABRNZ7EDYXID','0c738db7-c5f8-4270-94a7-81be5008c26b',NULL,_binary '\0',_binary '\0',NULL,_binary '',0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) NOT NULL,
  `LoginProvider` varchar(255) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Value` text,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
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
  `tipoAvaliacao` enum('PROVA','PROJETO','ATIVIDADE') NOT NULL,
  `peso` smallint NOT NULL,
  `avaliativo` tinyint(1) DEFAULT NULL,
  `idTurma` int NOT NULL,
  `idComponente` int unsigned NOT NULL,
  `idPeriodo` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
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
  `idCargo` int unsigned NOT NULL,
  `descricao` varchar(45) NOT NULL,
  PRIMARY KEY (`idCargo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cargo`
--

LOCK TABLES `cargo` WRITE;
/*!40000 ALTER TABLE `cargo` DISABLE KEYS */;
INSERT INTO `cargo` VALUES (1,'Professor'),(2,'Diretor');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `componente`
--

LOCK TABLES `componente` WRITE;
/*!40000 ALTER TABLE `componente` DISABLE KEYS */;
INSERT INTO `componente` VALUES (1,'Portugues');
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
  `enviarAlunos` tinyint NOT NULL DEFAULT '0',
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
  `anoLetivo` smallint NOT NULL,
  `idGoverno` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Curriculo_Governo1_idx` (`idGoverno`),
  CONSTRAINT `fk_Curriculo_Governo1` FOREIGN KEY (`idGoverno`) REFERENCES `governo` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `curriculo`
--

LOCK TABLES `curriculo` WRITE;
/*!40000 ALTER TABLE `curriculo` DISABLE KEYS */;
INSERT INTO `curriculo` VALUES (2,'A','2014',2024,1);
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
  `data` date NOT NULL,
  `dataShow` tinyint(1) NOT NULL DEFAULT '0',
  `livros` tinyint(1) NOT NULL DEFAULT '0',
  `livrosSeduc` tinyint(1) NOT NULL DEFAULT '0',
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
  `idGoverno` int unsigned NOT NULL,
  `idDiretor` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `Nome_UNIQUE` (`Nome`),
  KEY `fk_Escola_Prefeitura_idx` (`idGoverno`),
  KEY `fk_Escola_Pessoa1_idx` (`idDiretor`),
  CONSTRAINT `fk_Escola_Pessoa1` FOREIGN KEY (`idDiretor`) REFERENCES `pessoa` (`id`),
  CONSTRAINT `fk_Escola_Prefeitura` FOREIGN KEY (`idGoverno`) REFERENCES `governo` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `escola`
--

LOCK TABLES `escola` WRITE;
/*!40000 ALTER TABLE `escola` DISABLE KEYS */;
INSERT INTO `escola` VALUES (1,'Colégio Estadual Guilherme Campos','11111111111111','Maria soares da silveira','Centro',63,1,1);
/*!40000 ALTER TABLE `escola` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `frequenciaaluno`
--

DROP TABLE IF EXISTS `frequenciaaluno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `frequenciaaluno` (
  `idAluno` int unsigned NOT NULL,
  `idDiarioDeClasse` int unsigned NOT NULL,
  `faltas` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`idAluno`,`idDiarioDeClasse`),
  KEY `fk_PessoaDiarioDeClasse_DiarioDeClasse1_idx` (`idDiarioDeClasse`),
  KEY `fk_PessoaDiarioDeClasse_Pessoa1_idx` (`idAluno`),
  CONSTRAINT `fk_PessoaDiarioDeClasse_DiarioDeClasse1` FOREIGN KEY (`idDiarioDeClasse`) REFERENCES `diariodeclasse` (`id`),
  CONSTRAINT `fk_PessoaDiarioDeClasse_Pessoa1` FOREIGN KEY (`idAluno`) REFERENCES `pessoa` (`id`)
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
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `municipio` varchar(50) NOT NULL,
  `Estado` varchar(50) NOT NULL,
  `dependenciaAdministrativa` enum('M','E') NOT NULL DEFAULT 'M',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `governo`
--

LOCK TABLES `governo` WRITE;
/*!40000 ALTER TABLE `governo` DISABLE KEYS */;
INSERT INTO `governo` VALUES (1,'Campo do Brito','SE','M');
/*!40000 ALTER TABLE `governo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `governoservidor`
--

DROP TABLE IF EXISTS `governoservidor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `governoservidor` (
  `idGoverno` int unsigned NOT NULL,
  `idPessoa` int unsigned NOT NULL,
  `idCargo` int unsigned NOT NULL,
  `dataInicio` date NOT NULL,
  `dataFim` date DEFAULT NULL,
  `status` enum('A','I','L') NOT NULL DEFAULT 'A' COMMENT 'A - ATIVO\nI - INATIVO\nL - LICENCIADO',
  `idEscola` int unsigned DEFAULT NULL,
  PRIMARY KEY (`idGoverno`,`idPessoa`),
  KEY `fk_GovernoServidor_Pessoa1_idx` (`idPessoa`),
  KEY `fk_GovernoServidor_Cargo1_idx` (`idCargo`),
  KEY `fk_GovernoServidor_Escola1_idx` (`idEscola`),
  CONSTRAINT `fk_GovernoServidor_Cargo1` FOREIGN KEY (`idCargo`) REFERENCES `cargo` (`idCargo`),
  CONSTRAINT `fk_GovernoServidor_Escola1` FOREIGN KEY (`idEscola`) REFERENCES `escola` (`id`),
  CONSTRAINT `fk_GovernoServidor_Governo1` FOREIGN KEY (`idGoverno`) REFERENCES `governo` (`id`),
  CONSTRAINT `fk_GovernoServidor_Pessoa1` FOREIGN KEY (`idPessoa`) REFERENCES `pessoa` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `governoservidor`
--

LOCK TABLES `governoservidor` WRITE;
/*!40000 ALTER TABLE `governoservidor` DISABLE KEYS */;
INSERT INTO `governoservidor` VALUES (1,2,1,'2024-03-04',NULL,'A',NULL);
/*!40000 ALTER TABLE `governoservidor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gradehorario`
--

DROP TABLE IF EXISTS `gradehorario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gradehorario` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idComponente` int unsigned NOT NULL,
  `idTurma` int NOT NULL,
  `diaSemana` enum('DOM','SEG','TER','QUA','QUI','SEX','SAB') NOT NULL,
  `horaInicio` varchar(4) NOT NULL,
  `horaFim` varchar(4) NOT NULL,
  `idProfessor` int unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_ComponenteTurma_Turma1_idx` (`idTurma`),
  KEY `fk_ComponenteTurma_Componente1_idx` (`idComponente`),
  KEY `fk_GradeHorario_Pessoa1_idx` (`idProfessor`),
  CONSTRAINT `fk_ComponenteTurma_Componente1` FOREIGN KEY (`idComponente`) REFERENCES `componente` (`id`),
  CONSTRAINT `fk_ComponenteTurma_Turma1` FOREIGN KEY (`idTurma`) REFERENCES `turma` (`id`),
  CONSTRAINT `fk_GradeHorario_Pessoa1` FOREIGN KEY (`idProfessor`) REFERENCES `pessoa` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gradehorario`
--

LOCK TABLES `gradehorario` WRITE;
/*!40000 ALTER TABLE `gradehorario` DISABLE KEYS */;
INSERT INTO `gradehorario` VALUES (1,1,1,'SEG','07','09',2);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `habilidade`
--

LOCK TABLES `habilidade` WRITE;
/*!40000 ALTER TABLE `habilidade` DISABLE KEYS */;
INSERT INTO `habilidade` VALUES (1,'Descrição habilidade',2);
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
  `idUnidadeTematica` int unsigned NOT NULL,
  `descricao` varchar(100) NOT NULL,
  `sequenciaProposta` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_ObjetoDeConhecimento_UnidadeTematica1_idx` (`idUnidadeTematica`),
  CONSTRAINT `fk_ObjetoDeConhecimento_UnidadeTematica1` FOREIGN KEY (`idUnidadeTematica`) REFERENCES `unidadetematica` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `objetodeconhecimento`
--

LOCK TABLES `objetodeconhecimento` WRITE;
/*!40000 ALTER TABLE `objetodeconhecimento` DISABLE KEYS */;
INSERT INTO `objetodeconhecimento` VALUES (2,2,'Teste objeto',1);
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
  KEY `fk_ObjetoDeConhecimentoDiarioDeClasse_ObjetoDeConhecimento1_idx` (`idObjetoDeConhecimento`),
  KEY `fk_ObjetoDeConhecimentoDiarioDeClasse_DiarioDeClasse1_idx` (`idDiarioDeClasse`),
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `periodo`
--

LOCK TABLES `periodo` WRITE;
/*!40000 ALTER TABLE `periodo` DISABLE KEYS */;
INSERT INTO `periodo` VALUES (2,'1°',NULL,NULL,2024);
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
  `dataNascimento` date NOT NULL,
  `cep` varchar(8) NOT NULL,
  `rua` varchar(50) DEFAULT NULL,
  `bairro` varchar(40) DEFAULT NULL,
  `numero` smallint unsigned DEFAULT NULL,
  `email` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (1,'MATHEUS DA CRUZ SOUZA','08689099557','1998-05-21','49520000','Maria soares da silveira','Centro',63,'matheusdacruzsouza1998@gmail.com'),(2,'Matheus Souza','00000000000','0001-01-01','4511899',NULL,NULL,NULL,'matheus@gmail.com');
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
  `status` enum('A','F','C') NOT NULL DEFAULT 'A' COMMENT 'A - ATIVA\nF - FINALIZADA\nC - CANCELADA',
  PRIMARY KEY (`id`),
  KEY `fk_Turma_AnoLetivo1_idx` (`anoLetivo`),
  CONSTRAINT `fk_Turma_AnoLetivo1` FOREIGN KEY (`anoLetivo`) REFERENCES `anoletivo` (`anoLetivo`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turma`
--

LOCK TABLES `turma` WRITE;
/*!40000 ALTER TABLE `turma` DISABLE KEYS */;
INSERT INTO `turma` VALUES (1,2024,'1° A',30,30,'105','F','A');
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidadetematica`
--

LOCK TABLES `unidadetematica` WRITE;
/*!40000 ALTER TABLE `unidadetematica` DISABLE KEYS */;
INSERT INTO `unidadetematica` VALUES (2,'Teste',2024,2,1);
/*!40000 ALTER TABLE `unidadetematica` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-04 15:12:57
