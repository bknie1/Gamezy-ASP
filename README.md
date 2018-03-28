# Gamezy-ASP
My first ASP.NET app. Gamezy tracks players and games. Players will be able to login, add games to their play list, and see what their friends are playing. Ultimately, players will be able to see what games they have in common with their friends. This way, they can quickly coordinate multiplayer matches together.

## MVC 5
The .NET MVC Framework allows us to quickly realize the relationships between objects and how we present that information to the user.

### Model Examples
  - Player: UID, Name, location, a brief bio. We should probably rely on a SQL relation between what the Player is playing (e.g. player PLAYS game).
  - Game: UID, Name, Genre, Description. Games may be linked by company or series.
  
### Controller Examples
  - Here, we can use Entity to query our DB, return that info, and translate it into something C#-esque.
  - The Player controller can be used to populate a View with n number of Players or, if an integer is passed, a specific player.
  - Similarly, we can list Games. Both of these could feature SortBy or by UID.
  - Regardless, this is where we discriminate against our database and pull exactly what we want to present to the user.
  - This data gets passed to the appropriate View.

### View Examples
  - The Controller isolated the data we're interested in and now we pull it into the appropriate View for the user.
  - Here, we can use **Razor C# Markup** to embed C# into our HTML.
  - If we're displaying Player or Game data, each Player or Game may, in itself, be a partial view comprised of information for that specific Model. e.g. In our GameList view, each Game may have its own partial. This reduces clutter.

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
