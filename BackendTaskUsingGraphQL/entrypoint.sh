#!/bin/bash
set -e

echo "Applying EF Core migrations..."
dotnet ef database update --no-build

echo "Starting application..."
exec dotnet BackendTaskUsingGraphQL.dll
