/*==================================================================================================*/
/*===================INSERTAR DEPARTAMENTO ==========================================================*/
/*==================================================================================================*/
--ALTER CREATE 
CREATE PROCEDURE DepartamentoInsertar @Organizacion_id int,
									@Departamento_nombre VARCHAR(50),
									@Departamento_tipo VARCHAR(50),
									@Departamento_descripcion VARCHAR(50),
									@Departamento_estado VARCHAR(1)
AS
BEGIN
	INSERT INTO TDepartamento(Organizacion_id,
							Departamento_nombre,
							Departamento_tipo,
							Departamento_descripcion,
							Departamento_estado) 

	SELECT  @Organizacion_id,
			@Departamento_nombre,
			@Departamento_tipo,
			@Departamento_descripcion,
			@Departamento_estado
			
END
GO

--DepartamentoInsertar '1','FBI','POLICIA','NCIS','A'

/*==================================================================================================*/
/*===================MODIFICAR DEPARTAMENTO ========================================================*/
/*==================================================================================================*/

CREATE PROCEDURE DepartamentoModificar @Departamento_id INT,
									@Organizacion_id int,
									@Departamento_nombre VARCHAR(50),
									@Departamento_tipo VARCHAR(50),
									@Departamento_descripcion VARCHAR(50),
									@Departamento_estado VARCHAR(1)
AS
	BEGIN
		UPDATE TDepartamento
		SET	Organizacion_id = @Organizacion_id,
			Departamento_nombre = @Departamento_nombre,
			Departamento_tipo = @Departamento_tipo,
			Departamento_descripcion = @Departamento_descripcion,
			Departamento_estado = @Departamento_estado
				
		WHERE Departamento_id = @Departamento_id
	END
GO

--DepartamentoModificar 1,'2','FBI','POLICIA','NCIS','A'

/*==================================================================================================*/
/*===================INACTIVAR DEPARTAMENTO ========================================================*/
/*==================================================================================================*/

CREATE PROCEDURE DepartamentoInactivar @Departamento_id INT
AS
	BEGIN
		UPDATE TDepartamento
		SET Departamento_estado = 'I'
		WHERE Departamento_id = @Departamento_id
END
GO

--DepartamentoInactivar 1

/*==================================================================================================*/
/*==================ACTIVAR DEPARTAMENTO ===========================================================*/
/*==================================================================================================*/

CREATE PROCEDURE DepartamentoActivar @Departamento_id INT
AS
	BEGIN
		UPDATE TDepartamento
		SET Departamento_estado = 'A'
		WHERE Departamento_id = @Departamento_id
END
GO

--DepartamentoActivar 1

/*==================================================================================================*/
/*===================ELIMINAR DEPARTAMENTO =========================================================*/
/*==================================================================================================*/

CREATE PROCEDURE DepartamentoEliminar @Departamento_id INT 								
AS
BEGIN 
	DELETE FROM TDepartamento
	WHERE Departamento_id = @Departamento_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

--DepartamentoEliminar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA DEPARTAMENTO =============================*/
/*==================================================================================================*/

CREATE PROCEDURE DepartamentoConsultar @Departamento_id INT
AS
BEGIN
	 SELECT *
	 FROM TDepartamento
	 WHERE Departamento_id = @Departamento_id
END
GO

--DepartamentoConsultar 2

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA DEPARTAMENTO =============================*/
/*==================================================================================================*/

CREATE PROCEDURE DepartamentoListarA
AS
BEGIN
	SELECT Departamento_id,
			Organizacion_id,
			Departamento_nombre,
			Departamento_tipo,
			Departamento_descripcion,
			Departamento_estado

	FROM TDepartamento
	WHERE Departamento_estado = 'A'
END
GO
--DepartamentoListarA

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA DEPARTAMENTO =============================*/
/*==================================================================================================*/

CREATE PROCEDURE DepartamentoListarI
AS
BEGIN
	SELECT Departamento_id,
			Organizacion_id,
			Departamento_nombre,
			Departamento_tipo,
			Departamento_descripcion,
			Departamento_estado

	FROM TDepartamento
	WHERE Departamento_estado = 'I'
END
GO
--DepartamentoListarI
