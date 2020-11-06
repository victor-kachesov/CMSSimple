It's the simple cms project.

System requirements: docker with docker-compose.

For running project open /src folder and run command: docker-compose up

For stopping project run command: docker-compose down

Then all containers start the cms API will be available by url http://localhost:32770/api/article

The communication with api is in a JSON format.

Each api call should contain http header 'Authorization' with value '123456';

API methods:

GET /api/article - return list of articles
Request body contract example:
{
  "FiledToSort" : "Title",
  "Desc" : false,
  "Offset" : 0,
  "Limit" : 10
}

GET /api/article/{id} - return article by id
Where id - article id

POST /api/article - add new article
Request body contract example:
{
    "title": "title5",
    "body": "body5"
}

PUT /api/article/{id} - update article
Where id - article id
Request body contract example:
{
    "title": "title5",
    "body": "body5"
}

DELETE /api/article/{id} - delete article
Where id - article id