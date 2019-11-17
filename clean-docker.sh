#!/bin/bash

echo "Deleting taskapp..."
docker ps -a | awk '{print $1, $2}' | grep taskapp | awk '{print $1}' | xargs -I {} docker rm -f {}

docker image ls | awk '{print $1, $3}' | grep taskapp | awk '{print $2}' | xargs -I {} docker image rm -f {}

echo "Deleting mariadb..."
docker ps -a | awk '{print $1, $2}' | grep maria | awk '{print $1}' | xargs -I {} docker rm -f {}

docker volume ls | awk '{print $1, $2}' | grep cqrs | awk '{print $2}' | xargs -I {} docker volume rm {}

docker network ls | awk '{print $1, $2}' | grep cqrs | awk '{print $2}' | xargs -I {} docker network rm {}


