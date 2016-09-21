CREATE TABLE compta_personne (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nom VARCHAR(255) NOT NULL,
	avatar VARCHAR(255),
	pseudo VARCHAR(255) NOT NULL,
	password VARCHAR(255) NOT NULL,
	habituel TINYINT DEFAULT 0
) ENGINE=InnoDB;

CREATE TABLE compta_facture (
	id INT AUTO_INCREMENT PRIMARY KEY,
	id_payeur INT,
	valeur_totale FLOAT NOT NULL,
	ddate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	libelle VARCHAR(255) DEFAULT "",
	FOREIGN KEY (id_payeur) REFERENCES compta_personne(id)
) ENGINE=InnoDB;

CREATE TABLE compta_facture_personne (
	id_facture INT,
	id_personne INT,
	valide TINYINT DEFAULT 0,
	PRIMARY KEY (id_facture, id_personne),
	FOREIGN KEY (id_facture) REFERENCES compta_facture(id),
	FOREIGN KEY (id_personne) REFERENCES compta_personne(id)
) ENGINE=InnoDB;

CREATE TABLE compta_categorie (
	id INT AUTO_INCREMENT PRIMARY KEY,
	libelle VARCHAR(255)
) ENGINE=InnoDB;

CREATE TABLE compta_facture_categorie (
	id_facture INT,
	id_categorie INT,
	PRIMARY KEY (id_facture, id_categorie),
	FOREIGN KEY (id_facture) REFERENCES compta_facture(id),
	FOREIGN KEY (id_categorie) REFERENCES compta_categorie(id)
) ENGINE=InnoDB;

CREATE TABLE compta_magouille (
	id INT AUTO_INCREMENT PRIMARY KEY,
	id_facture INT,
	id_beneficiaire INT,
	valeur FLOAT NOT NULL,
	libelle VARCHAR(255) DEFAULT "",
	FOREIGN KEY (id_facture) REFERENCES compta_facture(id),
	FOREIGN KEY (id_beneficiaire) REFERENCES compta_personne(id)
) ENGINE=InnoDB;

CREATE TABLE compta_log (
	id INT AUTO_INCREMENT PRIMARY KEY,
	id_generant INT,
	ddate TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	libelle VARCHAR(255) DEFAULT "",
	FOREIGN KEY (id_generant) REFERENCES compta_personne(id)
) ENGINE=InnoDB;


INSERT INTO `compta_personne` (`id`, `nom`, `avatar`, `pseudo`, `password`, `habituel`) VALUES
(1, 'Nicolas', '1', 'Nicolas', 'b66QUYPOAgfIMsf/j/mHy8XpvJoFDOzzqCIYillDuig=', 0);