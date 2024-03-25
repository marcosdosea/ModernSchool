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
INSERT INTO `alunoavaliacao` VALUES (6,1,0.00,'2024-03-25 16:26:56',_binary 'from tkinter import *\r\nimport random as r\r\n\r\ndef resultado():\r\n\r\n    jogador = \"\"\r\n    vencedor = \"\"\r\n    if estado_radio.get() == 1:\r\n        jogador = \"Impar\"\r\n    elif estado_radio.get() == 2:\r\n        jogador = \"Par\"\r\n\r\n    if estado_radio.get() == 0:\r\n        resultadoPartida = Label(text=\"Escolha uma opcao\").grid(column=4,row=5)\r\n\r\n    else:\r\n        numPc = r.randint(1,10)\r\n        soma = int(escolhaNum.get()) + numPc\r\n        div = soma%2\r\n\r\n        if div == 0:\r\n            vencedor = \"Par\"\r\n        else:\r\n            vencedor = \"Impar\"\r\n        if(vencedor == jogador):\r\n            resultadoPartida = Label(text=f\"Voce venceu, o pc escolheu {numPc} \").grid(column=4,row=5)\r\n        else:\r\n\r\n            resultadoPartida = Label(text=f\"Voce perdeu, o pc escolheu {numPc} \").grid(column=4,row=5)\r\n            \r\njanela = Tk()\r\njanela.title(\"Impar par\")\r\njanela.minsize(height=500,width=500)\r\n\r\nestado_radio = IntVar()\r\n\r\nradiobutton1 = Radiobutton(text=\"Ímpar\", value=1, variable=estado_radio).grid(column=3,row=1)\r\nradiobutton2 = Radiobutton(text=\"Par\", value=2, variable=estado_radio).grid(column=6,row=1)\r\nnumInfo = Label(text=\"Informe o seu Número\").grid(column=4,row=2)\r\nescolhaNum = Entry()\r\nescolhaNum.grid(column=4,row=3)\r\njogar = Button(text=\"Jogar\",command=resultado).grid(column=4,row=4)\r\n\r\n\r\njanela.mainloop()\r\n\r\n\r\n\r\n\r\n\r\n'),(7,1,0.00,'2024-03-25 16:26:57',_binary 'from tkinter import *\r\nimport random as r\r\n\r\ndef resultado():\r\n\r\n    jogador = \"\"\r\n    vencedor = \"\"\r\n    if estado_radio.get() == 1:\r\n        jogador = \"Impar\"\r\n    elif estado_radio.get() == 2:\r\n        jogador = \"Par\"\r\n\r\n    if estado_radio.get() == 0:\r\n        resultadoPartida = Label(text=\"Escolha uma opcao\").grid(column=4,row=5)\r\n\r\n    else:\r\n        numPc = r.randint(1,10)\r\n        soma = int(escolhaNum.get()) + numPc\r\n        div = soma%2\r\n\r\n        if div == 0:\r\n            vencedor = \"Par\"\r\n        else:\r\n            vencedor = \"Impar\"\r\n        if(vencedor == jogador):\r\n            resultadoPartida = Label(text=f\"Voce venceu, o pc escolheu {numPc} \").grid(column=4,row=5)\r\n        else:\r\n\r\n            resultadoPartida = Label(text=f\"Voce perdeu, o pc escolheu {numPc} \").grid(column=4,row=5)\r\n            \r\njanela = Tk()\r\njanela.title(\"Impar par\")\r\njanela.minsize(height=500,width=500)\r\n\r\nestado_radio = IntVar()\r\n\r\nradiobutton1 = Radiobutton(text=\"Ímpar\", value=1, variable=estado_radio).grid(column=3,row=1)\r\nradiobutton2 = Radiobutton(text=\"Par\", value=2, variable=estado_radio).grid(column=6,row=1)\r\nnumInfo = Label(text=\"Informe o seu Número\").grid(column=4,row=2)\r\nescolhaNum = Entry()\r\nescolhaNum.grid(column=4,row=3)\r\njogar = Button(text=\"Jogar\",command=resultado).grid(column=4,row=4)\r\n\r\n\r\njanela.mainloop()\r\n\r\n\r\n\r\n\r\n\r\n');
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
INSERT INTO `alunoturma` VALUES (6,1,'M'),(7,1,'M');
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
INSERT INTO `anoletivo` VALUES (2024,1,'2024-03-25','2024-12-25');
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
INSERT INTO `aspnetroles` VALUES ('11742b69-211d-41a2-9ffa-253b3aedf818','PROFESSOR','PROFESSOR','28817609-d4d8-489b-92ba-39557ae22fdf'),('4e41763d-d54c-472a-ab46-dadabb2d8859','DIRETOR','DIRETOR','fac5a197-97f3-47e9-b29e-479fa1e5ac80'),('ea3ed6b4-2133-4f8c-b89f-30df4ba51944','ALUNO','ALUNO','2b0bd3f6-a00d-4cf0-8f20-556614d0fdc4');
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
INSERT INTO `aspnetuserroles` VALUES ('5fc0e926-1395-432e-ab8c-23da20026147','11742b69-211d-41a2-9ffa-253b3aedf818'),('7c9d95e4-8455-42bf-9c0b-03d419315713','11742b69-211d-41a2-9ffa-253b3aedf818'),('8cf66879-8c65-42c0-be2c-bc51370c61cb','11742b69-211d-41a2-9ffa-253b3aedf818'),('0f900e08-881c-41e0-8387-b2f8ea9c7eba','4e41763d-d54c-472a-ab46-dadabb2d8859'),('8cf66879-8c65-42c0-be2c-bc51370c61cb','4e41763d-d54c-472a-ab46-dadabb2d8859'),('5bcb9029-dd8d-44c9-85a7-e73747e43954','ea3ed6b4-2133-4f8c-b89f-30df4ba51944'),('d4abcf10-c819-409f-a0f8-220ecc0d682b','ea3ed6b4-2133-4f8c-b89f-30df4ba51944');
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
INSERT INTO `aspnetusers` VALUES ('0f900e08-881c-41e0-8387-b2f8ea9c7eba','diretor@gmail.com','diretor@gmail.com',NULL,NULL,_binary '\0','AQAAAAEAACcQAAAAECfuURCq3/SlKumV6LoffVZ/PJ1E+pUg0ZkVLrPC8L2MTj5forpWexL8oTCEx3d1Ww==','U3ODHHNJ3VZU45UGMWA2AEOTBKWHODV3','b3896af2-a235-48ad-b81e-4feed9c28f65',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),('5bcb9029-dd8d-44c9-85a7-e73747e43954','reinan@gmail.com','REINAN@GMAIL.COM','reinan@gmail.com','REINAN@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAEMhzl+SPSfkp9dMzKHuAlaFpqETkn1niWhvCvY7hAFeDgyew65xq3L/DrIZHZLTLFQ==','JX5XD4SAOKIG6DBA3EHPQ6SZ3JQZZOB3','fdbd9731-3ca5-4cc8-b0f2-ddfd81933768',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),('5fc0e926-1395-432e-ab8c-23da20026147','professor@gmail.com','PROFESSOR@GMAIL.COM','professor@gmail.com','PROFESSOR@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAEE6rkR8+pfEPSTQDtBl8UB07dTkhoEAOCvEHp7cQb0w4zQKXSir3RjvKFVNrBwlCJg==','6CMWNYR2VWWYPPICUSUDWULD6XH43ZBK','38a5a27e-8767-4d0f-8336-79180f84435d',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),('7c9d95e4-8455-42bf-9c0b-03d419315713','professoramaria@gmail.com','PROFESSORAMARIA@GMAIL.COM','professoramaria@gmail.com','PROFESSORAMARIA@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAELdEA1/OqrTVVJbjl/vJ3nsqCF2D+VOWNiT9QiPn8KSHQSRg6D2ik/VtGpV3ikVtOw==','D5S4GPUXSTCCXGJZFMSXDNKEIOHFIRJX','6805496c-7a7c-4998-a166-1507bd2a9e61',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),('8cf66879-8c65-42c0-be2c-bc51370c61cb','professorjose@gmail.com','PROFESSORJOSE@GMAIL.COM','professorjose@gmail.com','PROFESSORJOSE@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAEGT90IZtgnLE1DWUYBPbNRLyzePzoNDzEEnc99Egf2nBcdzOopAeLvhE+aCuAXTSKw==','ZLE7535LL4ZB2J5TK5KIFLICNRL2AT55','874a7ead-a8b2-4884-9d0c-695c276ce23e',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),('d4abcf10-c819-409f-a0f8-220ecc0d682b','matheusdacruzsouza1998@gmail.com','MATHEUSDACRUZSOUZA1998@GMAIL.COM','matheusdacruzsouza1998@gmail.com','MATHEUSDACRUZSOUZA1998@GMAIL.COM',_binary '','AQAAAAEAACcQAAAAEOEn3eCrWAjsMQPMtmkJT0N2vpgH+OqsvimOI/tW6YhVE946hdv2Vs1kjUmgVSHU+w==','FRLDJ4FKGZBHT2Y7O56JGHKIAM2AXQQT','5529f67d-b53e-4e0b-ab8b-c19ca39e37fb',NULL,_binary '\0',_binary '\0',NULL,_binary '',0);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `avaliacao`
--

