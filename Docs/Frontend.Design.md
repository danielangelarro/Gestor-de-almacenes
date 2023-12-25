# Organización de las carpetas

```bash
src
|-- assets
|-- components
|-- router
|-- services
|-- store
|-- views
```

Qué podría ir en cada carpeta:

- **assets**: Aquí puedes poner los archivos estáticos como imágenes, estilos (CSS) y fuentes.
- **components**: Esta carpeta contendrá todos tus componentes Vue. Puedes dividirlos en subcarpetas según su función o la página en la que se utilizan.
- **router**: Aquí es donde configurarías vue-router, que es la biblioteca de enrutamiento oficial para Vue.js.
- **services**: Esta carpeta puede contener los servicios que interactúan con la API. Cada servicio podría ser responsable de hacer llamadas a un punto final específico de la API.
- **store**: Si estás utilizando Vuex para la gestión del estado, aquí es donde configurarías tu store.
- **views**: Esta carpeta contendría los componentes de nivel superior que actúan como vistas.
