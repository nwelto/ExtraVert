// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;

List<PlantList> plantInventory = new List<PlantList>()
{
    new PlantList()
    {
        Species = "Fiddle-Leaf",
        AskingPrice = 181.00M,
        LightNeeds = 2,
        City = "Hendersonville",
        Zip = 37075,
        Sold = false
    },
    new PlantList()
    {
        Species = "Cactus",
        AskingPrice = 11.00M,
        LightNeeds = 1,
        City = "Hendersonville",
        Zip = 37075,
        Sold = false
    },



};

Console.WriteLine("Wanna buy some plants?");

string choice = null;
while (choice != "0")
{
    Console.WriteLine("Choose an option:\n0. Exit\n1. View All Plants\n2. Add New Plant\n3. View Plants by Species\n4. Update Plant\n5. View Plant Details\n6. Filter by City\n7. Filter by Light Needs\n8. Delete Plant");
    choice = Console.ReadLine();

    switch (choice)
    {
        case "0":
            Console.WriteLine("Goodbye!");
            break;
        case "1":
            ListPlantSpecies(plantInventory);
            break;
        case "2":
            AddNewPlant(plantInventory);
            break;
        case "3":
            ViewPlantsBySpecies(plantInventory);
            break;
        case "4":
            UpdatePlant(plantInventory);
            break;
        case "5":
            ViewPlantDetails(plantInventory);
            break;
        case "6":
            FilterPlantsByCity(plantInventory);
            break;
        case "7":
            FilterPlantsByLightNeeds(plantInventory);
            break;
        case "8":
            DeletePlant(plantInventory);
            break;
    }
}


void ListPlantSpecies(List<PlantList> inventory)
{
    Console.WriteLine("Plant Inventory:");
    int counter = 1;
    foreach (var item in inventory)
    {
        Console.WriteLine($"{counter++}. Species: {item.Species}, Asking Price: {item.AskingPrice}, Light Needs: {item.LightNeeds}, City: {item.City}, ZIP: {item.Zip}, Sold: {item.Sold}");
    }
}
void FilterPlantsByCity(List<PlantList> inventory)
{
    Console.Write("Enter city name to filter: ");
    string city = Console.ReadLine();
    var filteredPlants = inventory.Where(plant => plant.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
    DisplayPlants(filteredPlants);
}

void FilterPlantsByLightNeeds(List<PlantList> inventory)
{
    Console.Write("Enter light needs (1-5) to filter: ");
    if (int.TryParse(Console.ReadLine(), out int lightNeeds))
    {
        var filteredPlants = inventory.Where(plant => plant.LightNeeds == lightNeeds).ToList();
        DisplayPlants(filteredPlants);
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
    }
}

void DisplayPlants(List<PlantList> plants)
{
    int counter = 1;
    foreach (var plant in plants)
    {
        Console.WriteLine($"{counter++}. Species: {plant.Species}, City: {plant.City}, Light Needs: {plant.LightNeeds}");
    }
}


void AddNewPlant(List<PlantList> inventory)
{
    var newPlant = new PlantList();
    Console.Write("Enter species: ");
    newPlant.Species = Console.ReadLine();
    Console.Write("Enter asking price: ");
    newPlant.AskingPrice = decimal.Parse(Console.ReadLine());
    Console.Write("Enter light needs (1-5): ");
    newPlant.LightNeeds = double.Parse(Console.ReadLine());
    Console.Write("Enter city: ");
    newPlant.City = Console.ReadLine();
    Console.Write("Enter ZIP code: ");
    newPlant.Zip = int.Parse(Console.ReadLine());
    newPlant.Sold = false; 
    inventory.Add(newPlant);
    Console.WriteLine("New plant added!");
}

void UpdatePlant(List<PlantList> inventory)
{
    Console.Write("Enter the species of the plant to update: ");
    string species = Console.ReadLine();
    var plant = inventory.FirstOrDefault(p => p.Species.Equals(species, StringComparison.OrdinalIgnoreCase));
    if (plant != null)
    {
        Console.Write("Enter new asking price: ");
        plant.AskingPrice = decimal.Parse(Console.ReadLine());
        Console.WriteLine($"{species} has been updated.");
    }
    else
    {
        Console.WriteLine("Plant not found.");
    }
}

void ViewPlantsBySpecies(List<PlantList> inventory)
{
    Console.Write("Enter the species to view: ");
    string species = Console.ReadLine();
    var filteredPlants = inventory.Where(p => p.Species.Equals(species, StringComparison.OrdinalIgnoreCase)).ToList();
    if (filteredPlants.Any())
    {
        foreach (var plant in filteredPlants)
        {
            Console.WriteLine($"Species: {plant.Species}, Asking Price: {plant.AskingPrice}, Light Needs: {plant.LightNeeds}, City: {plant.City}, ZIP: {plant.Zip}, Sold: {plant.Sold}");
        }
    }
    else
    {
        Console.WriteLine("No plants found for the specified species.");
    }
}
void ViewPlantDetails(List<PlantList> inventory)
{
    Console.WriteLine("Enter the number of the plant you want to view details:");
    if (int.TryParse(Console.ReadLine(), out int plantNumber) && plantNumber > 0 && plantNumber <= inventory.Count)
    {
        var plant = inventory[plantNumber - 1];
        Console.WriteLine($"Species: {plant.Species}, Asking Price: {plant.AskingPrice}, Light Needs: {plant.LightNeeds}, City: {plant.City}, ZIP: {plant.Zip}, Sold: {plant.Sold}");
    }
    else
    {
        Console.WriteLine("Invalid input or plant number. Please try again.");
    }
}

void DeletePlant(List<PlantList> inventory)
{
    Console.Write("Enter the species of the plant to delete: ");
    string species = Console.ReadLine();
    var plant = inventory.FirstOrDefault(p => p.Species.Equals(species, StringComparison.OrdinalIgnoreCase));
    if (plant != null)
    {
        inventory.Remove(plant);
        Console.WriteLine($"{species} has been deleted.");
    }
    else
    {
        Console.WriteLine("Plant not found.");
    }
}

void AdoptPlant(List<PlantList> inventory)
{
    Console.WriteLine("Enter the number of the plant you want to adopt:");
    if (int.TryParse(Console.ReadLine(), out int plantNumber) && plantNumber > 0 && plantNumber <= inventory.Count)
    {
        var plant = inventory[plantNumber - 1];
        if (!plant.Sold)
        {
            plant.Sold = true;
            Console.WriteLine($"You have adopted {plant.Species}. Thank you for adopting!");
        }
        else
        {
            Console.WriteLine("This plant has already been adopted.");
        }
    }
    else
    {
        Console.WriteLine("Invalid input or plant number. Please try again.");
    }
}
