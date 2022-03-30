FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /src
COPY . /src/ 
RUN dotnet publish -c release -o /app
COPY . .

# Run production app with another image
FROM mcr.microsoft.com/dotnet/aspnet:6.0


# Set port 
CMD ASPNETCORE_URLS=http://*:$PORT dotnet hmrc_booking_system_backend.dll