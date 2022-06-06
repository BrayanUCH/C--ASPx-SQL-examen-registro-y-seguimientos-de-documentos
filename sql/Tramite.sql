/*==================================================================================================*/
/*===================INSERTAR TRAMITE ==============================================================*/
/*==================================================================================================*/
--ALTER CREATE 
CREATE PROCEDURE TramiteInsertar @Tramite_nombre VARCHAR(50),
									@Tramite_descripcion VARCHAR(50),
									@Tramite_estado VARCHAR(1)
AS
BEGIN
	INSERT INTO TTramite(Tramite_nombre,
							Tramite_descripcion,
							Tramite_estado) 

	SELECT  @Tramite_nombre,
			@Tramite_descripcion,
			@Tramite_estado
			
END
GO

--TramiteInsertar 'A','A','A'

/*==================================================================================================*/
/*===================MODIFICAR TRAMITE =============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE TramiteModificar @Tramite_id INT,
									@Tramite_nombre VARCHAR(50),
									@Tramite_descripcion VARCHAR(50),
									@Tramite_estado VARCHAR(1)
AS
	BEGIN
		UPDATE TTramite
		SET	Tramite_nombre = @Tramite_nombre,
			Tramite_descripcion = @Tramite_descripcion,
			Tramite_estado = @Tramite_estado
	
		WHERE Tramite_id = @Tramite_id
	END
GO

--TramiteModificar 1,'A','B','A'

/*==================================================================================================*/
/*===================INACTIVAR TRAMITE =============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE TramiteInactivar @Tramite_id INT
AS
	BEGIN
		UPDATE TTramite
		SET Tramite_estado = 'I'
		WHERE Tramite_id = @Tramite_id
END
GO

--TramiteInactivar 1

/*==================================================================================================*/
/*==================ACTIVAR TRAMITE ================================================================*/
/*==================================================================================================*/

CREATE PROCEDURE TramiteActivar @Tramite_id INT
AS
	BEGIN
		UPDATE TTramite
		SET Tramite_estado = 'A'
		WHERE Tramite_id = @Tramite_id
END
GO

--TramiteActivar 1

/*==================================================================================================*/
/*===================ELIMINAR TRAMITE ==============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE TramiteEliminar @Tramite_id INT 								
AS
BEGIN 
	DELETE FROM TTramite
	WHERE Tramite_id = @Tramite_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

--TramiteEliminar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACION DE UN TRAMITE ===================================*/
/*==================================================================================================*/

CREATE PROCEDURE TramiteConsultar @Tramite_id INT
AS
BEGIN
	 SELECT *
	 FROM TTramite
	 WHERE Tramite_id = @Tramite_id
END
GO

--TramiteConsultar 2

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN TRAMITE ===================================*/
/*==================================================================================================*/

CREATE PROCEDURE TramiteListarA
AS
BEGIN
	SELECT Tramite_id,
			Tramite_nombre,
			Tramite_descripcion,
			Tramite_estado

	FROM TTramite
	WHERE Tramite_estado = 'A'
END
GO

--TramiteListarA

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN TRAMITE ===================================*/
/*==================================================================================================*/

CREATE PROCEDURE TramiteListarI
AS
BEGIN
	SELECT Tramite_id,
			Tramite_nombre,
			Tramite_descripcion,
			Tramite_estado

	FROM TTramite
	WHERE Tramite_estado = 'I'
END
GO
--TramiteListarI
