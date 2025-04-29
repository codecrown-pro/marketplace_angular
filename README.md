## About
A basic overview project showcasing an Angular WebApp connecting to a .NET backend API.

The Angular app retrieves a list of offers from an external API and displays them. A user can login and/or create a new offer. If not logged in, the user is given a random account name. The app paginates the offers into separate pages. State is kept synchronized across all views and all states while adhering to the Angular way of things.

The .NET backend showcases a Controller API project. Further, extravagant layers of abstraction have been used for demonstration purposes only. The BL, DAL, Core and API layers are all fleshed out. The main controllers follow the repository pattern for demonstration purposes, acknowledging that EFC is configured as a repository already.

The database is a SQLite database configurd via .NET EFC migrations.

## Install

```git clone git@github.com:Ink230/onlinemarketplace```

### Angular
Update the packages as you see fit (npm-check-updates...etc).

```
cd "Angular Client Frontend/marketplace"
npm install
ng serve --ssl
```

```
Enable localhost untrusted certificates in Chrome / Browser of choice
Export Chrome localhost certificate
Import that certificate to the Trusted Root Certification Authorities
Restart Chrome / Browser
```

### .NET

```
Open .sln
Change the db file location to use in the MarketplaceContext.cs file
Run 'Marketplace.Api', not 'IIS Express'
Confirm Swagger lists all the API endpoints and uses https
```

### Database
Place the included database file in the target location from MarketplaceContext.cs. Or configure the directory and then use EFC migrations to build the database file.
