#!/usr/bin/env bash
set -euo pipefail

FILTER="${1:-}"

CMD='rm -f /src/dotnet && dotnet build WebApi.Tests/WebApi.Tests.csproj -c Release && ./WebApi.Tests/bin/Release/net10.0/WebApi.Tests'

if [[ -n "$FILTER" ]]; then
  CMD+=" --filter-trait 'Category=${FILTER}'"
fi

docker compose --env-file "${ENV_FILE:-.env}" run --rm --entrypoint /bin/bash test-runner -lc "$CMD"
