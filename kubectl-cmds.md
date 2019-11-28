# kubectl 命令

```cmd

kubectl create secret docker-registry netcorepal --docker-server=docker.pkg.github.com --docker-username='username' --docker-password='' --docker-email=''

kubectl apply -f .\aspnetcore-healthchecks-service.yaml

kubectl apply -f .\aspnetcore-healthchecks-deployment.yaml

## 安装 ingress
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/master/deploy/static/mandatory.yaml
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/master/deploy/static/provider/cloud-generic.yaml
kubectl apply -f .\ingress-port.yaml
```
