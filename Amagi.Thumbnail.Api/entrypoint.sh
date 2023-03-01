hostip=$(getent hosts host.docker.internal | awk '{ print $1 }');[ -n "$hostip" ] && [ "$ASPNETCORE_ENVIRONMENT" == "Development" ]
dotnet ./Amagi.Thumbnail.Api.dll