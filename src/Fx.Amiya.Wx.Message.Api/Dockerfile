#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM aspnetcore3.1-fx:0.0.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5622

FROM base AS final
WORKDIR /app
COPY . /app
ENTRYPOINT ["dotnet", "Fx.Amiya.Wx.Message.Api.dll"]