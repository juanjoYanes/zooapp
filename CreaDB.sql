USE [zoodb]
GO
/****** Object:  Table [dbo].[Clasificaciones]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clasificaciones](
	[idClasificacion] [int] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Clasificaciones] PRIMARY KEY CLUSTERED 
(
	[idClasificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Especies]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especies](
	[IdEspecie] [bigint] IDENTITY(1,1) NOT NULL,
	[IdClasificacion] [int] NOT NULL,
	[idTipoAnimal] [bigint] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[nPatas] [smallint] NOT NULL,
	[esMascota] [bit] NOT NULL,
 CONSTRAINT [PK_Especies] PRIMARY KEY CLUSTERED 
(
	[IdEspecie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TiposAnimal]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposAnimal](
	[idTipoAnimal] [bigint] IDENTITY(1,1) NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposAnimal] PRIMARY KEY CLUSTERED 
(
	[idTipoAnimal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Clasificaciones] ON 

INSERT [dbo].[Clasificaciones] ([idClasificacion], [denominacion]) VALUES (2, N'Aves')
INSERT [dbo].[Clasificaciones] ([idClasificacion], [denominacion]) VALUES (3, N'Peces')
INSERT [dbo].[Clasificaciones] ([idClasificacion], [denominacion]) VALUES (12, N'Reptiles')
INSERT [dbo].[Clasificaciones] ([idClasificacion], [denominacion]) VALUES (13, N'Mamifero')
SET IDENTITY_INSERT [dbo].[Clasificaciones] OFF
SET IDENTITY_INSERT [dbo].[Especies] ON 

INSERT [dbo].[Especies] ([IdEspecie], [IdClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (31, 2, 12, N'Canario', 2, 1)
INSERT [dbo].[Especies] ([IdEspecie], [IdClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (32, 13, 15, N'Perro', 4, 1)
INSERT [dbo].[Especies] ([IdEspecie], [IdClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (33, 13, 15, N'Gato', 4, 1)
INSERT [dbo].[Especies] ([IdEspecie], [IdClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (34, 13, 15, N'Rata', 4, 0)
INSERT [dbo].[Especies] ([IdEspecie], [IdClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (35, 13, 15, N'Caballo', 4, 1)
INSERT [dbo].[Especies] ([IdEspecie], [IdClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (36, 13, 10, N'Ballena', 0, 0)
INSERT [dbo].[Especies] ([IdEspecie], [IdClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (37, 12, 15, N'Serpiente', 0, 1)
INSERT [dbo].[Especies] ([IdEspecie], [IdClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (38, 2, 12, N'Aguila', 2, 0)
INSERT [dbo].[Especies] ([IdEspecie], [IdClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (39, 3, 10, N'Sardina', 0, 0)
INSERT [dbo].[Especies] ([IdEspecie], [IdClasificacion], [idTipoAnimal], [nombre], [nPatas], [esMascota]) VALUES (40, 12, 15, N'Camaleon', 4, 1)
SET IDENTITY_INSERT [dbo].[Especies] OFF
SET IDENTITY_INSERT [dbo].[TiposAnimal] ON 

INSERT [dbo].[TiposAnimal] ([idTipoAnimal], [denominacion]) VALUES (10, N'Acuatico')
INSERT [dbo].[TiposAnimal] ([idTipoAnimal], [denominacion]) VALUES (12, N'Volador')
INSERT [dbo].[TiposAnimal] ([idTipoAnimal], [denominacion]) VALUES (15, N'Terrestre')
SET IDENTITY_INSERT [dbo].[TiposAnimal] OFF
ALTER TABLE [dbo].[Clasificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Clasificaciones_Clasificaciones] FOREIGN KEY([idClasificacion])
REFERENCES [dbo].[Clasificaciones] ([idClasificacion])
GO
ALTER TABLE [dbo].[Clasificaciones] CHECK CONSTRAINT [FK_Clasificaciones_Clasificaciones]
GO
ALTER TABLE [dbo].[Especies]  WITH CHECK ADD  CONSTRAINT [FK_Especies_Clasificacion] FOREIGN KEY([IdClasificacion])
REFERENCES [dbo].[Clasificaciones] ([idClasificacion])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Especies] CHECK CONSTRAINT [FK_Especies_Clasificacion]
GO
ALTER TABLE [dbo].[Especies]  WITH CHECK ADD  CONSTRAINT [FK_Especies_TipoAnimal] FOREIGN KEY([idTipoAnimal])
REFERENCES [dbo].[TiposAnimal] ([idTipoAnimal])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Especies] CHECK CONSTRAINT [FK_Especies_TipoAnimal]
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZA_CLASIFICACION]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACTUALIZA_CLASIFICACION]
@idClasificacion Int,
@denominacion NVarChar(50)
AS
BEGIN
	UPDATE Clasificaciones 
	SET denominacion = @denominacion
	WHERE idClasificacion = @idClasificacion
END
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZA_ESPECIE]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACTUALIZA_ESPECIE]
@idEspecie BigInt,
@idClasificacion Int,
@idTipoAnimal BigInt,
@nombre NVarChar(50),
@nPatas SmallInt,
@esMascota Bit
AS
BEGIN
	UPDATE Especies 
	SET IdClasificacion = @idClasificacion,
	    idTipoAnimal = @idTipoAnimal, 
		nombre = @nombre, 
		nPatas = @nPatas,
		esMascota = @esMascota
	WHERE IdEspecie = @idEspecie;
END
GO
/****** Object:  StoredProcedure [dbo].[ACTUALIZA_TIPO_ANIMAL]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ACTUALIZA_TIPO_ANIMAL]
@idTipoAnimal BigInt,
@denominacion NVarChar(50)
AS
BEGIN
	UPDATE TiposAnimal 
	SET denominacion = @denominacion
	WHERE idTipoAnimal = @idTipoAnimal
END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_CLASIFICACION]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BORRAR_CLASIFICACION]
@idClasificacion Int
AS
BEGIN
	DELETE FROM Clasificaciones
	WHERE idClasificacion = @idClasificacion
END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_ESPECIE]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BORRAR_ESPECIE]
@idEspecie BigInt
AS
BEGIN
	DELETE FROM Especies
	WHERE IdEspecie = @idEspecie
END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_TIPO_ANIMAL]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BORRAR_TIPO_ANIMAL]
@idTipoAnimal BigInt
AS
BEGIN
	DELETE FROM TiposAnimal
	WHERE idTipoAnimal = @idTipoAnimal
END
GO
/****** Object:  StoredProcedure [dbo].[GET_CLASIFICACION]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_CLASIFICACION]
@idClasificacion BigInt
AS
BEGIN 
	SELECT * FROM Clasificaciones C WHERE C.idClasificacion = @idClasificacion
END
GO
/****** Object:  StoredProcedure [dbo].[GET_CLASIFICACIONES]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_CLASIFICACIONES]
AS
BEGIN
	SELECT * FROM Clasificaciones
END
GO
/****** Object:  StoredProcedure [dbo].[GET_ESPECIE]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ESPECIE]
@idEspecie BigInt
AS
BEGIN 
SELECT	E.IdEspecie,
			E.IdClasificacion,
			E.IdTipoAnimal,
			E.nombre,
			E.nPatas,
			E.esMascota,
			C.denominacion AS denominacionClasificacion,
			TA.denominacion AS denominacionTipoAnimal
	FROM Especies E
	  INNER JOIN Clasificaciones C ON E.IdClasificacion = C.IdClasificacion
	    INNER JOIN TiposAnimal TA ON E.IdTipoAnimal = TA.IdTipoAnimal
	WHERE E.idEspecie = @idEspecie
END
GO
/****** Object:  StoredProcedure [dbo].[GET_ESPECIES]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ESPECIES]
AS
BEGIN
	SELECT	E.IdEspecie,
			E.IdClasificacion,
			E.IdTipoAnimal,
			E.nombre,
			E.nPatas,
			E.esMascota,
			C.denominacion AS denominacionClasificacion,
			TA.denominacion AS denominacionTipoAnimal
	FROM Especies E
	  INNER JOIN Clasificaciones C ON E.IdClasificacion = C.IdClasificacion
	    INNER JOIN TiposAnimal TA ON E.IdTipoAnimal = TA.IdTipoAnimal
END
GO
/****** Object:  StoredProcedure [dbo].[GET_TIPO_ANIMAL]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_TIPO_ANIMAL]
@idTipoAnimal BigInt
AS
BEGIN 
	SELECT * FROM TiposAnimal TA WHERE TA.idTipoAnimal = @idTipoAnimal
END
GO
/****** Object:  StoredProcedure [dbo].[GET_TIPOS_ANIMALES]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_TIPOS_ANIMALES]
AS
BEGIN
	SELECT * FROM TiposAnimal
END
GO
/****** Object:  StoredProcedure [dbo].[INSERTA_CLASIFICACION]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTA_CLASIFICACION]
@denominacion NVarChar(50)
AS
BEGIN
	INSERT INTO Clasificaciones (denominacion)
	VALUES (@denominacion)
END
GO
/****** Object:  StoredProcedure [dbo].[INSERTA_ESPECIE]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTA_ESPECIE]
@idClasificacion Int,
@idTipoAnimal BigInt,
@nombre NVarChar(50),
@nPatas SmallInt,
@esMascota Bit
AS
BEGIN
	INSERT INTO Especies (IdClasificacion, idTipoAnimal, nombre, nPatas, esMascota)
	VALUES (@idClasificacion, @idTipoAnimal, @nombre, @nPatas, @esMascota)
END
GO
/****** Object:  StoredProcedure [dbo].[INSERTA_TIPO_ANIMAL]    Script Date: 16/06/2017 18:15:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[INSERTA_TIPO_ANIMAL]
@denominacion NVarChar(50)
AS
BEGIN
	INSERT INTO TiposAnimal (denominacion)
	VALUES (@denominacion)
END
GO
