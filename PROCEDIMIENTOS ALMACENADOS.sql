--
-- PROCEDIMIENTOS TABLA Especies
--
-- CONSULTA TODOS
ALTER PROCEDURE GET_ESPECIES
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

-- CONSULTA POR ID
ALTER PROCEDURE GET_ESPECIE
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

-- INSERTA UNA NUEVA ESPECIE en la tabla Especies
CREATE PROCEDURE INSERTA_ESPECIE
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

-- ACTUALIZA LOS DATOS DE UNA ESPECIE 
CREATE PROCEDURE ACTUALIZA_ESPECIE
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
	WHERE IdEspecie = @idEspecie
END


-- BORRA UNA ESPECIE
CREATE PROCEDURE BORRAR_ESPECIE
@idEspecie BigInt
AS
BEGIN
	DELETE FROM Especies
	WHERE IdEspecie = @idEspecie
END

------------------------------------------------------------------------
--
-- PROCEDIMIENTOS TABLA TiposAnimal
--

-- CONSULTA TODOS
CREATE PROCEDURE GET_TIPOS_ANIMALES
AS
BEGIN
	SELECT * FROM TiposAnimal
END

-- CONSULTA POR ID
CREATE PROCEDURE GET_TIPO_ANIMAL
@idTipoAnimal BigInt
AS
BEGIN 
	SELECT * FROM TiposAnimal TA WHERE TA.idTipoAnimal = @idTipoAnimal
END
-- INSERTA UN NUEVO Tipo de Animal
CREATE PROCEDURE INSERTA_TIPO_ANIMAL
@denominacion NVarChar(50)
AS
BEGIN
	INSERT INTO TiposAnimal (denominacion)
	VALUES (@denominacion)
END

-- ACTUALIZA Un Tipo de Animal 
CREATE PROCEDURE ACTUALIZA_TIPO_ANIMAL
@idTipoAnimal BigInt,
@denominacion NVarChar(50)
AS
BEGIN
	UPDATE TiposAnimal 
	SET denominacion = @denominacion
	WHERE idTipoAnimal = @idTipoAnimal
END

-- BORRA UN Tipo de Animal
CREATE PROCEDURE BORRAR_TIPO_ANIMAL
@idTipoAnimal BigInt
AS
BEGIN
	DELETE FROM TiposAnimal
	WHERE idTipoAnimal = @idTipoAnimal
END
------------------------------------------------------------------------
--
-- PROCEDIMIENTOS TABLA Clasificaciones
--

-- CONSULTA TODOS
CREATE PROCEDURE GET_CLASIFICACIONES
AS
BEGIN
	SELECT * FROM Clasificaciones
END

-- CONSULTA POR ID
CREATE PROCEDURE GET_CLASIFICACION
@idClasificacion BigInt
AS
BEGIN 
	SELECT * FROM Clasificaciones C WHERE C.idClasificacion = @idClasificacion
END

-- INSERTA UNA NUEVA CLASIFICACION en la tabla Clasificaciones
CREATE PROCEDURE INSERTA_CLASIFICACION
@denominacion NVarChar(50)
AS
BEGIN
	INSERT INTO Clasificaciones (denominacion)
	VALUES (@denominacion)
END
-- ACTUALIZA LOS DATOS DE UNA Clasificacion 
CREATE PROCEDURE ACTUALIZA_CLASIFICACION
@idClasificacion Int,
@denominacion NVarChar(50)
AS
BEGIN
	UPDATE Clasificaciones 
	SET denominacion = @denominacion
	WHERE idClasificacion = @idClasificacion
END
-- BORRA UNA Clasificacion
CREATE PROCEDURE BORRAR_CLASIFICACION
@idClasificacion Int
AS
BEGIN
	DELETE FROM Clasificaciones
	WHERE idClasificacion = @idClasificacion
END

------------------------------------------------------------------------