# ReST cURL requests

###### get all blabs sorted by date (feed)

curl --location --insecure --request GET https://localhost:44377/blabs/

###### get blab by id

curl --location --insecure --request GET https://localhost:44377/blabs/7

###### create new blab

curl --location --insecure --request POST 'https://localhost:44377/blabs/' --header 'Content-Type: application/json' --data-raw '{"message": "A new message","userId": 1}'

###### update blab by id

curl --location --insecure --request POST 'https://localhost:44377/blabs/9' header 'Content-Type: application/json' --data-raw '{"message": "Updated","userId": 1}'

###### delete blab by id

curl --location --insecure --request DELETE 'https://localhost:44377/blabs/8' --header 'Content-Type: application/json' --data-raw ''

###### delete all blabs

curl --location --insecure --request DELETE 'https://localhost:44377/blabs/' --header 'Content-Type: application/json' --data-raw ''

