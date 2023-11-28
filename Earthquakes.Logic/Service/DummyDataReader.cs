using System.Globalization;
using AutoMapper;
using Earthquakes.DataAccess;
using Earthquakes.DataAccess.Entity;
using Earthquakes.LogicInterface;
using Earthquakes.LogicInterface.Dto;
using Earthquakes.LogicInterface.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;

namespace Earthquakes.Logic.Service;

public class DummyDataReader : BaseService, IDummyDataReader
{
    public DummyDataReader(EarthquakeContext earthquakeContext, ILogger<DummyDataReader> logger, IMapper mapper) : base(earthquakeContext, logger, mapper)
    {
    }

    /// <summary>
    /// Inserts all rows from .csv data file. Updates types if any are missing.
    /// </summary>
    public async Task UpdateDatabase()
    {
        // Read data from .csv
        var dummyData = ReadDummyData();

        // Get already set types
        var existingLands = await DbContext.Lands.ToDictionaryAsync(l => l.Name);
        var existingCountries = await DbContext.Countries.ToDictionaryAsync(c => c.Name);

        // Insert all rows
        foreach (var dummyEarthquakeData in dummyData)
        {
            // If land doesn't exist, insert it to DB
            if (!existingLands.TryGetValue(dummyEarthquakeData.Land, out var land))
            {
                land = new Land { Name = dummyEarthquakeData.Land };
                
                DbContext.Lands.Add(land);
                existingLands.Add(land.Name, land);
            }

            // If country doesn't exist, insert it to DB
            if (!existingCountries.TryGetValue(dummyEarthquakeData.Country, out var country))
            {
                country = new Country { Name = dummyEarthquakeData.Country };
                
                DbContext.Countries.Add(country);
                existingCountries.Add(dummyEarthquakeData.Country, country);
            }

            var earthquake = new Earthquake
            {
                DateTime = dummyEarthquakeData.DateTime,
                Latitude = dummyEarthquakeData.Latitude,
                Longitude = dummyEarthquakeData.Longitude,
                Depth = dummyEarthquakeData.Depth,
                Magnitude = dummyEarthquakeData.Magnitude,
                Land = land,
                Country = country
            };

            DbContext.Earthquakes.Add(earthquake);
        }

        await DbContext.SaveChangesAsync();
    }

    private List<DummyEarthquakeDataDto> ReadDummyData()
    {
        // csv file gets copied to output folder on build.
        // Dirty way to get base directory. Ideally path would come from "appsettings" for example. 
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constants.DummyDataFileName);
        
        // Check if file exists
        if (!File.Exists(path))
        {
            Logger.LogError("File {DummyDataFile} does not exist", Constants.DummyDataFileName);
            throw new FileNotFoundException("Data file does not exist");
        }

        var earthquakes = new List<DummyEarthquakeDataDto>();
        using var parser = new TextFieldParser(path);

        parser.Delimiters = new[] { "," };
        parser.TrimWhiteSpace = true;
        
        // Data has header line, skip it
        parser.ReadLine();

        while (!parser.EndOfData)
        {
            var fields = parser.ReadFields();

            if (fields is null || string.IsNullOrWhiteSpace(fields[0])) continue;
            
            earthquakes.Add(new DummyEarthquakeDataDto
            {
                DateTime = DateTime.ParseExact(fields[0], "M/d/yyyy H:mm", CultureInfo.InvariantCulture),
                Latitude = decimal.Parse(fields[1], CultureInfo.InvariantCulture),
                Longitude = decimal.Parse(fields[2], CultureInfo.InvariantCulture),
                Depth = int.Parse(fields[3]),
                Magnitude = decimal.Parse(fields[4], CultureInfo.InvariantCulture),
                Land = fields[5],
                Country = fields[6]
            });
        }

        return earthquakes;
    }
}