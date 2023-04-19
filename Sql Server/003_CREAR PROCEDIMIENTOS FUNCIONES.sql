go
use BDCOLEGIOWEB
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ObtenerRoles')
DROP PROCEDURE usp_ObtenerRoles
go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarRol')
DROP PROCEDURE usp_RegistrarRol
go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ModificarRol')
DROP PROCEDURE usp_ModificarRol
go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EliminarRol')
DROP PROCEDURE usp_EliminarRol
go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ObtenerPermisos')
DROP PROCEDURE usp_ObtenerPermisos

GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ActualizarPermisos')
DROP PROCEDURE usp_ActualizarPermisos

GO
----------
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_LoginUsuario')
DROP PROCEDURE usp_LoginUsuario
go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ObtenerDetalleUsuario')
DROP PROCEDURE usp_ObtenerDetalleUsuario
go


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ListarAlumno')
DROP PROCEDURE usp_ListarAlumno

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarAlumno')
DROP PROCEDURE usp_RegistrarAlumno

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EditarAlumno')
DROP PROCEDURE usp_EditarAlumno

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EliminarAlumno')
DROP PROCEDURE usp_EliminarAlumno

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ListarPeriodo')
DROP PROCEDURE usp_ListarPeriodo

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarPeriodo')
DROP PROCEDURE usp_RegistrarPeriodo

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EditarPeriodo')
DROP PROCEDURE usp_EditarPeriodo

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EliminarPeriodo')
DROP PROCEDURE usp_EliminarPeriodo

go
--
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ListarNivel')
DROP PROCEDURE usp_ListarNivel

go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarNivel')
DROP PROCEDURE usp_RegistrarNivel

go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EditarNivel')
DROP PROCEDURE usp_EditarNivel

go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EliminarNivel')
DROP PROCEDURE usp_EliminarNivel

go
---
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ListarGradoSeccion')
DROP PROCEDURE usp_ListarGradoSeccion

go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarGradoSeccion')
DROP PROCEDURE usp_RegistrarGradoSeccion

go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EditarGradoSeccion')
DROP PROCEDURE usp_EditarGradoSeccion

go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EliminarGradoSeccion')
DROP PROCEDURE usp_EliminarGradoSeccion

go
--
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ListarNivelDetalle')
DROP PROCEDURE usp_ListarNivelDetalle

go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarNivelDetalle')
DROP PROCEDURE usp_RegistrarNivelDetalle

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarVacantes')
DROP PROCEDURE usp_RegistrarVacantes

go
---
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ListarCurso')
DROP PROCEDURE usp_ListarCurso

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarCurso')
DROP PROCEDURE usp_RegistrarCurso

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EditarCurso')
DROP PROCEDURE usp_EditarCurso

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EliminarCurso')
DROP PROCEDURE usp_EliminarCurso

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_AsginarCursos')
DROP PROCEDURE usp_AsginarCursos

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ListarCursosAsignados')
DROP PROCEDURE usp_ListarCursosAsignados

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ListarHorario')
DROP PROCEDURE usp_ListarHorario

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarHorario')
DROP PROCEDURE usp_RegistrarHorario

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EliminarHorario')
DROP PROCEDURE usp_EliminarHorario

go

---
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ListarDocente')
DROP PROCEDURE usp_ListarDocente

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarDocente')
DROP PROCEDURE usp_RegistrarDocente

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EditarDocente')
DROP PROCEDURE usp_EditarDocente

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EliminarDocente')
DROP PROCEDURE usp_EliminarDocente

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarDocenteCurso')
DROP PROCEDURE usp_RegistrarDocenteCurso

go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ListarDocenteCurso')
DROP PROCEDURE usp_ListarDocenteCurso

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EliminarDocenteCurso')
DROP PROCEDURE usp_EliminarDocenteCurso

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_DetalleDocenteCurso')
DROP PROCEDURE usp_DetalleDocenteCurso

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarCurricula')
DROP PROCEDURE usp_RegistrarCurricula

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ObtenerCurricula')
DROP PROCEDURE usp_ObtenerCurricula

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EliminarCurricula')
DROP PROCEDURE usp_EliminarCurricula

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarMatricula')
DROP PROCEDURE usp_RegistrarMatricula

go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ObtenerMatricula')
DROP PROCEDURE usp_ObtenerMatricula

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ObtenerClalificacion')
DROP PROCEDURE usp_ObtenerClalificacion

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarCalificacion')
DROP PROCEDURE usp_RegistrarCalificacion

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ReporteAlumno')
DROP PROCEDURE usp_ReporteAlumno

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ReporteMatricula')
DROP PROCEDURE usp_ReporteMatricula

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_RegistrarUsuario')
DROP PROCEDURE usp_RegistrarUsuario

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ModificarUsuario')
DROP PROCEDURE usp_ModificarUsuario

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_EliminarUsuario')
DROP PROCEDURE usp_EliminarUsuario

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_ObtenerUsuario')
DROP PROCEDURE usp_ObtenerUsuario

go


--PROCEDMIENTO PARA OBTENER ROLES
CREATE PROC usp_ObtenerRoles
as
begin
 select IdRol, Descripcion,Activo from ROL
end

go

--PROCEDIMIENTO PARA GUARDAR ROL
CREATE PROC usp_RegistrarRol(
@Descripcion varchar(50),
@Resultado bit output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM ROL WHERE Descripcion = @Descripcion)
	begin
		declare @idrol int = 0
		insert into ROL(Descripcion) values (
		@Descripcion
		)
		set @idrol  = Scope_identity()

		insert into PERMISOS(IdRol,IdSubMenu,Activo)
		select @idrol, IdSubMenu,0 from SUBMENU
	end
	ELSE
		SET @Resultado = 0
	
end


go

--PROCEDIMIENTO PARA MODIFICAR ROLES
create procedure usp_ModificarRol(
@IdRol int,
@Descripcion varchar(60),
@Activo bit,
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM ROL WHERE Descripcion =@Descripcion and IdRol != @IdRol)
		
		update ROL set 
		Descripcion = @Descripcion,
		Activo = @Activo
		where IdRol = @IdRol
	ELSE
		SET @Resultado = 0

end

go

--PROCEDIMIENTO PARA ELIMINAR ROL
create procedure usp_EliminarRol(
@IdRol int,
@Resultado bit output
)
as
begin
	SET @Resultado = 1

	--validamos que el rol no se encuentre asignado a algun usuario
	IF not EXISTS (select * from USUARIO u
	inner join ROL r on r.IdRol  = u.IdRol
	where r.IdRol = @IdRol)
	begin	
		delete from PERMISOS where IdRol = @IdRol
		delete from ROL where IdRol = @IdRol
	end
	ELSE
		SET @Resultado = 0

end
go


--PROCEDMIENTO PARA OBTENER PERMISOS
create procedure usp_ObtenerPermisos(
@IdRol int)
as
begin
select p.IdPermisos,m.Nombre[Menu],sm.Nombre[SubMenu],p.Activo from PERMISOS p
inner join SUBMENU sm on sm.IdSubMenu = p.IdSubMenu
inner join MENU m on m.IdMenu = sm.IdMenu
where p.IdRol = @IdRol
end

go

--PROCEDIMIENTO PARA ACTUALIZAR PERMISOS
create procedure usp_ActualizarPermisos(
@Detalle xml,
@Resultado bit output
)
as
begin
begin try

	BEGIN TRANSACTION
	declare @permisos table(idpermisos int,activo bit)

	insert into @permisos(idpermisos,activo)
	select 
	idpermisos = Node.Data.value('(IdPermisos)[1]','int'),
	activo = Node.Data.value('(Activo)[1]','bit')
	FROM @Detalle.nodes('/DETALLE/PERMISO') Node(Data)

	select * from @permisos

	update p set p.Activo = pe.activo from PERMISOS p
	inner join @permisos pe on pe.idpermisos = p.IdPermisos

	COMMIT
	set @Resultado = 1

