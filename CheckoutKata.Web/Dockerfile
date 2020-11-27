FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CheckoutKata.Web/CheckoutKata.Web.csproj", "CheckoutKata.Web/"]
RUN dotnet restore "CheckoutKata.Web/CheckoutKata.Web.csproj"
COPY . .
WORKDIR "/src/CheckoutKata.Web"
RUN dotnet build "CheckoutKata.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CheckoutKata.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CheckoutKata.Web.dll"]
