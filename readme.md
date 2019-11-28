# ASP.NET Core Health Checks Demo

## 官网文档

<https://docs.microsoft.com/zh-cn/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-3.0>

## 注意

请在配置appsettings.json里替换自己的钉钉机器人，并设置安全认证为关键词认证，关键词为"健康检查"

替换your-token

 ```Json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "MyFirstHealthCheckPublisherOptions": {
    "DingTalkUrl": "https://oapi.dingtalk.com/robot/send?access_token=your-token"
  }
}
 ```