end try
begin catch
	ROLLBACK
	set @Resultado = 0
end catch
end

go

--PROCEDMIENTO PARA OBTENER USUARIOS
CREATE PROC usp_ObtenerUsuario
as
begin
 select u.IdUsuario,u.Nombres,u.Apellidos,u.LoginUsuario,u.LoginClave,u.IdRol,u.Activo,u.DescripcionReferencia,r.Descripcion[DescripcionRol],u.Activo from USUARIO u
 inner join ROL r on r.IdRol = u.IdRol
end

go

--PROCEDMIENTO PARA OBTENER USUARIO

create procedure usp_LoginUsuario(
@Usuario varchar(60),
@Clave varchar(60),
@IdUsuario int output
)
as
begin
	set @IdUsuario = 0
	if exists(select * from USUARIO where [LoginUsuario] COLLATE Latin1_General_CS_AS = @Usuario and LoginClave COLLATE Latin1_General_CS_AS = @Clave and Activo = 1)
		set @IdUsuario = (select top 1 IdUsuario from USUARIO where [LoginUsuario]  COLLATE Latin1_General_CS_AS = @Usuario and LoginClave COLLATE Latin1_General_CS_AS = @Clave and Activo = 1)
end

go

--PROCEDIMIENTO PARA REGISTRAR USUARIO
CREATE PROC usp_RegistrarUsuario(
@Nombres varchar(50),
@Apellidos varchar(50),
@IdRol int,
@Usuario varchar(50),
@Clave varchar(50),
@DescripcionReferencia varchar(50),
@IdReferencia int,
@Resultado bit output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM USUARIO WHERE LoginUsuario = @Usuario)

		insert into USUARIO(Nombres,Apellidos,IdRol,LoginUsuario,LoginClave,DescripcionReferencia,IdReferencia) values (
		@Nombres,@Apellidos,@IdRol,@Usuario,@Clave,@DescripcionReferencia,@IdReferencia)
	ELSE
		SET @Resultado = 0
	
end
go

--PROCEDIMIENTO PARA MODIFICAR USUARIO
create procedure usp_ModificarUsuario(
@IdUsuario int,
@Nombres varchar(50),
@Apellidos varchar(50),
@IdRol int,
@Usuario varchar(50),
@Clave varchar(50),
@DescripcionReferencia varchar(50),
@IdReferencia int,
@Activo bit,
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM USUARIO WHERE LoginUsuario = @Usuario and IdUsuario != @IdUsuario)
		
		update USUARIO set 
		Nombres = @Nombres,
		Apellidos = @Apellidos,
		IdRol = @IdRol,
		LoginUsuario = @Usuario,
		LoginClave = @Clave,
		DescripcionReferencia = @DescripcionReferencia,
		IdReferencia = @IdReferencia,
		Activo = @Activo
		where IdUsuario = @IdUsuario

	ELSE
		SET @Resultado = 0

end

go

--PROCEDIMIENTO PARA ELIMINAR USUARIO
create procedure usp_EliminarUsuario(
@IdUsuario int,
@Resultado bit output
)
as
begin

	delete from USUARIO where IdUsuario = @IdUsuario
	SET @Resultado = 1
end

go

--PROCEDMIENTO PARA OBTENER DETALLE USUARIO
create proc usp_ObtenerDetalleUsuario(
@IdUsuario int
)
as
begin
 select *,
(select * from ROL r
 where r.IdRol = up.IdRol
FOR XML PATH (''),TYPE) AS 'DetalleRol'
,
 (
 select t.NombreMenu,t.Icono,
 (select sm.Nombre[NombreSubMenu],sm.NombreFormulario,sm.Accion,p.Activo
	 from PERMISOS p
	 inner join ROL r on r.IdRol = p.IdRol
	 inner join SUBMENU sm on sm.IdSubMenu = p.IdSubMenu
	 inner join MENU m on m.IdMenu = sm.IdMenu
	 inner join USUARIO u on u.IdRol = r.IdRol and u.IdUsuario = up.IdUsuario
	where sm.IdMenu = t.IdMenu
  FOR XML PATH ('SubMenu'),TYPE) AS 'DetalleSubMenu' 

 from (
 select distinct m.Nombre[NombreMenu],m.IdMenu,m.Icono
 from PERMISOS p
 inner join ROL r on r.IdRol = p.IdRol
 inner join SUBMENU sm on sm.IdSubMenu = p.IdSubMenu
 inner join MENU m on m.IdMenu = sm.IdMenu
 inner join USUARIO u on u.IdRol = r.IdRol and u.IdUsuario = up.IdUsuario
 where p.Activo = 1) t
 FOR XML PATH ('Menu'),TYPE) AS 'DetalleMenu'  
 from USUARIO up
 where UP.IdUsuario = @IdUsuario
 FOR XML PATH(''), ROOT('Usuario')  

end

GO


--PROCEDMIENTO PARA OBTENER USUARIOS
CREATE PROC usp_ListarAlumno
as
begin
 select IdAlumno,Codigo,Nombres,Apellidos,DocumentoIdentidad,FechaNacimiento,Sexo,Ciudad,Direccion,Activo from ALUMNO
end

go

-- REGISTRAR ALUMNO
CREATE PROC usp_RegistrarAlumno(
@Nombres varchar(100),
@Apellidos varchar(100),
@DocumentoIdentidad varchar(100),
@FechaNacimiento date,
@Sexo varchar(50),
@Ciudad varchar(100),
@Direccion varchar(100),
@Resultado bit output
)as
begin
	SET DATEFORMAT dmy;
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM ALUMNO WHERE DocumentoIdentidad = @DocumentoIdentidad and Nombres like '%' + @Nombres +'%' and Apellidos like '%' + @Apellidos +'%')
		insert into ALUMNO(ValorCodigo,Codigo,Nombres,Apellidos,DocumentoIdentidad,FechaNacimiento,Sexo,Ciudad,Direccion) values (
		(select isnull(max(ValorCodigo),0) + 1 from ALUMNO),
		'AL' + RIGHT('000000' + convert(varchar(max),(select isnull(max(ValorCodigo),0) + 1 from ALUMNO)),6),
		@Nombres,
		@Apellidos,
		@DocumentoIdentidad,
		@FechaNacimiento,
		@Sexo,
		@Ciudad,
		@Direccion
		)
	ELSE
		SET @Resultado = 0
	
end

go

-- REGISTRAR ALUMNO
CREATE PROC usp_EditarAlumno(
@IdAlumno int,
@Codigo varchar(50),
@Nombres varchar(100),
@Apellidos varchar(100),
@DocumentoIdentidad varchar(100),
@FechaNacimiento date,
@Sexo varchar(50),
@Ciudad varchar(100),
@Direccion varchar(100),
@Activo bit,
@Resultado bit output
)as
begin
	SET DATEFORMAT dmy;
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM ALUMNO WHERE DocumentoIdentidad = @DocumentoIdentidad and Nombres like '%' + @Nombres +'%' and Apellidos like '%' + @Apellidos +'%' and Codigo != @Codigo)
		update ALUMNO SET
		Nombres = @Nombres,
		Apellidos = @Apellidos,
		DocumentoIdentidad = @DocumentoIdentidad,
		FechaNacimiento = @FechaNacimiento,
		Sexo = @Sexo,
		Ciudad = @Ciudad,
		Direccion = @Direccion,
		Activo = @Activo
		where IdAlumno = @IdAlumno

	ELSE
		SET @Resultado = 0
	
