docker build -f Dockerfile -t  docker.pkg.github.com/netcorepal/healthchecksdemo/aspnetcore-healthchecks:v1.0 ..\..\.
docker push docker.pkg.github.com/netcorepal/healthchecksdemo/aspnetcore-healthchecks:v1.0
pause
