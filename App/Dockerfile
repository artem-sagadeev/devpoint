FROM node:latest AS builder
COPY . ./app
WORKDIR /app
RUN npm install
RUN $(npm bin)/ng build --prod

FROM nginx:latest
COPY --from=builder /app/dist/app/ /usr/share/nginx/html