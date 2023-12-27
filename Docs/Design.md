# Diseño del Proyecto

## Procesos que manejará la aplicación

1. **Gestión de Productos**: Este proceso manejará la creación, actualización y eliminación de productos. Incluirá la validación de los datos del producto y la asignación de un casillero para cada producto nuevo.

2. **Gestión de Casilleros**: Este proceso manejará la creación, actualización y eliminación de casilleros. También se encargará de verificar que un producto pueda caber en un casillero dado en base a su área y peso.

3. **Gestión de Racks**: Este proceso manejará la creación, actualización y eliminación de racks. También se encargará de asignar casilleros a los racks.

4. **Gestión de Proveedores y Clientes**: Este proceso manejará la creación, actualización y eliminación de proveedores y clientes. También se encargará de validar los datos del proveedor y del cliente.

5. **Gestión de Entradas y Salidas de Productos**: Este proceso manejará la entrada y salida de productos. Incluirá la validación de la entrada y salida de productos y la actualización del stock de productos.

6. **Gestión de Mermas**: Este proceso manejará la identificación y registro de mermas. También se encargará de calcular la cantidad de dinero perdido en mermas.

7. **Gestión de Usuarios**: Este proceso manejará la creación, actualización y eliminación de usuarios. También se encargará de la autenticación y autorización de usuarios.

8. **Reportes**: Este proceso manejará la generación de reportes. Estos reportes incluirán las ganancias mensuales, anuales y semanales, la cantidad de productos en stock, y la ubicación de cada producto en stock.

Cada uno de estos procesos se puede dividir en subprocesos más pequeños según sea necesario. Por ejemplo, el proceso de "Gestión de Productos" podría dividirse en subprocesos para la validación de datos del producto, la asignación de casilleros, y la actualización del stock de productos.


## Operaciones a implementar por cada Proceso

| Proceso | Commands | Queries |
| --- | --- | --- |
| Gestión de Productos | ✅ CrearProducto <br> ✅ ActualizarProducto <br> ✅ EliminarProducto | ✅ ObtenerProducto <br> ✅ ObtenerTodosProductos |
| Gestión de Casilleros | ✅ CrearCasillero <br> ✅ ActualizarCasillero <br> ✅ EliminarCasillero | ✅ ObtenerCasillero <br> ✅ ObtenerTodosCasilleros <br> ✅ ObtenerTodosCasillerosPorRack |
| Gestión de Racks | ✅ CrearRack <br> ✅ ActualizarRack <br> ✅ EliminarRack | ✅ ObtenerRack <br> ✅ ObtenerTodosRacks |
| Gestión de Proveedores y Clientes | ✅ CrearProveedor <br> ✅ ActualizarProveedor <br> ✅ EliminarProveedor <br> ✅ CrearCliente <br> ✅ ActualizarCliente <br> ✅ EliminarCliente | ✅ ObtenerProveedor <br> ✅ ObtenerTodosProveedores <br> ✅ ObtenerCliente <br> ✅ ObtenerTodosClientes |
| Gestión de Entradas y Salidas de Productos | ✅ RegistrarEntradaProducto <br> ✅ RegistrarSalidaProducto | ✅ ObtenerEntradaProducto <br> ✅ ObtenerSalidaProducto <br> ✅ ObtenerTodasEntradaProducto <br> ✅ ObtenerTodasSalidaProducto <br> ✅ HistorialEntradasSalidas |
| Gestión de Mermas | ✅ RegistrarMerma | ✅ ObtenerMerma <br> ✅ ObtenerTodasMermas |
| Gestión de Usuarios | ❌ CrearUsuario <br> ❌ ActualizarUsuario <br> ❌ EliminarUsuario | ❌ ObtenerUsuario <br> ❌ ObtenerTodosUsuarios |
| Reportes | ❌ GenerarReporteGanancias <br> ❌ GenerarReporteStock <br> ❌ GenerarReporteUbicacionProducto | ❌ ObtenerReporteGanancias <br> ❌ ObtenerReporteStock <br> ❌ ObtenerReporteUbicacionProducto |

## Transacciones

### -- Gestión de Productos

