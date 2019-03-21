# Nlog_Test

- -主要是练习一下NLog的使用


### 安装	
Nuget获取
### 配置寻找	
会自动寻找在应用程序目录下的NLog.config（大小写敏感）
### 如何配置config
```
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
      xsi:schemaLocation="http://www.nlog-project.org/schemas/NLog.xsd NLog.xsd"
      autoReload="true"
      throwExceptions="false"
      internalLogLevel="Off" internalLogFile="c:\temp\nlog-internal.log">
  <targets>
    <target xsi:type="File" name="debug1" fileName="..\..\Layout\CsvLayout.config"/>
  </targets>
  <rules>
    <logger name="*" level="Debug" writeTo="debug1" />
  </rules>
</nlog>
 ```
 
#### 配置主要有两个节点
##### 1 	Target	
###### Type	
定义日志信息输出到哪个平台	
####### File	

如果是File，后面还需要跟Filename参数定义输出到哪个文件	 	 
###### Layouts	
定义日志输出的格式	 	 
	 
###### Name	
定义这个Target的名字，好让Rule调用
 
更多的查看https://nlog-project.org/config/?tab=targets

##### 2	Rules	
######  Name	
定义Logger名称，程序可以根据名称寻找不同的logger实例	 
######   writeTo	
定义日志输出到哪个Target，用逗号分离	 

###  应用程序应用	
#### 构造实例	 
```
private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
```
#### 应用	
```
logger.Fatal("Fatal");
logger.Error("Error");
logger.Warn("Warn");
logger.Info("Info");
logger.Debug("Debug");
```

FAQ	如还需要更多配置，请看https://nlog-project.org/config/?tab=targets


