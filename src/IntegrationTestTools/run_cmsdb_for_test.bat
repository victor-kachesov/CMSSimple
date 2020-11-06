docker build -t cmsdb-test . && ^
docker run --name cmsdb-test -p 21433:1433 -d cmsdb-test