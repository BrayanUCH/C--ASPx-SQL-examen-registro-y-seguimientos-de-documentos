
CREATE PROCEDURE IdiomaInsertar @Idioma_nombre  VARCHAR(50),
									@Idioma_iniciales VARCHAR(3),
									@Idioma_estado VARCHAR(1)
AS
BEGIN
	INSERT INTO TIdioma(Idioma_nombre,
							Idioma_iniciales,
							Idioma_estado)
							
	SELECT  @Idioma_nombre,
			@Idioma_iniciales,
			@Idioma_estado
END
GO

CREATE PROCEDURE IdiomaModificar @Idioma_id INT,
									@Idioma_nombre  VARCHAR(50),
									@Idioma_iniciales VARCHAR(3),
									@Idioma_estado VARCHAR(1)
AS
	BEGIN
		UPDATE TIdioma
		SET	Idioma_nombre = @Idioma_nombre,
			Idioma_iniciales = @Idioma_iniciales,
			Idioma_estado = @Idioma_estado
	
		WHERE Idioma_id = @Idioma_id
	END
GO

CREATE PROCEDURE IdiomaInactivar @Idioma_id INT
AS
	BEGIN
		UPDATE TIdioma
		SET Idioma_estado = 'I'
		WHERE Idioma_id = @Idioma_id
END
GO

CREATE PROCEDURE IdiomaActivar @Idioma_id INT
AS
	BEGIN
		UPDATE TIdioma
		SET Idioma_estado = 'A'
		WHERE Idioma_id = @Idioma_id
END
GO

CREATE PROCEDURE IdiomaEliminar @Idioma_id INT 								
AS
BEGIN 
	DELETE FROM TIdioma
	WHERE Idioma_id = @Idioma_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

CREATE PROCEDURE IdiomaConsultar @Idioma_id INT
AS
BEGIN
	 SELECT *
	 FROM TIdioma
	 WHERE Idioma_id = @Idioma_id
END
GO

CREATE PROCEDURE IdiomaListarA
AS
BEGIN
	SELECT Idioma_id,
			Idioma_nombre,
			Idioma_iniciales,
			Idioma_estado
	FROM TIdioma
	WHERE Idioma_estado = 'A'
END
GO

CREATE PROCEDURE IdiomaListarI
AS
BEGIN
	SELECT Idioma_id,
			Idioma_nombre,
			Idioma_iniciales,
			Idioma_estado
	FROM TIdioma
	WHERE Idioma_estado = 'I'
END
GO



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

CREATE PROCEDURE OrganizacionInactivar @Organizacion_id INT
AS
	BEGIN
		UPDATE TOrganizacion
		SET Organizacion_estado = 'I'
		WHERE Organizacion_id = @Organizacion_id
END
GO

CREATE PROCEDURE OrganizacionActivar @Organizacion_id INT
AS
	BEGIN
		UPDATE TOrganizacion
		SET Organizacion_estado = 'A'
		WHERE Organizacion_id = @Organizacion_id
END
GO

CREATE PROCEDURE OrganizacionEliminar @Organizacion_id INT 								
AS
BEGIN 
	DELETE FROM TOrganizacion
	WHERE Organizacion_id = @Organizacion_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

CREATE PROCEDURE OrganizacionConsultar @Organizacion_id INT
AS
BEGIN
	 SELECT *
	 FROM TOrganizacion
	 WHERE Organizacion_id = @Organizacion_id
END
GO

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

CREATE PROCEDURE CodigoInactivar @Codigo_id INT
AS
	BEGIN
		UPDATE TCodigo
		SET Codigo_estado = 'I'
		WHERE Codigo_id = @Codigo_id
END
GO

CREATE PROCEDURE CodigoActivar @Codigo_id INT
AS
	BEGIN
		UPDATE TCodigo
		SET Codigo_estado = 'A'
		WHERE Codigo_id = @Codigo_id
END
GO

CREATE PROCEDURE CodigoEliminar @Codigo_id INT 								
AS
BEGIN 
	DELETE FROM TCodigo
	WHERE Codigo_id = @Codigo_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

CREATE PROCEDURE CodigoConsultar @Codigo_id INT
AS
BEGIN
	 SELECT *
	 FROM TCodigo
	 WHERE Codigo_id = @Codigo_id
END
GO

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

CREATE PROCEDURE DepartamentoInactivar @Departamento_id INT
AS
	BEGIN
		UPDATE TDepartamento
		SET Departamento_estado = 'I'
		WHERE Departamento_id = @Departamento_id
END
GO

CREATE PROCEDURE DepartamentoActivar @Departamento_id INT
AS
	BEGIN
		UPDATE TDepartamento
		SET Departamento_estado = 'A'
		WHERE Departamento_id = @Departamento_id
END
GO

CREATE PROCEDURE DepartamentoEliminar @Departamento_id INT 								
AS
BEGIN 
	DELETE FROM TDepartamento
	WHERE Departamento_id = @Departamento_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

CREATE PROCEDURE DepartamentoConsultar @Departamento_id INT
AS
BEGIN
	 SELECT *
	 FROM TDepartamento
	 WHERE Departamento_id = @Departamento_id
END
GO

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

CREATE PROCEDURE TramiteInactivar @Tramite_id INT
AS
	BEGIN
		UPDATE TTramite
		SET Tramite_estado = 'I'
		WHERE Tramite_id = @Tramite_id
