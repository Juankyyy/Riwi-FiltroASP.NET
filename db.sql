CREATE TABLE Jobs (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    NameCompany VARCHAR(255) NOT NULL,
    LogoCompany VARCHAR(255) NOT NULL,
    OfferTitle VARCHAR(255) NOT NULL,
    Description VARCHAR(255) NOT NULL,
    Salary DOUBLE NOT NULL,
    Positions INT NOT NULL,
    Status VARCHAR(45) NOT NULL,
    Country VARCHAR(45) NOT NULL,
    Languages VARCHAR(45) NOT NULL
);

DROP TABLE Jobs;
TRUNCATE TABLE Jobs;

INSERT INTO Jobs (NameCompany, LogoCompany, OfferTitle, Description, Salary, Positions, Status, Country, Languages)
VALUES ("Coca-Cola", "cocacola.jpeg", "Desarrollador Junior Flutter", "Programador con enfasis en flutter", 2200000, 2, "Activa", "Colombia", "Español, Inglés"),
("SENA", "sena.jpeg", "Instructor TIC", "Profesor con experiencia de 3 años", 4200000, 1, "Activa", "Colombia", "Español")

SELECT * FROM Employees;

CREATE TABLE Employees (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(45) NOT NULL,
    LastNames VARCHAR(45) NOT NULL,
    Email VARCHAR(125) NOT NULL UNIQUE,
    BirthDate DATE NOT NULL,
    ProfilePicture VARCHAR(255) NOT NULL,
    Cv VARCHAR(255) NOT NULL,
    Gender VARCHAR(20) NOT NULL,
    Phone VARCHAR(25) NOT NULL,
    Address VARCHAR(125) NOT NULL,
    CivilStatus VARCHAR(45) NOT NULL,
    Salary DOUBLE NOT NULL,
    About VARCHAR(255) NOT NULL,
    AcademicTitle VARCHAR(125) NOT NULL,
    Languages VARCHAR(125) NOT NULL,
    Area VARCHAR(45) NOT NULL
);

TRUNCATE TABLE Employees;

INSERT INTO Employees (Names, LastNames, Email, BirthDate, ProfilePicture, Cv, Gender, Phone, Address, CivilStatus, Salary, About, AcademicTitle, Languages, Area)
VALUES ("Juanky", "Herrera", "Juanky@gmail.com", "2005-03-02", "JuankyPicture.jpeg", "JuankyCv.pdf", "masculino", "3177944444", "Calle 61 #61D-61", "Soltero", 3500000, "Soy un desarrollador web aficionado con una profunda pasión por crear experiencias web atractivas.", "Desarrollador de Software", "Español, Inglés", "Tic"),
("Mateo", "Velez", "mateo@gmail.com", "2001-05-03", "MateoPicture.png", "MateoCv.pdf", "masculino", "3188844444", "Calle 12 #12-12", "Unión Libre", 2200000, "Lorem ipsum dolor sit amet consectetur adipisicing elit.", "Químico", "Español, Inglés", "Cosas químicas");