# NetCore Istio Service mesh

Sample applicaiton to demonstrate microservice architecture using .Net Core and Istio. Below are the features which is implemented in the demo app

 1. Kubernetes Application deployment via demployment, service manifest files
 2. Traffice routing in Istio
 3. Canary rollout using 80-20 % rules 

# Output

**Kubernetes Deployment**
Set up minikube and deployed to local cluster 
![enter image description here](https://i.imgur.com/i76mX4f.png)

Istio Side car injected for each pods 
![enter image description here](https://i.imgur.com/Zcyzkis.png)

Traffic routing : Configured for 80-20% routing to route the service requests to different version (80 for version 1, 20% for version 2). 

![80% - 20% traffic routing for User service](https://i.imgur.com/SpMgZlN.png)


and Grafana Monitoring for Microservices 
![Grafana Monitoring](https://i.imgur.com/WDaZzSd.png)


