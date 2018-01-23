#!/bin/bash

sudo docker run --detach \
	--publish 8080:8080 \
	--name api \
	--restart always \
	rogaliusz/wws-lab-api