CREATE TABLE joueur(
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    nom VARCHAR(255)
);

CREATE TABLE cheval(
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    angle INTEGER,
    width DOUBLE PRECISION,
    height DOUBLE PRECISION,
    couleur VARCHAR(255),
    distance INTEGER,
    vitesse INTEGER,
    pourcentageEndurence INTEGER,
    endurence INTEGER
);

CREATE TABLE jeu(
    id INTEGER PRIMARY KEY AUTO_INCREMENT,
    idJoueur1 INTEGER,
    idJoueur2 INTEGER,
    idCheval1 INTEGER,
    idCheval2 INTEGER,
    mise DOUBLE PRECISION,
    FOREIGN KEY(idJoueur1) REFERENCES joueur(id), 
    FOREIGN KEY(idJoueur2) REFERENCES joueur(id),
    FOREIGN KEY(idCheval1) REFERENCES cheval(id),
    FOREIGN KEY(idCheval2) REFERENCES cheval(id) 
);

CREATE TABLE resultat(
    idJeu INTEGER PRIMARY KEY AUTO_INCREMENT,
    idGagnant INTEGER,
    lot DOUBLE PRECISION,
    FOREIGN KEY(idGagnant) REFERENCES joueur(id)
);


INSERT INTO joueur VALUES(1,"joueur1"),(2,"joueur2");

INSERT INTO cheval VALUES(1,0,20,20,"Olive",30,3,70,2),(2,0,20,20,"Red",60,3,50,3),(3,0,20,20,"Blue",90,2,40,1),(4,0,20,20,"Chocolate",120,2,40,1)