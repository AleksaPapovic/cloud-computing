#!/bin/bash
set -e

# Create a new database
psql -v ON_ERROR_STOP=1 <<-EOSQL
    CREATE DATABASE mdb;
EOSQL
