# Use an official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Install Tesseract and its dependencies
RUN apt-get update && \
    apt-get install -y tesseract-ocr libtesseract-dev wget && \
    rm -rf /var/lib/apt/lists/* 

# Set the working directory in the container
WORKDIR /app

# Copy the project files to the container
COPY . ./

# Restore and build the project
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Use a runtime image for the final container
FROM mcr.microsoft.com/dotnet/runtime:7.0

# Copy the built application from the build container
WORKDIR /app
COPY --from=build-env /app/out .

# Set Tesseract path (if required)
ENV TESSDATA_PREFIX=/usr/share/tesseract-ocr/4.00/tessdata/

# Expose the container's entry point
ENTRYPOINT ["dotnet", "TesseractTest.dll"]
