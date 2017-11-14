FROM microsoft/dotnet:1.1.2-runtime
WORKDIR /app
COPY ./Zimmergren.NetCore.DockerDemo/bin/Debug/netcoreapp1.1/publish .
CMD ["dotnet", "Zimmergren.NetCore.DockerDemo.dll"]