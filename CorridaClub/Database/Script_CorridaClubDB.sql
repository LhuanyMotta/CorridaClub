-- Criação do banco de dados (caso não exista)
CREATE DATABASE IF NOT EXISTS CorridaClubDB;

USE CorridaClubDB;

-- Tabela de usuários
CREATE TABLE usuario (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100),
    email VARCHAR(100),
    senha VARCHAR(255),
    telefone VARCHAR(20),
    data_nascimento DATE,
    genero VARCHAR(20),
    tipo_membro VARCHAR(20)
);

SELECT * FROM usuario;

-- Tabela de eventos
CREATE TABLE evento (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100),
    data DATETIME,
    local VARCHAR(100),
    distancia DECIMAL(5,2),
    tipo VARCHAR(20),
    descricao TEXT
);

-- Tabela de inscrições
CREATE TABLE inscricao (
    id INT PRIMARY KEY AUTO_INCREMENT,
    usuario_id INT,
    evento_id INT,
    data_inscricao DATETIME,
    status VARCHAR(20),
    numero_peito VARCHAR(10),
    tamanho_camiseta VARCHAR(5),
    FOREIGN KEY (usuario_id) REFERENCES usuario(id),
    FOREIGN KEY (evento_id) REFERENCES evento(id)
);

-- Tabela de pedidos
CREATE TABLE pedido (
    id INT PRIMARY KEY AUTO_INCREMENT,
    usuario_id INT,
    item VARCHAR(50),
    tamanho VARCHAR(10),
    cor VARCHAR(20),
    quantidade INT,
    valor_unitario DECIMAL(10,2),
    status VARCHAR(20),
    data_pedido DATETIME,
    data_entrega DATETIME,
    FOREIGN KEY (usuario_id) REFERENCES usuario(id)
);