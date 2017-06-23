CREATE DATABASE PRODUTOS_CONUSI
USE PRODUTOS_CONUSI

-- Tabela Peças

CREATE TABLE PECAS
(
	Id INT IDENTITY PRIMARY KEY,
	CodConusi VARCHAR(100) NOT NULL,
	CodTipo	  INT  REFERENCES TIPOS (Id_Tipo)
)

-- Insert Peças

INSERT INTO PECAS VALUES ('PFT16322506', '1')
INSERT INTO PECAS VALUES ('PFT18402706', '1')
INSERT INTO PECAS VALUES ('PFT20052806', '1')
INSERT INTO PECAS VALUES ('PFT22053107', '1')
INSERT INTO PECAS VALUES ('PFT22082807', '1')
INSERT INTO PECAS VALUES ('PFT25063607', '1')
INSERT INTO PECAS VALUES ('PFT25063608', '1')
INSERT INTO PECAS VALUES ('PFT25453308', '1')
INSERT INTO PECAS VALUES ('PFT30074209', '1')
INSERT INTO PECAS VALUES ('PFT35085315', '1')
INSERT INTO PECAS VALUES ('PFT35095315', '1')
INSERT INTO PECAS VALUES ('PFT35105315', '1')
INSERT INTO PECAS VALUES ('PFT35105515', '1')
INSERT INTO PECAS VALUES ('PFT35125315', '1')
INSERT INTO PECAS VALUES ('PFT40085715', '1')
INSERT INTO PECAS VALUES ('PFT40095715', '1')
INSERT INTO PECAS VALUES ('PFT40105515', '1')
INSERT INTO PECAS VALUES ('PFT40105715', '1')
INSERT INTO PECAS VALUES ('PFT40125715', '1')
INSERT INTO PECAS VALUES ('PFT40155715', '1')
INSERT INTO PECAS VALUES ('PFT40275815', '1')
INSERT INTO PECAS VALUES ('PFT45117020', '1')
INSERT INTO PECAS VALUES ('PFT45126820', '1')
INSERT INTO PECAS VALUES ('PFT50117220', '1')
INSERT INTO PECAS VALUES ('PFT50137220', '1')
INSERT INTO PECAS VALUES ('PFT50147320', '1')
INSERT INTO PECAS VALUES ('PFT50167020', '1')
INSERT INTO PECAS VALUES ('PFT50167325', '1')

INSERT INTO PECAS VALUES ('PFTB18402506', '2')
INSERT INTO PECAS VALUES ('PFTB20052806', '2')
INSERT INTO PECAS VALUES ('PFTB22063006', '2')
INSERT INTO PECAS VALUES ('PFTB25063608', '2')
INSERT INTO PECAS VALUES ('PFTB30074308', '2')
INSERT INTO PECAS VALUES ('PFTB35085315', '2')
INSERT INTO PECAS VALUES ('PFTB35105315', '2')
INSERT INTO PECAS VALUES ('PFTB35125315', '2')
INSERT INTO PECAS VALUES ('PFTB40085715', '2')
INSERT INTO PECAS VALUES ('PFTB40105715', '2')
INSERT INTO PECAS VALUES ('PFTB40125715', '2')
INSERT INTO PECAS VALUES ('PFTB45126620', '2')
INSERT INTO PECAS VALUES ('PFTB50117020', '2')

INSERT INTO PECAS VALUES ('PFB40071220', '3')
INSERT INTO PECAS VALUES ('PFB50081225', '3')
INSERT INTO PECAS VALUES ('PFB50081525', '3')
INSERT INTO PECAS VALUES ('PFB50081825', '3')
INSERT INTO PECAS VALUES ('PFB50082025', '3')
INSERT INTO PECAS VALUES ('PFB60101630', '3')
INSERT INTO PECAS VALUES ('PFB60101830', '3')
INSERT INTO PECAS VALUES ('PFB60102030', '3')
INSERT INTO PECAS VALUES ('PFB60102004', '3')
INSERT INTO PECAS VALUES ('PFB60102530', '3')
INSERT INTO PECAS VALUES ('PFB60103030', '3')
INSERT INTO PECAS VALUES ('PFB80121640', '3')
INSERT INTO PECAS VALUES ('PFB80122040', '3')
INSERT INTO PECAS VALUES ('PFB80122540', '3')
INSERT INTO PECAS VALUES ('PFB80122840', '3')
INSERT INTO PECAS VALUES ('PFB80123040', '3')
INSERT INTO PECAS VALUES ('PFB10152050', '3')

