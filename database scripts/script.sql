CREATE DATABASE libreriaWeb;
USE libreriaWeb;

--Creación de tabla para información de autores
CREATE TABLE autores(Id BIGINT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT, 
                    Name VARCHAR(100),
                    DATEBORN DATE,
                    City VARCHAR(50),
                    Email VARCHAR(100));

--Creación de tabla para información de libros
CREATE TABLE libros(Id BIGINT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT,
                    AuthorId BIGINT UNSIGNED NOT NULL,
                    Name VARCHAR(100),
                    Year BIGINT UNSIGNED,
                    Gender VARCHAR(50),
                    PagesCount BIGINT UNSIGNED,
                    FOREIGN KEY (AuthorId) REFERENCES autores(Id));


                