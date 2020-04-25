docker build --no-cache -f  .\src\HealthChecksDemo\Dockerfile -t docker.pkg.github.com/netcorepal/healthchecksdemo/aspnetcore-healthchecks:v1.0 .
# docker push docker.pkg.github.com/netcorepal/healthchecksdemo/aspnetcore-healthchecks:v1.0

"Any key to exit"  ;
Read-Host | Out-Null ;
Exit