INSERT INTO PECAS VALUES ('CTB0640', '4')
INSERT INTO PECAS VALUES ('CTB0740', '4')
INSERT INTO PECAS VALUES ('CTB0840', '4')
INSERT INTO PECAS VALUES ('CTB0940', '4')
INSERT INTO PECAS VALUES ('CTB1040', '4')
INSERT INTO PECAS VALUES ('CTB1543', '4')
INSERT INTO PECAS VALUES ('CTB2043', '4')
INSERT INTO PECAS VALUES ('CTB2548', '4')
INSERT INTO PECAS VALUES ('CTP06xx14', '5')
INSERT INTO PECAS VALUES ('CTP07xx14', '5')
INSERT INTO PECAS VALUES ('CTP08xx14', '5')
INSERT INTO PECAS VALUES ('CTP09xx14', '5')
INSERT INTO PECAS VALUES ('CTP10xx14', '5')
INSERT INTO PECAS VALUES ('CTP15xx14', '5')
INSERT INTO PECAS VALUES ('CTP20xx14', '5')
INSERT INTO PECAS VALUES ('CTP25xx14', '5')

-- Tabela Tipos

CREATE TABLE TIPOS
(
	Id_Tipo INT IDENTITY PRIMARY KEY,
	Des_Tipo VARCHAR (100),
	CodPeca INT REFERENCES CATEGORIA (Id_Categoria) -- Codigo CATEGORIA
)

-- Insert Tipos

INSERT INTO TIPOS VALUES ('Parafuso Importado', '1')
INSERT INTO TIPOS VALUES ('Parafuso Nacional', '1')
INSERT INTO TIPOS VALUES ('Parafuso Bifuso', '1')
INSERT INTO TIPOS VALUES ('Chave Torx Bandeira', '2')
INSERT INTO TIPOS VALUES ('Chave Ponteira', '2')

-- Tabela Categoria

CREATE TABLE CATEGORIA
(
	Id_Categoria INT IDENTITY PRIMARY KEY,
	Des_Categoria VARCHAR (100)
)

-- Insert Categoria

INSERT INTO CATEGORIA VALUES ('Parafuso')
INSERT INTO CATEGORIA VALUES ('Chave')

-- Comandos Tabelas

SELECT * FROM PECAS
SELECT * FROM TIPOS
SELECT * FROM CATEGORIA



--Stored Procedures

--------------------------------------------------------------------------------------------
-------------------------------------PROCEDURES CATEGORIA-----------------------------------
--------------------------------------------------------------------------------------------

CREATE PROCEDURE spBuscarCategoria

	@p_id_categoria INT

AS
BEGIN
		SELECT	*
		FROM  CATEGORIA
		WHERE Id_Categoria = @p_id_categoria;

END
GO

delete from CATEGORIA where Id_Categoria = '4'


--------------------------------------------------------------------------------------------

CREATE PROCEDURE sp_Select_Categoria
AS
BEGIN
	SELECT	*
	FROM CATEGORIA
END
GO

--------------------------------------------------------------------------------------------

CREATE PROCEDURE sp_Update_Categoria
	
	@p_id_categoria		INT,
	@p_des_categoria	VARCHAR(50)

AS
BEGIN
	 UPDATE CATEGORIA 
		SET	Des_Categoria = @p_des_categoria
	  WHERE	Id_Categoria  = @p_id_categoria;
END
GO

--------------------------------------------------------------------------------------------

CREATE PROCEDURE sp_Delete_Categoria

	@p_id_categoria		INT

AS
BEGIN
	DELETE FROM CATEGORIA
	WHERE Id_Categoria = @p_id_categoria
END
GO

--------------------------------------------------------------------------------------------

CREATE PROCEDURE sp_Insert_Categoria
	
	@p_des_categoria	VARCHAR(50)

AS
BEGIN
	INSERT INTO CATEGORIA
	(
		Des_Categoria
	)
	VALUES
	(
		@p_des_categoria
	)
END
GO

-------------------------------------------------------------------------------------------

CREATE PROCEDURE spListaCategoria
(
	@pesquisa VARCHAR(50) = ''
)
AS
BEGIN 
		SELECT Id_Categoria, Des_Categoria
		FROM   CATEGORIA 
		WHERE  Des_Categoria LIKE '%' + @pesquisa + '%'

END

