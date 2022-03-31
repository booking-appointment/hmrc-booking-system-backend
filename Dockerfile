FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /src
COPY . /src/ 
RUN dotnet build
RUN dotnet publish -c release -o /app


# Run production app with another image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./

# Set port 
CMD ASPNETCORE_URLS=http://*:$PORT dotnet hmrc-booking-system-backend.dll