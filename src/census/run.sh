#!/bin/sh

# Disabled for now. Sorry. Not quite ready to go.
#find /usr/share/nginx/html/static/js -type f -name "*.js" -exec ./envsubst.sh {} \;

nginx -g 'daemon off;'