END
GO

CREATE PROCEDURE TramiteActivar @Tramite_id INT
AS
	BEGIN
		UPDATE TTramite
		SET Tramite_estado = 'A'
		WHERE Tramite_id = @Tramite_id
END
GO

CREATE PROCEDURE TramiteEliminar @Tramite_id INT 								
AS
BEGIN 
	DELETE FROM TTramite
	WHERE Tramite_id = @Tramite_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

CREATE PROCEDURE TramiteConsultar @Tramite_id INT
AS
BEGIN
	 SELECT *
	 FROM TTramite
	 WHERE Tramite_id = @Tramite_id
END
GO

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

CREATE PROCEDURE DocumentoInactivar @Documento_id INT
AS
	BEGIN
		UPDATE TDocumento
		SET Documento_estado = 'I'
		WHERE Documento_id = @Documento_id
END
GO

CREATE PROCEDURE DocumentoActivar @Documento_id INT
AS
	BEGIN
		UPDATE TDocumento
		SET Documento_estado = 'A'
		WHERE Documento_id = @Documento_id
END
GO

CREATE PROCEDURE DocumentoEliminar @Documento_id INT 								
AS
BEGIN 
	DELETE FROM TDocumento
	WHERE Documento_id = @Documento_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

CREATE PROCEDURE DocumentoConsultar @Documento_id INT
AS
BEGIN
	 SELECT *
	 FROM TDocumento
	 WHERE Documento_id = @Documento_id
END
GO

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

CREATE PROCEDURE CicloInactivar @Ciclo_id INT
AS
	BEGIN
		UPDATE TCiclo
		SET Ciclo_estado = 'I'
		WHERE Ciclo_id = @Ciclo_id
END
GO

CREATE PROCEDURE CicloActivar @Ciclo_id INT
AS
	BEGIN
		UPDATE TCiclo
		SET Ciclo_estado = 'A'
		WHERE Ciclo_id = @Ciclo_id
END
GO

CREATE PROCEDURE CicloEliminar @Ciclo_id INT 								
AS
BEGIN 
	DELETE FROM TCiclo
	WHERE Ciclo_id = @Ciclo_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

CREATE PROCEDURE CicloConsultar @Ciclo_id INT
AS
BEGIN
	 SELECT *
	 FROM TCiclo
	 WHERE Ciclo_id = @Ciclo_id
END
GO

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

CREATE PROCEDURE CasoInactivar @Caso_id INT
AS
	BEGIN
		UPDATE TCaso
		SET Caso_estado = 'I'
		WHERE Caso_id = @Caso_id
END
GO

CREATE PROCEDURE CasoActivar @Caso_id INT
AS
	BEGIN
		UPDATE TCaso
		SET Caso_estado = 'A'
		WHERE Caso_id = @Caso_id
END
GO

CREATE PROCEDURE CasoEliminar @Caso_id INT 								
AS
BEGIN 
	DELETE FROM TCaso
	WHERE Caso_id = @Caso_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

CREATE PROCEDURE CasoConsultar @Caso_id INT
AS
BEGIN
	 SELECT *
	 FROM TCaso
	 WHERE Caso_id = @Caso_id
END
GO

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


CREATE PROCEDURE CasoConsultarCodigo @Caso_codigo VARCHAR(50)
AS
BEGIN
	 SELECT *
	 FROM TCaso
	 WHERE Caso_codigo = @Caso_codigo
END
GO


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

CREATE PROCEDURE DetalleCasoInactivar @DetalleCaso_id INT
AS
	BEGIN
		UPDATE TDetalleCaso
		SET DetalleCaso_estado = 'I'
		WHERE DetalleCaso_id = @DetalleCaso_id
END
GO

CREATE PROCEDURE DetalleCasoActivar @DetalleCaso_id INT
AS
	BEGIN
		UPDATE TDetalleCaso
		SET DetalleCaso_estado = 'A'
		WHERE DetalleCaso_id = @DetalleCaso_id
END
GO


CREATE PROCEDURE DetalleCasoEliminar @DetalleCaso_id INT 								
AS
BEGIN 
	DELETE FROM TDetalleCaso
	WHERE DetalleCaso_id = @DetalleCaso_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

CREATE PROCEDURE DetalleCasoConsultar @DetalleCaso_id INT
AS
BEGIN
	 SELECT *
	 FROM TDetalleCaso
	 WHERE DetalleCaso_id = @DetalleCaso_id
END
GO

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

CREATE PROCEDURE LoginInactivar @Login_id INT
AS
	BEGIN
		UPDATE TLogin
		SET Login_estado = 'I'
		WHERE Login_id = @Login_id
END
GO

CREATE PROCEDURE LoginActivar @Login_id INT
AS
	BEGIN
		UPDATE TLogin
		SET Login_estado = 'A'
		WHERE Login_id = @Login_id
END
GO

CREATE PROCEDURE LoginEliminar @Login_id INT 								
AS
BEGIN 
	DELETE FROM TLogin
	WHERE Login_id = @Login_id
	SELECT 'SE HA ELIMINADO CON EXITO' 		
	
END
GO

CREATE PROCEDURE LoginConsultar @Login_id INT
AS
BEGIN
	 SELECT *
	 FROM TLogin
	 WHERE Login_id = @Login_id
END
GO

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
