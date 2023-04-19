USE BDCOLEGIOWEB
GO

--INSERTAR ROL
INSERT INTO ROL(Descripcion) VALUES
('ADMINISTRADOR'),
('DOCENTE'),
('ALUMNO')

GO

--INSERTAR MENU
INSERT INTO MENU(Nombre,Icono) VALUES
('Configuraciones',''),
('Usuarios',''),
('Alumnos',''),
('Docentes',''),
('Cursos',''),
('Matricula','')

GO

--INSERTAR SUBMENU

INSERT INTO SUBMENU(IdMenu,Nombre,NombreFormulario,Accion) VALUES
((SELECT IdMenu FROM MENU WHERE Nombre = 'Usuarios'),'Crear Usuario','Usuario','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Usuarios'),'Crear Rol','Rol','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Usuarios'),'Asignar rol permisos','RolPermiso','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Alumnos'),'Crear Alumnos','Alumno','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Alumnos'),'Consulta y Reporte','Alumno','Reporte'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Docentes'),'Crear Docentes','Docente','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Docentes'),'Agregar Curricula','Docente','Curricula'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Docentes'),'Agregar Calificacion','Docente','Calificacion'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Cursos'),'Crear Cursos','Curso','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Matricula'),'Crear Matricula','Matricula','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Matricula'),'Consulta y Reporte','Matricula','Reporte'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Configuraciones'),'Crear Periodo','Periodo','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Configuraciones'),'Crear Nivel Academico','NivelAcademico','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Configuraciones'),'Crear Grados y Secciones','GradoSeccion','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Configuraciones'),'Asignar Grados por Niveles','GradoporNivel','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Configuraciones'),'Asignar Cursos por Niveles','Curso','Asignar'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Configuraciones'),'Asignar Vacantes','Vacante','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Configuraciones'),'Crear Horario','Horario','Crear'),
((SELECT IdMenu FROM MENU WHERE Nombre = 'Configuraciones'),'Asignar Docentes por Cursos','Docente','Asignar')

go


--INSERTAR USUARIO
insert into USUARIO(Nombres,Apellidos,IdRol,LoginUsuario,LoginClave,DescripcionReferencia,IdReferencia)
values('Eren','Thopsom',(select TOP 1 IdRol from ROL where Descripcion = 'ADMINISTRADOR'),'Admin','Admin123','NINGUNA',0)

go

--INSERTAR PERMISOS
INSERT INTO PERMISOS(IdRol,IdSubMenu)
SELECT (select TOP 1 IdRol from ROL where Descripcion = 'ADMINISTRADOR'), IdSubMenu FROM SUBMENU
GO
INSERT INTO PERMISOS(IdRol,IdSubMenu,Activo)
SELECT (select TOP 1 IdRol from ROL where Descripcion = 'DOCENTE'),IdSubMenu,0 FROM SUBMENU
GO
INSERT INTO PERMISOS(IdRol,IdSubMenu,Activo)
SELECT (select TOP 1 IdRol from ROL where Descripcion = 'ALUMNO'),IdSubMenu,0 FROM SUBMENU

GO

update p set p.Activo = 1 from PERMISOS p
inner join SUBMENU sm on sm.IdSubMenu = p.IdSubMenu
where sm.NombreFormulario in ('frmAgregarCurricula','frmAgregarCalificacion') and p.IdRol = (select TOP 1 IdRol from ROL where Descripcion = 'DOCENTE')

go


--INSERTAR PERIODOS
insert into PERIODO(Descripcion,FechaInicio,FechaFin,Activo) values
('PERIODO 2019','13/03/2019','20/12/2019',0),
('PERIODO 2020','10/03/2020','18/12/2020',0),
('PERIODO 2021','10/03/2021','17/12/2021',1)

GO
--INSERTAR NIVELES
insert into NIVEL(IdPeriodo,DescripcionNivel,DescripcionTurno,HoraInicio,HoraFin,Activo) values
((select IdPeriodo from PERIODO where Descripcion = 'PERIODO 2020'),
'PRIMARIA','MAÑANA','08:30:00.0000000','12:35:00.0000000',0
),
((select IdPeriodo from PERIODO where Descripcion = 'PERIODO 2020'),
'SECUNDARIA','TARDE','13:00:00.0000000','18:00:00.0000000',0
),
((select IdPeriodo from PERIODO where Descripcion = 'PERIODO 2021'),
'PRIMARIA','MAÑANA','08:30:00.0000000','12:35:00.0000000',1
),
((select IdPeriodo from PERIODO where Descripcion = 'PERIODO 2021'),
'SECUNDARIA','TARDE','13:00:00.0000000','18:00:00.0000000',1
)


GO
--INSERTAR GRADO_SECCION
INSERT INTO GRADO_SECCION(DescripcionGrado,DescripcionSeccion) VALUES
('PRIMERO','A'),
('PRIMERO','B'),
('PRIMERO','C'),
('SEGUNDO','A'),
('SEGUNDO','B'),
('SEGUNDO','C'),
('TERCERO','A'),
('TERCERO','B'),
('TERCERO','C')

GO
-- INSERTAR NIVEL DETALLE

INSERT INTO NIVEL_DETALLE(IdNivel,IdGradoSeccion,TotalVacantes,VacantesDisponibles,VacantesOcupadas)
select 
(select top 1 IdNivel from NIVEL where IdPeriodo = 3 ),
IdGradoSeccion,30,30,0
from GRADO_SECCION where IdGradoSeccion in (1,2,3)


