MIGRATION_NAME="add-shit"

## Add Migration 
cd ./HomeBooth.Data && dotnet ef --startup-project ../HomeBooth.Web/ migrations add $MIGRATION_NAME 

## Update Database
cd ./HomeBooth.Data && dotnet ef --startup-project ../HomeBooth.Web/ database update


- user will register
- user will choose account type
    - user will fill in information
