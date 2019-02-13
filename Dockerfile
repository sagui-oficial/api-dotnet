FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Sagui.Application/Sagui.Application.csproj", "Sagui.Application/"]
COPY ["Sagui.Service/Sagui.Service.csproj", "Sagui.Service/"]
COPY ["Sagui.Model/Sagui.Model.csproj", "Sagui.Model/"]
COPY ["Sagui.Business/Sagui.Business.csproj", "Sagui.Business/"]
COPY ["Sagui.Base/Sagui.Base.csproj", "Sagui.Base/"]
COPY ["Sagui.Data/Sagui.Data.csproj", "Sagui.Data/"]
COPY ["Sagui.Service.RequestResponse/Sagui.Service.RequestResponse.csproj", "Sagui.Service.RequestResponse/"]
COPY ["Sagui.DBNN/Sagui.DB.csproj", "Sagui.DBNN/"]
RUN dotnet restore "Sagui.Application/Sagui.Application.csproj"
COPY . .
WORKDIR "/src/Sagui.Application"
RUN dotnet build "Sagui.Application.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sagui.Application.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sagui.Application.dll"]