end

GO
--ELIMINAR ALUMNO
create procedure usp_EliminarAlumno(
@IdAlumno int,
@Resultado bit output
)
as
begin
	SET @Resultado = 1

	--validamos que ningun usuario se encuentre relacionado a una tienda
	IF (not EXISTS (select * from MATRICULA m 
		inner join ALUMNO a on a.IdAlumno = m.IdAlumno
		where a.IdAlumno = @IdAlumno
		) 
	)
		delete from ALUMNO where IdAlumno = @IdAlumno
	ELSE
		SET @Resultado = 0

end


go

--PROCEDMIENTO PERIODO
CREATE PROC usp_ListarPeriodo
as
begin
 select IdPeriodo, Descripcion,FechaInicio,FechaFin,Activo from PERIODO
end

go

-- REGISTRAR PERIODO
CREATE PROC usp_RegistrarPeriodo(
@Descripcion varchar(50),
@FechaInicio date,
@FechaFin Date,
@Resultado bit output
)as
begin
	SET DATEFORMAT dmy;
	SET @Resultado = 1

	IF NOT EXISTS (SELECT * FROM PERIODO WHERE Activo = 1)
		INSERT INTO PERIODO(Descripcion,FechaInicio,FechaFin)
		values(
			@Descripcion,
			@FechaInicio,
			@FechaFin
		)
	ELSE
		SET @Resultado = 0
	
end

go


-- EDITAR PERIODO
CREATE PROC usp_EditarPeriodo(
@IdPeriodo int,
@Descripcion varchar(50),
@FechaInicio date,
@FechaFin Date,
@Activo bit,
@Resultado bit output
)as
begin
	SET DATEFORMAT dmy;
	SET @Resultado = 1

	IF(@Activo = 1)
		IF NOT EXISTS (SELECT * FROM PERIODO where IdPeriodo != @IdPeriodo and Activo = 1 )
			update PERIODO SET
			Descripcion = @Descripcion,
			FechaInicio = @FechaInicio,
			FechaFin = @FechaFin,
			Activo = @Activo
			where IdPeriodo = @IdPeriodo
		ELSE
			SET @Resultado = 0
	else
		update PERIODO SET
			Descripcion = @Descripcion,
			FechaInicio = @FechaInicio,
			FechaFin = @FechaFin,
			Activo = @Activo
			where IdPeriodo = @IdPeriodo
	
end

go

--ELIMINAR PERIODO
create procedure usp_EliminarPeriodo(
@IdPeriodo int,
@Resultado bit output
)
as
begin
	SET @Resultado = 1

	--validamos que ningun usuario se encuentre relacionado a una tienda
	IF (not EXISTS (select * from NIVEL n 
		inner join PERIODO p on p.IdPeriodo = n.IdPeriodo
		where p.IdPeriodo = @IdPeriodo
		) 
	)
		delete from PERIODO where IdPeriodo = @IdPeriodo
	ELSE
		SET @Resultado = 0

end


GO

--PROCEDMIENTO NIVEL
CREATE PROC usp_ListarNivel
as
begin
 select n.IdNivel,n.IdPeriodo,p.Descripcion[DescripcionPeriodo],n.DescripcionNivel,n.DescripcionTurno,n.HoraInicio,n.HoraFin,n.Activo from NIVEL n
 inner join PERIODO p on n.IdPeriodo = p.IdPeriodo
 
end

go

-- REGISTRAR NIVEL
CREATE PROC usp_RegistrarNivel(
@IdPeriodo int,
@DescripcionNivel varchar(100),
@DescripcionTurno varchar(100),
@HoraInicio time,
@HoraFin time,
@Resultado bit output
)as
begin
	SET DATEFORMAT dmy;
	SET @Resultado = 1

	IF NOT EXISTS (SELECT * FROM NIVEL WHERE DescripcionNivel like '%' + @DescripcionNivel +'%' and DescripcionTurno like '%' + @DescripcionTurno +'%' and IdPeriodo = @IdPeriodo )
		INSERT INTO NIVEL(IdPeriodo,DescripcionNivel,DescripcionTurno,HoraInicio,HoraFin)
		values(
			@IdPeriodo,
			@DescripcionNivel,
			@DescripcionTurno,
			@HoraInicio,
			@HoraFin
		)
	ELSE
		SET @Resultado = 0
	
end

go

-- EDITAR NIVEL
CREATE PROC usp_EditarNivel(
@IdNivel int ,
@IdPeriodo int ,
@DescripcionNivel varchar(100),
@DescripcionTurno varchar(100),
@HoraInicio time,
@HoraFin time,
@Activo bit,
@Resultado bit output
)as
begin
	SET DATEFORMAT dmy;
	SET @Resultado = 1


	IF NOT EXISTS (SELECT * FROM NIVEL WHERE DescripcionNivel like '%' + @DescripcionNivel +'%' and DescripcionTurno like '%' + @DescripcionTurno +'%' and IdPeriodo = @IdPeriodo and IdNivel !=@IdNivel )
		update NIVEL SET
		IdPeriodo = @IdPeriodo,
		DescripcionNivel = @DescripcionNivel,
		DescripcionTurno = @DescripcionTurno,
		HoraInicio = @HoraInicio,
		HoraFin = @HoraFin,
		Activo = @Activo
		where IdNivel = @IdNivel
	ELSE
		SET @Resultado = 0

	
end


go

--ELIMINAR NIVEL
create procedure usp_EliminarNivel(
@IdNivel int,
@Resultado bit output
)
as
begin
	SET @Resultado = 1

	--validamos que ningun usuario se encuentre relacionado a una tienda
	IF (not EXISTS (select * from NIVEL n 
		inner join NIVEL_DETALLE p on p.IdNivel = n.IdNivel
		where n.IdNivel = @IdNivel
		) 
	)
		delete from NIVEL where IdNivel = @IdNivel
	ELSE
		SET @Resultado = 0

end

GO

--PROCEDMIENTO GRADOSECCION
CREATE PROC usp_ListarGradoSeccion
as
begin
 SELECT IdGradoSeccion,DescripcionGrado,DescripcionSeccion,Activo FROM GRADO_SECCION
end

go

-- REGISTRAR GRADOSECCION
CREATE PROC usp_RegistrarGradoSeccion(
@DescripcionGrado varchar(100),
@DescripcionSeccion varchar(100),
@Resultado bit output
)as
begin
	SET DATEFORMAT dmy;
	SET @Resultado = 1

	IF NOT EXISTS (SELECT * FROM GRADO_SECCION WHERE DescripcionGrado like '%' + @DescripcionGrado +'%' and DescripcionSeccion like '%' + @DescripcionSeccion +'%')
		INSERT INTO GRADO_SECCION(DescripcionGrado,DescripcionSeccion)
		values(
			@DescripcionGrado,
			@DescripcionSeccion
		)
	ELSE
		SET @Resultado = 0
	
end
go
-- EDITAR GRADOSECCION
CREATE PROC usp_EditarGradoSeccion(
@IdGradoSeccion int ,
@DescripcionGrado varchar(100),
@DescripcionSeccion varchar(100),
@Activo bit,
@Resultado bit output
)as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM GRADO_SECCION WHERE DescripcionGrado like '%' + @DescripcionGrado +'%' and DescripcionSeccion like '%' + @DescripcionSeccion +'%' and IdGradoSeccion !=@IdGradoSeccion )
		update GRADO_SECCION SET
		DescripcionGrado = @DescripcionGrado,
		DescripcionSeccion = @DescripcionSeccion,
		Activo = @Activo
		where IdGradoSeccion = @IdGradoSeccion
	ELSE
		SET @Resultado = 0
