/*==================================================================================================*/
/*===================INSERTAR DETALLE DEL CASO =====================================================*/
/*==================================================================================================*/
--ALTER CREATE 
CREATE PROCEDURE DetalleCasoInsertar @Caso_id int,
									@Ciclo_id int,
									@Documento_id int,
									@DetalleCaso_fechaRecibido DATE,
									@DetalleCaso_fechaTranspaso DATE,
									@DetalleCaso_descripcion VARCHAR(50),
									@DetalleCaso_estado VARCHAR(1)
AS
BEGIN
	INSERT INTO TDetalleCaso(Caso_id,
							Ciclo_id,
							Documento_id,
							DetalleCaso_fechaRecibido,
							DetalleCaso_fechaTranspaso,
							DetalleCaso_descripcion,
							DetalleCaso_estado) 

	SELECT  @Caso_id,
			@Ciclo_id,
			@Documento_id,
			@DetalleCaso_fechaRecibido,
			@DetalleCaso_fechaTranspaso,
			@DetalleCaso_descripcion,
			@DetalleCaso_estado
			
END
GO

--DetalleCasoInsertar '1','2','1','2000-05-19','2020-11-19','ok','A'

/*==================================================================================================*/
/*===================MODIFICAR DETALLE DEL CASO ====================================================*/
/*==================================================================================================*/

CREATE PROCEDURE DetalleCasoModificar @DetalleCaso_id INT,
									@Caso_id int,
									@Ciclo_id int,
									@Documento_id int,
									@DetalleCaso_fechaRecibido DATE,
									@DetalleCaso_fechaTranspaso DATE,
									@DetalleCaso_descripcion VARCHAR(50),
									@DetalleCaso_estado VARCHAR(1)
AS
	BEGIN
		UPDATE TDetalleCaso
		SET	Caso_id = @Caso_id,
			Ciclo_id = @Ciclo_id,
			Documento_id = @Documento_id,
			DetalleCaso_fechaRecibido = @DetalleCaso_fechaRecibido,
			DetalleCaso_fechaTranspaso = @DetalleCaso_fechaTranspaso,
			DetalleCaso_descripcion = @DetalleCaso_descripcion,
			DetalleCaso_estado = @DetalleCaso_estado

		WHERE DetalleCaso_id = @DetalleCaso_id
	END
GO

--DetalleCasoModificar 2,'1','1','2','19/05/2000','19/11/2020','ok','A'

/*==================================================================================================*/
/*===================INACTIVAR DETALLE DEL CASO ====================================================*/
/*==================================================================================================*/

CREATE PROCEDURE DetalleCasoInactivar @DetalleCaso_id INT
AS
	BEGIN
		UPDATE TDetalleCaso
		SET DetalleCaso_estado = 'I'
		WHERE DetalleCaso_id = @DetalleCaso_id
END
GO

--DetalleCasoInactivar 1

/*==================================================================================================*/
/*==================ACTIVAR DETALLE DEL CASO =======================================================*/
/*==================================================================================================*/

CREATE PROCEDURE DetalleCasoActivar @DetalleCaso_id INT
AS
	BEGIN
		UPDATE TDetalleCaso
		SET DetalleCaso_estado = 'A'
		WHERE DetalleCaso_id = @DetalleCaso_id
END
GO

--DetalleCasoActivar 1

/*==================================================================================================*/
/*===================ELIMINAR DETALLE DEL CASO =====================================================*/
/*==================================================================================================*/

CREATE PROCEDURE DetalleCasoEliminar @DetalleCaso_id INT 								
AS
BEGIN 
	DELETE FROM TDetalleCaso
	WHERE DetalleCaso_id = @DetalleCaso_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

--DetalleCasoEliminar 1

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN DETALLE DEL CASO ==========================*/
/*==================================================================================================*/

CREATE PROCEDURE DetalleCasoConsultar @DetalleCaso_id INT
AS
BEGIN
	 SELECT *
	 FROM TDetalleCaso
	 WHERE DetalleCaso_id = @DetalleCaso_id
END
GO

--DetalleCasoConsultar 2

/*==================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN DETALLE DEL CASO ==========================*/
/*==================================================================================================*/

CREATE PROCEDURE DetalleCasoListarA
AS
BEGIN
	SELECT DetalleCaso_id,
			Caso_id,
			Ciclo_id,
			Documento_id,
			DetalleCaso_fechaRecibido,
			DetalleCaso_fechaTranspaso,
			DetalleCaso_descripcion,
			DetalleCaso_estado

	FROM TDetalleCaso
	WHERE DetalleCaso_estado = 'A'
END
GO
--DetalleCasoListarA

/*=================================================================================================*/
/*===================CONSULTAR TODA LA INFORMACI�N DE UN DETALLE DEL CASO ===========================*/
/*==================================================================================================*/

CREATE PROCEDURE DetalleCasoListarI
AS
BEGIN
	SELECT DetalleCaso_id,
			Caso_id,
			Ciclo_id,
			Documento_id,
			DetalleCaso_fechaRecibido,
			DetalleCaso_fechaTranspaso,
			DetalleCaso_descripcion,
			DetalleCaso_estado

	FROM TDetalleCaso
	WHERE DetalleCaso_estado = 'I'
END
GO
--DetalleCasoListarI
