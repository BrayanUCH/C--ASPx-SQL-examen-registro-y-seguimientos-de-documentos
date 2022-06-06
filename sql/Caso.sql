/*==================================================================================================*/
/*===================INSERTAR CASO =================================================================*/
/*==================================================================================================*/
--ALTER CREATE 
CREATE PROCEDURE CasoInsertar @Tramite_id int,
									@Caso_codigo VARCHAR(50),
									@Caso_fechaInicio DATE,
									@Caso_fechaFinal DATE,
									@Caso_estado VARCHAR(1)
AS
BEGIN
	INSERT INTO TCaso(Tramite_id,
							Caso_codigo,
							Caso_fechaInicio,
							Caso_fechaFinal,
							Caso_estado) 

	SELECT  @Tramite_id,
			@Caso_codigo,
			@Caso_fechaInicio,
			@Caso_fechaFinal,
			@Caso_estado
			
END
GO

--CasoInsertar '1','123','2020-03-19','2020-11-05','A'

/*==================================================================================================*/
/*===================MODIFICAR CASO ================================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CasoModificar @Caso_id INT,
									@Tramite_id INT,
									@Caso_codigo VARCHAR(50),
									@Caso_fechaInicio DATE,
									@Caso_fechaFinal DATE,
									@Caso_estado VARCHAR(1)
AS
	BEGIN
		UPDATE TCaso
		SET	Tramite_id = @Tramite_id,
			Caso_codigo = @Caso_codigo,
			Caso_fechaInicio = @Caso_fechaInicio,
			Caso_fechaFinal = @Caso_fechaFinal,
			Caso_estado = @Caso_estado
		WHERE Caso_id = @Caso_id
	END
GO

--CasoModificar 1,'1','321','17/05/2020','30/10/2020','A'

/*==================================================================================================*/
/*===================INACTIVAR CASO ================================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CasoInactivar @Caso_id INT
AS
	BEGIN
		UPDATE TCaso
		SET Caso_estado = 'I'
		WHERE Caso_id = @Caso_id
END
GO

--CasoInactivar 1

/*==================================================================================================*/
/*==================ACTIVAR CASO ===================================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CasoActivar @Caso_id INT
AS
	BEGIN
		UPDATE TCaso
		SET Caso_estado = 'A'
		WHERE Caso_id = @Caso_id
END
GO

--CasoActivar 1

/*==================================================================================================*/
/*===================ELIMINAR CASO =================================================================*/
/*==================================================================================================*/

CREATE PROCEDURE CasoEliminar @Caso_id INT 								
AS
BEGIN 
	DELETE FROM TCaso
	WHERE Caso_id = @Caso_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

--CasoEliminar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN CASO ======================================*/
/*==================================================================================================*/

CREATE PROCEDURE CasoConsultar @Caso_id INT
AS
BEGIN
	 SELECT *
	 FROM TCaso
	 WHERE Caso_id = @Caso_id
END
GO

--CasoConsultar 2

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN CASO ======================================*/
/*==================================================================================================*/

CREATE PROCEDURE CasoListarA
AS
BEGIN
	SELECT Caso_id,
			Tramite_id,
			Caso_codigo,
			Caso_fechaInicio,
			Caso_fechaFinal,
			Caso_estado

	FROM TCaso
	WHERE Caso_estado = 'A'
END
GO
--CasoListarA

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN CASO ======================================*/
/*==================================================================================================*/

CREATE PROCEDURE CasoListarI
AS
BEGIN
	SELECT Caso_id,
			Tramite_id,
			Caso_codigo,
			Caso_fechaInicio,
			Caso_fechaFinal,
			Caso_estado

	FROM TCaso
	WHERE Caso_estado = 'I'
END
GO
--CasoListarI


CREATE PROCEDURE CasoConsultarCodigo @Caso_codigo VARCHAR(50)
AS
BEGIN
	 SELECT *
	 FROM TCaso
	 WHERE Caso_codigo = @Caso_codigo
END
GO
