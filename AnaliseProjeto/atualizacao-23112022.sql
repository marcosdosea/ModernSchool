-- MySQL Workbench Synchronization
-- Generated: 2022-11-23 21:41
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: junio

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

ALTER SCHEMA `modernschool`  DEFAULT CHARACTER SET utf8  DEFAULT COLLATE utf8_general_ci ;

ALTER TABLE `modernschool`.`Escola` 
DROP FOREIGN KEY `fk_Escola_Prefeitura`;

ALTER TABLE `modernschool`.`ObjetoDeConhecimento` 
DROP FOREIGN KEY `fk_ObjetoDeConhecimento_UnidadeTematica1`;

ALTER TABLE `modernschool`.`Avaliacao` 
DROP FOREIGN KEY `fk_Avaliacao_Componente1`,
DROP FOREIGN KEY `fk_Avaliacao_Periodo1`;

ALTER TABLE `modernschool`.`Periodo` 
DROP FOREIGN KEY `fk_Periodo_AnoLetivo1`;

ALTER TABLE `modernschool`.`Comunicacao` 
DROP FOREIGN KEY `fk_Comunicacao_Componente1`;

ALTER TABLE `modernschool`.`Turma` 
DROP FOREIGN KEY `fk_Turma_AnoLetivo1`;

ALTER TABLE `modernschool`.`DiarioDeClasse` 
DROP FOREIGN KEY `fk_DiarioDeClasse_Componente1`,
DROP FOREIGN KEY `fk_DiarioDeClasse_Pessoa1`;

ALTER TABLE `modernschool`.`Curriculo` 
DROP FOREIGN KEY `fk_Curriculo_Governo1`;

ALTER TABLE `modernschool`.`UnidadeTematica` 
DROP FOREIGN KEY `fk_UnidadeTematica_Componente1`;

ALTER TABLE `modernschool`.`Habilidade` 
DROP FOREIGN KEY `fk_Habilidade_ObjetoDeConhecimento1`;

ALTER TABLE `modernschool`.`AnoLetivo` 
DROP FOREIGN KEY `fk_AnoLetivo_Escola1`;

ALTER TABLE `modernschool`.`GovernoServidor` 
DROP FOREIGN KEY `fk_GovernoServidor_Cargo1`,
DROP FOREIGN KEY `fk_GovernoServidor_Governo1`,
DROP FOREIGN KEY `fk_GovernoServidor_Pessoa1`;

ALTER TABLE `modernschool`.`GradeHorario` 
DROP FOREIGN KEY `fk_ComponenteTurma_Componente1`,
DROP FOREIGN KEY `fk_ComponenteTurma_Turma1`,
DROP FOREIGN KEY `fk_GradeHorario_Pessoa1`;

ALTER TABLE `modernschool`.`ObjetoDeConhecimentoDiarioDeClasse` 
DROP FOREIGN KEY `fk_ObjetoDeConhecimentoDiarioDeClasse_DiarioDeClasse1`;

ALTER TABLE `modernschool`.`FrequenciaAluno` 
DROP FOREIGN KEY `fk_PessoaDiarioDeClasse_DiarioDeClasse1`;

ALTER TABLE `modernschool`.`AlunoAvaliacao` 
DROP FOREIGN KEY `fk_PessoaAvaliacao_Avaliacao1`;

ALTER TABLE `modernschool`.`AlunoComunicacao` 
DROP FOREIGN KEY `fk_PessoaComunicacao_Comunicacao1`;

ALTER TABLE `modernschool`.`PessoaComunicacao` 
DROP FOREIGN KEY `fk_PessoaComunicacao_Comunicacao2`;

ALTER TABLE `modernschool`.`Escola` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
CHANGE COLUMN `numero` `numero` SMALLINT(4) NULL DEFAULT NULL ;

ALTER TABLE `modernschool`.`Componente` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`ObjetoDeConhecimento` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`Avaliacao` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
CHANGE COLUMN `peso` `peso` SMALLINT(2) NULL DEFAULT NULL ,
DROP PRIMARY KEY,
ADD PRIMARY KEY (`id`, `horarioEntrega`);
;

ALTER TABLE `modernschool`.`Periodo` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`Comunicacao` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`Turma` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`Pessoa` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
CHANGE COLUMN `idade` `idade` SMALLINT(2) NULL DEFAULT NULL ,
CHANGE COLUMN `numero` `numero` SMALLINT(4) UNSIGNED NULL DEFAULT NULL ;

