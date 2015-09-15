FROM microsoft/aspnet

COPY . /app
WORKDIR /app
RUN ["dnu", "restore"]

WORKDIR /app/src/FinTech.Web
EXPOSE 5000
ENTRYPOINT ["dnx", "kestrel"]
