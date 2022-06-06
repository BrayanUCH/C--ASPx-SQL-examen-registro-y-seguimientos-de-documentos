/*==================================================================================================*/
/*===================INSERTAR IDIOMA ===============================================================*/
/*==================================================================================================*/
--ALTER CREATE
CREATE PROCEDURE IdiomaInsertar @Idioma_nombre  VARCHAR(50),
									@Idioma_iniciales VARCHAR(3),
									@Idioma_estado VARCHAR(1)
AS
BEGIN
	INSERT INTO TIdioma(Idioma_nombre,
							Idioma_iniciales,
							Idioma_estado)
							
	SELECT  @Idioma_nombre,
			@Idioma_iniciales,
			@Idioma_estado
END
GO

--IdiomaInsertar Ingles,'ing','A'

/*==================================================================================================*/
/*===================MODIFICAR IDIOMA ==============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE IdiomaModificar @Idioma_id INT,
									@Idioma_nombre  VARCHAR(50),
									@Idioma_iniciales VARCHAR(3),
									@Idioma_estado VARCHAR(1)
AS
	BEGIN
		UPDATE TIdioma
		SET	Idioma_nombre = @Idioma_nombre,
			Idioma_iniciales = @Idioma_iniciales,
			Idioma_estado = @Idioma_estado
	
		WHERE Idioma_id = @Idioma_id
	END
GO

--IdiomaModificar 1,Esp,'spa','A'

/*==================================================================================================*/
/*===================INACTIVAR IDIOMA ==============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE IdiomaInactivar @Idioma_id INT
AS
	BEGIN
		UPDATE TIdioma
		SET Idioma_estado = 'I'
		WHERE Idioma_id = @Idioma_id
END
GO

--IdiomaInactivar 1

/*==================================================================================================*/
/*=====================ACTIVAR IDIOMA ==============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE IdiomaActivar @Idioma_id INT
AS
	BEGIN
		UPDATE TIdioma
		SET Idioma_estado = 'A'
		WHERE Idioma_id = @Idioma_id
END
GO

--IdiomaActivar 1

/*==================================================================================================*/
/*===================ELIMINAR IDIOMA ===============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE IdiomaEliminar @Idioma_id INT 								
AS
BEGIN 
	DELETE FROM TIdioma
	WHERE Idioma_id = @Idioma_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

--IdiomaEliminar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN IDIOMA ====================================*/
/*==================================================================================================*/

CREATE PROCEDURE IdiomaConsultar @Idioma_id INT
AS
BEGIN
	 SELECT *
	 FROM TIdioma
	 WHERE Idioma_id = @Idioma_id
END
GO

--IdiomaConsultar 2

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN IDIOMA ====================================*/
/*==================================================================================================*/

CREATE PROCEDURE IdiomaListarA
AS
BEGIN
	SELECT Idioma_id,
			Idioma_nombre,
			Idioma_iniciales,
			Idioma_estado
	FROM TIdioma
	WHERE Idioma_estado = 'A'
END
GO
--IdiomaListarA

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN IDIOMA ====================================*/
/*==================================================================================================*/

CREATE PROCEDURE IdiomaListarI
AS
BEGIN
	SELECT Idioma_id,
			Idioma_nombre,
			Idioma_iniciales,
			Idioma_estado
	FROM TIdioma
	WHERE Idioma_estado = 'I'
END
GO
--IdiomaListarI
