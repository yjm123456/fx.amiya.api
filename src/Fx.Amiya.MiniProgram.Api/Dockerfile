FROM fx-net5:0.0.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5621

FROM base AS final
WORKDIR /app
COPY . /app
ENTRYPOINT ["dotnet", "Fx.Amiya.MiniProgram.Api.dll"]