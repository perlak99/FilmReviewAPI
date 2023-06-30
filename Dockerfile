FROM mcr.microsoft.com/mssql/server

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=admin
ENV MSSQL_DB_NAME=filmReviewTestDb

COPY DockerScripts/ /docker-entrypoint-initdb.d/