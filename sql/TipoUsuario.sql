CREATE PROCEDURE UsuarioInsertar @Usuario_id int,
									@Usuario_tipo VARCHAR(15)
AS
BEGIN
	INSERT INTO TTipoUsuario(Usuario_id,
							Usuario_tipo) 

	SELECT  @Usuario_id,
			@Usuario_tipo
			
END
GO

--UsuarioInsertar 1,'jpg'

CREATE PROCEDURE UsuarioModificar @Usuario_id INT,
									@Usuario_tipo VARCHAR(15)
									
									
AS
	BEGIN
		UPDATE TTipoUsuario
		SET	Usuario_id = @Usuario_id,
			Usuario_tipo = @Usuario_tipo
	
		WHERE Usuario_id = @Usuario_id
	END
GO


CREATE PROCEDURE UsuarioConsultar @Usuario_id INT
AS
BEGIN
	 SELECT *
	 FROM TTipoUsuario
	 WHERE Usuario_id = @Usuario_id
END
GO