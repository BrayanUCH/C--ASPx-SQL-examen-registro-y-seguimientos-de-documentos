/*==================================================================================================*/
/*===================INSERTAR LOGIN ================================================================*/
/*==================================================================================================*/
--ALTER CREATE 
CREATE PROCEDURE LoginInsertar @Login_Usuario VARCHAR(10),
									@Login_contraseña VARCHAR(8),
									@Login_correoElectronico VARCHAR(50),
									@Login_administrador VARCHAR(13),
									@Login_estado VARCHAR(1)
AS
BEGIN
	INSERT INTO TLogin(Login_Usuario,
							Login_contraseña,
							Login_correoElectronico,
							Login_administrador,
							Login_estado) 

	SELECT  @Login_Usuario,
			@Login_contraseña,
			@Login_correoElectronico,
			@Login_administrador,
			@Login_estado
			
END
GO

--LoginInsertar 'brandon','gemelo','brandonugaldech@gmail.com','S','A'

/*==================================================================================================*/
/*===================MODIFICAR LOGIN ===============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE LoginModificar @Login_id INT,
							@Login_Usuario VARCHAR(10),
							@Login_contraseña VARCHAR(8),
							@Login_correoElectronico VARCHAR(50),
							@Login_administrador VARCHAR(13),
							@Login_estado VARCHAR(1)
AS
	BEGIN
		UPDATE TLogin
		SET	Login_Usuario = @Login_Usuario,
			Login_contraseña = @Login_contraseña,
			Login_correoElectronico = @Login_correoElectronico,
			Login_administrador = @Login_administrador,
			Login_estado = @Login_estado
	
		WHERE Login_id = @Login_id
	END
GO

--LoginModificar 1,'brandon','gemelo1','brandonugaldech@gmail.com','S','A'

/*==================================================================================================*/
/*===================INACTIVAR LOGIN ===============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE LoginInactivar @Login_id INT
AS
	BEGIN
		UPDATE TLogin
		SET Login_estado = 'I'
		WHERE Login_id = @Login_id
END
GO

--LoginInactivar 1

/*==================================================================================================*/
/*==================ACTIVAR LOGIN ==================================================================*/
/*==================================================================================================*/

CREATE PROCEDURE LoginActivar @Login_id INT
AS
	BEGIN
		UPDATE TLogin
		SET Login_estado = 'A'
		WHERE Login_id = @Login_id
END
GO

--LoginActivar 1

/*==================================================================================================*/
/*===================ELIMINAR LOGIN ================================================================*/
/*==================================================================================================*/

CREATE PROCEDURE LoginEliminar @Login_id INT 								
AS
BEGIN 
	DELETE FROM TLogin
	WHERE Login_id = @Login_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

--LoginEliminar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACION DE UN LOGIN =====================================*/
/*==================================================================================================*/

CREATE PROCEDURE LoginConsultar @Login_id INT
AS
BEGIN
	 SELECT *
	 FROM TLogin
	 WHERE Login_id = @Login_id
END
GO

--LoginConsultar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN LOGIN =====================================*/
/*==================================================================================================*/

CREATE PROCEDURE LoginListarA
AS
BEGIN
	SELECT Login_id,
			Login_Usuario,
			Login_contraseña,
			Login_correoElectronico,
			Login_administrador,
			Login_estado

	FROM TLogin
	WHERE Login_estado = 'A'
END
GO

--LoginListarA

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN LOGIN =====================================*/
/*==================================================================================================*/

CREATE PROCEDURE LoginListarI
AS
BEGIN
	SELECT Login_id,
			Login_Usuario,
			Login_contraseña,
			Login_correoElectronico,
			Login_administrador,
			Login_estado

	FROM TLogin
	WHERE Login_estado = 'I'
END
GO
--LoginListarI


CREATE PROCEDURE LoginConsultarUsuario @Login_Usuario Varchar(10)
AS
BEGIN
	 SELECT *
	 FROM TLogin
	 WHERE Login_Usuario = @Login_Usuario 
END
GO

CREATE PROCEDURE LoginConsultarCorreo @Login_correoElectronico Varchar(50)
AS
BEGIN
	 SELECT *
	 FROM TLogin
	 WHERE Login_correoElectronico = @Login_correoElectronico 
END
GO