LOCK TABLES `avaliacao` WRITE;
/*!40000 ALTER TABLE `avaliacao` DISABLE KEYS */;
INSERT INTO `avaliacao` VALUES (1,'2024-03-25 16:25:00','PROVA',2,1,1,1,1);
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
INSERT INTO `cargo` VALUES (1,'Diretor'),(2,'Professor');
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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `componente`
--

LOCK TABLES `componente` WRITE;
/*!40000 ALTER TABLE `componente` DISABLE KEYS */;
INSERT INTO `componente` VALUES (1,'Matemática'),(2,'Geografia'),(3,'História'),(4,'Inglês '),(5,'E. Física'),(6,'Arte'),(7,'Ciências '),(8,'Religião'),(9,'Português');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `curriculo`
--

LOCK TABLES `curriculo` WRITE;
/*!40000 ALTER TABLE `curriculo` DISABLE KEYS */;
INSERT INTO `curriculo` VALUES (1,'I','1',2024,1);
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diariodeclasse`
--

LOCK TABLES `diariodeclasse` WRITE;
/*!40000 ALTER TABLE `diariodeclasse` DISABLE KEYS */;
INSERT INTO `diariodeclasse` VALUES (1,'2024-03-25',1,0,0,'Soma dos números inteiros ',1,1,2,'C'),(2,'2024-03-25',1,0,0,'Soma de números inteiros',1,1,2,'C');
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
INSERT INTO `escola` VALUES (1,'Colégio Estadual Murilo Braga','78.415.485/415',' R. Quintino Bocaiúva','Centro',659,1,1);
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
INSERT INTO `governo` VALUES (1,'Itabaiana','SE','M');
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
INSERT INTO `governoservidor` VALUES (1,1,1,'2024-03-25',NULL,'A',NULL),(1,2,2,'2024-03-25',NULL,'A',NULL),(1,4,2,'2024-03-25',NULL,'A',NULL),(1,5,2,'2024-03-25',NULL,'A',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gradehorario`
--