```sql
CREATE PROCEDURE CrearProducto @Nombre VARCHAR(255), @Descripcion TEXT, @Precio_Total DECIMAL(10,2), @Precio_Unitario DECIMAL(10,2), @Cantidad INT, @Tipo VARCHAR(255), @Alto DECIMAL(10,2), @Ancho DECIMAL(10,2), @Largo DECIMAL(10,2), @Unidad_Dimensiones ENUM('cm', 'm', 'ft'), @Peso DECIMAL(10,2), @Fecha_Llegada DATE, @Fecha_Caducidad DATE, @EnAlmacen BOOLEAN DEFAULT FALSE
AS
INSERT INTO Productos (Nombre, Descripcion, Precio_Total, Precio_Unitario, Cantidad, Tipo, Alto, Ancho, Largo, Unidad_Dimensiones, Peso, Fecha_Llegada, Fecha_Caducidad, EnAlmacen)
VALUES (@Nombre, @Descripcion, @Precio_Total, @Precio_Unitario, @Cantidad, @Tipo, @Alto, @Ancho, @Largo, @Unidad_Dimensiones, @Peso, @Fecha_Llegada, @Fecha_Caducidad, @EnAlmacen)

CREATE PROCEDURE ActualizarProducto @ID_Producto INT, @Nombre VARCHAR(255), @Descripcion TEXT, @Precio_Total DECIMAL(10,2), @Precio_Unitario DECIMAL(10,2), @Cantidad INT, @Tipo VARCHAR(255), @Alto DECIMAL(10,2), @Ancho DECIMAL(10,2), @Largo DECIMAL(10,2), @Unidad_Dimensiones ENUM('cm', 'm', 'ft'), @Peso DECIMAL(10,2), @Fecha_Llegada DATE, @Fecha_Caducidad DATE, @EnAlmacen BOOLEAN DEFAULT FALSE
AS
UPDATE Productos
SET Nombre = @Nombre, Descripcion = @Descripcion, Precio_Total = @Precio_Total, Precio_Unitario = @Precio_Unitario, Cantidad = @Cantidad, Tipo = @Tipo, Alto = @Alto, Ancho = @Ancho, Largo = @Largo, Unidad_Dimensiones = @Unidad_Dimensiones, Peso = @Peso, Fecha_Llegada = @Fecha_Llegada, Fecha_Caducidad = @Fecha_Caducidad, EnAlmacen = @EnAlmacen
WHERE ID_Producto = @ID_Producto

CREATE PROCEDURE EliminarProducto @ID_Producto INT
AS
DELETE FROM Productos
WHERE ID_Producto = @ID_Producto

CREATE PROCEDURE ObtenerProducto @ID_Producto INT
AS
SELECT * FROM Productos
WHERE ID_Producto = @ID_Producto

CREATE PROCEDURE ObtenerTodosProductos
AS
SELECT * FROM Productos
```

### -- Gestión de Casillero

```sql
-- Crear Casillero
CREATE PROCEDURE CrearCasillero @ID_Rack INT, @Area DECIMAL(10,2), @Peso_Maximo DECIMAL(10,2), @Alto DECIMAL(10,2), @Ancho DECIMAL(10,2), @Largo DECIMAL(10,2), @Unidad_Dimensiones ENUM('cm', 'm', 'ft')
AS
INSERT INTO Casilleros (ID_Rack, Area, Peso_Maximo, Alto, Ancho, Largo, Unidad_Dimensiones)
VALUES (@ID_Rack, @Area, @Peso_Maximo, @Alto, @Ancho, @Largo, @Unidad_Dimensiones)

-- Actualizar Casillero
CREATE PROCEDURE ActualizarCasillero @ID_Casillero INT, @ID_Rack INT, @Area DECIMAL(10,2), @Peso_Maximo DECIMAL(10,2), @Alto DECIMAL(10,2), @Ancho DECIMAL(10,2), @Largo DECIMAL(10,2), @Unidad_Dimensiones ENUM('cm', 'm', 'ft')
AS
UPDATE Casilleros
SET ID_Rack = @ID_Rack, Area = @Area, Peso_Maximo = @Peso_Maximo, Alto = @Alto, Ancho = @Ancho, Largo = @Largo, Unidad_Dimensiones = @Unidad_Dimensiones
WHERE ID_Casillero = @ID_Casillero

-- Eliminar Casillero
CREATE PROCEDURE EliminarCasillero @ID_Casillero INT
AS
DELETE FROM Casilleros
WHERE ID_Casillero = @ID_Casillero

-- Obtener Casillero
CREATE PROCEDURE ObtenerCasillero @ID_Casillero INT
AS
SELECT * FROM Casilleros
WHERE ID_Casillero = @ID_Casillero

-- Obtener Todos Casilleros
CREATE PROCEDURE ObtenerTodosCasilleros
AS
SELECT * FROM Casilleros

```

### -- Gestión de Racks

```sql
-- Crear Rack
CREATE PROCEDURE CrearRack @Pasillo VARCHAR(255)
AS
INSERT INTO Racks (Pasillo)
VALUES (@Pasillo)

-- Actualizar Rack
CREATE PROCEDURE ActualizarRack @ID_Rack INT, @Pasillo VARCHAR(255)
AS
UPDATE Racks
SET Pasillo = @Pasillo
WHERE ID_Rack = @ID_Rack

-- Eliminar Rack
CREATE PROCEDURE EliminarRack @ID_Rack INT
AS
DELETE FROM Racks
WHERE ID_Rack = @ID_Rack

-- Obtener Rack
CREATE PROCEDURE ObtenerRack @ID_Rack INT
AS
SELECT * FROM Racks
WHERE ID_Rack = @ID_Rack

-- Obtener Todos Racks
CREATE PROCEDURE ObtenerTodosRacks
AS
SELECT * FROM Racks

```