end
go
--ELIMINAR GRADOSECCION
create procedure usp_EliminarGradoSeccion(
@IdGradoSeccion int,
@Resultado bit output
)
as
begin
	SET @Resultado = 1

	--validamos que ningun usuario se encuentre relacionado a una tienda
	IF (not EXISTS (select * from GRADO_SECCION n 
		inner join NIVEL_DETALLE p on p.IdGradoSeccion = n.IdGradoSeccion
		where n.IdGradoSeccion = @IdGradoSeccion
		) 
	)
		delete from GRADO_SECCION where IdGradoSeccion = @IdGradoSeccion
	ELSE
		SET @Resultado = 0

end

go

--LISTAR NIVELDETALLE
CREATE PROC usp_ListarNivelDetalle
as
begin
 --SELECT IdNivelDetalle, IdNivel,IdGradoSeccion,TotalVacantes,VacantesDisponibles,VacantesOcupadas,Activo FROM NIVEL_DETALLE

 select nd.IdNivelDetalle,n.IdNivel,n.DescripcionNivel,n.DescripcionTurno,gs.IdGradoSeccion,gs.DescripcionGrado,gs.DescripcionSeccion,nd.TotalVacantes,nd.VacantesDisponibles,nd.VacantesOcupadas,nd.Activo from NIVEL_DETALLE nd
	  inner join NIVEL n on n.IdNivel = nd.IdNivel
	  inner join GRADO_SECCION gs on gs.IdGradoSeccion = nd.IdGradoSeccion
end

go

--REGITRAR NIVELDETALLE
create procedure usp_RegistrarNivelDetalle(
@xml xml,
@Resultado bit output
)
as
begin
begin try

	BEGIN TRANSACTION
		declare @nivel table(idnivel int)
		declare @gradoseccion table(idgradoseccion int)	
		declare @nivelgradoseccion table(idnivel int,idgradoseccion int,totalvacantes int, vacantesdisponibles int,vacantesocupadas int)


		insert into @nivel(idnivel)
		select 
		IdNivel = Node.Data.value('(IdNivel)[1]','int')
		FROM @xml.nodes('/DETALLE/DATA') Node(Data)

		insert into @gradoseccion(idgradoseccion)
		select 
		IdGradoSeccion = Node.Data.value('(IdGradoSeccion)[1]','int')
		FROM @xml.nodes('/DETALLE/GRADOSECCION/DATA') Node(Data)

		if not exists(select * from NIVEL_DETALLE nd
		inner join NIVEL_DETALLE_CURSO ndc on ndc.IdNivelDetalle = nd.IdNivelDetalle
		where nd.IdNivel = (select idnivel from @nivel))
		begin

			insert into @nivelgradoseccion(idnivel,idgradoseccion,totalvacantes,vacantesdisponibles,vacantesocupadas)
			SELECT (select idnivel from @nivel), idgradoseccion,0,0,0 FROM @gradoseccion

			update ngs set 
			ngs.totalvacantes = nd.TotalVacantes, 
			ngs.vacantesdisponibles = nd.VacantesDisponibles,
			ngs.vacantesocupadas = nd.VacantesOcupadas 
			from @nivelgradoseccion ngs
			inner join NIVEL_DETALLE nd on nd.IdNivel = ngs.idnivel and nd.IdGradoSeccion = ngs.idgradoseccion


			delete from NIVEL_DETALLE where IdNivel = (select idnivel from @nivel)
			set @Resultado = 1
		end
		else
			set @Resultado = 0

		if(@Resultado = 1)
		begin
			insert into NIVEL_DETALLE(IdNivel,IdGradoSeccion,TotalVacantes,VacantesOcupadas,VacantesDisponibles)
			SELECT (select idnivel from @nivel), idgradoseccion,0,0,0 FROM @gradoseccion
		

			update nd set 
			nd.TotalVacantes = ngs.TotalVacantes,
			nd.VacantesDisponibles = nd.TotalVacantes - ngs.VacantesOcupadas
			from NIVEL_DETALLE nd
			inner join @nivelgradoseccion ngs on nd.IdNivel = ngs.idnivel and nd.IdGradoSeccion = ngs.idgradoseccion
		end
		


	COMMIT
	

 end try
 begin catch
	ROLLBACK
	set @Resultado = 0
 end catch
end


go


--REGITRAR VACANTES
create procedure usp_RegistrarVacantes(
@xml xml,
@Resultado bit output
)
as
begin
begin try

	BEGIN TRANSACTION
		declare @detalle table(idniveldetalle int,totalvacantes int)	

		insert into @detalle(idniveldetalle,totalvacantes)
		select 
		idniveldetalle = Node.Data.value('(IdNivelDetalle)[1]','int'),
		totalvacantes = Node.Data.value('(TotalVacantes)[1]','int')
		FROM @xml.nodes('/DETALLE/DATA') Node(Data)


		update nd set nd.TotalVacantes = d.totalvacantes , nd.VacantesDisponibles = d.totalvacantes - nd.VacantesOcupadas from NIVEL_DETALLE nd
		inner join @detalle d on d.idniveldetalle = nd.IdNivelDetalle

		set @Resultado = 1

	COMMIT

 end try
 begin catch
	ROLLBACK
	set @Resultado = 0
 end catch
end

go

--LISTAR CURSO
CREATE PROC usp_ListarCurso
as
begin
 select IdCurso,Descripcion,Activo from CURSO
end

go

-- REGISTRAR CURSO
CREATE PROC usp_RegistrarCurso(
@Descripcion varchar(50),
@Resultado bit output
)as
begin
	SET DATEFORMAT dmy;
	SET @Resultado = 1

	IF NOT EXISTS (SELECT * FROM CURSO WHERE Descripcion = @Descripcion )
		INSERT INTO CURSO(Descripcion)
		values(
			@Descripcion
		)
	ELSE
		SET @Resultado = 0
	
end

go

-- EDITAR CURSO
CREATE PROC usp_EditarCurso(
@IdCurso int,
@Descripcion varchar(50),
@Activo bit,
@Resultado bit output
)as
begin
	SET DATEFORMAT dmy;
	SET @Resultado = 1

	IF NOT EXISTS (SELECT * FROM CURSO WHERE Descripcion = @Descripcion and IdCurso != @IdCurso )
		update CURSO SET
		Descripcion = @Descripcion,
		Activo = @Activo
		where IdCurso = @IdCurso
	ELSE
		SET @Resultado = 0
	
end

go


--ELIMINAR NIVEL
create procedure usp_EliminarCurso(
@IdCurso int,
@Resultado bit output
)
as
begin
	SET @Resultado = 1

	--validamos que ningun usuario se encuentre relacionado a una tienda
	IF (not EXISTS (select * from CURSO c 
		inner join NIVEL_DETALLE_CURSO ndc on ndc.IdCurso = c.IdCurso
		where c.IdCurso = @IdCurso
		) 
	)
		delete from CURSO where IdCurso = @IdCurso
	ELSE
		SET @Resultado = 0

end


go

------

