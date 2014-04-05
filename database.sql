CREATE TABLE MONSTERS (idMonstruo INTEGER PRIMARY KEY, nombre TEXT, idSprite INTEGER, colorSprite FLOAT, rango TEXT, nivel INTEGER, experiencia FLOAT, idArquetipo INTEGER, sincronia FLOAT);
CREATE TABLE MONSTER_ABS (idMounstruo INTEGER PRIMARY KEY, porcentajeUso FLOAT, habilidadEnfocada INTEGER, idHabilidad1 INTEGER, idHabilidad2 INTEGER, idHabilidad3 INTEGER, idHabilidad4 INTEGER);
CREATE TABLE MONSTER_RES (idMounstruo INTEGER PRIMARY KEY, fuego FLOAT, hielo FLOAT, rayo FLOAT, arcano FLOAT, oscuridad FLOAT, luz FLOAT);
CREATE TABLE MONSTER_STATS (idMonstruo INTEGER PRIMARY KEY, ataque INTEGER, poder INTEGER, vida INTEGER, mana INTEGER, alcance INTEGER, velocidad FLOAT);
