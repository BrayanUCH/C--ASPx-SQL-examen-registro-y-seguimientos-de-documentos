/*==================================================================================================*/
/*===================INSERTAR ORGANIZACION =========================================================*/
/*==================================================================================================*/
--ALTER CREATE 
CREATE PROCEDURE OrganizacionInsertar @Organizacion_nombre VARCHAR(50),
									@Organizacion_tipo VARCHAR(50),
									@Organizacion_descripcion VARCHAR(50),
									@Organizacion_estado VARCHAR(1)
AS
BEGIN
	INSERT INTO TOrganizacion(Organizacion_nombre,
							Organizacion_tipo,
							Organizacion_descripcion,
							Organizacion_estado) 

	SELECT  @Organizacion_nombre,
			@Organizacion_tipo,
			@Organizacion_descripcion,
			@Organizacion_estado
			
END
GO

--OrganizacionInsertar 'B','B','B','A'

/*==================================================================================================*/
/*===================MODIFICAR ORGANIZACION ========================================================*/
/*==================================================================================================*/

CREATE PROCEDURE OrganizacionModificar @Organizacion_id INT,
									@Organizacion_nombre VARCHAR(50),
									@Organizacion_tipo VARCHAR(50),
									@Organizacion_descripcion VARCHAR(50),
									@Organizacion_estado VARCHAR(1)
AS
	BEGIN
		UPDATE TOrganizacion
		SET	Organizacion_nombre = @Organizacion_nombre,
			Organizacion_tipo = @Organizacion_tipo,
			Organizacion_descripcion = @Organizacion_descripcion,
			Organizacion_estado = @Organizacion_estado
	
		WHERE Organizacion_id = @Organizacion_id
	END
GO

--OrganizacionModificar 1,'A','B','B','A'

/*==================================================================================================*/
/*===================INACTIVAR ORGANIZACION ========================================================*/
/*==================================================================================================*/

CREATE PROCEDURE OrganizacionInactivar @Organizacion_id INT
AS
	BEGIN
		UPDATE TOrganizacion
		SET Organizacion_estado = 'I'
		WHERE Organizacion_id = @Organizacion_id
END
GO

--OrganizacionInactivar 1

/*==================================================================================================*/
/*==================ACTIVAR ORGANIZACION ===========================================================*/
/*==================================================================================================*/

CREATE PROCEDURE OrganizacionActivar @Organizacion_id INT
AS
	BEGIN
		UPDATE TOrganizacion
		SET Organizacion_estado = 'A'
		WHERE Organizacion_id = @Organizacion_id
END
GO

--OrganizacionActivar 1

/*==================================================================================================*/
/*===================ELIMINAR ORGANIZACION =========================================================*/
/*==================================================================================================*/

CREATE PROCEDURE OrganizacionEliminar @Organizacion_id INT 								
AS
BEGIN 
	DELETE FROM TOrganizacion
	WHERE Organizacion_id = @Organizacion_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

--OrganizacionEliminar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA ORGANIZACION =============================*/
/*==================================================================================================*/

CREATE PROCEDURE OrganizacionConsultar @Organizacion_id INT
AS
BEGIN
	 SELECT *
	 FROM TOrganizacion
	 WHERE Organizacion_id = @Organizacion_id
END
GO

--OrganizacionConsultar 2

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA ORGANIZACION =============================*/
/*==================================================================================================*/

CREATE PROCEDURE OrganizacionListarA
AS
BEGIN
	SELECT Organizacion_id,
			Organizacion_nombre,
			Organizacion_tipo,
			Organizacion_descripcion,
			Organizacion_estado

	FROM TOrganizacion
	WHERE Organizacion_estado = 'A'
END
GO
--OrganizacionListarA

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA ORGANIZACION =============================*/
/*==================================================================================================*/

CREATE PROCEDURE OrganizacionListarI
AS
BEGIN
	SELECT Organizacion_id,
			Organizacion_nombre,
			Organizacion_tipo,
			Organizacion_descripcion,
			Organizacion_estado

	FROM TOrganizacion
	WHERE Organizacion_estado = 'I'
END
GO
--OrganizacionListarI