--REGITRAR ASIGNAMIENTO DE CURSOS
create procedure usp_AsginarCursos(
@xml xml,
@Resultado bit output
)
as
begin
begin try

	BEGIN TRANSACTION
		declare @nivel table(idnivel int)
		declare @gradoseccion table(idgradoseccion int)
		declare @curso table (idcurso int)
		declare @idniveldetalle int = 0;

		declare @horario table(idnivel int,idgradoseccion int,idcurso int, diasemana varchar(100), horainicio time,horafin time)


		insert into @nivel(idnivel)
		select 
		IdNivel = Node.Data.value('(IdNivel)[1]','int')
		FROM @xml.nodes('/DETALLE/NIVEL') Node(Data)

		insert into @gradoseccion(idgradoseccion)
		select 
		IdGradoSeccion = Node.Data.value('(IdGradoSeccion)[1]','int')
		FROM @xml.nodes('/DETALLE/GRADOSECCION') Node(Data)

		insert into @curso(idcurso)
		select 
		IdCurso = Node.Data.value('(IdCurso)[1]','int')
		FROM @xml.nodes('/DETALLE/CURSOS/DATA') Node(Data)



		if not exists(select * from NIVEL_DETALLE_CURSO ndc
		inner join HORARIO h on h.IdNivelDetalleCurso = ndc.IdNivelDetalleCurso
		inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = ndc.IdNivelDetalle
		where nd.IdNivel = (select idnivel from @nivel) and nd.IdGradoSeccion = (select idgradoseccion from @gradoseccion))
		begin

			/*insert into @horario(idnivel,idgradoseccion,idcurso,diasemana,horainicio,horafin)
			SELECT (select idnivel from @nivel),(select idgradoseccion from @gradoseccion),idcurso, '',convert(time, getdate()),convert(time, getdate()) FROM @curso

			update ht set
			ht.diasemana = h.DiaSemana,
			ht.horainicio = h.HoraInicio,
			ht.horafin = h.HoraFin
			
			from 
			@horario ht
			inner join NIVEL_DETALLE nd on nd.IdNivel = ht.idnivel and nd.IdGradoSeccion = ht.idgradoseccion
			inner join NIVEL_DETALLE_CURSO ndc on ndc.IdNivelDetalle = nd.IdNivelDetalle and ndc.IdCurso = ht.idcurso
			inner join HORARIO h on h.IdNivelDetalleCurso = ndc.IdNivelDetalleCurso*/


			set @idniveldetalle = (select top 1 IdNivelDetalle from NIVEL_DETALLE where IdNivel = (select idnivel from @nivel) and IdGradoSeccion = (select idgradoseccion from @gradoseccion))

			delete from NIVEL_DETALLE_CURSO where IdNivelDetalle =  @idniveldetalle
			set @Resultado = 1
		end
		else
			set @Resultado = 0

		if(@Resultado = 1)
		begin
			insert into NIVEL_DETALLE_CURSO(IdNivelDetalle,IdCurso)
			SELECT @idniveldetalle, idcurso FROM @curso
		

		end
		
	COMMIT
	
 end try
 begin catch
	ROLLBACK
	set @Resultado = 0
 end catch
end


go


--LISTAR CURSOS ASIGNADOS
CREATE PROC usp_ListarCursosAsignados
as
begin
SELECT 
NDC.IdNivelDetalleCurso,

nd.IdNivelDetalle,

n.IdNivel, n.DescripcionNivel, n.DescripcionTurno,n.HoraInicio,n.HoraFin,

gs.IdGradoSeccion, gs.DescripcionGrado,gs.DescripcionSeccion,

C.IdCurso, C.Descripcion, C.Activo[CursoActivo]


FROM NIVEL_DETALLE_CURSO NDC
INNER JOIN NIVEL_DETALLE ND ON ND.IdNivelDetalle = NDC.IdNivelDetalle
INNER JOIN NIVEL N ON N.IdNivel = ND.IdNivel
INNER JOIN GRADO_SECCION GS ON GS.IdGradoSeccion = ND.IdGradoSeccion
INNER JOIN CURSO C ON C.IdCurso = NDC.IdCurso

end


go

--LISTAR HORARIO

 CREATE PROC usp_ListarHorario
as
begin

select h.IdHorario,ndc.IdCurso,nd.IdNivel,nd.IdGradoSeccion, h.DiaSemana,c.Descripcion[NombreCurso] ,h.HoraInicio,h.HoraFin,h.Activo from horario h
 inner join NIVEL_DETALLE_CURSO ndc on ndc.IdNivelDetalleCurso = h.IdNivelDetalleCurso
 inner join CURSO c on c.IdCurso = ndc.IdCurso
 inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = ndc.IdNivelDetalle

end

go

--REGISTRAR HORARIO
CREATE PROC usp_RegistrarHorario(
@IdNivel int,
@IdGradoSeccion int,
@IdCurso int,
@DiaSemana varchar(100),
@HoraInicio datetime,
@HoraFin datetime,
@Resultado bit output
)
as
begin
	declare @idniveldetallecurso int = 0
	declare @idhorario int = 0

	set @idniveldetallecurso = (select top 1 ndc.IdNivelDetalleCurso from NIVEL_DETALLE_CURSO ndc
	inner join NIVEL_DETALLE nd on ndc.IdNivelDetalle = ndc.IdNivelDetalle
	where nd.IdNivel = @IdNivel and nd.IdGradoSeccion = @IdGradoSeccion and ndc.IdCurso = @IdCurso)

	if(@idniveldetallecurso = 0)
		set @Resultado = 0
	else
	begin
		
		set @idhorario = (select top 1 IdHorario from HORARIO where IdNivelDetalleCurso = @idniveldetallecurso)

		if(@idhorario = 0 or @idhorario is null)
			insert into HORARIO(IdNivelDetalleCurso,DiaSemana,HoraInicio,HoraFin) values
			(@idniveldetallecurso,@DiaSemana,@HoraInicio,@HoraFin)
		else
			update HORARIO set
			DiaSemana = @DiaSemana,
			HoraInicio = @HoraInicio,
			HoraFin = @HoraFin
			where IdHorario = @idhorario

		set @Resultado = 1
	end

end

go

--ELIMINAR HORARIO
create proc usp_EliminarHorario(
@IdHorario int,
@Resultado bit output
)
as
begin
	begin try
		begin transaction

		delete from HORARIO where IdHorario = @IdHorario

		commit
		set @Resultado = 1
		
	end try
	begin catch
		ROLLBACK
		set @Resultado = 0
	end catch
end


GO

--LISTAR DOCENTE
CREATE PROC usp_ListarDocente
as
begin
 select IdDocente,Codigo,DocumentoIdentidad,Nombres,Apellidos,FechaNacimiento,Sexo,GradoEstudio,Ciudad,Direccion,Email,NumeroTelefono,Activo from DOCENTE
 order by Nombres
end

go

-- REGISTRAR DOCENTE
CREATE PROC usp_RegistrarDocente(
@DocumentoIdentidad varchar(100),
@Nombres varchar(100),
@Apellidos varchar(100),
@FechaNacimiento date,
@Sexo varchar(50),
@GradoEstudio varchar(100),
@Ciudad varchar(100),
@Direccion varchar(100),
@Email varchar(100),
@NumeroTelefono varchar(50),
@Resultado bit output
)as
begin
	SET DATEFORMAT dmy;
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM DOCENTE WHERE DocumentoIdentidad = @DocumentoIdentidad and Nombres like '%' + @Nombres +'%' and Apellidos like '%' + @Apellidos +'%')
		insert into DOCENTE(ValorCodigo,Codigo,DocumentoIdentidad,Nombres,Apellidos,FechaNacimiento,Sexo,GradoEstudio,Ciudad,Direccion,Email,NumeroTelefono) values (
		(select isnull(max(ValorCodigo),0) + 1 from DOCENTE),
		'DO' + RIGHT('000000' + convert(varchar(max),(select isnull(max(ValorCodigo),0) + 1 from DOCENTE)),6),
		@DocumentoIdentidad,
		@Nombres,
		@Apellidos,
		@FechaNacimiento,
		@Sexo,
		@GradoEstudio,
		@Ciudad,
		@Direccion,
		@Email,
		@NumeroTelefono
		)
	ELSE
		SET @Resultado = 0
	
end

go

