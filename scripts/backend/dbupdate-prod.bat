@echo off

echo Started

SET currentPath=%~dp0
SET apiPath=%~dp0\..\..\..\HashtagAggregatorCommon\backend\HashtagAggregator.Data.DataAccess

cd %apiPath% 

dotnet ef database update -e prod -c SqlApplicationDbContext


