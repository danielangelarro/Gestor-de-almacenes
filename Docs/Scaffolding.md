# Organización de carpetas

```
📦src
 ┣ 📂api
 ┃ ┣ 📂commands
 ┃ ┃ ┣ 📜CrearProducto.js
 ┃ ┃ ┣ 📜ActualizarProducto.js
 ┃ ┃ ┣ 📜EliminarProducto.js
 ┃ ┃ ┣ 📜CrearCasillero.js
 ┃ ┃ ┣ 📜ActualizarCasillero.js
 ┃ ┃ ┗ 📜EliminarCasillero.js
 ┃ ┗ 📂queries
 ┃   ┣ 📜ObtenerProducto.js
 ┃   ┣ 📜ObtenerTodosProductos.js
 ┃   ┣ 📜ObtenerCasillero.js
 ┃   ┣ 📜ObtenerTodosCasilleros.js
 ┃   ┗ 📜ObtenerTodosCasillerosPorRack.js
 ┣ 📂components
 ┃ ┣ 📂Producto
 ┃ ┃ ┣ 📜CrearProducto.vue
 ┃ ┃ ┣ 📜ActualizarProducto.vue
 ┃ ┃ ┗ 📜EliminarProducto.vue
 ┃ ┣ 📂Casillero
 ┃ ┃ ┣ 📜CrearCasillero.vue
 ┃ ┃ ┣ 📜ActualizarCasillero.vue
 ┃ ┃ ┗ 📜EliminarCasillero.vue
 ┃ ┗ 📂Rack
 ┃   ┣ 📜CrearRack.vue
 ┃   ┣ 📜ActualizarRack.vue
 ┃   ┗ 📜EliminarRack.vue
 ┣ 📂store
 ┃ ┣ 📂modules
 ┃ ┃ ┣ 📜producto.js
 ┃ ┃ ┣ 📜casillero.js
 ┃ ┃ ┗ 📜rack.js
 ┃ ┗ 📜index.js
 ┣ 📂views
 ┃ ┣ 📜ProductoView.vue
 ┃ ┣ 📜CasilleroView.vue
 ┃ ┗ 📜RackView.vue
 ┣ 📜App.vue
 ┗ 📜main.js

```

# División en Componentes Vue

1. `App.vue`: Este sería el componente principal que engloba todos los demás componentes.

2. `Sidebar.vue`: Este componente representaría la barra lateral de la aplicación.

3. `SidebarBrand.vue`: Este componente representaría la marca en la barra lateral.

4. `NavItem.vue`: Este componente representaría un elemento individual en la barra de navegación.

5. `SidebarDivider.vue`: Este componente representaría un divisor en la barra lateral.

6. `Topbar.vue`: Este componente representaría la barra superior de la aplicación.

7. `TopbarSearch.vue`: Este componente representaría la función de búsqueda en la barra superior.

8. `TopbarAlerts.vue`: Este componente representaría las alertas en la barra superior.

9. `TopbarMessages.vue`: Este componente representaría los mensajes en la barra superior.

10. `TopbarUser.vue`: Este componente representaría la información del usuario en la barra superior.

11. `ContentWrapper.vue`: Este componente representaría el contenedor principal del contenido de la aplicación.

12. `PageContent.vue`: Este componente representaría el contenido de la página.

13. `Footer.vue`: Este componente representaría el pie de página de la aplicación.

14. `Modal.vue`: Este componente representaría un modal genérico en la aplicación.

15. `LogoutModal.vue`: Este componente representaría el modal de cierre de sesión.
