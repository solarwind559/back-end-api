### Project structure:
```
Base_Directory
├── Backend
│   ├── Api1
│   │   ├── Controllers
│   │   ├── program.cs
│   │   ├── [..] other files and directories
├── Frontend
│   ├── client-side-app
│   │   ├── src
│   │   │   ├── app
│   │   │   ├── index.html
│   │   │   ├── [..] other files and directories
│   │   ├── [..] other files and directories
```
#### Database must be connected
##### For this purpose, I used SQLite database and packages

### BackEnd
Run in console and download all listed packages
```
dotnet list package
```
Run migrations in console 
```
Add-Migration InitialMigration -Context ApplicationDbContext
Add-Migration InitialMigrationForIdentity -Context Api1.Models.IdentityDbContext
Update-Database -Context ApplicationDbContext
Update-Database -Context Api1.Models.IdentityDbContext
```
Start the app 
