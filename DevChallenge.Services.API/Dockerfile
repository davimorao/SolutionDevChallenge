FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DevChallenge.Services.API/DevChallenge.Services.API.csproj", "DevChallenge.Services.API/"]
RUN dotnet restore "DevChallenge.Services.API/DevChallenge.Services.API.csproj"
COPY . .
WORKDIR "/src/DevChallenge.Services.API"
RUN dotnet build "DevChallenge.Services.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DevChallenge.Services.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DevChallenge.Services.API.dll"]