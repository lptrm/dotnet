FROM mcr.microsoft.com/dotnet/sdk:6.0

# Accept UID and GID as build arguments
ARG USER_ID=1000
ARG GROUP_ID=1000

# Create a group and user
RUN groupadd -g ${GROUP_ID} dotnetuser && \
    useradd -u ${USER_ID} -g dotnetuser -m dotnetuser

# Set DOTNET_CLI_HOME for the dotnetuser
ENV DOTNET_CLI_HOME=/home/dotnetuser/.dotnet

USER dotnetuser

# Set the working directory
WORKDIR /workspace
