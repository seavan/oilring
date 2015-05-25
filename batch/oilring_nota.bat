call vsvars32.bat
sqlmetal /conn:"Data Source=46.46.156.42;Initial Catalog=oilring;Integrated Security=False;User id=oilring_web;Password=kimberlite_1414" /views /context:OilringContext /code:..\trunk\oilring.database\oilring.cs /namespace:Oilring.Database /language:C# /sprocs /pluralize
sqlmetal /conn:"Data Source=46.46.156.42;Initial Catalog=oilring;Integrated Security=False;User id=oilring_web;Password=kimberlite_1414" /views /context:OilringContext /xml:..\trunk\oilring.database\oilring.xml /namespace:Oilring.Database /language:C# /sprocs /pluralize

msxsl ..\trunk\oilring.database\oilring.xml tables.xsl FILENAME="..\trunk\oilring.database\oilring.xml" PROJECT_NAME="Oilring" > tables.bat
REM tables.bat