# Stage 1: Build the angular app
FROM node:18 AS build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build --prod

# Stage 2: Serve the app with nginx server
FROM nginx:alpine
COPY --from=build /app/dist/expense-tracker-frontend /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]