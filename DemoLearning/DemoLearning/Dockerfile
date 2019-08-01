FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["DemoLearning/DemoLearning.csproj", "DemoLearning/"]
RUN dotnet restore "DemoLearning/DemoLearning.csproj"
COPY . .
WORKDIR "/src/DemoLearning"
RUN dotnet build "DemoLearning.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DemoLearning.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DemoLearning.dll"]