ALTER TABLE `modernschool`.`DiarioDeClasse` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`Governo` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`Curriculo` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
CHANGE COLUMN `anoLetivo` `anoLetivo` SMALLINT(4) NULL DEFAULT NULL ;

ALTER TABLE `modernschool`.`UnidadeTematica` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
CHANGE COLUMN `anoLetivo` `anoLetivo` SMALLINT(4) NULL DEFAULT NULL ;

ALTER TABLE `modernschool`.`Habilidade` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`AnoLetivo` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`GovernoServidor` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`Cargo` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`GradeHorario` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`ObjetoDeConhecimentoDiarioDeClasse` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`FrequenciaAluno` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`AlunoAvaliacao` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`AlunoComunicacao` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`PessoaComunicacao` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

ALTER TABLE `modernschool`.`Escola` 
ADD CONSTRAINT `fk_Escola_Prefeitura`
  FOREIGN KEY (`idGoverno`)
  REFERENCES `modernschool`.`Governo` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`ObjetoDeConhecimento` 
ADD CONSTRAINT `fk_ObjetoDeConhecimento_UnidadeTematica1`
  FOREIGN KEY (`idUnidadeTematica`)
  REFERENCES `modernschool`.`UnidadeTematica` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`Avaliacao` 
DROP FOREIGN KEY `fk_Avaliacao_Turma1`;

ALTER TABLE `modernschool`.`Avaliacao` ADD CONSTRAINT `fk_Avaliacao_Turma1`
  FOREIGN KEY (`idTurma`)
  REFERENCES `modernschool`.`Turma` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_Avaliacao_Componente1`
  FOREIGN KEY (`idComponente`)
  REFERENCES `modernschool`.`Componente` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_Avaliacao_Periodo1`
  FOREIGN KEY (`idPeriodo`)
  REFERENCES `modernschool`.`Periodo` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`Periodo` 
