# Migrate Tables in Heroku DB

## 1. Copy Heroku DB URI
`heroku config -a <APPNAME>` to display DATABASE_URL, then copy the string value

## 2. Run the code to manually migrate the DB on Heroku
`DATABASE_URL="<postgres.URI>" dotnet ef database update`