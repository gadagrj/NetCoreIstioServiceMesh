#!/bin/bash 

REVIEWS_IP="$(kubectl get svc | grep netcoreistio-users-svc | awk '{ print $4 }')"
REVIEWS_URL="http://${REVIEWS_IP}:8091/api/user"

while true;
do 
    curl -s "${REVIEWS_URL}"
    echo "" ;
    sleep 0.5
done

# while true; do curl -s "http://$(kubectl get svc | grep netcoreistio-users-svc | awk '{ print $4 }'):8091/api/user" ; echo "" ; sleep 0.5; done

# while true; do curl -s "http://netcoreistio-users-svc:8091/api/user" ; echo "" ; sleep 0.5; done