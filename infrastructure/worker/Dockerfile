FROM mcr.microsoft.com/dotnet/core/runtime:3.1

RUN apt-get update -y
RUN apt-get install -y iputils-ping 
RUN apt-get install -y telnet


COPY ./app /app
WORKDIR /app
ENTRYPOINT ["dotnet", "Owlvey.Falcon.Worker.dll"]
