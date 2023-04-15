CREATE TABLE USUARIO(
IdUsuario int primary key identity,
Nombres varchar(100),
Apellidos varchar(100),
Numero_de_doc varchar(100),
Telefono varchar(12),
Numero_Cuenta varchar(100),
Salario varchar(100),
Correo varchar(100),
Clave varchar(150),
Reestablecer bit default 1,
Activo bit default 1,
)