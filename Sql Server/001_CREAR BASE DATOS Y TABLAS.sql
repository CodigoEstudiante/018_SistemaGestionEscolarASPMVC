USE MASTER
GO
IF EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'BDCOLEGIOWEB')
DROP DATABASE BDCOLEGIOWEB

go

CREATE DATABASE BDCOLEGIOWEB

GO

USE BDCOLEGIOWEB

GO

--(1) TABLA MENU
create table MENU(
IdMenu int primary key identity(1,1),
Nombre varchar(60),
Icono varchar(60),
Activo bit default 1,
FechaRegistro datetime default getdate()
)

GO

--(2) TABLA SUBMENU
create table SUBMENU(
IdSubMenu int primary key identity(1,1),
IdMenu int references MENU(IdMenu),
Nombre varchar(60),
NombreFormulario varchar(60),
Accion varchar(50),
Activo bit default 1,
FechaRegistro datetime default getdate()
)


GO

--(3) TABLA ROL
create table ROL(
IdRol int primary key identity(1,1),
Descripcion varchar(60),
Activo bit default 1,
FechaRegistro datetime default getdate()
)

GO

--(4) TABLA PERMISOS
create table PERMISOS(
IdPermisos int primary key identity(1,1),
IdRol int references ROL(IdRol),
IdSubMenu int references SUBMENU(IdSubMenu),
Activo bit default 1,
FechaRegistro datetime default getdate()
)
go
--(5) TABLA USUARIO
create table USUARIO(
IdUsuario int primary key identity(1,1),
Nombres varchar(100),
Apellidos varchar(100),
IdRol int references ROL(IdRol),
LoginUsuario varchar(50),
LoginClave varchar(50),
DescripcionReferencia varchar(50),
IdReferencia int,
Activo bit default 1,
FechaRegistro datetime default getdate()
)
go
--(6) TABLA ALUMNO
create table ALUMNO(
IdAlumno int primary key identity(1,1),
ValorCodigo int,
Codigo varchar(50),
Nombres varchar(100),
Apellidos varchar(100),
DocumentoIdentidad varchar(100),
FechaNacimiento date,
Sexo varchar(50),
Ciudad varchar(100),
Direccion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate()
)
go
--(7) TABLA DOCENTE
create table DOCENTE(
IdDocente int primary key identity(1,1),
ValorCodigo int,
Codigo varchar(50),
DocumentoIdentidad varchar(100),
Nombres varchar(100),
Apellidos varchar(100),
FechaNacimiento date,
Sexo varchar(50),
GradoEstudio varchar(100),
Ciudad varchar(100),
Direccion varchar(100),
Email varchar(50),
NumeroTelefono varchar(50),
Activo bit default 1,
FechaRegistro datetime default getdate()
)
go
--(8) TABLA APODERADO
create table APODERADO(
IdApoderado int primary key identity(1,1),
TipoRelacion varchar(50),
Nombres varchar(100),
Apellidos varchar(100),
DocumentoIdentidad varchar(100),
FechaNacimiento date,
Sexo varchar(50),
EstadoCivil varchar(50),
Ciudad varchar(100),
Direccion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate()
)
go
--(9) TABLA PERIODO
create table PERIODO(
IdPeriodo int primary key identity(1,1),
Descripcion varchar(50),
FechaInicio date,
FechaFin Date,
Activo bit default 1,
FechaRegistro datetime default getdate()
)
go
--(10) TABLA GRADO_SECCION
create table GRADO_SECCION(
IdGradoSeccion int primary key identity(1,1),
DescripcionGrado varchar(100),
DescripcionSeccion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate()
)

go
--(11) TABLA CURSO
create table CURSO(
IdCurso int primary key identity(1,1),
Descripcion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate()
)

go
--(12) TABLA NIVEL
create table NIVEL(
IdNivel int primary key identity(1,1),
IdPeriodo int references PERIODO(IdPeriodo),
DescripcionNivel varchar(100),
DescripcionTurno varchar(100),
HoraInicio time,
HoraFin time,
Activo bit default 1,
FechaRegistro datetime default getdate()
)

go

--(13) TABLA NIVEL_DETALLE
create table NIVEL_DETALLE(
IdNivelDetalle int primary key identity(1,1),
IdNivel int references NIVEL(IdNivel),
IdGradoSeccion int references GRADO_SECCION(IdGradoSeccion),
TotalVacantes int,
VacantesDisponibles int,
VacantesOcupadas int,
Activo bit default 1,
FechaRegistro datetime default getdate()
)

go

--(14) TABLA NIVEL_DETALLE_CURSO
create table NIVEL_DETALLE_CURSO(
IdNivelDetalleCurso int primary key identity(1,1),
IdNivelDetalle int references NIVEL_DETALLE(IdNivelDetalle),
IdCurso int references CURSO(IdCurso),
Activo bit default 1,
FechaRegistro datetime default getdate()
)
go

--(15) TABLA HORARIO
create table HORARIO(
IdHorario int primary key identity(1,1),
IdNivelDetalleCurso int references NIVEL_DETALLE_CURSO(IdNivelDetalleCurso),
DiaSemana varchar(50),
HoraInicio time,
HoraFin time,
Activo bit default 1,
FechaRegistro datetime default getdate()
)

go

--(16) TABLA DOCENTE_NIVELDETALLE_CURSO
create table DOCENTE_NIVELDETALLE_CURSO(
IdDocenteNivelDetalleCurso int primary key identity(1,1),
IdNivelDetalleCurso int references NIVEL_DETALLE_CURSO(IdNivelDetalleCurso),
IdDocente int references DOCENTE(IdDocente),
Activo bit default 1,
FechaRegistro datetime default getdate()
)

go

--(17) TABLA CURRICULA
create table CURRICULA(
IdCurricula int primary key identity(1,1),
IdDocenteNivelDetalleCurso int references DOCENTE_NIVELDETALLE_CURSO(IdDocenteNivelDetalleCurso),
Descripcion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate()
)
go
--(18) TABLA CALIFICACION
create table CALIFICACION(
IdCalificacion int primary key identity(1,1),
IdCurricula int references CURRICULA(IdCurricula),
IdAlumno int references ALUMNO(IdAlumno),
Nota float,
Activo bit default 1,
FechaRegistro datetime default getdate()
)

go

--(19) TABLA MATRICULA
create table MATRICULA(
IdMatricula int primary key identity(1,1),
ValorCodigo int,
Codigo varchar(50),
Situacion varchar(50),
IdAlumno int references ALUMNO(IdAlumno),
IdNivelDetalle int references NIVEL_DETALLE(IdNivelDetalle),
IdApoderado int references APODERADO(IdApoderado),
InstitucionProcedencia varchar(50),
EsRepitente bit,
Activo bit default 1,
FechaRegistro datetime default getdate()
)