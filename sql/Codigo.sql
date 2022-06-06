/*==================================================================================================*/
/*===================INSERTAR CODIGO ===============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CodigoInsertar @Organizacion_id int,
									@Codigo_formato VARCHAR(50),
									@Codigo_estado VARCHAR(1)
AS
BEGIN
	INSERT INTO TCodigo(Organizacion_id,
							Codigo_formato,
							Codigo_estado) 

	SELECT  @Organizacion_id,
			@Codigo_formato,
			@Codigo_estado
			
END
GO

--CodigoInsertar 1,'jpg','A'

/*==================================================================================================*/
/*===================MODIFICAR CODIGO ==============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CodigoModificar @Codigo_id INT,
									@Organizacion_id int,
									@Codigo_formato VARCHAR(50),
									@Codigo_estado VARCHAR(1)
									
AS
	BEGIN
		UPDATE TCodigo
		SET	Organizacion_id = @Organizacion_id,
			Codigo_formato = @Codigo_formato,
			Codigo_estado = @Codigo_estado
	
		WHERE Codigo_id = @Codigo_id
	END
GO

--CodigoModificar 1,1,'PNG','A'

/*==================================================================================================*/
/*===================INACTIVAR CODIGO ==============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CodigoInactivar @Codigo_id INT
AS
	BEGIN
		UPDATE TCodigo
		SET Codigo_estado = 'I'
		WHERE Codigo_id = @Codigo_id
END
GO

--CodigoInactivar 1

/*==================================================================================================*/
/*===================ACTIVAR CODIGO ================================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CodigoActivar @Codigo_id INT
AS
	BEGIN
		UPDATE TCodigo
		SET Codigo_estado = 'A'
		WHERE Codigo_id = @Codigo_id
END
GO

--CodigoActivar 1

/*==================================================================================================*/
/*===================ELIMINAR CODIGO ===============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CodigoEliminar @Codigo_id INT 								
AS
BEGIN 
	DELETE FROM TCodigo
	WHERE Codigo_id = @Codigo_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

--CodigoEliminar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA CODIGO ===================================*/
/*==================================================================================================*/

CREATE PROCEDURE CodigoConsultar @Codigo_id INT
AS
BEGIN
	 SELECT *
	 FROM TCodigo
	 WHERE Codigo_id = @Codigo_id
END
GO

--CodigoConsultar 2

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA CODIGO ===================================*/
/*==================================================================================================*/

CREATE PROCEDURE CodigoListarA
AS
BEGIN
	SELECT Codigo_id,
			Organizacion_id,
			Codigo_formato,
			Codigo_estado

	FROM TCodigo
	WHERE Codigo_estado = 'A'
END
GO
--CodigoListarA

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA CODIGO ===================================*/
/*==================================================================================================*/

CREATE PROCEDURE CodigoListarI
AS
BEGIN
	SELECT Codigo_id,
			Organizacion_id,
			Codigo_formato,
			Codigo_estado

	FROM TCodigo
	WHERE Codigo_estado = 'I'
END
GO
--CodigoListarI
