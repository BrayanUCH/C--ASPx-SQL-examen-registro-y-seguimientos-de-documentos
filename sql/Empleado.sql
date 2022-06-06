/*==================================================================================================*/
/*===================INSERTAR EMPLEADO =============================================================*/
/*==================================================================================================*/
--ALTER CREATE 
CREATE PROCEDURE EmpleadoInsertar @Departamento_id int,
									@Empleado_nombre VARCHAR(50),
									@Empleado_apellidos VARCHAR(50),
									@Empleado_fechaNacimiento datetime,
									@Empleado_puesto VARCHAR(50),
									@Empleado_genero VARCHAR(50),
									@Empleado_estadoCivil VARCHAR(50),
									@Empleado_fechaIngreso datetime,
									@Empleado_estado VARCHAR(1)
AS
BEGIN
	INSERT INTO TEmpleado(Departamento_id,
							Empleado_nombre,
							Empleado_apellidos,
							Empleado_fechaNacimiento,
							Empleado_puesto,
							Empleado_genero,
							Empleado_estadoCivil,
							Empleado_fechaIngreso,
							Empleado_estado) 

	SELECT  @Departamento_id,
			 @Empleado_nombre,
			 @Empleado_apellidos,
			 @Empleado_fechaNacimiento,
			 @Empleado_puesto,
			 @Empleado_genero,
			 @Empleado_estadoCivil,
			 @Empleado_fechaIngreso,
			 @Empleado_estado
			
END
GO

--EmpleadoInsertar '2','brandon','u_ch','2000-05-19','jefe','masculino','soltero','2015-05-19','A'

/*==================================================================================================*/
/*===================MODIFICAR EMPLEADO ============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE EmpleadoModificar @Empleado_id INT,
									@Departamento_id int,
									@Empleado_nombre VARCHAR(50),
									@Empleado_apellidos VARCHAR(50),
									@Empleado_fechaNacimiento DATE,
									@Empleado_puesto VARCHAR(50),
									@Empleado_genero VARCHAR(50),
									@Empleado_estadoCivil VARCHAR(50),
									@Empleado_fechaIngreso DATE,
									@Empleado_estado VARCHAR(1)
AS
	BEGIN
		UPDATE TEmpleado
		SET	Departamento_id = @Departamento_id,
			Empleado_nombre = @Empleado_nombre,
			Empleado_apellidos = @Empleado_apellidos,
			Empleado_fechaNacimiento = @Empleado_fechaNacimiento,
			Empleado_puesto = @Empleado_puesto,
			Empleado_genero = @Empleado_genero,
			Empleado_estadoCivil = @Empleado_estadoCivil,
			Empleado_fechaIngreso = @Empleado_fechaIngreso,
			Empleado_estado = @Empleado_estado
	
		WHERE Empleado_id = @Empleado_id
	END
GO

--EmpleadoModificar 1,'1','BRANDON','U_CH','19/05/2000','BOSS','Masculino','Soltero','19/05/2015','A'

/*==================================================================================================*/
/*===================INACTIVAR EMPLEADO ============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE EmpleadoInactivar @Empleado_id INT
AS
	BEGIN
		UPDATE TEmpleado
		SET Empleado_estado = 'I'
		WHERE Empleado_id = @Empleado_id
END
GO

--EmpleadoInactivar 1

/*==================================================================================================*/
/*==================ACTIVAR EMPLEADO ===============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE EmpleadoActivar @Empleado_id INT
AS
	BEGIN
		UPDATE TEmpleado
		SET Empleado_estado = 'A'
		WHERE Empleado_id = @Empleado_id
END
GO

--EmpleadoActivar 1

/*==================================================================================================*/
/*===================ELIMINAR EMPLEADO =============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE EmpleadoEliminar @Empleado_id INT 								
AS
BEGIN 
	DELETE FROM TEmpleado
	WHERE Empleado_id = @Empleado_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

--EmpleadoEliminar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA EMPLEADO =================================*/
/*==================================================================================================*/

CREATE PROCEDURE EmpleadoConsultar @Empleado_id INT
AS
BEGIN
	 SELECT *
	 FROM TEmpleado
	 WHERE Empleado_id = @Empleado_id
END
GO

--EmpleadoConsultar 2

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA EMPLEADO =================================*/
/*==================================================================================================*/

CREATE PROCEDURE EmpleadoListarA
AS
BEGIN
	SELECT Empleado_id,
			Departamento_id,
			Empleado_nombre,
			Empleado_apellidos,
			Empleado_fechaNacimiento,
			Empleado_puesto,
			Empleado_genero,
			Empleado_estadoCivil,
			Empleado_fechaIngreso,
			Empleado_estado

	FROM TEmpleado
	WHERE Empleado_estado = 'A'
END
GO
--EmpleadoListarA

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UNA EMPLEADO =================================*/
/*==================================================================================================*/

CREATE PROCEDURE EmpleadoListarI
AS
BEGIN
	SELECT  Empleado_id,
			Departamento_id,
			Empleado_nombre,
			Empleado_apellidos,
			Empleado_fechaNacimiento,
			Empleado_puesto,
			Empleado_genero,
			Empleado_estadoCivil,
			Empleado_fechaIngreso,
			Empleado_estado

	FROM TEmpleado
	WHERE Empleado_estado = 'I'
END
GO
--EmpleadoListarI
