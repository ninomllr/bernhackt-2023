FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5282

ENV ASPNETCORE_URLS=http://+:5282

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["Server/BernHackt-2022.Server.csproj", "Server/"]
RUN dotnet restore "Server/BernHackt-2022.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "BernHackt-2022.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BernHackt-2022.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BernHackt-2022.Server.dll"]
EXPOSE 5282