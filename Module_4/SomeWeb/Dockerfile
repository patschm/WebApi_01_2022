FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["SomeWeb/SomeWeb.csproj", "SomeWeb/"]
RUN dotnet restore "SomeWeb/SomeWeb.csproj"
COPY . .
WORKDIR "/src/SomeWeb"
RUN dotnet build "SomeWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SomeWeb.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SomeWeb.dll"]