-- REGISTRAR ALUMNO
CREATE PROC usp_EditarDocente(
@IdDocente int,
@DocumentoIdentidad varchar(100),
@Nombres varchar(100),
@Apellidos varchar(100),
@FechaNacimiento date,
@Sexo varchar(50),
@GradoEstudio varchar(100),
@Ciudad varchar(100),
@Direccion varchar(100),
@Email varchar(100),
@NumeroTelefono varchar(50),
@Activo bit,
@Resultado bit output
)as
begin
	SET DATEFORMAT dmy;
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM DOCENTE WHERE DocumentoIdentidad = @DocumentoIdentidad and Nombres like '%' + @Nombres +'%' and Apellidos like '%' + @Apellidos +'%' and IdDocente != @IdDocente)
		update DOCENTE SET
		DocumentoIdentidad = @DocumentoIdentidad,
		Nombres = @Nombres,
		Apellidos = @Apellidos,
		FechaNacimiento = @FechaNacimiento,
		Sexo = @Sexo,
		GradoEstudio = @GradoEstudio,
		Ciudad = @Ciudad,
		Direccion = @Direccion,
		Email = @Email,
		NumeroTelefono = @NumeroTelefono,
		Activo = @Activo
		where IdDocente = @IdDocente

	ELSE
		SET @Resultado = 0
	
end

GO
--ELIMINAR ALUMNO
create procedure usp_EliminarDocente(
@IdDocente int,
@Resultado bit output
)
as
begin
	SET @Resultado = 1

	--validamos que ningun usuario se encuentre relacionado a una tienda
	IF (not EXISTS (select * from DOCENTE_NIVELDETALLE_CURSO m 
		inner join DOCENTE a on a.IdDocente = m.IdDocente
		where a.IdDocente = @IdDocente
		) 
	)
		delete from DOCENTE where IdDocente = @IdDocente
	ELSE
		SET @Resultado = 0

end

go


--LISTAR DOCENTE CURSO
CREATE PROC usp_ListarDocenteCurso
as
begin
 
 select
 dndc.IdDocenteNivelDetalleCurso[IdDocenteCurso],
 n.IdNivel,
 gs.IdGradoSeccion,
 d.IdDocente,
 c.IdCurso,
 d.Codigo[CodigoDocente],
 d.Nombres[NombreDocente],
 d.Apellidos[ApellidoDocente],
 n.DescripcionNivel,
 gs.DescripcionGrado,
 gs.DescripcionSeccion,
 c.Descripcion[DescripcionCurso],
 dndc.Activo

 from DOCENTE_NIVELDETALLE_CURSO dndc
 inner join NIVEL_DETALLE_CURSO ndc on ndc.IdNivelDetalleCurso = dndc.IdNivelDetalleCurso
 inner join CURSO c on c.IdCurso = ndc.IdCurso
 inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = ndc.IdNivelDetalle
 inner join NIVEL n on n.IdNivel = nd.IdNivel
 inner join GRADO_SECCION gs on gs.IdGradoSeccion = nd.IdGradoSeccion
 inner join DOCENTE d on d.IdDocente = dndc.IdDocente
 order by d.Nombres
end

go

--REGISTRAR DOCENTE CURSO
CREATE PROC usp_RegistrarDocenteCurso(
@IdNivel int,
@IdGradoSeccion int,
@IdCurso int,
@IdDocente int,
@Resultado bit output
)
as
begin
	declare @idniveldetallecurso int = 0
	declare @idhorario int = 0

	set @idniveldetallecurso = (select top 1 ndc.IdNivelDetalleCurso from NIVEL_DETALLE_CURSO ndc
	inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = ndc.IdNivelDetalle
	where nd.IdNivel = @IdNivel and nd.IdGradoSeccion = @IdGradoSeccion and ndc.IdCurso = @IdCurso)

	if(@idniveldetallecurso = 0)
		set @Resultado = 0
	else
	begin
		insert into DOCENTE_NIVELDETALLE_CURSO(IdNivelDetalleCurso,IdDocente) values
		(@idniveldetallecurso,@IdDocente)
		

		set @Resultado = 1
	end

end

go
--ELIMINAR DOCENTE CURSO
create proc usp_EliminarDocenteCurso(
@IdDocenteCurso int,
@Resultado bit output
)
as
begin
	begin try
		begin transaction

		delete from DOCENTE_NIVELDETALLE_CURSO where IdDocenteNivelDetalleCurso = @IdDocenteCurso

		commit
		set @Resultado = 1
		
	end try
	begin catch
		ROLLBACK
		set @Resultado = 0
	end catch
end

go

--OBTENER DETALLE DOCENTE CURSO
create proc usp_DetalleDocenteCurso
as
begin

 select 

 (select d.IdDocente,d.Nombres,d.Apellidos,

  (select 
  
	(SELECT N.IdNivel,N.DescripcionNivel,(
		select 
			(select GS.IdGradoSeccion,gs.DescripcionGrado,gs.DescripcionSeccion,(
				select
				 (SELECT c.IdCurso,c.Descripcion FROM CURSO C WHERE C.IdCurso = CU.IdCurso FOR XML PATH (''),TYPE) AS 'CURSO'
				
				from (
					select distinct c.IdCurso from DOCENTE_NIVELDETALLE_CURSO dndc
					  INNER JOIN NIVEL_DETALLE_CURSO NDC ON NDC.IdNivelDetalleCurso = dndc.IdNivelDetalleCurso
					  INNER JOIN NIVEL_DETALLE ND ON ND.IdNivelDetalle = NDC.IdNivelDetalle
					  INNER JOIN NIVEL N ON N.IdNivel = ND.IdNivel 
					  inner join CURSO C on c.IdCurso = ndc.IdCurso 
					  inner join GRADO_SECCION gs1 on gs1.IdGradoSeccion = nd.IdGradoSeccion 
					  where gs1.IdGradoSeccion = gs.IdGradoSeccion and dndc.IdDocente = fd.IdDocente
				
				) cu FOR XML PATH (''),TYPE) AS 'CURSOS' 
			
			
			from GRADO_SECCION gs 
			where gs.IdGradoSeccion = gsu.IdGradoSeccion FOR XML PATH (''),TYPE) AS 'GRADO'



		from (
		  select distinct gs.IdGradoSeccion from DOCENTE_NIVELDETALLE_CURSO dndc
		  INNER JOIN NIVEL_DETALLE_CURSO NDC ON NDC.IdNivelDetalleCurso = dndc.IdNivelDetalleCurso
		  INNER JOIN NIVEL_DETALLE ND1 ON ND1.IdNivelDetalle = NDC.IdNivelDetalle
		  INNER JOIN NIVEL N1 ON N1.IdNivel = ND1.IdNivel 
		  inner join GRADO_SECCION gs on gs.IdGradoSeccion = nd1.IdGradoSeccion where n1.IdNivel = nd.IdNivel
		) gsu
	
		FOR XML PATH (''),TYPE) AS 'GRADOS_SECCION' 


	FROM NIVEL N WHERE N.IDNIVEL = ND.IDNIVEL FOR XML PATH (''),TYPE) AS 'NIVEL'

  
  from (
  select DISTINCT N.IdNivel from DOCENTE_NIVELDETALLE_CURSO dndc
  INNER JOIN NIVEL_DETALLE_CURSO NDC ON NDC.IdNivelDetalleCurso = dndc.IdNivelDetalleCurso
  INNER JOIN NIVEL_DETALLE ND ON ND.IdNivelDetalle = NDC.IdNivelDetalle
  INNER JOIN NIVEL N ON N.IdNivel = ND.IdNivel WHERE DNDC.IdDocente = d.IdDocente) nd
  FOR XML PATH (''),TYPE) AS 'NIVELES' 
 


 from DOCENTE d
 where d.IdDocente = fd.IdDocente
 FOR XML PATH (''),TYPE) AS 'DOCENTE' 
 
 
 from (

 SELECT 
 distinct IdDocente FROM 
 DOCENTE_NIVELDETALLE_CURSO) 
 fd
