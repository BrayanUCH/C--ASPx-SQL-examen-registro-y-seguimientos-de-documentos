/*==================================================================================================*/
/*===================INSERTAR CICLO ================================================================*/
/*==================================================================================================*/
--ALTER CREATE 
CREATE PROCEDURE CicloInsertar @Tramite_id int,
									@Departamento_id int,
									@Ciclo_orden VARCHAR(50),
									@Ciclo_estado VARCHAR(1)
AS
BEGIN
	INSERT INTO TCiclo(Tramite_id,
							Departamento_id,
							Ciclo_orden,
							Ciclo_estado) 

	SELECT  @Tramite_id,
			@Departamento_id,
			@Ciclo_orden,
			@Ciclo_estado
			
END
GO

--CicloInsertar 1,2,'num','A'

/*==================================================================================================*/
/*===================MODIFICAR CICLO ===============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CicloModificar @Ciclo_id INT,
									@Tramite_id int,
									@Departamento_id int,
									@Ciclo_orden VARCHAR(50),
									@Ciclo_estado VARCHAR(1)
AS
	BEGIN
		UPDATE TCiclo
		SET	Tramite_id = @Tramite_id,
			Departamento_id = @Departamento_id,
			Ciclo_orden = @Ciclo_orden,
			Ciclo_estado = @Ciclo_estado
	
		WHERE Ciclo_id = @Ciclo_id
	END
GO

--CicloModificar 3,2,1,'num','A'

/*==================================================================================================*/
/*===================INACTIVAR CICLO ===============================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CicloInactivar @Ciclo_id INT
AS
	BEGIN
		UPDATE TCiclo
		SET Ciclo_estado = 'I'
		WHERE Ciclo_id = @Ciclo_id
END
GO

--CicloInactivar 1

/*==================================================================================================*/
/*==================ACTIVAR CICLO ==================================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CicloActivar @Ciclo_id INT
AS
	BEGIN
		UPDATE TCiclo
		SET Ciclo_estado = 'A'
		WHERE Ciclo_id = @Ciclo_id
END
GO

--CicloActivar 1

/*==================================================================================================*/
/*===================ELIMINAR CICLO ================================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CicloEliminar @Ciclo_id INT 								
AS
BEGIN 
	DELETE FROM TCiclo
	WHERE Ciclo_id = @Ciclo_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

--CicloEliminar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN CICLO =====================================*/
/*==================================================================================================*/

CREATE PROCEDURE CicloConsultar @Ciclo_id INT
AS
BEGIN
	 SELECT *
	 FROM TCiclo
	 WHERE Ciclo_id = @Ciclo_id
END
GO

--CicloConsultar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN DOCUCICLOMENTO ============================*/
/*==================================================================================================*/

CREATE PROCEDURE CicloListarA
AS
BEGIN
	SELECT Ciclo_id,
			Tramite_id,
			Departamento_id,
			Ciclo_orden,
			Ciclo_estado

	FROM TCiclo
	WHERE Ciclo_estado = 'A'
END
GO
--CicloListarA

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN CICLO =====================================*/
/*==================================================================================================*/

CREATE PROCEDURE CicloListarI
AS
BEGIN
	SELECT Ciclo_id,
			Tramite_id,
			Departamento_id,
			Ciclo_orden,
			Ciclo_estado

	FROM TCiclo
	WHERE Ciclo_estado = 'I'
END
GO
--CicloListarI
