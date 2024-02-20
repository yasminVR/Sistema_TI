-- MySQL Script generated by MySQL Workbench
-- Thu Feb 15 16:54:32 2024
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema yasmin_servico_ti
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema yasmin_servico_ti
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `yasmin_servico_ti` DEFAULT CHARACTER SET utf8 ;
USE `yasmin_servico_ti` ;

-- -----------------------------------------------------
-- Table `yasmin_servico_ti`.`tbl_cadastro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `yasmin_servico_ti`.`tbl_cadastro` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `fk_cliente` INT NOT NULL,
  `nome` VARCHAR(45) NULL,
  `sobrenome` VARCHAR(45) NULL,
  `email` VARCHAR(45) NULL,
  `telefone` VARCHAR(45) NULL,
  `celular` VARCHAR(45) NULL,
  `data_entrada` VARCHAR(45) NULL,
  `status` VARCHAR(45) NULL,
  `observacoes` VARCHAR(45) NULL,
  `caracteristicas_equipamento` VARCHAR(45) NULL,
  `queixa_cliente` VARCHAR(45) NULL,
  `valor_total` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