GO
--INSERTAR CURSOS
INSERT INTO CURSO(Descripcion) VALUES
('QUIMICA'),
('MATEMATICAS'),
('RELIGION'),
('HISTORIA'),
('COMPUTACION'),
('FISICA'),
('COMUNICACION'),
('PSICOLOGIA')

GO
--INSERTAR NIVEL_DETALLE

 INSERT INTO NIVEL_DETALLE_CURSO(IdNivelDetalle,IdCurso) VALUES
((SELECT IdNivelDetalle FROM NIVEL_DETALLE WHERE IdNivel = 3 AND IdGradoSeccion = 1),1),
((SELECT IdNivelDetalle FROM NIVEL_DETALLE WHERE IdNivel = 3 AND IdGradoSeccion = 1),2),
((SELECT IdNivelDetalle FROM NIVEL_DETALLE WHERE IdNivel = 3 AND IdGradoSeccion = 1),3),
((SELECT IdNivelDetalle FROM NIVEL_DETALLE WHERE IdNivel = 3 AND IdGradoSeccion = 1),4),
((SELECT IdNivelDetalle FROM NIVEL_DETALLE WHERE IdNivel = 3 AND IdGradoSeccion = 1),5),
((SELECT IdNivelDetalle FROM NIVEL_DETALLE WHERE IdNivel = 3 AND IdGradoSeccion = 1),6),
((SELECT IdNivelDetalle FROM NIVEL_DETALLE WHERE IdNivel = 3 AND IdGradoSeccion = 1),7),
((SELECT IdNivelDetalle FROM NIVEL_DETALLE WHERE IdNivel = 3 AND IdGradoSeccion = 1),8)


GO
--INSERTAR HORARIO

 insert into HORARIO(IdNivelDetalleCurso,DiaSemana,HoraInicio,HoraFin) values
(( select top 1 ndc.IdNivelDetalleCurso from NIVEL_DETALLE_CURSO ndc
 inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = ndc.IdNivelDetalle
 where nd.IdNivel = 3 and nd.IdGradoSeccion = 1 and ndc.IdCurso = 1),
 'Lunes','08:30:00.0000000','09:30:00.0000000'),

(( select top 1 ndc.IdNivelDetalleCurso from NIVEL_DETALLE_CURSO ndc
 inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = ndc.IdNivelDetalle
 where nd.IdNivel = 3 and nd.IdGradoSeccion = 1 and ndc.IdCurso = 2),
 'Lunes','09:30:00.0000000','10:30:00.0000000'),

(( select top 1 ndc.IdNivelDetalleCurso from NIVEL_DETALLE_CURSO ndc
 inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = ndc.IdNivelDetalle
 where nd.IdNivel = 3 and nd.IdGradoSeccion = 1 and ndc.IdCurso = 3),
 'Lunes','10:30:00.0000000','11:30:00.0000000'),
 
(( select top 1 ndc.IdNivelDetalleCurso from NIVEL_DETALLE_CURSO ndc
 inner join NIVEL_DETALLE nd on nd.IdNivelDetalle = ndc.IdNivelDetalle
 where nd.IdNivel = 3 and nd.IdGradoSeccion = 1 and ndc.IdCurso = 4),
 'Lunes','11:30:00.0000000','12:35:00.0000000')

 GO
 --REGISTRAR DOCENTE
  insert into DOCENTE(ValorCodigo,Codigo,DocumentoIdentidad,Nombres,Apellidos,FechaNacimiento,Sexo,GradoEstudio,Ciudad,Direccion,Email,NumeroTelefono) values
 (1,'DO000001','78945612','ALBERTO','RODRIGUEZ','1980-07-19','Masculino','BACHICHERATO','TEXAS','MIAMI 123','ROD@GMAIL.COM','936798490'),
 (2,'DO000002','78894500','ESTEBAN','TAPUR','1970-02-06','Masculino','TITULADO','THE END','STRET 456','EST@GMAIL.COM','987654321'),
 (3,'DO000003','789458923','SARA','SANTIR','1979-02-06','Femenino','TITULADO','AV.TORE','STRET 799','SAR@GMAIL.COM','964852100')

 GO

--REGISTAR ALUMNO
 INSERT INTO ALUMNO(ValorCodigo,Codigo,Nombres,Apellidos,DocumentoIdentidad,FechaNacimiento,Sexo,Ciudad,Direccion) VALUES
 (1,'AL000001','ROSALIA','MENDEZ','78974545','1999-02-16','Femenino','TEXAS','AV. GUG'),
 (2,'AL000002','JUAN','TORRES','78946548','2000-02-08','Masculino','ALENG','AV.UG'),
 (3,'AL000003','PAMELA','ESTEBAN','79005645','2000-12-23','Femenino','ALEXANDRIA','AV.TORRYU'),
 (4,'AL000004','ROCIO','PINTO','76345623','2001-06-12','Femenino','LUISIANA','AV.LUX'),
 (5,'AL000005','ALFONSO','SANCHEZ','70795647','2001-07-10','Masculino','PERSIANA','AV.PERSI'),
 (6,'AL000006','RODRIGO','PEREZ','76453626','2000-08-17','Masculino','LOREM','AV.LOREM')

 GO

--REGISTRAR DONCENTES CURSOS
 INSERT INTO DOCENTE_NIVELDETALLE_CURSO(IdNivelDetalleCurso,IdDocente) values
(1,1),
(2,2)

GO

--REGISTRAR CURRICULA
INSERT INTO CURRICULA(IdDocenteNivelDetalleCurso,Descripcion) VALUES
(1,'EVALUACION 001'),
(1,'EVALUACION 002'),
(1,'EVALUACION 003')

