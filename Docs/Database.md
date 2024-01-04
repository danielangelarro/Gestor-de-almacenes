# Herramientas para crear el proyecto

## Descripcion

Crear una aplicacion que permitan registrar entradas y salidas de productos. Cuando un producto entra se reserva una ubicacion que corresponde a un casillero en un rack determinado. Cada rack contiene casilleros. Cada producto tiene un nombre, descripcion, precio total y precio individual por producto, cantidad, tipo, dimensiones y peso , fecha de llegada y fecha de caducidad. Cada casilla contiene un area determinadaa y un peso máximo que soporta. Cada producto es enviado por un proveedor y es comprado por un cliente. De cada uno se conoce su nombre, carnet de identidad, numero de telefono, correo y dirección. Cuando un producto caduce pasa a ser una merma. En cada momento se desea saber la cantidad de dinero perdido en mermas, las ganancias mensuales, anuales y semanales. La cantidad de productos en stock actualmente. Que usuario autorizó la entrada y salida de productos respectivamente. Los usuarios se clasifican en administradores y almaceneros. Ademas se desea saber la ubicacion de cada producto en stock. los racks se ubican por pasillos. Se pueden destinar una serie de casillas para almacenar un tipo de productos específicos. Crea las tablas que modelen los datos anteriores.


## Migraciones

> dotnet ef migrations add DeleteFieldsProductTable --context GestorDeAlmacenesDBContext --output-dir Migrations/SqliteMigrations
> dotnet ef database update


## Base de datos

```sql
CREATE TABLE Productos (
    ID_Producto INT PRIMARY KEY,
    Nombre VARCHAR(255),
    Descripcion TEXT,
    Precio_Total DECIMAL(10,2),
    Precio_Unitario DECIMAL(10,2),
    Cantidad INT,
    Tipo VARCHAR(255),
    Alto DECIMAL(10,2),
    Ancho DECIMAL(10,2),
    Largo DECIMAL(10,2),
    Unidad_Dimensiones ENUM('cm', 'm', 'ft'),
    Peso DECIMAL(10,2),
    Fecha_Llegada DATE,
    Fecha_Caducidad DATE,
    EnAlmacen BOOLEAN DEFAULT FALSE
);

CREATE TABLE Casilleros (
    ID_Casillero INT PRIMARY KEY,
    ID_Rack INT,
    Area DECIMAL(10,2),
    Peso_Maximo DECIMAL(10,2),
    Alto DECIMAL(10,2),
    Ancho DECIMAL(10,2),
    Largo DECIMAL(10,2),
    Unidad_Dimensiones ENUM('cm', 'm', 'ft'),
    FOREIGN KEY (ID_Rack) REFERENCES Racks(ID_Rack)
);

CREATE TABLE Racks (
    ID_Rack INT PRIMARY KEY,
    Pasillo VARCHAR(255)
);

CREATE TABLE Ubicaciones (
    ID_Producto INT,
    ID_Casillero INT,
    Cantidad INT,
    FOREIGN KEY (ID_Producto) REFERENCES Productos(ID_Producto),
    FOREIGN KEY (ID_Casillero) REFERENCES Casilleros(ID_Casillero)
);

CREATE TABLE Proveedores (
    ID_Proveedor INT PRIMARY KEY,
    Nombre VARCHAR(255),
    CI VARCHAR(255),
    Telefono VARCHAR(255),
    Correo VARCHAR(255),
    Direccion VARCHAR(255)
);

CREATE TABLE Clientes (
    ID_Cliente INT PRIMARY KEY,
    Nombre VARCHAR(255),
    CI VARCHAR(255),
    Telefono VARCHAR(255),
    Correo VARCHAR(255),
    Direccion VARCHAR(255)
);

CREATE TABLE Mermas (
    ID_Producto INT,
    Cantidad INT,
    Fecha_Caducidad DATE,
    FOREIGN KEY (ID_Producto) REFERENCES Productos(ID_Producto)
);

CREATE TABLE Usuarios (
    ID_Usuario INT PRIMARY KEY,
    Nombre VARCHAR(255),
    Rol ENUM('Administrador', 'Almacenero')
);

CREATE TABLE Entradas (
    ID_Entrada INT PRIMARY KEY,
    ID_Producto INT,
    ID_Usuario INT,
    Cantidad INT,
    Fecha DATE,
    FOREIGN KEY (ID_Producto) REFERENCES Productos(ID_Producto),
    FOREIGN KEY (ID_Usuario) REFERENCES Usuarios(ID_Usuario)
);

CREATE TABLE Salidas (
    ID_Salida INT PRIMARY KEY,
    ID_Producto INT,
    ID_Usuario INT,
    Cantidad INT,
    Fecha DATE,
    FOREIGN KEY (ID_Producto) REFERENCES Productos(ID_Producto),
    FOREIGN KEY (ID_Usuario) REFERENCES Usuarios(ID_Usuario)
);

```

## Transacciones

Aquí están algunas de las transacciones SQL que se necesitan para el funcionamiento del sistema de gestión de almacenes:

1. **Registrar una entrada de producto:**
```sql
INSERT INTO Entradas (ID_Producto, ID_Usuario, Cantidad, Fecha)
VALUES (?, ?, ?, ?);

UPDATE Productos
SET Cantidad = Cantidad + ?, EnAlmacen = TRUE
WHERE ID_Producto = ?;

UPDATE Ubicaciones
SET Cantidad = Cantidad + ?
WHERE ID_Producto = ? AND ID_Casillero = ?;
```

2. **Registrar una salida de producto:**
```sql
INSERT INTO Salidas (ID_Producto, ID_Usuario, Cantidad, Fecha)
VALUES (?, ?, ?, ?);

UPDATE Productos
SET Cantidad = Cantidad - ?
WHERE ID_Producto = ?;

UPDATE Ubicaciones
SET Cantidad = Cantidad - ?
WHERE ID_Producto = ? AND ID_Casillero = ?;
```

3. **Registrar una merma de producto:**
```sql
INSERT INTO Mermas (ID_Producto, Cantidad, Fecha_Caducidad)
VALUES (?, ?, ?);

UPDATE Productos
SET Cantidad = Cantidad - ?
WHERE ID_Producto = ?;

UPDATE Ubicaciones
SET Cantidad = Cantidad - ?
WHERE ID_Producto = ? AND ID_Casillero = ?;
```

4. **Consultar la cantidad de productos en stock:**
```sql
SELECT SUM(Cantidad)
FROM Productos
WHERE EnAlmacen = TRUE;
```

5. **Consultar la cantidad de productos en una casilla determinada:**
```sql
SELECT Cantidad
FROM Ubicaciones
WHERE ID_Casillero = ?;
```

6. **Consultar la ubicación de un producto:**
```sql
SELECT ID_Casillero
FROM Ubicaciones
WHERE ID_Producto = ?;
```

