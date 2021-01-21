### Run Docker Compose file to start Pulsar Container and Pulsar Manager Container
`docker-compose up`

### Connect to pulsar-dashboard shell
`docker exec -it puslar-dashboard sh`

### Then Execute the following to create admin account for Pulsar Manager

`apk update`
`apk add`
`apk add --update curl`

`CSRF_TOKEN=$(curl http://localhost:7750/pulsar-manager/csrf-token)`

`curl -H 'X-XSRF-TOKEN: $CSRF_TOKEN' -H 'Cookie: XSRF-TOKEN=$CSRF_TOKEN;' -H "Content-Type: application/json" -X PUT http://localhost:7750/pulsar-manager/users/superuser -d '{"name": "admin", "password": "apachepulsar", "description": "test", "email": "username@test.org"}'`

### Pulsar Admin UI
http://localhost:9527/
