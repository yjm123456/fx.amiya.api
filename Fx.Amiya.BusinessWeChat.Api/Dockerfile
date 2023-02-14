FROM fx-net5:0.0.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5630

FROM base AS final
WORKDIR /app
COPY . /app
ENTRYPOINT ["dotnet", "Fx.Amiya.BusinessWeChat.Api.dll"]

##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["Fx.Amiya.BusinessWeChat.Api/Fx.Amiya.BusinessWeChat.Api.csproj", "Fx.Amiya.BusinessWeChat.Api/"]
#COPY ["../方旋统一登录认证库/src/Fx.Authorization/Fx.Authorization.csproj", "../方旋统一登录认证库/src/Fx.Authorization/"]
#COPY ["../方旋统一登录认证库/src/Fx.Identity.Core/Fx.Identity.Core.csproj", "../方旋统一登录认证库/src/Fx.Identity.Core/"]
#COPY ["../方旋基础类库/业务基础类库/方旋业务基础类库/Fx.Infrastructure.DataAccess.EFCore/Fx.Infrastructure.DataAccess.EFCore.csproj", "../方旋基础类库/业务基础类库/方旋业务基础类库/Fx.Infrastructure.DataAccess.EFCore/"]
#COPY ["../方旋基础类库/业务基础类库/方旋业务基础类库/Fx.Infrastructure/Fx.Infrastructure.csproj", "../方旋基础类库/业务基础类库/方旋业务基础类库/Fx.Infrastructure/"]
#COPY ["src/Fx.Amiya.Common/Fx.Amiya.Common.csproj", "src/Fx.Amiya.Common/"]
#COPY ["../方旋短信平台/src/Fx.Sms.Aliyun/Fx.Sms.Aliyun.csproj", "../方旋短信平台/src/Fx.Sms.Aliyun/"]
#COPY ["../方旋短信平台/src/Fx.Sms.Core/Fx.Sms.Core.csproj", "../方旋短信平台/src/Fx.Sms.Core/"]
#COPY ["src/Fx.Amiya.Service/Fx.Amiya.Service.csproj", "src/Fx.Amiya.Service/"]
#COPY ["src/Fx.Amiya.IDal/Fx.Amiya.IDal.csproj", "src/Fx.Amiya.IDal/"]
#COPY ["src/Fx.Amiya.DbModels/Fx.Amiya.DbModels.csproj", "src/Fx.Amiya.DbModels/"]
#COPY ["src/Fx.Amiya.SyncOrder.JD/Fx.Amiya.SyncOrder.JD.csproj", "src/Fx.Amiya.SyncOrder.JD/"]
#COPY ["src/JDSDK/jos-sdk-net.csproj", "src/JDSDK/"]
#COPY ["src/Fx.Amiya.Dto/Fx.Amiya.Dto.csproj", "src/Fx.Amiya.Dto/"]
#COPY ["src/Fx.Amiya.SyncOrder.Core/Fx.Amiya.SyncOrder.Core.csproj", "src/Fx.Amiya.SyncOrder.Core/"]
#COPY ["src/Fx.Amiya.IService/Fx.Amiya.IService.csproj", "src/Fx.Amiya.IService/"]
#COPY ["../方旋通用基础库/src/Fx.Common/Fx.Common.csproj", "../方旋通用基础库/src/Fx.Common/"]
#COPY ["../方旋基础类库/方旋微信SDK/src/Fx.Weixin.MP/Fx.Weixin.MP.csproj", "../方旋基础类库/方旋微信SDK/src/Fx.Weixin.MP/"]
#COPY ["../方旋基础类库/web基础类库/方旋Web基础类库/Fx.Open.Infrastructure.Web/Fx.Open.Infrastructure.Web.csproj", "../方旋基础类库/web基础类库/方旋Web基础类库/Fx.Open.Infrastructure.Web/"]
#COPY ["src/Fx.Amiya.Infrastructure/Fx.Amiya.Infrastructure.csproj", "src/Fx.Amiya.Infrastructure/"]
#COPY ["src/Fx.Amiya.Domain.IRepository/Fx.Amiya.Domain.IRepository.csproj", "src/Fx.Amiya.Domain.IRepository/"]
#COPY ["src/Fx.Amiya.Domain/Fx.Amiya.Domain.csproj", "src/Fx.Amiya.Domain/"]
#COPY ["../方旋领域驱动开发基础类库/src/Fx.Domain.Base/Fx.Domain.Base.csproj", "../方旋领域驱动开发基础类库/src/Fx.Domain.Base/"]
#COPY ["src/Core/Fx.Amiya.Core/Fx.Amiya.Core.csproj", "src/Core/Fx.Amiya.Core/"]
#COPY ["src/Core/Fx.Amiya.Core.Infrastructure/Fx.Amiya.Core.Infrastructure.csproj", "src/Core/Fx.Amiya.Core.Infrastructure/"]
#COPY ["src/Core/Fx.Amiya.Core.Dto/Fx.Amiya.Core.Dto.csproj", "src/Core/Fx.Amiya.Core.Dto/"]
#COPY ["src/Fx.Amiya.Dal/Fx.Amiya.Dal.csproj", "src/Fx.Amiya.Dal/"]
#COPY ["../方旋统一登录认证库/src/Fx.Authentication/Fx.Authentication.csproj", "../方旋统一登录认证库/src/Fx.Authentication/"]
#COPY ["../方旋基础类库/业务基础类库/方旋业务基础类库/Fx.Infrastructure.DataAccess.Mongodb.Standard/Fx.Infrastructure.DataAccess.Mongodb.Standard.csproj", "../方旋基础类库/业务基础类库/方旋业务基础类库/Fx.Infrastructure.DataAccess.Mongodb.Standard/"]
#RUN dotnet restore "Fx.Amiya.BusinessWeChat.Api/Fx.Amiya.BusinessWeChat.Api.csproj"
#COPY . .
#WORKDIR "/src/Fx.Amiya.BusinessWeChat.Api"
#RUN dotnet build "Fx.Amiya.BusinessWeChat.Api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Fx.Amiya.BusinessWeChat.Api.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Fx.Amiya.BusinessWeChat.Api.dll"]

