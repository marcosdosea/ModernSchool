-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema ModernSchool
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `ModernSchool` ;

-- -----------------------------------------------------
-- Schema ModernSchool
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ModernSchool` DEFAULT CHARACTER SET utf8 ;
USE `ModernSchool` ;

-- -----------------------------------------------------
-- Table `ModernSchool`.`Governo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`Governo` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`Governo` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `municipio` VARCHAR(50) NOT NULL,
  `Estado` VARCHAR(50) NOT NULL,
  `dependenciaAdministrativa` ENUM('M', 'E') NOT NULL DEFAULT 'M',
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`Pessoa`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`Pessoa` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`Pessoa` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(70) NOT NULL,
  `cpf` CHAR(11) NOT NULL,
  `dataNascimento` DATE NOT NULL,
  `cep` VARCHAR(8) NOT NULL,
  `rua` VARCHAR(50) NULL,
  `bairro` VARCHAR(40) NULL,
  `numero` SMALLINT(4) UNSIGNED NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`Escola`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`Escola` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`Escola` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(70) NOT NULL,
  `cnpj` CHAR(14) NOT NULL,
  `rua` VARCHAR(50) NULL,
  `bairro` VARCHAR(40) NULL,
  `numero` SMALLINT(4) NULL,
  `idGoverno` INT UNSIGNED NOT NULL,
  `idDiretor` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `Nome_UNIQUE` (`Nome` ASC),
  INDEX `fk_Escola_Prefeitura_idx` (`idGoverno` ASC),
  INDEX `fk_Escola_Pessoa1_idx` (`idDiretor` ASC),
  CONSTRAINT `fk_Escola_Prefeitura`
    FOREIGN KEY (`idGoverno`)
    REFERENCES `ModernSchool`.`Governo` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Escola_Pessoa1`
    FOREIGN KEY (`idDiretor`)
    REFERENCES `ModernSchool`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`Componente`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`Componente` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`Componente` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(40) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`Curriculo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`Curriculo` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`Curriculo` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `escolaridade` CHAR(1) NOT NULL,
  `anoFaixa` VARCHAR(4) NOT NULL,
  `anoLetivo` SMALLINT(4) NOT NULL,
  `idGoverno` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Curriculo_Governo1_idx` (`idGoverno` ASC),
  CONSTRAINT `fk_Curriculo_Governo1`
    FOREIGN KEY (`idGoverno`)
    REFERENCES `ModernSchool`.`Governo` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`UnidadeTematica`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`UnidadeTematica` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`UnidadeTematica` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(100) NOT NULL,
  `anoLetivo` SMALLINT(4) NULL,
  `idCurriculo` INT UNSIGNED NOT NULL,
  `idComponente` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_UnidadeTematica_Curriculo1_idx` (`idCurriculo` ASC),
  INDEX `fk_UnidadeTematica_Componente1_idx` (`idComponente` ASC),
  CONSTRAINT `fk_UnidadeTematica_Curriculo1`
    FOREIGN KEY (`idCurriculo`)
    REFERENCES `ModernSchool`.`Curriculo` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_UnidadeTematica_Componente1`
    FOREIGN KEY (`idComponente`)
    REFERENCES `ModernSchool`.`Componente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`ObjetoDeConhecimento`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`ObjetoDeConhecimento` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`ObjetoDeConhecimento` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `idUnidadeTematica` INT UNSIGNED NOT NULL,
  `descricao` VARCHAR(100) NOT NULL,
  `sequenciaProposta` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_ObjetoDeConhecimento_UnidadeTematica1_idx` (`idUnidadeTematica` ASC),
  CONSTRAINT `fk_ObjetoDeConhecimento_UnidadeTematica1`
    FOREIGN KEY (`idUnidadeTematica`)
    REFERENCES `ModernSchool`.`UnidadeTematica` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`AnoLetivo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`AnoLetivo` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`AnoLetivo` (
  `anoLetivo` INT UNSIGNED NOT NULL,
  `idEscola` INT UNSIGNED NOT NULL,
  `dataInicio` DATE NOT NULL,
  `dataFim` DATE NOT NULL,
  INDEX `fk_AnoLetivo_Escola1_idx` (`idEscola` ASC),
  PRIMARY KEY (`anoLetivo`),
  CONSTRAINT `fk_AnoLetivo_Escola1`
    FOREIGN KEY (`idEscola`)
    REFERENCES `ModernSchool`.`Escola` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`Turma`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`Turma` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`Turma` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `anoLetivo` INT UNSIGNED NOT NULL,
  `turma` VARCHAR(50) NOT NULL,
  `vagas` INT UNSIGNED NOT NULL,
  `vagasDisponiveis` INT NOT NULL,
  `sala` VARCHAR(20) NULL,
  `escolaridade` ENUM('F', 'I', 'M') NOT NULL DEFAULT 'F',
  `status` ENUM('A', 'F', 'C') NOT NULL DEFAULT 'A' COMMENT 'A - ATIVA\nF - FINALIZADA\nC - CANCELADA',
  PRIMARY KEY (`id`),
  INDEX `fk_Turma_AnoLetivo1_idx` (`anoLetivo` ASC),
  CONSTRAINT `fk_Turma_AnoLetivo1`
    FOREIGN KEY (`anoLetivo`)
    REFERENCES `ModernSchool`.`AnoLetivo` (`anoLetivo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`Periodo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`Periodo` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`Periodo` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(30) NOT NULL,
  `dataInicio` DATE NULL,
  `dataFim` DATE NULL,
  `anoLetivo` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Periodo_AnoLetivo1_idx` (`anoLetivo` ASC),
  CONSTRAINT `fk_Periodo_AnoLetivo1`
    FOREIGN KEY (`anoLetivo`)
    REFERENCES `ModernSchool`.`AnoLetivo` (`anoLetivo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`Avaliacao`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`Avaliacao` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`Avaliacao` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `dataEntrega` DATETIME NOT NULL,
  `horarioEntrega` DATETIME NOT NULL,
  `tipoDeAtividade` ENUM('PROVA', 'PROJETO', 'ATIVIDADE') NOT NULL,
  `peso` SMALLINT(2) NOT NULL,
  `avaliativo` TINYINT(1) NULL,
  `idTurma` INT NOT NULL,
  `idComponente` INT UNSIGNED NOT NULL,
  `idPeriodo` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Avaliacao_Turma1_idx` (`idTurma` ASC),
  INDEX `fk_Avaliacao_Componente1_idx` (`idComponente` ASC),
  INDEX `fk_Avaliacao_Periodo1_idx` (`idPeriodo` ASC),
  CONSTRAINT `fk_Avaliacao_Turma1`
    FOREIGN KEY (`idTurma`)
    REFERENCES `ModernSchool`.`Turma` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Avaliacao_Componente1`
    FOREIGN KEY (`idComponente`)
    REFERENCES `ModernSchool`.`Componente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Avaliacao_Periodo1`
    FOREIGN KEY (`idPeriodo`)
    REFERENCES `ModernSchool`.`Periodo` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`Comunicacao`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`Comunicacao` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`Comunicacao` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `enviarAlunos` TINYINT NOT NULL DEFAULT 0,
  `enviarResponsaveis` TINYINT NOT NULL,
  `mensagem` VARCHAR(500) NOT NULL,
  `idTurma` INT NOT NULL,
  `idComponente` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Comunicacao_Turma1_idx` (`idTurma` ASC),
  INDEX `fk_Comunicacao_Componente1_idx` (`idComponente` ASC),
  CONSTRAINT `fk_Comunicacao_Turma1`
    FOREIGN KEY (`idTurma`)
    REFERENCES `ModernSchool`.`Turma` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Comunicacao_Componente1`
    FOREIGN KEY (`idComponente`)
    REFERENCES `ModernSchool`.`Componente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`DiarioDeClasse`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`DiarioDeClasse` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`DiarioDeClasse` (
  `id` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `dataShow` TINYINT(1) NOT NULL DEFAULT 0,
  `livros` TINYINT(1) NOT NULL DEFAULT 0,
  `livrosSeduc` TINYINT(1) NOT NULL DEFAULT 0,
  `resumoAula` VARCHAR(100) NULL,
  `idTurma` INT NOT NULL,
  `idComponente` INT UNSIGNED NOT NULL,
  `idProfessor` INT UNSIGNED NOT NULL,
  `tipoAula` ENUM('C', 'A') NOT NULL DEFAULT 'C',
  PRIMARY KEY (`id`),
  INDEX `fk_DiarioDeClasse_Turma1_idx` (`idTurma` ASC),
  INDEX `fk_DiarioDeClasse_Componente1_idx` (`idComponente` ASC),
  INDEX `fk_DiarioDeClasse_Pessoa1_idx` (`idProfessor` ASC),
  CONSTRAINT `fk_DiarioDeClasse_Turma1`
    FOREIGN KEY (`idTurma`)
    REFERENCES `ModernSchool`.`Turma` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DiarioDeClasse_Componente1`
    FOREIGN KEY (`idComponente`)
    REFERENCES `ModernSchool`.`Componente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DiarioDeClasse_Pessoa1`
    FOREIGN KEY (`idProfessor`)
    REFERENCES `ModernSchool`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`Habilidade`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`Habilidade` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`Habilidade` (
  `idHabilidade` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(100) NOT NULL,
  `idObjetoDeConhecimento` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`idHabilidade`),
  INDEX `fk_Habilidade_ObjetoDeConhecimento1_idx` (`idObjetoDeConhecimento` ASC),
  CONSTRAINT `fk_Habilidade_ObjetoDeConhecimento1`
    FOREIGN KEY (`idObjetoDeConhecimento`)
    REFERENCES `ModernSchool`.`ObjetoDeConhecimento` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`Cargo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`Cargo` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`Cargo` (
  `idCargo` INT UNSIGNED NOT NULL,
  `descricao` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idCargo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`GovernoServidor`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`GovernoServidor` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`GovernoServidor` (
  `idGoverno` INT UNSIGNED NOT NULL,
  `idPessoa` INT UNSIGNED NOT NULL,
  `idCargo` INT UNSIGNED NOT NULL,
  `dataInicio` DATE NOT NULL,
  `dataFim` DATE NULL,
  `status` ENUM('A', 'I', 'L') NOT NULL DEFAULT 'A' COMMENT 'A - ATIVO\nI - INATIVO\nL - LICENCIADO',
  `idEscola` INT UNSIGNED NULL DEFAULT NULL,
  PRIMARY KEY (`idGoverno`, `idPessoa`),
  INDEX `fk_GovernoServidor_Pessoa1_idx` (`idPessoa` ASC),
  INDEX `fk_GovernoServidor_Cargo1_idx` (`idCargo` ASC),
  INDEX `fk_GovernoServidor_Escola1_idx` (`idEscola` ASC),
  CONSTRAINT `fk_GovernoServidor_Cargo1`
    FOREIGN KEY (`idCargo`)
    REFERENCES `ModernSchool`.`Cargo` (`idCargo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_GovernoServidor_Governo1`
    FOREIGN KEY (`idGoverno`)
    REFERENCES `ModernSchool`.`Governo` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_GovernoServidor_Pessoa1`
    FOREIGN KEY (`idPessoa`)
    REFERENCES `ModernSchool`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_GovernoServidor_Escola1`
    FOREIGN KEY (`idEscola`)
    REFERENCES `ModernSchool`.`Escola` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`GradeHorario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`GradeHorario` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`GradeHorario` (
  `id` INT NOT NULL,
  `idComponente` INT UNSIGNED NOT NULL,
  `idTurma` INT NOT NULL,
  `diaSemana` ENUM('DOM', 'SEG', 'TER', 'QUA', 'QUI', 'SEX', 'SAB') NOT NULL,
  `horaInicio` VARCHAR(4) NOT NULL,
  `horaFim` VARCHAR(4) NOT NULL,
  `idProfessor` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_ComponenteTurma_Turma1_idx` (`idTurma` ASC),
  INDEX `fk_ComponenteTurma_Componente1_idx` (`idComponente` ASC),
  INDEX `fk_GradeHorario_Pessoa1_idx` (`idProfessor` ASC),
  CONSTRAINT `fk_ComponenteTurma_Componente1`
    FOREIGN KEY (`idComponente`)
    REFERENCES `ModernSchool`.`Componente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ComponenteTurma_Turma1`
    FOREIGN KEY (`idTurma`)
    REFERENCES `ModernSchool`.`Turma` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_GradeHorario_Pessoa1`
    FOREIGN KEY (`idProfessor`)
    REFERENCES `ModernSchool`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`ObjetoDeConhecimentoDiarioDeClasse`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`ObjetoDeConhecimentoDiarioDeClasse` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`ObjetoDeConhecimentoDiarioDeClasse` (
  `idObjetoDeConhecimento` INT UNSIGNED NOT NULL,
  `idDiarioDeClasse` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`idObjetoDeConhecimento`, `idDiarioDeClasse`),
  INDEX `fk_ObjetoDeConhecimentoDiarioDeClasse_DiarioDeClasse1_idx` (`idDiarioDeClasse` ASC),
  INDEX `fk_ObjetoDeConhecimentoDiarioDeClasse_ObjetoDeConhecimento1_idx` (`idObjetoDeConhecimento` ASC),
  CONSTRAINT `fk_ObjetoDeConhecimentoDiarioDeClasse_ObjetoDeConhecimento1`
    FOREIGN KEY (`idObjetoDeConhecimento`)
    REFERENCES `ModernSchool`.`ObjetoDeConhecimento` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ObjetoDeConhecimentoDiarioDeClasse_DiarioDeClasse1`
    FOREIGN KEY (`idDiarioDeClasse`)
    REFERENCES `ModernSchool`.`DiarioDeClasse` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`FrequenciaAluno`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`FrequenciaAluno` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`FrequenciaAluno` (
  `idAluno` INT UNSIGNED NOT NULL,
  `idDiarioDeClasse` INT UNSIGNED NOT NULL,
  `faltas` INT NOT NULL DEFAULT 0,
  PRIMARY KEY (`idAluno`, `idDiarioDeClasse`),
  INDEX `fk_PessoaDiarioDeClasse_DiarioDeClasse1_idx` (`idDiarioDeClasse` ASC),
  INDEX `fk_PessoaDiarioDeClasse_Pessoa1_idx` (`idAluno` ASC),
  CONSTRAINT `fk_PessoaDiarioDeClasse_Pessoa1`
    FOREIGN KEY (`idAluno`)
    REFERENCES `ModernSchool`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PessoaDiarioDeClasse_DiarioDeClasse1`
    FOREIGN KEY (`idDiarioDeClasse`)
    REFERENCES `ModernSchool`.`DiarioDeClasse` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`AlunoAvaliacao`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`AlunoAvaliacao` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`AlunoAvaliacao` (
  `idAluno` INT UNSIGNED NOT NULL,
  `idAvaliacao` INT UNSIGNED NOT NULL,
  `nota` DECIMAL(10,2) NOT NULL DEFAULT 0,
  `dataEntrega` DATETIME NOT NULL,
  `arquivo` BLOB NOT NULL,
  PRIMARY KEY (`idAluno`, `idAvaliacao`),
  INDEX `fk_PessoaAvaliacao_Avaliacao1_idx` (`idAvaliacao` ASC),
  INDEX `fk_PessoaAvaliacao_Pessoa1_idx` (`idAluno` ASC),
  CONSTRAINT `fk_PessoaAvaliacao_Pessoa1`
    FOREIGN KEY (`idAluno`)
    REFERENCES `ModernSchool`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PessoaAvaliacao_Avaliacao1`
    FOREIGN KEY (`idAvaliacao`)
    REFERENCES `ModernSchool`.`Avaliacao` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`AlunoComunicacao`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`AlunoComunicacao` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`AlunoComunicacao` (
  `idAluno` INT UNSIGNED NOT NULL,
  `idComunicacao` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`idAluno`, `idComunicacao`),
  INDEX `fk_PessoaComunicacao_Comunicacao1_idx` (`idComunicacao` ASC),
  INDEX `fk_PessoaComunicacao_Pessoa1_idx` (`idAluno` ASC),
  CONSTRAINT `fk_PessoaComunicacao_Pessoa1`
    FOREIGN KEY (`idAluno`)
    REFERENCES `ModernSchool`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PessoaComunicacao_Comunicacao1`
    FOREIGN KEY (`idComunicacao`)
    REFERENCES `ModernSchool`.`Comunicacao` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`PessoaComunicacao`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`PessoaComunicacao` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`PessoaComunicacao` (
  `idPessoa` INT UNSIGNED NOT NULL,
  `idComunicacao` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`idPessoa`, `idComunicacao`),
  INDEX `fk_PessoaComunicacao_Comunicacao2_idx` (`idComunicacao` ASC),
  INDEX `fk_PessoaComunicacao_Pessoa2_idx` (`idPessoa` ASC),
  CONSTRAINT `fk_PessoaComunicacao_Pessoa2`
    FOREIGN KEY (`idPessoa`)
    REFERENCES `ModernSchool`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PessoaComunicacao_Comunicacao2`
    FOREIGN KEY (`idComunicacao`)
    REFERENCES `ModernSchool`.`Comunicacao` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ModernSchool`.`AlunoTurma`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `ModernSchool`.`AlunoTurma` ;

CREATE TABLE IF NOT EXISTS `ModernSchool`.`AlunoTurma` (
  `idAluno` INT UNSIGNED NOT NULL,
  `idTurma` INT NOT NULL,
  `status` ENUM('M', 'A', 'R', 'C') NOT NULL DEFAULT 'M' COMMENT 'M - MATRICULADO\nA - APROVADO\nR - REPROVADO\nC - CANCELADO',
  PRIMARY KEY (`idAluno`, `idTurma`),
  INDEX `fk_PessoaTurma_Turma1_idx` (`idTurma` ASC),
  INDEX `fk_PessoaTurma_Pessoa1_idx` (`idAluno` ASC),
  CONSTRAINT `fk_PessoaTurma_Pessoa1`
    FOREIGN KEY (`idAluno`)
    REFERENCES `ModernSchool`.`Pessoa` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PessoaTurma_Turma1`
    FOREIGN KEY (`idTurma`)
    REFERENCES `ModernSchool`.`Turma` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
