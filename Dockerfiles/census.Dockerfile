FROM node:9.6.1 as build
ARG BUILD_NUMBER=0.0.0

WORKDIR /src
COPY src/census/nginx.conf /etc/nginx/nginx.conf
COPY src/census/ ./

RUN mv -f ./src/config.docker.json ./src/config.json
RUN echo {\"Version\":\"${BUILD_NUMBER}\"} > ./src/version.json
RUN npm install --silent
RUN npm run build

FROM nginx:1.13.9-alpine AS base
FROM base AS census
COPY --from=build /src/build /usr/share/nginx/html
COPY --from=build /src/run.sh /
COPY --from=build /src/envsubst.sh /
RUN chmod 755 run.sh
RUN chmod 755 envsubst.sh

EXPOSE 80
CMD ["./run.sh"]
