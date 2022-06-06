CREATE TABLE TIdioma (Idioma_id INT IDENTITY(1,1),/*LLAVE PRIMARIA*/
							Idioma_nombre VARCHAR(50),
							Idioma_iniciales VARCHAR(3),
							Idioma_estado VARCHAR(1)
							)
ALTER TABLE TIdioma ADD CONSTRAINT TIdioma_PK PRIMARY KEY (Idioma_id)/*Llave primaria*/


CREATE TABLE TDocumento (Documento_id INT IDENTITY(1,1),/*LLAVE PRIMARIA*/
							Tramite_id  INT NOT NULL,
							Idioma_id  INT NOT NULL,
							Documento_nombre VARCHAR(50),
							Documento_ruta VARCHAR(2083),
							Documento_tipo VARCHAR(50),
							Documento_estado VARCHAR(1),
							)
ALTER TABLE TDocumento ADD CONSTRAINT TDocumento_PK PRIMARY KEY (Documento_id)/*Llave primaria*/
ALTER TABLE TDocumento ADD CONSTRAINT TDocumento_FK FOREIGN KEY (Tramite_id) REFERENCES TTramite(Tramite_id)/*Llave foránea*/
ALTER TABLE TDocumento ADD CONSTRAINT TDocumento_FK1 FOREIGN KEY (Idioma_id) REFERENCES TIdioma(Idioma_id)/*Llave foránea*/


CREATE TABLE TTramite (Tramite_id INT IDENTITY(1,1), /*Llave primaria*/
						  Tramite_nombre VARCHAR(50),
						  Tramite_descripcion VARCHAR(50),
						  Tramite_estado VARCHAR(1)
						 )	
ALTER TABLE TTramite ADD CONSTRAINT TTramite_PK PRIMARY KEY (Tramite_id)/*Llave primaria*/


CREATE TABLE TCiclo (Ciclo_id INT IDENTITY(1,1), /*Llave primaria*/
						  Tramite_id INT NOT NULL, /*Llave foránea*/
						  Departamento_id INT NOT NULL, /*Llave foránea*/
						  Ciclo_orden VARCHAR(50),
						  Ciclo_estado VARCHAR(1)
						 )	
ALTER TABLE TCiclo ADD CONSTRAINT TCiclo_PK PRIMARY KEY (Ciclo_id)/*Llave primaria*/
ALTER TABLE TCiclo ADD CONSTRAINT TCiclo_FK FOREIGN KEY (Tramite_id) REFERENCES TTramite(Tramite_id)/*Llave foránea*/
ALTER TABLE TCiclo ADD CONSTRAINT TCiclo_FK1 FOREIGN KEY (Departamento_id) REFERENCES TDepartamento(Departamento_id)/*Llave foránea*/
 

CREATE TABLE TDepartamento (Departamento_id INT IDENTITY(1,1),/*LLAVE PRIMARIA*/
							Organizacion_id INT NOT NULL, /*Llave foránea*/
							Departamento_nombre VARCHAR(50),
							Departamento_tipo VARCHAR(50),
							Departamento_descripcion VARCHAR(50),
							Departamento_estado VARCHAR(1)
							)
ALTER TABLE TDepartamento ADD CONSTRAINT TDepartamento_PK PRIMARY KEY (Departamento_id)/*Llave primaria*/
ALTER TABLE TDepartamento ADD CONSTRAINT TDepartamento_FK FOREIGN KEY (Organizacion_id) REFERENCES TOrganizacion(Organizacion_id)/*Llave foránea*/
 

CREATE TABLE TDetalleCaso (DetalleCaso_id INT IDENTITY(1,1),/*LLAVE PRIMARIA*/
							Caso_id INT NOT NULL, /*Llave foránea*/
							Ciclo_id INT NOT NULL, /*Llave foránea*/
							Documento_id INT NOT NULL, /*Llave foránea*/
							DetalleCaso_fechaRecibido DATE,
							DetalleCaso_fechaTranspaso DATE,
							DetalleCaso_descripcion VARCHAR(50),
							DetalleCaso_estado VARCHAR(1)
							)
