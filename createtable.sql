CREATE TABLE `tb_livro` (
  `nm_isbn` VARCHAR(50) NOT NULL,
  `nm_autor` VARCHAR(80) NOT NULL,
  `nm_nome` VARCHAR(150) NOT NULL,
  `vl_preco` DECIMAL(9,2) NOT NULL,
  `dt_publicacao` DATETIME NOT NULL,
  `img_capa` LONGBLOB,
  `id_livro` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_livro`)
)
ENGINE = InnoDB;
