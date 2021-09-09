# name-sorter [![Build Status](https://app.travis-ci.com/maines-pet/name-sorter.svg?branch=master)](https://app.travis-ci.com/maines-pet/name-sorter)
Simple name sorting console application written in C# .Net Core
---
## Pre-requisite
1. .NET SDK
2. Visual Studio Code (optional)
---
## Running the app
With the command line
1. Clone the repository to your local by  
`git clone https://github.com/maines-pet/name-sorter.git`
2. Navigate to the folder by  
`cd name-sorter`
3. Build the project by  
`dotnet build --configuration Release`
4. `cd` to .\NameSorter\bin\Release or with VS Code, right-click on NameSorter\bin\Release folder then `Open in Integrated Terminal`
5. Run the console application by  


`.\name-sorter [input-file-path]`
  
or  

`.\name-sorter [input-file-path] [output-file-path]`

## Assessment Criteria
- [x] The solution should be available for review on github.
- [x] The names should be sorted correctly.
- [x] It should print the sorted list of names to screen.
- [x] It should write/overwrite the sorted list of names to a file called sorted-names-list.txt.
- [x] Unit tests should exist.
- [x] Minimal, practical documentation should exist.
- [x] Create a build pipeline like Travis or AppVeyor that execute build and test steps.
