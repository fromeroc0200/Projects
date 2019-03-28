Se instala EntityFramework desde nuget pakage en los 3 proyectos Data, Services, WebApi
Se instala Unity.WebApi para manejar dependency injection

------------- WEB API CONFIGURATION--------------------------

--Excecute nuget console
- Install-Package Microsoft.AspNet.WebApi.Cors 
# NuGet Command : Fix Version Compactability of Cors and Http
- Update-Package Microsoft.AspNet.WebApi -reinstall
- Install-Package Microsoft.AspNet.WebApi.Core

------------- LOGGING CONFIGURATION -------------------------

- Create ILoggerManager interface and LoggerManager class
- Install NLog nuget package: Install-Package NLog.Extensions.Logging

- Add the next code in web.config:

				<configSections>
					<section name="nlog" type="NLog.Config.ConfigSectionHandler, NLog" />
				  </configSections>


				  <nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
					  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
					  autoReload="true"
					  internalLogLevel="Trace"
					  internalLogFile="${basedir}\internal_logs\internallog.txt">

					<targets>
					  <target name="logfile" xsi:type="File"
							  fileName="${basedir}/logs/${shortdate}_logfile.txt"
							  layout="${longdate} ${level:uppercase=true} ${message}"/>
					</targets>

					<rules>
					  <logger name="*" minlevel="Debug" writeTo="logfile" />
					</rules>
				  </nlog>

- Inject the ILoggerManager interface in UnityConfig.cs
		container.RegisterType<ILoggerManager, LoggerManager>();

