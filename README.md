# Feed Optimization Application
This C# application is designed to optimize the feed mix for dairy cows based on their nutritional requirements. 
The goal is to create a cost-effective and nutritious feed mix that meets the dry matter, energy, protein and fiber (NDF, ADF) needs of the animal. 
The application uses linear programming (via Google OR-Tools) to minimize the total cost while meeting all required nutritional needs within specified constraints.

## Features
* Flexible Feed Model: Supports properties such as energy, protein, NDF, ADF, calcium, and phosphorus content.
* Optimized Cost Calculation: Minimizes the cost of the feed mix while meeting nutritional requirements.
* Adjustable Nutrient Constraints: Each feed has minimum and maximum usage percentages, allowing for granular control of feed composition.
* Tolerance for Requirements: Uses a tolerance percentage to allow small deviations in nutrient requirements for flexibility.

## Installation

* Clone the repository:
```bash
git clone https://github.com/oznakdn/OptiFeed.git
cd OptiFeed.BlazorWeb
```

* Enter your db connnection string (OptiFeed.BlazorWeb/appsettings.json):
```json
"ConnectionStrings": {
    "DefaultConnection": "Enter your sqlserver connection string here"
  }
```

* Migrate database:

```bash
cd OptiFeed.Persistence
```

```bash
dotnet ef migrations add [migration name] --startup-project [OptiFeed.BlazorWeb path]
```

```bash
dotnet ef database update --startup-project [OptiFeed.BlazorWeb path]
```

-------------------------------------------------------------------------------------------------------------------------------

<img src="https://github.com/oznakdn/OptiFeed/blob/master/docs/Screenshot_1.png">

<img src="https://github.com/oznakdn/OptiFeed/blob/master/docs/Screen.png">

<img src="https://github.com/oznakdn/OptiFeed/blob/master/docs/Screen_1.png">

<img src="https://github.com/oznakdn/OptiFeed/blob/master/docs/Screen_2.png">

<img src="https://github.com/oznakdn/OptiFeed/blob/master/docs/Screen_3.png">




