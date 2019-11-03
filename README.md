# ANIMALSHELTER API

Animal shelter pet finder. 

## USE

An API for looking up pets in a shelter. 

## SET-UP

- from terminal, enter 'git clone https://github.com/loewymalkov/AnimalShelterApi'
- navigate to 'AnimalShelter' project folder and enter 'dotnet restore', and then 'dotnet watch run' to launch server
- navigate to 'AnimalShelterClient' project folder and enter 'dotnet restore', and then 'dotnet watch run' to launch server
- follow link to http://localhost:5004 and you can interact with API via webpage; at http://localhost:5001 you can interact with API directly 

## SPECS

| _Behavior_ | _Input_ | _Output_ |
|-|-|-|
| user can input an animal into the database | 'Charles, Dog, 13' | _name: Charles, type: dog, age: 13_|
| user can view a list of all animals | 'Index / View List' | _Charles, Blue, Cannoli, Finley_ |
| user can view animals by type | 'View by Type' | _dog, cat_ |

## TECHNOLOGIES USED

C#, VS Code, MySQL, EntityFramework;

## AUTHOR

Loewy Malkovich, loewymalkov@gmail.com

## LICENSE

Open Source (2019)
