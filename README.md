# Mario's Specialty Food Products

## By Lois Choi

#### _This application focuses on comprehensive unit and controller testing in .Net., 10.20.17_


## Description

_This site shows all of Mario's Specialty Food Products._

|| Behavior  | Input  | Output  |
|---|---|---|---|
|1| User may view all products in the products view. | Click `Products`  | View displays all products |
|2| User may click on a product to view its details | Click specific `Product`| View displays product details|
|3| Site admin can add, edit, delete products. | Click `Add` or `Edit` or `Delete`  | View displays proper form |
|4| User may view products average rating | Click `Product` | View average rating in details |
|5| User may add a review to a product | Click `Add review` | Review is added to review section of page |
|6| User may 3 most recently added items and 3 items with the most reviews on the Home page  | Click `Home` in navigation bar  | View displays 6 products|

## Technical Specs

|1| Products and Reviews should be properly saved to the database. <br>
|2| Average rating of a Product should be accurately computed <br>
|3| Ratings can only be an integar between 1 and 5 <br>
|4| Reviews content should be between 50 and 250 character (an error message should show if it is not) <br>
|5| The controllers should accurately return Products and Reviews dedicated routes <br>


## WishList
_Add reviews on product detail page_
_Display all reviews for product on detail page_
_After creating a review, redirect to specific product page with reviews_
_Delete confirmation popup instead of seperate view_

## Open Project 
_Inside terminal run > dotnet restore_
_Inside terminal run > dotnet build_
_Inside terminal run > dotnet run_
_Navigate to http://localhost:5000_

#### There are two options to create the database:
##### 1. In MySQL
`> CREATE DATABASE mario_products;`<br>
`> USE mario_products;`<br>
`> CREATE TABLE products (id serial PRIMARY KEY, name VARCHAR(255), cost INT, country_of_origin VARCHAR(255);`<br>
`> CREATE TABLE reviews (id serial PRIMARY KEY, author VARCHAR(255), content_body TEXT, rating INT, product_id INT);`<br>

##### 2. Import from the Cloned Repository
* _Click 'Open start page' in MAMP_
* _Under 'Tools', select 'phpMyAdmin'_
* _Click 'Import' tab_
* _Choose database file (from cloned repository folder)_
* _Click 'Go'_

## Setup/Installation Requirements

* _Download and install [.NET Core 1.1 SDK](https://www.microsoft.com/net/download/core)_
* _Download and install [Mono](http://www.mono-project.com/download/)_
* _Download and install [MAMP](https://www.mamp.info/en/)_
* _Set MySQL Port to 8889_
* _Clone repository_


## Technologies Used
* _C#_
* _.NET_
* _MVC_
* _Entity Framework_
* _[Bootstrap](http://getbootstrap.com/getting-started/)_
* _[MySQL](https://www.mysql.com/)_

### License

Copyright (c) 2017 **_Lois Choi**

*Licensed under the [MIT License](https://opensource.org/licenses/MIT)*


### ASP.Net
#### Add Packages
* Microsoft.AspNetCore.Mvc - Version 1.1.2
* Microsoft.EntityFrameworkCore - Version 1.1.2
* Pomelo.EntityFrameworkCore.MySql - Version 1.1.2
* Microsoft.AspNetCore.StaticFiles - Version 1.1.2
* Microsoft.AspNetCore - Version 1.1.2

### Migration
#### Add Packages
* Microsoft.EntityFrameworkCore.Design - Version 1.1.2

#### Add to .csproj
```
<ItemGroup>
  <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="1.0.0" />
</ItemGroup>
```
If missing, add:
```
<ItemGroup>
  <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="1.1.2" />
</ItemGroup>
```

#### Commands in terminal or VS Package Console (Windows only)
* Right click on solution file, `Build` project
* `Start Server` in MAMP
* `dotnet restore` (keep running restore if you come across errors)
* `dotnet ef migrations add Initial` (Initial can be any name of your migration, like a commit message)
* `dotnet ef database update`
