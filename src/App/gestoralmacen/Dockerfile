# Establecer la imagen base
FROM node:14 as build-stage
WORKDIR /app

# Instalar dependencias
COPY package*.json ./
RUN npm install

# Copiar el resto del código fuente y construir la aplicación
COPY . .
RUN npm run build

# Usar nginx para servir la aplicación
FROM nginx:stable-alpine
COPY --from=build-stage /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]