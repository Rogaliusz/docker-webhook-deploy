#!/bin/bash

sudo docker run --detach \
	--publish 80:80 \
	--name frontend \
	--restart always \
	rogaliusz/wws-lab-frontend