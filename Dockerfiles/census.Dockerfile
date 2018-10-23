FROM node:9.6.1 as build
WORKDIR /src
COPY census/ ./
RUN npm install

RUN npm run build

FROM nginx:1.13.9-alpine AS base
FROM base AS census
COPY --from=build /src/build /usr/share/nginx/html
COPY --from=build /src/run.sh /
RUN chmod 755 run.sh

EXPOSE 80
CMD ["./run.sh"]
