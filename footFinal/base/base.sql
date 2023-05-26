CREATE TABLE joueur(
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(255)
);

CREATE TABLE jeuton(
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    prix DOUBLE PRECISION,
    nombreBall INTEGER
);

--la table match
CREATE TABLE jeu(
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    idJoueur1 INTEGER,
    idJoueur2 INTEGER,
    date DATETIME,
    idJeuton INTEGER,
    FOREIGN KEY(idJoueur1) REFERENCES joueur(id),
    FOREIGN KEY(idJoueur2) REFERENCES joueur(id)
);

CREATE TABLE mise(
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    idJeu INTEGER,
    miseJoueur1 DOUBLE PRECISION,
    miseJoueur2 DOUBLE PRECISION,
    FOREIGN KEY(idJeu) REFERENCES jeu(id)
);

CREATE TABLE resultat(
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    idJeu INTEGER,
    scoreJoueur1 INTEGER,
    scoreJoueur2 INTEGER,
    moneyJoueur1 DOUBLE PRECISION,       
    moneyJoueur2 DOUBLE PRECISION,       
    FOREIGN KEY(idJeu) REFERENCES jeu(id)
);