LOCK TABLES `gradehorario` WRITE;
/*!40000 ALTER TABLE `gradehorario` DISABLE KEYS */;
INSERT INTO `gradehorario` VALUES (1,1,1,'SEG','0730','1100',2),(2,2,1,'QUA','0730','1100',4),(3,3,1,'TER','0830','1100',5);
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
  `descricao` varchar(300) NOT NULL,
  `idObjetoDeConhecimento` int unsigned NOT NULL,
  PRIMARY KEY (`idHabilidade`),
  KEY `fk_Habilidade_ObjetoDeConhecimento1_idx` (`idObjetoDeConhecimento`),
  CONSTRAINT `fk_Habilidade_ObjetoDeConhecimento1` FOREIGN KEY (`idObjetoDeConhecimento`) REFERENCES `objetodeconhecimento` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=89 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `habilidade`
--

LOCK TABLES `habilidade` WRITE;
/*!40000 ALTER TABLE `habilidade` DISABLE KEYS */;
INSERT INTO `habilidade` VALUES (43,'(EF01MA02) Contar de maneira exata ou aproximada, utilizando diferentes estratégias como o pareamento e outros agrupamentos.',34),(44,'(EF01MA03) Estimar e comparar quantidades de objetos de dois conjuntos (em torno de 20 elementos), por estimativa e/ou por correspondência (um a um, dois a dois) para indicar “tem mais”, “tem menos” ou “tem a mesma quantidade”.',35),(45,'(EF01MA04) Contar a quantidade de objetos de coleções até 100 unidades e apresentar o resultado por registros verbais e simbólicos, em situações de seu interesse, como jogos, brincadeiras, materiais da sala de aula, entre outros.',36),(46,'(EF01MA05) Comparar números naturais de até duas ordens em situações cotidianas, com e sem suporte da reta numérica.',37),(47,'(EF01MA06) Construir fatos básicos da adição e utilizá-los em procedimentos de cálculo para resolver problemas.',38),(48,'(EF01MA07) Compor e decompor número de até duas ordens, por meio de diferentes adições, com o suporte de material manipulável, contribuindo para a compreensão de características do sistema de numeração decimal e o desenvolvimento de estratégias de cálculo.',39),(49,'(EF01MA08) Resolver e elaborar problemas de adição e de subtração, envolvendo números de até dois algarismos, com os significados de juntar, acrescentar, separar e retirar, com o suporte de imagens e/ou material manipulável, utilizando estratégias e formas de registro pessoais.',40),(50,'(EF01MA09) Organizar e ordenar objetos familiares ou representações por figuras, por meio de atributos, tais como cor, forma e medida.',41),(51,'(EF01MA10) Descrever, após o reconhecimento e a explicitação de um padrão (ou regularidade), os elementos ausentes em sequências recursivas de números naturais, objetos ou figuras.',42),(52,'(EF01MA11) Descrever a localização de pessoas e de objetos no espaço em relação à sua própria posição, utilizando termos como à direita, à esquerda, em frente, atrás.',43),(53,'(EF01MA12) Descrever a localização de pessoas e de objetos no espaço segundo um dado ponto de referência, compreendendo que, para a utilização de termos que se referem à posição, como direita, esquerda, em cima, em baixo, é necessário explicitar-se o referencial.',44),(54,'(EF01MA13) Relacionar figuras geométricas espaciais (cones, cilindros, esferas e blocos retangulares) a objetos familiares do mundo físico.',45),(55,'(EF01MA14) Identificar e nomear figuras planas (círculo, quadrado, retângulo e triângulo) em desenhos apresentados em diferentes disposições ou em contornos de faces de sólidos geométricos.',46),(56,'(EF01MA15) Comparar comprimentos, capacidades ou massas, utilizando termos como mais alto, mais baixo, mais comprido, mais curto, mais grosso, mais fino, mais largo, mais pesado, mais leve, cabe mais, cabe menos, entre outros, para ordenar objetos de uso cotidiano.',47),(57,'(EF01MA16) Relatar em linguagem verbal ou não verbal sequência de acontecimentos relativos a um dia, utilizando, quando possível, os horários dos eventos.',48),(58,'(EF01MA17) Reconhecer e relacionar períodos do dia, dias da semana e meses do ano, utilizando calendário, quando necessário.',49),(59,'(EF01MA18) Produzir a escrita de uma data, apresentando o dia, o mês e o ano, e indicar o dia da semana de uma data, consultando calendários.',50),(60,'(EF01MA19) Reconhecer e relacionar valores de moedas e cédulas do sistema monetário brasileiro para resolver situações simples do cotidiano do estudante.',51),(61,'(EF01MA20) Classificar eventos envolvendo o acaso, tais como “acontecerá com certeza”, “talvez aconteça” e “é impossível acontecer”, em situações do cotidiano.',52),(62,'(EF01MA21) Ler dados expressos em tabelas e em gráficos de colunas simples.',53),(63,'(EF01MA22) Realizar pesquisa, envolvendo até duas variáveis categóricas de seu interesse e universo de até 30 elementos, e organizar dados por meio de representações pessoais.',54),(65,'(EF01GE02) Identificar semelhanças e diferenças entre jogos e brincadeiras de diferentes épocas e lugares.',55),(66,'(EF01GE03) Identificar e relatar semelhanças e diferenças de usos do espaço público (praças, parques) para o lazer e diferentes manifestações.',56),(67,'(EF01GE04) Discutir e elaborar, coletivamente, regras de convívio em diferentes espaços (sala de aula, escola etc.).',57),(68,'(EF01GE05) Observar e descrever ritmos naturais (dia e noite, variação de temperatura e umidade etc.) em diferentes escalas espaciais e temporais, comparando a sua realidade com outras.',58),(69,'(EF01GE06) Descrever e comparar diferentes tipos de moradia ou objetos de uso cotidiano (brinquedos, roupas, mobiliários), considerando técnicas e materiais utilizados em sua produção.',59),(70,'(EF01GE07) Descrever atividades de trabalho relacionadas com o dia a dia da sua comunidade.',60),(71,'(EF01GE08) Criar mapas mentais e desenhos com base em itinerários, contos literários, histórias inventadas e brincadeiras.',61),(72,'(EF01GE09) Elaborar e utilizar mapas simples para localizar elementos do local de vivência, considerando referenciais espaciais (frente e atrás, esquerda e direita, em cima e embaixo, dentro e fora) e tendo o corpo como referência.',62),(73,'(EF01GE10) Descrever características de seus lugares de vivência relacionadas aos ritmos da natureza (chuva, vento, calor etc.).',63),(74,'(EF01GE11) Associar mudanças de vestuário e hábitos alimentares em sua comunidade ao longo do ano, decorrentes da variação de temperatura e umidade no ambiente.',64),(75,'(EF01HI02) Identificar a relação entre as suas histórias e as histórias de sua família e de sua comunidade.',65),(76,'(EF01HI03) Descrever e distinguir os seus papéis e responsabilidades relacionados à família, à escola e à comunidade.',66),(77,'(EF01HI04) Identificar as diferenças entre os variados ambientes em que vive (doméstico, escolar e da comunidade), reconhecendo as especificidades dos hábitos e das regras que os regem.',67),(78,'(EF01HI05) Identificar semelhanças e diferenças entre jogos e brincadeiras atuais e de outras épocas e lugares.',68),(79,'(EF01HI06) Conhecer as histórias da família e da escola e identificar o papel desempenhado por diferentes sujeitos em diferentes espaços.',69),(80,'(EF01HI07) Identificar mudanças e permanências nas formas de organização familiar.',70),(81,'(EF01HI08) Reconhecer o significado das comemorações e festas escolares, diferenciando-as das datas festivas comemoradas no âmbito familiar ou da comunidade.',71),(82,'(EF01HI02) Identificar a relação entre as suas histórias e as histórias de sua família e de sua comunidade.',65),(83,'(EF01HI03) Descrever e distinguir os seus papéis e responsabilidades relacionados à família, à escola e à comunidade.',66),(84,'(EF01HI04) Identificar as diferenças entre os variados ambientes em que vive (doméstico, escolar e da comunidade), reconhecendo as especificidades dos hábitos e das regras que os regem.',67),(85,'(EF01HI05) Identificar semelhanças e diferenças entre jogos e brincadeiras atuais e de outras épocas e lugares.',68),(86,'(EF01HI06) Conhecer as histórias da família e da escola e identificar o papel desempenhado por diferentes sujeitos em diferentes espaços.',69),(87,'(EF01HI07) Identificar mudanças e permanências nas formas de organização familiar.',70),(88,'(EF01HI08) Reconhecer o significado das comemorações e festas escolares, diferenciando-as das datas festivas comemoradas no âmbito familiar ou da comunidade.',71);
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
  `descricao` varchar(200) NOT NULL,
  `sequenciaProposta` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_ObjetoDeConhecimento_UnidadeTematica1_idx` (`idUnidadeTematica`),
  CONSTRAINT `fk_ObjetoDeConhecimento_UnidadeTematica1` FOREIGN KEY (`idUnidadeTematica`) REFERENCES `unidadetematica` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `objetodeconhecimento`
--

LOCK TABLES `objetodeconhecimento` WRITE;
/*!40000 ALTER TABLE `objetodeconhecimento` DISABLE KEYS */;
INSERT INTO `objetodeconhecimento` VALUES (34,32,'Quantificação de elementos de uma coleção: estimativas, contagem um a um, pareamento ou outros agrupamentos e comparação',1),(35,33,'Quantificação de elementos de uma coleção: estimativas, contagem um a um, pareamento ou outros agrupamentos e comparação',2),(36,34,'Leitura, escrita e comparação de números naturais (até 100)\r\nReta numérica',3),(37,35,'Leitura, escrita e comparação de números naturais (até 100)\r\nReta numérica',4),(38,36,'Construção de fatos básicos da adição',5),(39,37,'Composição e decomposição de números naturais',6),(40,38,'Problemas envolvendo diferentes significados da adição e da subtração (juntar, acrescentar, separar, retirar)',7),(41,39,'Padrões figurais e numéricos: investigação de regularidades ou padrões em sequências',8),(42,40,'Sequências recursivas: observação de regras usadas utilizadas em seriações numéricas (mais 1, mais 2, menos 1, menos 2, por exemplo)',9),(43,41,'Localização de objetos e de pessoas no espaço, utilizando diversos pontos de referência e vocabulário apropriado',10),(44,42,'Localização de objetos e de pessoas no espaço, utilizando diversos pontos de referência e vocabulário apropriado',11),(45,43,'Figuras geométricas espaciais: reconhecimento e relações com objetos familiares do mundo físico',12),(46,44,'Figuras geométricas planas: reconhecimento do formato das faces de figuras geométricas espaciais',13),(47,45,'Medidas de comprimento, massa e capacidade: comparações e unidades de medida não convencionais',14),(48,46,'Medidas de tempo: unidades de medida de tempo, suas relações e o uso do calendário',15),(49,47,'Medidas de tempo: unidades de medida de tempo, suas relações e o uso do calendário',16),(50,48,'Medidas de tempo: unidades de medida de tempo, suas relações e o uso do calendário',17),(51,49,'Sistema monetário brasileiro: reconhecimento de cédulas e moedas',18),(52,50,'Noção de acaso',19),(53,51,'Leitura de tabelas e de gráficos de colunas simples',20),(54,52,'Coleta e organização de informações\r\nRegistros pessoais para comunicação de informações coletadas',21),(55,53,'O modo de vida das crianças em diferentes lugares',1),(56,54,'Situações de convívio em diferentes lugares',2),(57,55,'Situações de convívio em diferentes lugares',3),(58,56,'Ciclos naturais e a vida cotidiana',4),(59,57,'Diferentes tipos de trabalho existentes no seu dia a dia',5),(60,58,'Diferentes tipos de trabalho existentes no seu dia a dia',6),(61,59,'Pontos de referência',7),(62,60,'Pontos de referência',8),(63,61,'Condições de vida nos lugares de vivência',9),(64,62,'Condições de vida nos lugares de vivência',10),(65,77,'As diferentes formas de organização da família e da comunidade: os vínculos pessoais e as relações de amizade',1),(66,78,'As diferentes formas de organização da família e da comunidade: os vínculos pessoais e as relações de amizade',2),(67,79,'A escola e a diversidade do grupo social envolvido',3),(68,80,'A vida em casa, a vida na escola e formas de representação social e espacial: os jogos e brincadeiras como forma de interação social e espacial',4),(69,81,'A vida em família: diferentes configurações e vínculos',5),(70,82,'A vida em família: diferentes configurações e vínculos',6),(71,83,'A escola, sua representação espacial, sua história e seu papel na comunidade',7);
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
INSERT INTO `objetodeconhecimentodiariodeclasse` VALUES (34,2);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `periodo`
--

LOCK TABLES `periodo` WRITE;
/*!40000 ALTER TABLE `periodo` DISABLE KEYS */;
INSERT INTO `periodo` VALUES (1,'1°','2024-03-25','2024-05-30',2024);
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
INSERT INTO `pessoa` VALUES (1,'Jose Souza','78954126684','1979-06-05','4511899',NULL,NULL,NULL,'diretor@gmail.com'),(2,'Emilio da Conceição ','78548854486','1982-01-04','4511899',NULL,NULL,NULL,'professor@gmail.com'),(4,'Jose Ramalho da Silva','45124567544','1995-06-21','4511899',NULL,NULL,NULL,'professorjose@gmail.com'),(5,'Maria da Silva','27854123645','2000-01-01','4511899',NULL,NULL,NULL,'professoramaria@gmail.com'),(6,'Matheus Da Cruz Souza','87456985471','2006-05-21','78547851',NULL,NULL,60,'matheusdacruzsouza1998@gmail.com'),(7,'Reinan De Jesus','25488763548','2000-06-25','75665652',NULL,NULL,60,'reinan@gmail.com');
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
INSERT INTO `turma` VALUES (1,2024,'1° A',30,30,'108','I','A');
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
) ENGINE=InnoDB AUTO_INCREMENT=84 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidadetematica`
--

