# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar todos os arquivos do repositório para dentro do container
COPY . ./

# Restaurar as dependências a partir do arquivo de solução
RUN dotnet restore FrioAPI.sln

# Buildar o projeto no modo Release
RUN dotnet publish FrioAPI.sln -c Release -o /publish

# Etapa de runtime (imagem mais leve para executar)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar o conteúdo publicado da etapa anterior para o container
COPY --from=build /publish .

# Expor as portas que serão usadas pela aplicação
EXPOSE 5000
EXPOSE 5001

# Configurar o comando de entrada para iniciar sua API
ENTRYPOINT ["dotnet", "FrioAPI.Api.dll"]