FOR XML PATH(''), ROOT('DOCENTES') 

end


GO

create proc usp_ObtenerCurricula(
@IdNivel int,
@IdGradoSeccion int,
@IdCurso int,
@IdDocente int
)
as
begin
	select cu.IdCurricula,cu.IdDocenteNivelDetalleCurso,cu.Descripcion from CURRICULA cu
	inner join DOCENTE_NIVELDETALLE_CURSO dndc on dndc.IdDocenteNivelDetalleCurso = cu.IdDocenteNivelDetalleCurso
	inner join NIVEL_DETALLE_CURSO ndc on ndc.IdNivelDetalleCurso = dndc.IdNivelDetalleCurso
	inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = ndc.IdNivelDetalle
	where nd.IdNivel = @IdNivel and nd.IdGradoSeccion = @IdGradoSeccion and ndc.IdCurso = @IdCurso and dndc.IdDocente = @IdDocente
end

go

--REGISTRAR DOCENTE CURSO
CREATE PROC usp_RegistrarCurricula(
@IdNivel int,
@IdGradoSeccion int,
@IdCurso int,
@IdDocente int,
@Descripcion varchar(100),
@Resultado bit output
)
as
begin
	declare @iddocenteniveldetallecurso int = 0

	set @iddocenteniveldetallecurso = (select top 1 ndc.IdNivelDetalleCurso from DOCENTE_NIVELDETALLE_CURSO dndc
	inner join NIVEL_DETALLE_CURSO ndc on ndc.IdNivelDetalleCurso = dndc.IdNivelDetalleCurso
	inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = ndc.IdNivelDetalle
	where nd.IdNivel = @IdNivel and nd.IdGradoSeccion = @IdGradoSeccion and ndc.IdCurso = @IdCurso and dndc.IdDocente = @IdDocente)

	if(@iddocenteniveldetallecurso = 0 or @iddocenteniveldetallecurso is null)
		set @Resultado = 0
	else
	begin
		set @Resultado = 1

		if( not exists (select * from CURRICULA where IdDocenteNivelDetalleCurso = @iddocenteniveldetallecurso and Descripcion like '%' + @Descripcion +'%'))
			insert into CURRICULA(IdDocenteNivelDetalleCurso,Descripcion) values
			(@iddocenteniveldetallecurso,@Descripcion)
		else
			set @Resultado = 0

		
	end

end

go

--ELIMINAR CURRICULA
create proc usp_EliminarCurricula(
@IdCurricula int,
@Resultado bit output
)
as
begin
	begin try
		begin transaction

		delete from CURRICULA where IdCurricula = @IdCurricula

		commit
		set @Resultado = 1
		
	end try
	begin catch
		ROLLBACK
		set @Resultado = 0
	end catch
end

go


--REGITRAR MATRICULA
create procedure usp_RegistrarMatricula(
@xml xml,
@Resultado int output
)
as
begin
begin try

	BEGIN TRANSACTION

		SET DATEFORMAT dmy;
		declare @idalumno int
		declare @idapoderado int
		declare @idniveldetalle int

		declare @academico table (situacion varchar(50),idperiodo int,idnivel int,idgradoseccion int,institucionprocedencia varchar(100),esrepitente varchar(50))
		declare @alumno table(idalumno int,documentoidentidad varchar(50),nombres varchar(50),apellidos varchar(50),fechanacimiento varchar(50),
							sexo varchar(50),ciudad varchar(50), direccion varchar(100))

		declare @apoderado table(tiporelacion varchar(50),documentoidentidad varchar(50),nombres varchar(50),apellidos varchar(50),fechanacimiento varchar(50),
							sexo varchar(50),estadocivil varchar(50),ciudad varchar(50), direccion varchar(100))
		
		insert into @academico(situacion,idperiodo,idnivel,idgradoseccion,institucionprocedencia,esrepitente)
		select 
		data0 = Node.Data.value('(situacion)[1]','varchar(50)'),
		data1 = Node.Data.value('(idperiodo)[1]','int'),
		data2 = Node.Data.value('(idnivel)[1]','int'),
		data3 = Node.Data.value('(idgradoseccion)[1]','int'),
		data4 = Node.Data.value('(institucionprocedencia)[1]','varchar(100)'),
		data5 = Node.Data.value('(esrepitente)[1]','varchar(50)')
		FROM @xml.nodes('/DATA/ACADEMICO') Node(Data)

		insert into @alumno(idalumno,documentoidentidad,nombres,apellidos,fechanacimiento,sexo,ciudad,direccion)
		select 
		data1 = Node.Data.value('(idalumno)[1]','int'),
		data2 = Node.Data.value('(documentoidentidad)[1]','varchar(100)'),
		data3 = Node.Data.value('(nombres)[1]','varchar(100)'),
		data4 = Node.Data.value('(apellidos)[1]','varchar(100)'),
		data5 = Node.Data.value('(fechanacimiento)[1]','varchar(50)'),
		data6 = Node.Data.value('(sexo)[1]','varchar(100)'),
		data7 = Node.Data.value('(ciudad)[1]','varchar(100)'),
		data8 = Node.Data.value('(direccion)[1]','varchar(100)')
		FROM @xml.nodes('/DATA/ALUMNO') Node(Data)


		insert into @apoderado(tiporelacion,documentoidentidad,nombres,apellidos,fechanacimiento,sexo,estadocivil,ciudad,direccion)
		select 
		data1 = Node.Data.value('(tiporelacion)[1]','varchar(100)'),
		data2 = Node.Data.value('(documentoidentidad)[1]','varchar(100)'),
		data3 = Node.Data.value('(nombres)[1]','varchar(100)'),
		data4 = Node.Data.value('(apellidos)[1]','varchar(100)'),
		data5 = Node.Data.value('(fechanacimiento)[1]','varchar(50)'),
		data6 = Node.Data.value('(sexo)[1]','varchar(100)'),
		data7 = Node.Data.value('(estadocivil)[1]','varchar(100)'),
		data8 = Node.Data.value('(ciudad)[1]','varchar(100)'),
		data8 = Node.Data.value('(direccion)[1]','varchar(100)')
		FROM @xml.nodes('/DATA/APODERADO') Node(Data)

		---AREA DE TRABAJO
		--REGISTRAMOS ALUMNO
		if((select top 1 idalumno from @alumno) = 0)
		begin
			insert into ALUMNO(ValorCodigo,Codigo,Nombres,Apellidos,DocumentoIdentidad,FechaNacimiento,Sexo,Ciudad,Direccion)
			select 
			(select isnull(max(ValorCodigo),0) + 1 from ALUMNO),
			'AL' + RIGHT('000000' + convert(varchar(max),(select isnull(max(ValorCodigo),0) + 1 from ALUMNO)),6),
			nombres,
			apellidos,
			documentoidentidad,
			convert(date,fechanacimiento),
			sexo,
			ciudad,
			direccion
			from @alumno

			set @idalumno = scope_identity()
		end
		else
			set @idalumno =(select top 1 idalumno from @alumno)

		--REGISTRAMOS DOCENTE
		insert into APODERADO(TipoRelacion,Nombres,Apellidos,DocumentoIdentidad,FechaNacimiento,Sexo,EstadoCivil,Ciudad,Direccion)
		select 
		tiporelacion,
		nombres,
		apellidos,
		documentoidentidad,
		convert(date,fechanacimiento),
		sexo,
		estadocivil,
		ciudad,
		direccion
		from @apoderado

		set @idapoderado = scope_identity()

		
		set @idniveldetalle = (select top 1 IdNivelDetalle from NIVEL_DETALLE 
		where IdNivel = (select top 1 idnivel from @academico) and 
		IdGradoSeccion = (select top 1 IdGradoSeccion from @academico))


		insert into MATRICULA(ValorCodigo,Codigo,Situacion,IdAlumno,IdNivelDetalle,IdApoderado,InstitucionProcedencia,EsRepitente)
		select 
		(select isnull(max(ValorCodigo),0) + 1 from MATRICULA),
		'MA' + RIGHT('000000' + convert(varchar(max),(select isnull(max(ValorCodigo),0) + 1 from MATRICULA)),6),
		situacion,
		@idalumno,
		@idniveldetalle,
		@idapoderado,
		institucionprocedencia,
		iif(esrepitente= 'NO',0,1)
		from @academico

		
		update NIVEL_DETALLE set VacantesOcupadas = VacantesOcupadas + 1  where IdNivelDetalle = @idniveldetalle
		update NIVEL_DETALLE set VacantesDisponibles = TotalVacantes - VacantesOcupadas   where IdNivelDetalle =  @idniveldetalle


		set @Resultado = scope_identity()

	COMMIT

 end try
 begin catch
	ROLLBACK
	--set @Resultado = ERROR_MESSAGE()
	set @Resultado = 0
 end catch