LOCK TABLES `unidadetematica` WRITE;
/*!40000 ALTER TABLE `unidadetematica` DISABLE KEYS */;
INSERT INTO `unidadetematica` VALUES (32,'Números',2024,1,1),(33,'Números',2024,1,1),(34,'Números',2024,1,1),(35,'Números',2024,1,1),(36,'Números',2024,1,1),(37,'Números',2024,1,1),(38,'Números',2024,1,1),(39,'Álgebra',2024,1,1),(40,'Álgebra',2024,1,1),(41,'Geometria',2024,1,1),(42,'Geometria',2024,1,1),(43,'Geometria',2024,1,1),(44,'Geometria',2024,1,1),(45,'Grandezas e medidas',2024,1,1),(46,'Grandezas e medidas',2024,1,1),(47,'Grandezas e medidas',2024,1,1),(48,'Grandezas e medidas',2024,1,1),(49,'Grandezas e medidas',2024,1,1),(50,'Probabilidade e estatística',2024,1,1),(51,'Probabilidade e estatística',2024,1,1),(52,'Probabilidade e estatística',2024,1,1),(53,'O sujeito e seu lugar no mundo',2024,1,2),(54,'O sujeito e seu lugar no mundo',2024,1,2),(55,'O sujeito e seu lugar no mundo',2024,1,2),(56,'Conexões e escalas',2024,1,2),(57,'Mundo do trabalho',2024,1,2),(58,'Mundo do trabalho',2024,1,2),(59,'Formas de representação e pensamento espacial',2024,1,2),(60,'Formas de representação e pensamento espacial',2024,1,2),(61,'Natureza, ambientes e qualidade de vida',2024,1,2),(62,'Natureza, ambientes e qualidade de vida',2024,1,2),(77,'Mundo pessoal: meu lugar no mundo',2024,1,3),(78,'Mundo pessoal: meu lugar no mundo',2024,1,3),(79,'Mundo pessoal: meu lugar no mundo',2024,1,3),(80,'Mundo pessoal: eu, meu grupo social e meu tempo',2024,1,3),(81,'Mundo pessoal: eu, meu grupo social e meu tempo',2024,1,3),(82,'Mundo pessoal: eu, meu grupo social e meu tempo',2024,1,3),(83,'Mundo pessoal: eu, meu grupo social e meu tempo',2024,1,3);
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

-- Dump completed on 2024-03-25 16:35:38