ADD CONSTRAINT `fk_Periodo_AnoLetivo1`
  FOREIGN KEY (`anoLetivo`)
  REFERENCES `modernschool`.`AnoLetivo` (`anoLetivo`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`Comunicacao` 
DROP FOREIGN KEY `fk_Comunicacao_Turma1`;

ALTER TABLE `modernschool`.`Comunicacao` ADD CONSTRAINT `fk_Comunicacao_Turma1`
  FOREIGN KEY (`idTurma`)
  REFERENCES `modernschool`.`Turma` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_Comunicacao_Componente1`
  FOREIGN KEY (`idComponente`)
  REFERENCES `modernschool`.`Componente` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`Turma` 
ADD CONSTRAINT `fk_Turma_AnoLetivo1`
  FOREIGN KEY (`anoLetivo`)
  REFERENCES `modernschool`.`AnoLetivo` (`anoLetivo`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`DiarioDeClasse` 
DROP FOREIGN KEY `fk_DiarioDeClasse_Turma1`;

ALTER TABLE `modernschool`.`DiarioDeClasse` ADD CONSTRAINT `fk_DiarioDeClasse_Turma1`
  FOREIGN KEY (`idTurma`)
  REFERENCES `modernschool`.`Turma` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_DiarioDeClasse_Componente1`
  FOREIGN KEY (`idComponente`)
  REFERENCES `modernschool`.`Componente` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_DiarioDeClasse_Pessoa1`
  FOREIGN KEY (`idProfessor`)
  REFERENCES `modernschool`.`Pessoa` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`Curriculo` 
ADD CONSTRAINT `fk_Curriculo_Governo1`
  FOREIGN KEY (`idGoverno`)
  REFERENCES `modernschool`.`Governo` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`UnidadeTematica` 
DROP FOREIGN KEY `fk_UnidadeTematica_Curriculo1`;

ALTER TABLE `modernschool`.`UnidadeTematica` ADD CONSTRAINT `fk_UnidadeTematica_Curriculo1`
  FOREIGN KEY (`idCurriculo`)
  REFERENCES `modernschool`.`Curriculo` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_UnidadeTematica_Componente1`
  FOREIGN KEY (`idComponente`)
  REFERENCES `modernschool`.`Componente` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`Habilidade` 
ADD CONSTRAINT `fk_Habilidade_ObjetoDeConhecimento1`
  FOREIGN KEY (`idObjetoDeConhecimento`)
  REFERENCES `modernschool`.`ObjetoDeConhecimento` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`AnoLetivo` 
ADD CONSTRAINT `fk_AnoLetivo_Escola1`
  FOREIGN KEY (`idEscola`)
  REFERENCES `modernschool`.`Escola` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`GovernoServidor` 
ADD CONSTRAINT `fk_GovernoServidor_Cargo1`
  FOREIGN KEY (`idCargo`)
  REFERENCES `modernschool`.`Cargo` (`idCargo`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_GovernoServidor_Governo1`
  FOREIGN KEY (`idGoverno`)
  REFERENCES `modernschool`.`Governo` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_GovernoServidor_Pessoa1`
  FOREIGN KEY (`idPessoa`)
  REFERENCES `modernschool`.`Pessoa` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`GradeHorario` 
ADD CONSTRAINT `fk_ComponenteTurma_Componente1`
  FOREIGN KEY (`idComponente`)
  REFERENCES `modernschool`.`Componente` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_ComponenteTurma_Turma1`
  FOREIGN KEY (`idTurma`)
  REFERENCES `modernschool`.`Turma` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_GradeHorario_Pessoa1`
  FOREIGN KEY (`idProfessor`)
  REFERENCES `modernschool`.`Pessoa` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`ObjetoDeConhecimentoDiarioDeClasse` 
DROP FOREIGN KEY `fk_ObjetoDeConhecimentoDiarioDeClasse_ObjetoDeConhecimento1`;

ALTER TABLE `modernschool`.`ObjetoDeConhecimentoDiarioDeClasse` ADD CONSTRAINT `fk_ObjetoDeConhecimentoDiarioDeClasse_ObjetoDeConhecimento1`
  FOREIGN KEY (`idObjetoDeConhecimento`)
  REFERENCES `modernschool`.`ObjetoDeConhecimento` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_ObjetoDeConhecimentoDiarioDeClasse_DiarioDeClasse1`
  FOREIGN KEY (`idDiarioDeClasse`)
  REFERENCES `modernschool`.`DiarioDeClasse` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`FrequenciaAluno` 
DROP FOREIGN KEY `fk_PessoaDiarioDeClasse_Pessoa1`;

ALTER TABLE `modernschool`.`FrequenciaAluno` ADD CONSTRAINT `fk_PessoaDiarioDeClasse_Pessoa1`
  FOREIGN KEY (`idPessoa`)
  REFERENCES `modernschool`.`Pessoa` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_PessoaDiarioDeClasse_DiarioDeClasse1`
  FOREIGN KEY (`idDiarioDeClasse`)
  REFERENCES `modernschool`.`DiarioDeClasse` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`AlunoAvaliacao` 
DROP FOREIGN KEY `fk_PessoaAvaliacao_Pessoa1`;

ALTER TABLE `modernschool`.`AlunoAvaliacao` ADD CONSTRAINT `fk_PessoaAvaliacao_Pessoa1`
  FOREIGN KEY (`idPessoa`)
  REFERENCES `modernschool`.`Pessoa` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_PessoaAvaliacao_Avaliacao1`
  FOREIGN KEY (`idAvaliacao`)
  REFERENCES `modernschool`.`Avaliacao` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`AlunoComunicacao` 
DROP FOREIGN KEY `fk_PessoaComunicacao_Pessoa1`;

ALTER TABLE `modernschool`.`AlunoComunicacao` ADD CONSTRAINT `fk_PessoaComunicacao_Pessoa1`
  FOREIGN KEY (`idPessoa`)
  REFERENCES `modernschool`.`Pessoa` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_PessoaComunicacao_Comunicacao1`
  FOREIGN KEY (`idComunicacao`)
  REFERENCES `modernschool`.`Comunicacao` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `modernschool`.`PessoaComunicacao` 
DROP FOREIGN KEY `fk_PessoaComunicacao_Pessoa2`;

ALTER TABLE `modernschool`.`PessoaComunicacao` ADD CONSTRAINT `fk_PessoaComunicacao_Pessoa2`
  FOREIGN KEY (`idPessoa`)
  REFERENCES `modernschool`.`Pessoa` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `fk_PessoaComunicacao_Comunicacao2`
  FOREIGN KEY (`idComunicacao`)
  REFERENCES `modernschool`.`Comunicacao` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