--------------------------------------------------------------------------------------------
-------------------------------------PROCEDURES TIPOS---------------------------------------
--------------------------------------------------------------------------------------------

CREATE PROCEDURE spBuscarTipos

	@p_id_tipos INT

AS
BEGIN
		SELECT	*
		FROM  TIPOS
		WHERE Id_Tipo = @p_id_tipos;
		
END
GO

--------------------------------------------------------------------------------------------
SELECT * FROM PECAS
CREATE PROCEDURE sp_Select_Tipos
AS
BEGIN
	SELECT	*
	FROM TIPOS
END
GO

--------------------------------------------------------------------------------------------

CREATE PROCEDURE sp_Update_Tipos
	
	@p_id_tipos		 INT,
	@p_des_tipos	 VARCHAR(50),
	@p_CodPeca_tipos VARCHAR(50)

AS
BEGIN
	 UPDATE TIPOS
		SET	Des_Tipo = @p_des_tipos,
			CodPeca  = @p_CodPeca_tipos

	  WHERE	Id_Tipo  = @p_id_tipos;
END
GO

--------------------------------------------------------------------------------------------

CREATE PROCEDURE sp_Delete_Tipos

	@p_id_tipos		INT

AS
BEGIN
	DELETE FROM TIPOS

	WHERE		Id_Tipo = @p_id_tipos;
END
GO

--------------------------------------------------------------------------------------------

CREATE PROCEDURE sp_Insert_Tipos
	
	@p_des_tipos	VARCHAR(50),
	@p_codpeca_tipo	INT
AS
BEGIN
	INSERT INTO TIPOS
	(
		Des_tipo,
		CodPeca
	)
	VALUES
	(
		@p_des_tipos,
		@p_codpeca_tipo
	)
END
GO

---------------------------------------------------------------------------------------------

ALTER PROCEDURE spListaTipos
(
	@pesquisa VARCHAR(50) = ''
)
AS
BEGIN 
		SELECT T.Id_Tipo, T.Des_Tipo, T.CodPeca, C.Des_Categoria 
		FROM   TIPOS T
		INNER JOIN CATEGORIA C
		ON C.Id_Categoria = T.CodPeca
		WHERE  Des_Tipo LIKE '%' + @pesquisa + '%'

END


--------------------------------------------------------------------------------------------
-------------------------------------PROCEDURES PEÇAS---------------------------------------
--------------------------------------------------------------------------------------------

CREATE PROCEDURE spBuscarPecas

	@p_id_pecas INT

AS
BEGIN
		SELECT	*
		FROM  PECAS
		WHERE Id = @p_id_pecas;

END
GO

--------------------------------------------------------------------------------------------

CREATE PROCEDURE sp_Select_Pecas
AS
BEGIN
	SELECT	*
	FROM	PECAS
END
GO

--------------------------------------------------------------------------------------------

CREATE PROCEDURE sp_Update_Pecas
	
	@p_id_pecas		     INT,
	@p_CodConusi_pecas	 VARCHAR(50),
	@p_CodTipo_pecas	 VARCHAR(50)

AS
BEGIN
	 UPDATE PECAS
		SET	CodConusi = @p_CodConusi_pecas,
			CodTipo   = @p_CodTipo_pecas

	  WHERE	Id = @p_id_pecas;
END
GO

--------------------------------------------------------------------------------------------

CREATE PROCEDURE sp_Delete_Pecas

	@p_id_pecas		INT

AS
BEGIN
	DELETE FROM PECAS

	WHERE		Id = @p_id_pecas;
END
GO

--------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_Insert_Pecas
	
	@p_CodConusi_pecas	VARCHAR(50),
	@p_CodTipo_pecas	INT


AS
BEGIN
	INSERT INTO PECAS
	(
		CodConusi,
		CodTipo
	)
	VALUES
	(
		@p_CodConusi_pecas,
		@p_CodTipo_pecas
	)
END
GO
-------------------------------------------------------------------------------------------

CREATE PROCEDURE spListaPecas
(
	@pesquisa VARCHAR(50) = ''
)
AS
BEGIN 
		SELECT P.Id, P.CodConusi, P.CodTipo, T.Des_Tipo
		FROM   PECAS P
		inner join TIPOS T ON t.Id_Tipo = p.CodTipo

		WHERE  CodConusi LIKE '%' + @pesquisa + '%'
		OR
			   CodTipo   LIKE '%' + @pesquisa + '%'
END

execute spListaPecas