//MIS 3033
//Database Manipulations
//Aiden Dodd
//113556164

using a;
using System.ComponentModel;
using System.Runtime.CompilerServices;

Console.WriteLine("DB");

//step 2
//< StartWorkingDirectory >$(MSBuildProjectDirectory) </ StartWorkingDirectory >

//step 3
//install packages

string menuStr = @"
******************************************************************
Option Menu
1. Add a new city
2. Show all cities
3. Search a city by name
4. Delete a city by ID
5. Search cities in one state
6. Calculate the total population
7. Find the city with the largest population 
Press other keys to exit
******************************************************************
";

CityDB db;
db = new CityDB();//database connection


while (true)//infinite loop
{
    Console.WriteLine(menuStr);
    Console.Write("Input an option: ");
   string optstr= Console.ReadLine();

    if(optstr =="1")
    {
        //add a city
        Console.WriteLine("Add a new city");
        Console.Write("Input the city by ID: ");
        string idstr = Console.ReadLine();
        int id = Convert.ToInt32(idstr);

        Console.Write("Input a city name: ");
        string cityName=Console.ReadLine();

        Console.Write("Input a state name: ");
        string statename = Console.ReadLine();

        Console.Write("Input population: ");
        string popstr = Console.ReadLine();
        int pop = Convert.ToInt32(popstr);

        Console.Write("Input the latitude: ");
        string latstr = Console.ReadLine();
        double latdbl=Convert.ToDouble(latstr);

        Console.Write("Input the Longitude: ");
        string lonstr = Console.ReadLine();
        double londbl = Convert.ToDouble(lonstr);

        City city= new City();
        city.Id = id;
        city.CityName = cityName;
        city.State = statename;
        city.Population = pop;
        city.lat = latdbl;
        city.lon = londbl;

        db.cities.Add(city);//db is in the memory

        db.SaveChanges();//persist save to the db file on the harddrive
        
    }
    else if(optstr =="2") 
    {
        //show all cities
        Console.WriteLine("All Cities");
        List<City> cityList=db.cities.ToList();
        for(int i = 0;i<cityList.Count;i++)
        {
            Console.WriteLine(cityList[i]);
        }
    }
    else if (optstr =="3") 
    {
        //search by name
        Console.WriteLine("Search a city by name");
        Console.Write("Input a city name: ");
        string cityname = Console.ReadLine();

        //you only get one city
      // City city=db.cities.Where(x=>x.CityName==cityname).FirstOrDefault();
      List<City> CityList=db.cities.Where(x=>x.CityName.ToLower()==cityname.ToLower()).ToList();
        for(int i=0;i<CityList.Count;i++)
        {
            Console.WriteLine(CityList[i]);
        }
    }
    else if (optstr=="4")
    {
        //delete a city by id
        Console.WriteLine("Delete a city by ID");
        Console.Write("Input a city ID: ");
        string cityidstr=Console.ReadLine();
        int cityid = Convert.ToInt32(cityidstr);

        City city = db.cities.Where(x => x.Id == cityid).FirstOrDefault();

        if (city == null)
        {
            Console.WriteLine("The city ID does not exist in the DB!");
        }
        else
        {
            db.cities.Remove(city);//we remove the city from the database in the ram

            db.SaveChanges();//persist and save changes
        }
    }
    else if( optstr =="5") 
    {
        //search cities in one state
        Console.WriteLine("Search cities in one state");
        Console.Write("Input a state name: ");
        string statenamestr=Console.ReadLine();

        List<City> cityList=db.cities.Where(x=>x.State.ToLower()==statenamestr.ToLower()).ToList();

        if(cityList.Count==0)
        {
            Console.WriteLine($"No cities found in state {statenamestr}!");
        }
        else
        {
            Console.WriteLine($"{cityList.Count} cities are found in state {statenamestr}");

            for(int i=0 ;i<cityList.Count;i++)
            {
                Console.WriteLine(cityList[i]);
            }
        }

    }
    else if(optstr=="6") 
    {
        //calculate total population
        Console.WriteLine("Sum of population");

        double sumPop=db.cities.Sum(x=>x.Population);

        Console.WriteLine($"Total population: {sumPop:F0}");
    }
    else if(optstr =="7")
    {
        //find the city with the largest population
        Console.WriteLine("City with the largest population");

        City city = db.cities.ToList().MaxBy(x => x.Population);

        Console.WriteLine(city);
    }
    else
    {
        Console.WriteLine("Thank you and goodbye!");
        break;
    }
}


