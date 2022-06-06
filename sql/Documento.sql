/*==================================================================================================*/
/*===================INSERTAR DOCUMENTO ============================================================*/
/*==================================================================================================*/
--ALTER CREATE 
CREATE PROCEDURE DocumentoInsertar @Tramite_id int,
									@Idioma_id int,
									@Documento_nombre VARCHAR(50),
									@Documento_ruta VARCHAR(2083),
									@Documento_tipo VARCHAR(50),
									@Documento_estado VARCHAR(1)
AS
BEGIN
	INSERT INTO TDocumento(Tramite_id,
							Idioma_id,
							Documento_nombre,
							Documento_ruta,
							Documento_tipo,
							Documento_estado) 

	SELECT  @Tramite_id,
			@Idioma_id,
			@Documento_nombre,
			@Documento_ruta,
			@Documento_tipo,
			@Documento_estado
			
END
GO

--DocumentoInsertar '1','1','MSI','C:\Users\Brandon\Documents\BRANDON\universidad\2020\Semestre N2, 2020\PROGRAMACION 3\Sistema_Matricula','pdf','A'

/*==================================================================================================*/
/*===================MODIFICAR DOCUMENTO ===========================================================*/
/*==================================================================================================*/

CREATE PROCEDURE DocumentoModificar @Documento_id INT,
									@Tramite_id int,
									@Idioma_id int,
									@Documento_nombre VARCHAR(50),
									@Documento_ruta VARCHAR(2083),
									@Documento_tipo VARCHAR(50),
									@Documento_estado VARCHAR(1)
AS
	BEGIN
		UPDATE TDocumento
		SET	Tramite_id = @Tramite_id,
			Idioma_id = @Idioma_id,
			Documento_nombre = @Documento_nombre,
			Documento_ruta = @Documento_ruta,
			Documento_tipo = @Documento_tipo,
			Documento_estado = @Documento_estado
	
		WHERE Documento_id = @Documento_id
	END
GO

--DocumentoModificar 1,'1','1','DELL','C:\Users\Brandon\Documents\BRANDON\universidad\2020\Semestre N2, 2020\PROGRAMACION 3\Sistema_Matricula','pdf','A'

/*==================================================================================================*/
/*===================INACTIVAR DOCUMENTO ===========================================================*/
/*==================================================================================================*/

CREATE PROCEDURE DocumentoInactivar @Documento_id INT
AS
	BEGIN
		UPDATE TDocumento
		SET Documento_estado = 'I'
		WHERE Documento_id = @Documento_id
END
GO

--DocumentoInactivar 1

/*==================================================================================================*/
/*==================ACTIVAR DOCUMENTO ==============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE DocumentoActivar @Documento_id INT
AS
	BEGIN
		UPDATE TDocumento
		SET Documento_estado = 'A'
		WHERE Documento_id = @Documento_id
END
GO

--DocumentoActivar 1

/*==================================================================================================*/
/*===================ELIMINAR DOCUMENTO ============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE DocumentoEliminar @Documento_id INT 								
AS
BEGIN 
	DELETE FROM TDocumento
	WHERE Documento_id = @Documento_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

--DocumentoEliminar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA DOCUMENTO ================================*/
/*==================================================================================================*/

CREATE PROCEDURE DocumentoConsultar @Documento_id INT
AS
BEGIN
	 SELECT *
	 FROM TDocumento
	 WHERE Documento_id = @Documento_id
END
GO

--DocumentoConsultar 2

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA DOCUMENTO ================================*/
/*==================================================================================================*/

CREATE PROCEDURE DocumentoListarA
AS
BEGIN
	SELECT Documento_id,
			Tramite_id,
			Idioma_id,
			Documento_nombre,
			Documento_ruta,
			Documento_tipo,
			Documento_estado

	FROM TDocumento
	WHERE Documento_estado = 'A'
END
GO
--DocumentoListarA

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA DOCUMENTO ================================*/
/*==================================================================================================*/

CREATE PROCEDURE DocumentoListarI
AS
BEGIN
	SELECT Documento_id,
			Tramite_id,
			Idioma_id,
			Documento_nombre,
			Documento_ruta,
			Documento_tipo,
			Documento_estado

	FROM TDocumento
	WHERE Documento_estado = 'I'
END
GO
--DocumentoListarI