end

go

create proc usp_ObtenerMatricula
as
begin
  select m.IdMatricula, nd.IdNivel,nd.IdGradoSeccion,a.IdAlumno,a.Nombres,a.Apellidos from MATRICULA m
  inner join NIVEL_DETALLE nd on m.IdNivelDetalle = nd.IdNivelDetalle
  inner join ALUMNO a on a.IdAlumno = m.IdAlumno
end

go


create proc usp_ObtenerClalificacion(
@IdNivel int,
@IdGradoSeccion int,
@IdCurso int,
@IdAlumno int
)
as
begin
	  select nd.IdNivel,nd.IdGradoSeccion,ndc.IdCurso,ca.IdAlumno,cu.IdCurricula,cu.Descripcion,ca.Nota from CALIFICACION ca
	  inner join CURRICULA cu on cu.IdCurricula = ca.IdCurricula
	  inner join DOCENTE_NIVELDETALLE_CURSO dndc on dndc.IdDocenteNivelDetalleCurso = cu.IdDocenteNivelDetalleCurso
	  inner join NIVEL_DETALLE_CURSO ndc on ndc.IdNivelDetalleCurso = dndc.IdNivelDetalleCurso
	  inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = ndc.IdNivelDetalle
	  where nd.IdNivel = @IdNivel and nd.IdGradoSeccion = @IdGradoSeccion and ndc.IdCurso = @IdCurso and ca.IdAlumno = @IdAlumno
end

go


--REGITRAR VACANTES
create procedure usp_RegistrarCalificacion(
@xml xml,
@Resultado bit output
)
as
begin
begin try

	BEGIN TRANSACTION
		declare @detalle table(IdCurricula int,IdAlumno int,Nota float)
		declare @IdAlumno int = 0;

		insert into @detalle(IdCurricula,IdAlumno,Nota)
		select 
		d1 = Node.Data.value('(IdCurricula)[1]','int'),
		d2 = Node.Data.value('(IdAlumno)[1]','int'),
		d3 = Node.Data.value('(Nota)[1]','float')
		FROM @xml.nodes('/DETALLE/DATA') Node(Data)


		set @IdAlumno = (select top 1 IdAlumno from @detalle)

		delete ca from CALIFICACION ca
		inner join CURRICULA cu on cu.IdCurricula = ca.IdCurricula
		inner join DOCENTE_NIVELDETALLE_CURSO dndc on dndc.IdDocenteNivelDetalleCurso = cu.IdDocenteNivelDetalleCurso
		inner join NIVEL_DETALLE_CURSO ndc on ndc.IdNivelDetalleCurso = dndc.IdNivelDetalleCurso
		inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = ndc.IdNivelDetalle
		inner join NIVEL n on nd.IdNivel = nd.IdNivel
		inner join PERIODO p on p.IdPeriodo = n.IdPeriodo
		where ca.IdAlumno = @IdAlumno and p.Activo = 1

		insert into CALIFICACION(IdCurricula,IdAlumno,Nota)
		select IdCurricula,IdAlumno,Nota from @detalle

		set @Resultado = 1

	COMMIT

 end try
 begin catch
	ROLLBACK
	set @Resultado = 0
 end catch
end

go

create proc usp_ReporteAlumno(
@Nombres varchar(50),
@Apellidos varchar(50),
@Codigo varchar(50),
@DocumentoIdentidad varchar(50)
)
as
begin

  select a.Codigo,a.DocumentoIdentidad[Documento Identidad],a.Nombres,a.Apellidos,
  convert(char(10),a.FechaNacimiento,103)[Fecha Nacimiento],a.Sexo,a.Ciudad,a.Direccion,
  n.DescripcionNivel[Nivel Academico],n.DescripcionTurno[Turno],gs.DescripcionGrado[Grado],gs.DescripcionSeccion[Seccion]
  from MATRICULA m
  inner join ALUMNO a on a.IdAlumno = m.IdAlumno
  inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = m.IdNivelDetalle
  inner join NIVEL n on n.IdNivel = nd.IdNivel
  inner join GRADO_SECCION gs on gs.IdGradoSeccion = nd.IdGradoSeccion
  where a.Nombres like '%' + @Nombres +'%' and a.Apellidos like '%' + @Apellidos +'%' and 
  a.Codigo like '%' + @Codigo+ '%' and a.DocumentoIdentidad like '%' + @DocumentoIdentidad+ '%'

end

go

create proc usp_ReporteMatricula(
@CodigoMatricula varchar(50),
@SituacionMatricula varchar(50),
@CodigoAlumno varchar(50),
@DocumentoIdentidad varchar(50),
@Nombres varchar(50),
@Apellidos varchar(50),
@Periodo varchar(50),
@NivelAcademico varchar(50),
@GradoSeccion varchar(50)
)
as
begin

 select 
m.Codigo[Codigo Matricula],m.Situacion,iif(m.EsRepitente=1,'si','no')[Repitente],
n.DescripcionNivel[Nivel Academico],n.DescripcionTurno[Turno Nivel],
gs.DescripcionGrado[Grado],gs.DescripcionSeccion[Seccion],
a.Codigo[Codigo alumno],a.DocumentoIdentidad[Documento identidad alumno],a.Nombres,a.Apellidos
from MATRICULA m
inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = m.IdNivelDetalle
inner join NIVEL n on nd.IdNivel = n.IdNivel
inner join PERIODO p on n.IdPeriodo = p.IdPeriodo
inner join GRADO_SECCION gs on gs.IdGradoSeccion = nd.IdGradoSeccion
inner join ALUMNO a on a.IdAlumno = m.IdAlumno 
where m.Codigo like '%' + @CodigoMatricula + '%' and m.Situacion like '%' + @SituacionMatricula +'%' and
a.Codigo like '%' + @CodigoAlumno + '%' and a.DocumentoIdentidad like '%' + @DocumentoIdentidad +'%' and a.Nombres like '%' + @Nombres+'%' and a.Apellidos like '%' +@Apellidos+'%' and
n.DescripcionNivel like '%'+@NivelAcademico+'%' and p.Descripcion like '%'+@Periodo+'%' and
concat(gs.DescripcionGrado,' - ',gs.DescripcionSeccion) like '%' +@GradoSeccion+'%'

end

go

