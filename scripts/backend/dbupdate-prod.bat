@echo off

echo Started

SET currentPath=%~dp0
SET apiPath=%~dp0\..\..\..\HashtagAggregator\WebAPI\HashtagAggregator.Data.DataAccess

cd %apiPath% 

dotnet ef database update -e prod -c SqlApplicationDbContext


