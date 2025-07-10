-- Criação do banco
CREATE DATABASE CorridaClubDB;
USE CorridaClubDB;

-- Tabelas padrão do ASP.NET Identity
CREATE TABLE AspNetRoles (
    Id VARCHAR(255) NOT NULL PRIMARY KEY,
    Name VARCHAR(256),
    NormalizedName VARCHAR(256),
    ConcurrencyStamp TEXT
);

CREATE TABLE AspNetUsers (
    Id VARCHAR(255) NOT NULL PRIMARY KEY,
    UserName VARCHAR(256),
    NormalizedUserName VARCHAR(256),
    Email VARCHAR(256),
    NormalizedEmail VARCHAR(256),
    EmailConfirmed BIT NOT NULL,
    PasswordHash TEXT,
    SecurityStamp TEXT,
    ConcurrencyStamp TEXT,
    PhoneNumber VARCHAR(50),
    PhoneNumberConfirmed BIT NOT NULL,
    TwoFactorEnabled BIT NOT NULL,
    LockoutEnd DATETIME,
    LockoutEnabled BIT NOT NULL,
    AccessFailedCount INT NOT NULL
);

CREATE TABLE AspNetUserRoles (
    UserId VARCHAR(255) NOT NULL,
    RoleId VARCHAR(255) NOT NULL,
    PRIMARY KEY (UserId, RoleId),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE,
    FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id) ON DELETE CASCADE
);

CREATE TABLE AspNetUserClaims (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    UserId VARCHAR(255) NOT NULL,
    ClaimType TEXT,
    ClaimValue TEXT,
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
);

CREATE TABLE AspNetUserLogins (
    LoginProvider VARCHAR(128) NOT NULL,
    ProviderKey VARCHAR(128) NOT NULL,
    ProviderDisplayName VARCHAR(256),
    UserId VARCHAR(255) NOT NULL,
    PRIMARY KEY (LoginProvider, ProviderKey),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
);

CREATE TABLE AspNetUserTokens (
    UserId VARCHAR(255) NOT NULL,
    LoginProvider VARCHAR(128) NOT NULL,
    Name VARCHAR(128) NOT NULL,
    Value TEXT,
    PRIMARY KEY (UserId, LoginProvider, Name),
    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
);

CREATE TABLE AspNetRoleClaims (
    Id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    RoleId VARCHAR(255) NOT NULL,
    ClaimType TEXT,
    ClaimValue TEXT,
    FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id) ON DELETE CASCADE
);

-- Tabelas personalizadas
CREATE TABLE evento (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100),
    data DATETIME,
    local VARCHAR(100),
    distancia DECIMAL(5,2),
    tipo VARCHAR(20),
    descricao TEXT
);

CREATE TABLE inscricao (
    id INT PRIMARY KEY AUTO_INCREMENT,
    usuario_id VARCHAR(255),
    evento_id INT,
    data_inscricao DATETIME,
    status VARCHAR(20),
    numero_peito VARCHAR(10),
    tamanho_camiseta VARCHAR(5),
    FOREIGN KEY (usuario_id) REFERENCES AspNetUsers(Id),
    FOREIGN KEY (evento_id) REFERENCES evento(id)
);

CREATE TABLE pedido (
    id INT PRIMARY KEY AUTO_INCREMENT,
    usuario_id VARCHAR(255),
    item VARCHAR(50),
    tamanho VARCHAR(10),
    cor VARCHAR(20),
    quantidade INT,
    valor_unitario DECIMAL(10,2),
    status VARCHAR(20),
    data_pedido DATETIME,
    data_entrega DATETIME,
    FOREIGN KEY (usuario_id) REFERENCES AspNetUsers(Id)
);
