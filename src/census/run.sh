#!/bin/sh

find /usr/share/nginx/html/static/js -type f -name "*.js" -exec ./envsubst.sh {} \;

nginx -g 'daemon off;'
