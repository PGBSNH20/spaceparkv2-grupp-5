#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SpaceParkAPI/SpaceParkAPI.csproj", "SpaceParkAPI/"]
RUN dotnet restore "SpaceParkAPI/SpaceParkAPI.csproj"
COPY . .
WORKDIR "/src/SpaceParkAPI"
RUN dotnet build "SpaceParkAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaceParkAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpaceParkAPI.dll"]


#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#COPY *.csproj .
#RUN dotnet restore
#
#COPY . .
#RUN dotnet publish -c release -o /app --no-restore
#
#FROM mcr.microsoft.com/dotnet/runtime:5.0
#WORKDIR /app
#COPY --from=build /app .
#ENTRYPOINT ["dotnet"], "SpaceParkAPI.dll"]
#
