#!/bin/bash

docker pull $1

docker stop $2
docker rm $2

sh ./dockers/$2.sh

