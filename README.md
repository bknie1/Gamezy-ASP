# Gamezy-ASP
My first ASP.NET app. Gamezy tracks players and games. Players will be able to login, add games to their play list, and see what their friends are playing. Ultimately, players will be able to see what games they have in common with their friends. This way, they can quickly coordinate multiplayer matches together.

## Entity Framework
This is my first time using Entity Framework. In brief, Entity serves as an ORM between our C# Identity model objects and a standard, SQL database.

### Packet Manager
#### Console Commands
- enable-migration
  - Adds "Code First" migration support.
- add-migration [ModelName]
  - Uses DbSet data from IdentityModels to generate a DbMigration model that will, in turn, be used to generate our SQL Database.
- update-database
  - Uses the Migration(s) we made in the previous step to create the SQL database.
  - Note: Migration history, in our database Tables folder, keeps track of our migrations.