### -- Gestión de Proveedores y Clientes

```sql
-- Crear Proveedor
CREATE PROCEDURE CrearProveedor @Nombre VARCHAR(255), @CI VARCHAR(255), @Telefono VARCHAR(255), @Correo VARCHAR(255), @Direccion VARCHAR(255)
AS
INSERT INTO Proveedores (Nombre, CI, Telefono, Correo, Direccion)
VALUES (@Nombre, @CI, @Telefono, @Correo, @Direccion)

-- Actualizar Proveedor
CREATE PROCEDURE ActualizarProveedor @ID_Proveedor INT, @Nombre VARCHAR(255), @CI VARCHAR(255), @Telefono VARCHAR(255), @Correo VARCHAR(255), @Direccion VARCHAR(255)
AS
UPDATE Proveedores
SET Nombre = @Nombre, CI = @CI, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion
WHERE ID_Proveedor = @ID_Proveedor

-- Eliminar Proveedor
CREATE PROCEDURE EliminarProveedor @ID_Proveedor INT
AS
DELETE FROM Proveedores
WHERE ID_Proveedor = @ID_Proveedor

-- Obtener Proveedor
CREATE PROCEDURE ObtenerProveedor @ID_Proveedor INT
AS
SELECT * FROM Proveedores
WHERE ID_Proveedor = @ID_Proveedor

-- Obtener Todos Proveedores
CREATE PROCEDURE ObtenerTodosProveedores
AS
SELECT * FROM Proveedores

-- Crear Cliente
CREATE PROCEDURE CrearCliente @Nombre VARCHAR(255), @CI VARCHAR(255), @Telefono VARCHAR(255), @Correo VARCHAR(255), @Direccion VARCHAR(255)
AS
INSERT INTO Clientes (Nombre, CI, Telefono, Correo, Direccion)
VALUES (@Nombre, @CI, @Telefono, @Correo, @Direccion)

-- Actualizar Cliente
CREATE PROCEDURE ActualizarCliente @ID_Cliente INT, @Nombre VARCHAR(255), @CI VARCHAR(255), @Telefono VARCHAR(255), @Correo VARCHAR(255), @Direccion VARCHAR(255)
AS
UPDATE Clientes
SET Nombre = @Nombre, CI = @CI, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion
WHERE ID_Cliente = @ID_Cliente

-- Eliminar Cliente
CREATE PROCEDURE EliminarCliente @ID_Cliente INT
AS
DELETE FROM Clientes
WHERE ID_Cliente = @ID_Cliente

-- Obtener Cliente
CREATE PROCEDURE ObtenerCliente @ID_Cliente INT
AS
SELECT * FROM Clientes
WHERE ID_Cliente = @ID_Cliente

-- Obtener Todos Clientes
CREATE PROCEDURE ObtenerTodosClientes
AS
SELECT * FROM Clientes

```

### -- Gestión de Entradas y Salidas de Productos

```sql
```

### -- Gestión de Mermas

```sql
```

### -- Gestión de Usuarios

```sql
```

### -- Reportes

```sql
DELIMITER //
CREATE PROCEDURE GenerarReportes()
BEGIN
    -- Ganancias mensuales
    SELECT MONTH(Fecha) AS Mes, YEAR(Fecha) AS Año, SUM(Precio_Unitario * Cantidad) AS Ganancias_Mensuales
    FROM Entradas
    GROUP BY YEAR(Fecha), MONTH(Fecha);

    -- Ganancias anuales
    SELECT YEAR(Fecha) AS Año, SUM(Precio_Unitario * Cantidad) AS Ganancias_Anuales
    FROM Entradas
    GROUP BY YEAR(Fecha);

    -- Ganancias semanales
    SELECT WEEK(Fecha) AS Semana, YEAR(Fecha) AS Año, SUM(Precio_Unitario * Cantidad) AS Ganancias_Semanales
    FROM Entradas
    GROUP BY YEAR(Fecha), WEEK(Fecha);

    -- Cantidad de productos en stock
    SELECT ID_Producto, SUM(Cantidad) AS Cantidad_En_Stock
    FROM Productos
    WHERE EnAlmacen = TRUE
    GROUP BY ID_Producto;

    -- Ubicación de cada producto en stock
    SELECT U.ID_Producto, C.ID_Casillero, R.Pasillo
    FROM Ubicaciones U
    JOIN Casilleros C ON U.ID_Casillero = C.ID_Casillero
    JOIN Racks R ON C.ID_Rack = R.ID_Rack
    WHERE P.EnAlmacen = TRUE;
END //
DELIMITER ;

```
