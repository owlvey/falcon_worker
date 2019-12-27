FROM mcr.microsoft.com/dotnet/core/runtime:3.1

RUN apt-get update -y
RUN apt-get install -y iputils-ping 

COPY ./app /app
WORKDIR /app
ENTRYPOINT ["dotnet", "Owlvey.Falcon.Worker.dll"]
