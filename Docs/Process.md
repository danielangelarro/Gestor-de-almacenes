# Herramientas para crear el proyecto


## Procesos que maneja la aplicación

1. **Registro de productos**: Cuando un producto entra al almacén, se registra en la base de datos con su nombre, descripción, precio total, precio individual, cantidad, tipo, dimensiones, peso, fecha de llegada y fecha de caducidad.

2. **Asignación de ubicación**: Se reserva una ubicación para el producto que corresponde a un casillero en un rack específico. Cada rack contiene varios casilleros y cada casillero tiene un área y un peso máximo que puede soportar.

3. **Gestión de proveedores y clientes**: Cada producto es asociado con un proveedor que lo envía y un cliente que lo compra. De cada uno se registra su nombre, carnet de identidad, número de teléfono, correo y dirección. Se mantiene un registro de todos los productos suministrados por un proveedor y comprados por un cliente. Esto permite tener un historial de las transacciones y facilita la gestión de las relaciones con proveedores y clientes.

4. **Gestión de mermas**: Cuando un producto caduca, se registra como una merma. Se mantiene un registro de la cantidad de dinero perdido en mermas.

5. **Informes financieros**: Se generan informes de las ganancias mensuales, anuales y semanales basados en las entradas y salidas de productos.

6. **Inventario**: Se mantiene un registro de la cantidad de productos en stock. Se puede consultar la ubicación de cada producto en stock en cualquier momento.

7. **Gestión de usuarios**: Se registra qué usuario autorizó la entrada y salida de productos. Los usuarios se clasifican en administradores y almaceneros.

8. **Ubicación de productos**: Se mantiene un registro de la ubicación de cada producto en stock. Los racks se ubican por pasillos y se pueden destinar una serie de casillas para almacenar un tipo de productos específicos.

9. **Entrada de productos**: Cuando un producto es enviado por un proveedor, se registra su entrada en la base de datos. Se registra la información del producto y se asigna una ubicación en un casillero específico. El usuario que autoriza la entrada del producto también se registra.

10. **Salida de productos**: Cuando un producto es comprado por un cliente, se registra su salida de la base de datos. Se actualiza la cantidad de producto en stock y se registra el usuario que autorizó la salida del producto.

## Operaciones a implementar por cada Proceso
Por supuesto, aquí está la tabla reestructurada con "Commands" y "Queries" como columnas:

| Proceso | Commands | Queries |
|---|---|---|
| Registro de productos | ❌ AddProduct <br> ❌ UpdateProduct | ❌ GetProductById <br> ❌ GetAllProducts |
| Asignación de ubicación | ❌ AssignLocationToProduct | ❌ GetLocationOfProduct |
| Gestión de proveedores y clientes | ❌ AddProvider <br> ❌ AddCustomer <br> ❌ UpdateProvider <br> ❌ UpdateCustomer | ❌ GetProviderById <br> ❌ GetCustomerById <br> ❌ GetAllProviders <br> ❌ GetAllCustomers |
| Gestión de mermas | ❌ AddWaste <br> ❌ UpdateWaste | ❌ GetWasteById <br> ❌ GetAllWastes |
| Informes financieros | | ❌ GetMonthlyRevenue <br> ❌ GetAnnualRevenue <br> ❌ GetWeeklyRevenue |
| Inventario | ❌ UpdateInventory | ❌ GetInventory <br> ❌ GetProductStock |
| Gestión de usuarios | ❌ AddUser <br> ❌ UpdateUser | ❌ GetUserById <br> ❌ GetAllUsers |
| Ubicación de productos | | ❌ GetProductLocation |
| Entrada de productos | ❌ AddProductEntry | ❌ GetProductEntryById <br> ❌ GetAllProductEntries |
| Salida de productos | ❌ AddProductExit | ❌ GetProductExitById <br> ❌ GetAllProductExits |
