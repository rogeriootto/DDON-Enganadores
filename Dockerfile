FROM mcr.microsoft.com/dotnet/sdk:10.0

WORKDIR /src

COPY . .

# Database
EXPOSE 3306/tcp
# Game server
EXPOSE 52000/tcp
# Web server
EXPOSE 52099/tcp
# Login server
EXPOSE 52100/tcp
ENV DOTNET_EnableDiagnostics=0

CMD ["tail", "-f", "/dev/null"]
