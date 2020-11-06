# It's the simple CMS project.

System requirements: docker with docker-compose.

For running project open /src folder and run command: `docker-compose up`

For stopping project run command: `docker-compose down`

Then all containers start CMS API will be available by url http://localhost:32770/api/article

The communication with api is in a JSON format.

To switch communication with api to XML format add http header 'Accept' with value 'application/xml' to each request.

Each api request should contain http header 'Authorization' with value '123456';

# API methods:

`GET /api/article` - return list of articles
Request body contract example:
```
{
  "FiledToSort" : "Title",
  "Desc" : false,
  "Offset" : 0,
  "Limit" : 10
}
```

`GET /api/article/{id}` - return article by id
Where id - article id

`POST /api/article` - add new article
Request body contract example:
```
{
    "title": "title5",
    "body": "body5"
}
```

`PUT /api/article/{id}` - update article
Where id - article id
Request body contract example:
```
{
    "title": "title5",
    "body": "body5"
}
```

`DELETE /api/article/{id}` - delete article
Where id - article id

# Tests
Solution contains CMSSimple.IntegrationTest project.
Test can be ran from Visual Studio.
Before running the test you should execute file run_cmsdb_for_test.bat from src/IntegrationTestTools folder.
It starts new docker container with test database.
After running the test you should execute file stop_and_remove_cmsdb_for_test.bat from src/IntegrationTestTools folder.