ALTER TABLE TDetalleCaso ADD CONSTRAINT TDetalleCaso_PK PRIMARY KEY (DetalleCaso_id)/*Llave primaria*/
ALTER TABLE TDetalleCaso ADD CONSTRAINT TDetalleCaso_FK FOREIGN KEY (Caso_id) REFERENCES TCaso(Caso_id)/*Llave foránea*/
ALTER TABLE TDetalleCaso ADD CONSTRAINT TDetalleCaso_FK1 FOREIGN KEY (Ciclo_id) REFERENCES TCiclo(Ciclo_id)/*Llave foránea*/
ALTER TABLE TDetalleCaso ADD CONSTRAINT TDetalleCaso_FK2 FOREIGN KEY (Documento_id) REFERENCES TDocumento(Documento_id)/*Llave foránea*/


CREATE TABLE TCaso (Caso_id INT IDENTITY(1,1), /*Llave primaria*/
								Tramite_id INT NOT NULL, /*Llave foránea*/
								Caso_codigo VARCHAR(50),
								Caso_fechaInicio DATE,
								Caso_fechaFinal DATE,
								Caso_estado VARCHAR(1)
						 )	
ALTER TABLE TCaso ADD CONSTRAINT TCaso_PK PRIMARY KEY (Caso_id)/*Llave primaria*/
ALTER TABLE TCaso ADD CONSTRAINT TCaso_FK FOREIGN KEY (Tramite_id) REFERENCES TTramite(Tramite_id)/*Llave foránea*/


CREATE TABLE TCodigo (Codigo_id INT IDENTITY(1,1),/*LLAVE PRIMARIA*/
							Organizacion_id INT NOT NULL, /*Llave foránea*/
							Codigo_formato VARCHAR(50),
							Codigo_estado VARCHAR(1)
							)
ALTER TABLE TCodigo ADD CONSTRAINT TCodigo_PK PRIMARY KEY (Codigo_id)/*Llave primaria*/
ALTER TABLE TCodigo ADD CONSTRAINT TCodigo_FK FOREIGN KEY (Organizacion_id) REFERENCES TOrganizacion(Organizacion_id)/*Llave foránea*/


CREATE TABLE TOrganizacion (Organizacion_id INT IDENTITY(1,1),/*LLAVE PRIMARIA*/
							Organizacion_nombre VARCHAR(50),
							Organizacion_tipo VARCHAR(50),
							Organizacion_descripcion VARCHAR(50),
							Organizacion_estado VARCHAR(1)
							)
ALTER TABLE TOrganizacion ADD CONSTRAINT TOrganizacion_PK PRIMARY KEY (Organizacion_id)/*Llave primaria*/


CREATE TABLE TEmpleado (Empleado_id INT IDENTITY(1,1),/*LLAVE PRIMARIA*/
							Departamento_id INT NOT NULL, /*Llave foránea*/
							Empleado_nombre VARCHAR(50),
							Empleado_apellidos VARCHAR(50),
							Empleado_fechaNacimiento DATE,
							Empleado_puesto VARCHAR(50),
							Empleado_genero VARCHAR(50),
							Empleado_estadoCivil VARCHAR(50),
							Empleado_fechaIngreso DATE,
							Empleado_estado VARCHAR(1)
							)
ALTER TABLE TEmpleado ADD CONSTRAINT TEmpleado_PK PRIMARY KEY (Empleado_id)/*Llave primaria*/
ALTER TABLE TEmpleado ADD CONSTRAINT TEmpleado_FK FOREIGN KEY (Departamento_id) REFERENCES TDepartamento(Departamento_id)/*Llave foránea*/

CREATE TABLE TLogin (Login_id INT IDENTITY(1,1),/*LLAVE PRIMARIA*/
							Login_Usuario VARCHAR(10),
							Login_contraseña VARCHAR(8),
							Login_correoElectronico VARCHAR(50),
							Login_administrador VARCHAR(13),
							Login_estado VARCHAR(1)
							)
ALTER TABLE TLogin ADD CONSTRAINT TLogin_PK PRIMARY KEY (Login_id)/*Llave primaria*/

CREATE TABLE TTipoUsuario (Usuario_id INT ,/*LLAVE PRIMARIA*/
							Usuario_tipo VARCHAR(15)
							)
ALTER TABLE TTipoUsuario ADD CONSTRAINT TTipoUsuario_PK PRIMARY KEY (Usuario_id)/*Llave primaria*/
