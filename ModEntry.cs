using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using SpaceCraft;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

namespace PlanetCrafterMod
{
    public enum WindowType
    {
        UNKNOWN,
        CONSOLE,
        PLAYER,
        SPAWNER
    }

    [Serializable]
    public class WindowData
    {
        public int windowID;
        public Rect windowRect;
        public bool showWindow;
        public string windowTitle;
        public WindowType windowType;
    }

    public class ItemData
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }

    public static class ItemIds
    {
        public static List<ItemData> items = new List<ItemData>();

        static ItemIds()
        {
            items.Add(new ItemData
            {
                Name = "AirFilter1",
                DisplayName = "Air Filter",
                Description = "Reduces oxygen consumption depending on the level of terraformation"
            });
            items.Add(new ItemData
            {
                Name = "Algae1Seed",
                DisplayName = "Algae",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "AlgaeGenerator1",
                DisplayName = "T1 Algae Generator",
                Description = "Grows underwater algae. Generates Biomass. Place on a water surface"
            });
            items.Add(new ItemData
            {
                Name = "AlgaeGenerator2",
                DisplayName = "T2 Algae Generator",
                Description = "Grows underwater algae. Generates Biomass. Place on a water surface"
            });
            items.Add(new ItemData
            {
                Name = "Alloy",
                DisplayName = "Super Alloy",
                Description = "Used for advanced technology"
            });
            items.Add(new ItemData
            {
                Name = "Aluminium",
                DisplayName = "Aluminum",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "AmphibiansFarm1",
                DisplayName = "Amphibian Farm",
                Description = "Insert frog eggs to create frogs"
            });
            items.Add(new ItemData
            {
                Name = "AnimalFeeder1",
                DisplayName = "Animal Feeder",
                Description = "Insert food to allow nearby animals to eat"
            });
            items.Add(new ItemData
            {
                Name = "AnimalFood1",
                DisplayName = "T1 Animal Food",
                Description = "Animals fed with this have an augmented production."
            });
            items.Add(new ItemData
            {
                Name = "AnimalFood2",
                DisplayName = "T2 Animal Food",
                Description = "Animals fed with this have an augmented production."
            });
            items.Add(new ItemData
            {
                Name = "AnimalShelter1",
                DisplayName = "Animal Shelter",
                Description = "Insert creatures DNA to spawn animals"
            });
            items.Add(new ItemData
            {
                Name = "Aquarium1",
                DisplayName = "T1 Aquarium",
                Description = "Generates animals"
            });
            items.Add(new ItemData
            {
                Name = "Aquarium2",
                DisplayName = "T2 Aquarium",
                Description = "Generates animals"
            });
            items.Add(new ItemData
            {
                Name = "astrofood",
                DisplayName = "Space Food",
                Description = "Restores health"
            });
            items.Add(new ItemData
            {
                Name = "astrofood2",
                DisplayName = "High Quality Food",
                Description = "Restores a lot of health"
            });
            items.Add(new ItemData
            {
                Name = "AutoCrafter1",
                DisplayName = "Auto-Crafter",
                Description = "Automatically crafts the chosen recipe if the ingredients are found within a certain range, either in a storage or directly in the world."
            });
            items.Add(new ItemData
            {
                Name = "Backpack1",
                DisplayName = "T1 Backpack",
                Description = "Increases inventory size"
            });
            items.Add(new ItemData
            {
                Name = "Backpack2",
                DisplayName = "T2 Backpack",
                Description = "Increases inventory size"
            });
            items.Add(new ItemData
            {
                Name = "Backpack3",
                DisplayName = "T3 Backpack",
                Description = "Increases inventory size"
            });
            items.Add(new ItemData
            {
                Name = "Backpack4",
                DisplayName = "T4 Backpack",
                Description = "Increases inventory size"
            });
            items.Add(new ItemData
            {
                Name = "Backpack5",
                DisplayName = "T5 Backpack",
                Description = "Increases inventory size"
            });
            items.Add(new ItemData
            {
                Name = "Backpack6",
                DisplayName = "T6 Backpack",
                Description = "Increases inventory size"
            });
            items.Add(new ItemData
            {
                Name = "Bacteria1",
                DisplayName = "Bacteria Sample",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BalzarQuartz",
                DisplayName = "Blazar Quartz",
                Description = "Quartz containing tremendous amounts of energy"
            });
            items.Add(new ItemData
            {
                Name = "Beacon",
                DisplayName = "Beacon",
                Description = "Helps you find your way"
            });
            items.Add(new ItemData
            {
                Name = "BedDouble",
                DisplayName = "Double Bed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BedDoubleColored",
                DisplayName = "Customizable Bed",
                Description = "Click on it to change its color"
            });
            items.Add(new ItemData
            {
                Name = "BedSimple",
                DisplayName = "Bed",
                Description = "A single bed"
            });
            items.Add(new ItemData
            {
                Name = "Bee1Hatched",
                DisplayName = "Bee1hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Bee1Larvae",
                DisplayName = "Bee Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Beehive1",
                DisplayName = "Beehive",
                Description = "Increases plants and insects"
            });
            items.Add(new ItemData
            {
                Name = "Beehive2",
                DisplayName = "T2 Beehive",
                Description = "Generates honey and bee larvae."
            });
            items.Add(new ItemData
            {
                Name = "biodome",
                DisplayName = "Biodome",
                Description = "Perfect place to grow plants and generate 0²"
            });
            items.Add(new ItemData
            {
                Name = "Biodome2",
                DisplayName = "T2 Biodome",
                Description = "Generates tree bark"
            });
            items.Add(new ItemData
            {
                Name = "Biolab",
                DisplayName = "Biolab",
                Description = "Science lab. Allows you to craft bio recipes"
            });
            items.Add(new ItemData
            {
                Name = "Bioplastic1",
                DisplayName = "Bioplastic Nugget",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintBedDoubleColored",
                DisplayName = "Blueprintbeddoublecolored",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintContainer3",
                DisplayName = "Blueprintcontainer3",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintCookingStation",
                DisplayName = "Blueprintcookingstation",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintDrone2",
                DisplayName = "Blueprintdrone2",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintFireplace",
                DisplayName = "Blueprintfireplace",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintFlare",
                DisplayName = "Blueprintflare",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintFountainBig",
                DisplayName = "Blueprintfountainbig",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintHologramGenerator",
                DisplayName = "Blueprinthologramgenerator",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintLightBoxMedium",
                DisplayName = "Blueprintlightboxmedium",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintPod9xA",
                DisplayName = "Blueprintpod9xa",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintPod9xB",
                DisplayName = "Blueprintpod9xb",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintPod9xC",
                DisplayName = "Blueprintpod9xc",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintSmartFabric",
                DisplayName = "Blueprintsmartfabric",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintSofaColored",
                DisplayName = "Blueprintsofacolored",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintSolarQuartz",
                DisplayName = "Blueprintsolarquartz",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintT1",
                DisplayName = "Blueprint Microchip",
                Description = "Use this in the blueprints screen to unlock a new blueprint"
            });
            items.Add(new ItemData
            {
                Name = "BlueprintTreePlanter",
                DisplayName = "Blueprinttreeplanter",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BlueprintWardensChip",
                DisplayName = "Blueprintwardenschip",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "BootsSpeed1",
                DisplayName = "T1 Agility Boots",
                Description = "Increases movement speed"
            });
            items.Add(new ItemData
            {
                Name = "BootsSpeed2",
                DisplayName = "T2 Agility Boots",
                Description = "Increases movement speed"
            });
            items.Add(new ItemData
            {
                Name = "BootsSpeed3",
                DisplayName = "T3 Agility Boots",
                Description = "Increases movement speed"
            });
            items.Add(new ItemData
            {
                Name = "Butterfly10Larvae",
                DisplayName = "Liux Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly11Larvae",
                DisplayName = "Nere Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly12Larvae",
                DisplayName = "Lorpen Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly13Larvae",
                DisplayName = "Fiorente Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly14Larvae",
                DisplayName = "Alben Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly15Larvae",
                DisplayName = "Futura Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly16Larvae",
                DisplayName = "Imeo Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly17Larvae",
                DisplayName = "Serena Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly18Larvae",
                DisplayName = "Golden Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly19Larvae",
                DisplayName = "Faleria Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly1Larvae",
                DisplayName = "Azurae Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly2Larvae",
                DisplayName = "Leani Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly3Larvae",
                DisplayName = "Fensea Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly4Larvae",
                DisplayName = "Galaxe Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly5Larvae",
                DisplayName = "Abstreus Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly6Larvae",
                DisplayName = "Empalio Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly7Larvae",
                DisplayName = "Penga Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly8Larvae",
                DisplayName = "Chevrone Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Butterfly9Larvae",
                DisplayName = "Aemel Butterfly Larva",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "ButterflyDisplayer1",
                DisplayName = "Butterfly Display Box",
                Description = "Place a butterfly larva inside to see the butterfly"
            });
            items.Add(new ItemData
            {
                Name = "ButterflyDome1",
                DisplayName = "Butterfly Dome",
                Description = "Insert butterfly larvae to increase insects levels"
            });
            items.Add(new ItemData
            {
                Name = "ButterflyFarm1",
                DisplayName = "Butterfly Farm",
                Description = "Insert butterfly larvae to increase insects levels"
            });
            items.Add(new ItemData
            {
                Name = "ButterflyFarm2",
                DisplayName = "T2 Butterfly Farm",
                Description = "Insert butterfly larvae to increase insects levels"
            });
            items.Add(new ItemData
            {
                Name = "Chair1",
                DisplayName = "Chair",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "CircuitBoard1",
                DisplayName = "Circuit Board",
                Description = "Used in advanced crafting recipes"
            });
            items.Add(new ItemData
            {
                Name = "Cobalt",
                DisplayName = "Cobalt",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "ComAntenna",
                DisplayName = "Communication Antenna",
                Description = "Receives transmissions from outer space. Use in combination with transmissions screen."
            });
            items.Add(new ItemData
            {
                Name = "Container1",
                DisplayName = "Storage Crate",
                Description = "Medium storage container"
            });
            items.Add(new ItemData
            {
                Name = "Container2",
                DisplayName = "Locker Storage",
                Description = "Large storage container"
            });
            items.Add(new ItemData
            {
                Name = "Container3",
                DisplayName = "T2 Locker Storage",
                Description = "A much bigger storage"
            });
            items.Add(new ItemData
            {
                Name = "CookCake1",
                DisplayName = "Birthday Cake",
                Description = "First birthday cake"
            });
            items.Add(new ItemData
            {
                Name = "CookChocolate",
                DisplayName = "Chocolate",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "CookCocoaGrowable",
                DisplayName = "Cocoa",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "CookCocoaSeed",
                DisplayName = "Cocoa Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "CookCookie1",
                DisplayName = "Cookie",
                Description = "Chocolate cookie"
            });
            items.Add(new ItemData
            {
                Name = "CookCroissant",
                DisplayName = "Croissant",
                Description = "A perfect French croissant"
            });
            items.Add(new ItemData
            {
                Name = "CookFlour",
                DisplayName = "Flour",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "CookingStation1",
                DisplayName = "Cooking Station",
                Description = "Allows you to cook food"
            });
            items.Add(new ItemData
            {
                Name = "CookStew1",
                DisplayName = "Honey Cooked Beans",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "CookStewFish1",
                DisplayName = "Fish Soup",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "CookWheatGrowable",
                DisplayName = "Wheat",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "CookWheatSeed",
                DisplayName = "Wheat Seeds",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "CraftStation1",
                DisplayName = "T2 Craft Station",
                Description = "Improved crafting station to craft better tools"
            });
            items.Add(new ItemData
            {
                Name = "CraftStation2",
                DisplayName = "Advanced Craft Station",
                Description = "Craft new advanced tools and blueprints"
            });
            items.Add(new ItemData
            {
                Name = "DeparturePlatform",
                DisplayName = "Extraction Platform",
                Description = "Used to rejoin a ship in orbit"
            });
            items.Add(new ItemData
            {
                Name = "Desktop1",
                DisplayName = "Desktop",
                Description = "A desk to place your screens"
            });
            items.Add(new ItemData
            {
                Name = "Destructor1",
                DisplayName = "Shredder Machine",
                Description = "Destroys items placed inside"
            });
            items.Add(new ItemData
            {
                Name = "DisplayCase",
                DisplayName = "Display Case",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "DNASequence",
                DisplayName = "Creature DNA",
                Description = "Insert it into an animal shelter to spawn an animal"
            });
            items.Add(new ItemData
            {
                Name = "door",
                DisplayName = "Living Compartment Door",
                Description = "Provides access to a living compartment"
            });
            items.Add(new ItemData
            {
                Name = "Drill0",
                DisplayName = "T1 Drill",
                Description = "Generates pressure by releasing gases trapped in the ground"
            });
            items.Add(new ItemData
            {
                Name = "Drill1",
                DisplayName = "T2 Drill",
                Description = "Generates pressure by releasing gases trapped in the ground"
            });
            items.Add(new ItemData
            {
                Name = "Drill2",
                DisplayName = "T3 Drill",
                Description = "Generates pressure by releasing gases trapped in the ground"
            });
            items.Add(new ItemData
            {
                Name = "Drill3",
                DisplayName = "T4 Drill",
                Description = "Generates pressure by releasing gases trapped in the ground"
            });
            items.Add(new ItemData
            {
                Name = "Drill4",
                DisplayName = "T5 Drill",
                Description = "Generates pressure by releasing gases trapped in the ground"
            });
            items.Add(new ItemData
            {
                Name = "Drone1",
                DisplayName = "T1 Drone",
                Description = "Transports materials from supply inventories to corresponding demand inventories"
            });
            items.Add(new ItemData
            {
                Name = "Drone2",
                DisplayName = "T2 Drone",
                Description = "Faster Drone"
            });
            items.Add(new ItemData
            {
                Name = "DroneStation1",
                DisplayName = "Drone Station",
                Description = "Activates the logistics system and enables drone creation"
            });
            items.Add(new ItemData
            {
                Name = "Ecosystem1",
                DisplayName = "Ecosystem",
                Description = "Produces larvaes and increase plants level"
            });
            items.Add(new ItemData
            {
                Name = "EndingExplosives",
                DisplayName = "Large Explosive Device",
                Description = "Place this under the Wardens’ anomaly and trigger it to be able to leave the planet"
            });
            items.Add(new ItemData
            {
                Name = "EnergyGenerator1",
                DisplayName = "Wind Turbine",
                Description = "Generates energy that powers all machines on the planet"
            });
            items.Add(new ItemData
            {
                Name = "EnergyGenerator2",
                DisplayName = "T1 Solar Panel",
                Description = "Generates energy that powers all machines on the planet"
            });
            items.Add(new ItemData
            {
                Name = "EnergyGenerator3",
                DisplayName = "T2 Solar Panel",
                Description = "Generates energy that powers all machines on the planet"
            });
            items.Add(new ItemData
            {
                Name = "EnergyGenerator4",
                DisplayName = "T1 Nuclear Reactor",
                Description = "Generates energy that powers all machines on the planet"
            });
            items.Add(new ItemData
            {
                Name = "EnergyGenerator5",
                DisplayName = "T2 Nuclear Reactor",
                Description = "Generates energy that powers all machines on the planet"
            });
            items.Add(new ItemData
            {
                Name = "EnergyGenerator6",
                DisplayName = "Nuclear Fusion Generator",
                Description = "Generates energy that powers all machines on the planet"
            });
            items.Add(new ItemData
            {
                Name = "EquipmentIncrease1",
                DisplayName = "T1 Exoskeleton",
                Description = "Increases equipment capacity"
            });
            items.Add(new ItemData
            {
                Name = "EquipmentIncrease2",
                DisplayName = "T2 Exoskeleton",
                Description = "Increases equipment capacity"
            });
            items.Add(new ItemData
            {
                Name = "EquipmentIncrease3",
                DisplayName = "T3 Exoskeleton",
                Description = "Increases equipment capacity"
            });
            items.Add(new ItemData
            {
                Name = "EquipmentIncrease4",
                DisplayName = "T4 Exoskeleton",
                Description = "Increases equipment capacity"
            });
            items.Add(new ItemData
            {
                Name = "Explosive",
                DisplayName = "Explosive",
                Description = "Use it to blow up objects."
            });
            items.Add(new ItemData
            {
                Name = "FabricBlue",
                DisplayName = "Fabric",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Farm1",
                DisplayName = "Outdoor Farm",
                Description = "Insert a vegetable seed in it to grow multiple vegetables"
            });
            items.Add(new ItemData
            {
                Name = "Fence",
                DisplayName = "Fence",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fertilizer1",
                DisplayName = "Fertilizer",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fertilizer2",
                DisplayName = "T2 Fertilizer",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fireplace",
                DisplayName = "Fireplace",
                Description = "For a bit of warmth"
            });
            items.Add(new ItemData
            {
                Name = "Fish10Eggs",
                DisplayName = "Tiloo Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish10Hatched",
                DisplayName = "Fish10hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish11Eggs",
                DisplayName = "Golden Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish11Hatched",
                DisplayName = "Fish11hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish12Eggs",
                DisplayName = "Velkia Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish12Hatched",
                DisplayName = "Fish12hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish13Eggs",
                DisplayName = "Galbea Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish13Hatched",
                DisplayName = "Fish13hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish1Eggs",
                DisplayName = "Provios Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish1Hatched",
                DisplayName = "Fish1hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish2Eggs",
                DisplayName = "Vilnus Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish2Hatched",
                DisplayName = "Fish2hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish3Eggs",
                DisplayName = "Gerrero Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish4Eggs",
                DisplayName = "Khrom Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish4Hatched",
                DisplayName = "Fish4hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish5Eggs",
                DisplayName = "Ulani Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish5Hatched",
                DisplayName = "Fish5hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish6Eggs",
                DisplayName = "Aelera Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish6Hatched",
                DisplayName = "Fish6hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish7Eggs",
                DisplayName = "Tegede Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish7Hatched",
                DisplayName = "Fish7hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish8Eggs",
                DisplayName = "Ecaru Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish8Hatched",
                DisplayName = "Fish8hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Fish9Eggs",
                DisplayName = "Buyu Fish Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "FishDisplayer1",
                DisplayName = "Fish Display",
                Description = "Insert a fish egg to see the fish"
            });
            items.Add(new ItemData
            {
                Name = "FishFarm1",
                DisplayName = "Fish Farm",
                Description = "Generates animals"
            });
            items.Add(new ItemData
            {
                Name = "Flare",
                DisplayName = "Flare",
                Description = "Use it to light places up in different colors. Deconstruct it to get rid of it."
            });
            items.Add(new ItemData
            {
                Name = "FloorGlass",
                DisplayName = "Living Compartment Glass",
                Description = "Glass floor or ceiling for living compartments"
            });
            items.Add(new ItemData
            {
                Name = "FlowerPot1",
                DisplayName = "Flower Pot",
                Description = "Insert a seed in this to grow a flower"
            });
            items.Add(new ItemData
            {
                Name = "Foundation",
                DisplayName = "Foundation Grid",
                Description = "Structures can be used to create outdoor floors and stairs, to reach new spaces or for anything you can imagine"
            });
            items.Add(new ItemData
            {
                Name = "FountainBig",
                DisplayName = "Fountain",
                Description = "A decorative fountain"
            });
            items.Add(new ItemData
            {
                Name = "Frog10Eggs",
                DisplayName = "Kenjoss Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog10Hatched",
                DisplayName = "Frog10hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog11Eggs",
                DisplayName = "Lavaum Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog11Hatched",
                DisplayName = "Frog11hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog12Eggs",
                DisplayName = "Leglus Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog12Hatched",
                DisplayName = "Frog12hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog13Eggs",
                DisplayName = "Jumi Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog13Hatched",
                DisplayName = "Frog13hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog1Eggs",
                DisplayName = "Generic Frog Eggs",
                Description = "Find these in the wild, near natural ponds"
            });
            items.Add(new ItemData
            {
                Name = "Frog1Hatched",
                DisplayName = "Frog1hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog2Eggs",
                DisplayName = "Huli Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog2Hatched",
                DisplayName = "Frog2hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog3Eggs",
                DisplayName = "Felicianna Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog3Hatched",
                DisplayName = "Frog3hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog4Eggs",
                DisplayName = "Strabo Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog4Hatched",
                DisplayName = "Frog4hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog5Eggs",
                DisplayName = "Trajuu Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog5Hatched",
                DisplayName = "Frog5hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog6Eggs",
                DisplayName = "Aiolus Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog6Hatched",
                DisplayName = "Frog6hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog7Eggs",
                DisplayName = "Afae Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog7Hatched",
                DisplayName = "Frog7hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog8Eggs",
                DisplayName = "Cillus Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog8Hatched",
                DisplayName = "Frog8hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog9Eggs",
                DisplayName = "Amedo Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Frog9Hatched",
                DisplayName = "Frog9hatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "FrogDisplayer1",
                DisplayName = "Frog Displayer",
                Description = "Insert a frog egg to display a frog"
            });
            items.Add(new ItemData
            {
                Name = "FrogGoldEggs",
                DisplayName = "Golden Frog Eggs",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "FrogGoldHatched",
                DisplayName = "Froggoldhatched",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "FuseEnergy1",
                DisplayName = "Energy Multiplier Fuse",
                Description = "Insert this fuse in an optimizer to boost performance of nearby energy generators"
            });
            items.Add(new ItemData
            {
                Name = "FuseHeat1",
                DisplayName = "Heat Multiplier Fuse",
                Description = "Insert this fuse in an optimizer to boost the performance of nearby machines"
            });
            items.Add(new ItemData
            {
                Name = "FuseOxygen1",
                DisplayName = "Oxygen Multiplier Fuse",
                Description = "Insert this fuse in an optimizer to boost the performance of nearby machines"
            });
            items.Add(new ItemData
            {
                Name = "FusePlants1",
                DisplayName = "Plant Multiplier Fuse",
                Description = "Insert this fuse in an optimizer to boost the performance of nearby machines"
            });
            items.Add(new ItemData
            {
                Name = "FusePressure1",
                DisplayName = "Pressure Multiplier Fuse",
                Description = "Insert this fuse in an optimizer to boost the performance of nearby machines"
            });
            items.Add(new ItemData
            {
                Name = "FuseProduction1",
                DisplayName = "Production Multiplier Fuse",
                Description = "Insert this fuse in an optimizer to speed up generation time for machines that generate items"
            });
            items.Add(new ItemData
            {
                Name = "FuseTradeRocketsSpeed1",
                DisplayName = "Trade Rocket Multiplier Fuse",
                Description = "Insert this fuse into an optimizer to increase the speed of nearby trade space rockets"
            });
            items.Add(new ItemData
            {
                Name = "FusionEnergyCell",
                DisplayName = "Fusion Energy Cell",
                Description = "Nuclear fusion cell"
            });
            items.Add(new ItemData
            {
                Name = "FusionGenerator1",
                DisplayName = "Fusion Reactor",
                Description = "Provides energy using nuclear fusion cells"
            });
            items.Add(new ItemData
            {
                Name = "GasExtractor1",
                DisplayName = "Gas Extractor",
                Description = "Automatically extracts gas from the ground"
            });
            items.Add(new ItemData
            {
                Name = "GasExtractor2",
                DisplayName = "T2 Gas Extractor",
                Description = "Automatically extracts gas from the ground"
            });
            items.Add(new ItemData
            {
                Name = "GeneticExtractor1",
                DisplayName = "Genetic Extractor",
                Description = "Allows the extraction of genes from a multitude of living beings"
            });
            items.Add(new ItemData
            {
                Name = "GeneticManipulator1",
                DisplayName = "DNA Manipulator",
                Description = "Manipulates DNA to create new genes"
            });
            items.Add(new ItemData
            {
                Name = "GeneticSynthetizer1",
                DisplayName = "Genetic Synthesizer",
                Description = "Creates a creatures DNA by combining genetic traits"
            });
            items.Add(new ItemData
            {
                Name = "GeneticTrait",
                DisplayName = "Genetic Trait",
                Description = "Insert it in a genetic synthesizer to create a new creature"
            });
            items.Add(new ItemData
            {
                Name = "GoldenContainer",
                DisplayName = "Golden Crate",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "GoldenEffigie1",
                DisplayName = "Golden Effigy",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "GoldenEffigie2",
                DisplayName = "Golden Effigy",
                Description = "Golden effigy"
            });
            items.Add(new ItemData
            {
                Name = "GoldenEffigie3",
                DisplayName = "Golden Effigy",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "GoldenEffigie4",
                DisplayName = "Golden Effigy",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "GoldenEffigie5",
                DisplayName = "Golden Effigy",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "GoldenEffigie6",
                DisplayName = "Golden Effigy",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "GoldenEffigie7",
                DisplayName = "Golden Effigy",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "GoldenEffigie8",
                DisplayName = "Golden Effigy",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "GrassSpreader1",
                DisplayName = "Grass Spreader",
                Description = "Grows grass outside, generates Biomass"
            });
            items.Add(new ItemData
            {
                Name = "Heater1",
                DisplayName = "T1 Heater",
                Description = "Generates heat"
            });
            items.Add(new ItemData
            {
                Name = "Heater2",
                DisplayName = "T2 Heater",
                Description = "Generates heat"
            });
            items.Add(new ItemData
            {
                Name = "Heater3",
                DisplayName = "T3 Heater",
                Description = "Generates heat"
            });
            items.Add(new ItemData
            {
                Name = "Heater4",
                DisplayName = "T4 Heater",
                Description = "Generates heat"
            });
            items.Add(new ItemData
            {
                Name = "Heater5",
                DisplayName = "T5 Heater",
                Description = "Generates heat"
            });
            items.Add(new ItemData
            {
                Name = "HologramGenerator",
                DisplayName = "Hologram Projector",
                Description = "Insert an item into it to generate a hologram"
            });
            items.Add(new ItemData
            {
                Name = "honey",
                DisplayName = "Honey",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "HudChipCleanConstruction",
                DisplayName = "Microchip – Construction Menu Filter",
                Description = "Hides lower tiers of items from the construction menu"
            });
            items.Add(new ItemData
            {
                Name = "HudCompass",
                DisplayName = "Microchip - Compass",
                Description = "Adds a compass to your screen"
            });
            items.Add(new ItemData
            {
                Name = "ice",
                DisplayName = "Ice",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Incubator1",
                DisplayName = "Incubator",
                Description = "Use this to create new insects with larvae and mutagen. Mutations can create different larvae with the same recipe. Some mutations have to be discovered."
            });
            items.Add(new ItemData
            {
                Name = "InsideLamp1",
                DisplayName = "Area Lamp",
                Description = "A lamp that can be placed anywhere"
            });
            items.Add(new ItemData
            {
                Name = "Iridium",
                DisplayName = "Iridium",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Iron",
                DisplayName = "Iron",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Jetpack1",
                DisplayName = "T1 Jetpack",
                Description = "Allows you to fly in the air and increases displacement speed"
            });
            items.Add(new ItemData
            {
                Name = "Jetpack2",
                DisplayName = "T2 Jetpack",
                Description = "Allows you to fly in the air and increases displacement speed"
            });
            items.Add(new ItemData
            {
                Name = "Jetpack3",
                DisplayName = "T3 Jetpack",
                Description = "Allows you to fly in the air and increases displacement speed"
            });
            items.Add(new ItemData
            {
                Name = "Jetpack4",
                DisplayName = "T4 Jetpack",
                Description = "Allows you to fly in the air and increases displacement speed"
            });
            items.Add(new ItemData
            {
                Name = "Keycard1",
                DisplayName = "Access Card",
                Description = "Used to open closed doors"
            });
            items.Add(new ItemData
            {
                Name = "Ladder",
                DisplayName = "Indoor Ladder",
                Description = "Indoor ladder to climb between living compartments"
            });
            items.Add(new ItemData
            {
                Name = "LarvaeBase1",
                DisplayName = "Common Larva",
                Description = "Use it in the incubator to create new species. Found outside when insect stage is reached."
            });
            items.Add(new ItemData
            {
                Name = "LarvaeBase2",
                DisplayName = "Uncommon Larva",
                Description = "Use it in the incubator to create new species. Found outside when insect stage is reached."
            });
            items.Add(new ItemData
            {
                Name = "LarvaeBase3",
                DisplayName = "Rare Larva",
                Description = "Use it in the incubator to create new species. Found outside when insect stage is reached."
            });
            items.Add(new ItemData
            {
                Name = "LaunchPlatform",
                DisplayName = "Launch Platform",
                Description = "Greatly speeds up the terraformation process by sending rockets into space"
            });
            items.Add(new ItemData
            {
                Name = "LightBoxMedium",
                DisplayName = "Light Box",
                Description = "A box emitting light"
            });
            items.Add(new ItemData
            {
                Name = "Magnesium",
                DisplayName = "Magnesium",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "MagnetarQuartz",
                DisplayName = "Magnetar Quartz",
                Description = "Quartz containing tremendous amounts of energy"
            });
            items.Add(new ItemData
            {
                Name = "MapChip",
                DisplayName = "Microchip – Map",
                Description = "Allows map to be displayed from anywhere"
            });
            items.Add(new ItemData
            {
                Name = "MethanCapsule1",
                DisplayName = "Methane Cartridge",
                Description = "Contains methane"
            });
            items.Add(new ItemData
            {
                Name = "MultiBuild",
                DisplayName = "Microchip - Construction",
                Description = "Equip this chip to be able to build structures by pressing the corresponding key"
            });
            items.Add(new ItemData
            {
                Name = "MultiDeconstruct",
                DisplayName = "Microchip - Deconstruction",
                Description = "Equip this chip to be able to deconstruct entities with your multitool. Needed to salvage wrecks."
            });
            items.Add(new ItemData
            {
                Name = "MultiToolDeconstruct2",
                DisplayName = "Microchip – T2 Deconstruction",
                Description = "Allows you to deconstruct advanced items in wrecks"
            });
            items.Add(new ItemData
            {
                Name = "MultiToolDeconstruct3",
                DisplayName = "Microchip – T3 Deconstruction",
                Description = "Allows you to deconstruct items quicker"
            });
            items.Add(new ItemData
            {
                Name = "MultiToolLight",
                DisplayName = "Microchip - Torch",
                Description = "Equip this chip to add a light to your multitool. Needed to explore wrecks. Press F to toggle."
            });
            items.Add(new ItemData
            {
                Name = "MultiToolLight2",
                DisplayName = "Microchip – T2 Torch",
                Description = "Better lighting microchip"
            });
            items.Add(new ItemData
            {
                Name = "MultiToolLight3",
                DisplayName = "Microchip – T3 Torch",
                Description = "Better lighting microchip"
            });
            items.Add(new ItemData
            {
                Name = "MultiToolMineSpeed1",
                DisplayName = "Microchip - T1 Mining Speed",
                Description = "Equip this chip to reduce ore mining time"
            });
            items.Add(new ItemData
            {
                Name = "MultiToolMineSpeed2",
                DisplayName = "Microchip - T2 Mining Speed",
                Description = "Equip this chip to reduce ore mining time"
            });
            items.Add(new ItemData
            {
                Name = "MultiToolMineSpeed3",
                DisplayName = "Microchip - T3 Mining Speed",
                Description = "Equip this chip to reduce ore mining time"
            });
            items.Add(new ItemData
            {
                Name = "MultiToolMineSpeed4",
                DisplayName = "Microchip - T4 Mining Speed",
                Description = "Equip this chip to reduce ore mining time"
            });
            items.Add(new ItemData
            {
                Name = "Mutagen1",
                DisplayName = "Mutagen",
                Description = "Mutagenic agent. Use it in the DNA Manipulator."
            });
            items.Add(new ItemData
            {
                Name = "Mutagen2",
                DisplayName = "T2 Mutagen",
                Description = "Strong mutagenic agent."
            });
            items.Add(new ItemData
            {
                Name = "Mutagen3",
                DisplayName = "T3 Mutagen",
                Description = "Mutagenic agent. Can be used to create fish in the incubator"
            });
            items.Add(new ItemData
            {
                Name = "Mutagen4",
                DisplayName = "T4 Mutagen",
                Description = "Mutagenic agent. Can be used to create frogs in the incubator"
            });
            items.Add(new ItemData
            {
                Name = "NitrogenCapsule1",
                DisplayName = "Nitrogen Cartridge",
                Description = "Contains nitrogen"
            });
            items.Add(new ItemData
            {
                Name = "Obsidian",
                DisplayName = "Obsidian",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Optimizer1",
                DisplayName = "Machine Optimizer",
                Description = "Find and insert fuses into this to boost the performance of nearby machines"
            });
            items.Add(new ItemData
            {
                Name = "Optimizer2",
                DisplayName = "T2 Machine Optimizer",
                Description = "Find and insert fuses into this to boost the performance of nearby machines"
            });
            items.Add(new ItemData
            {
                Name = "OreExtractor1",
                DisplayName = "Ore Extractor",
                Description = "Extracts ores from the ground depending on where its placed"
            });
            items.Add(new ItemData
            {
                Name = "OreExtractor2",
                DisplayName = "T2 Ore Extractor",
                Description = "Extracts rarer ores from the ground"
            });
            items.Add(new ItemData
            {
                Name = "OreExtractor3",
                DisplayName = "T3 Ore Extractor",
                Description = "Extracts ores from the ground depending on user selection"
            });
            items.Add(new ItemData
            {
                Name = "Osmium",
                DisplayName = "Osmium",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "OutsideLamp1",
                DisplayName = "Outdoor Lamp",
                Description = "Illuminates outside"
            });
            items.Add(new ItemData
            {
                Name = "OxygenCapsule1",
                DisplayName = "Oxygen Capsule",
                Description = "Fully refills your oxygen tanks"
            });
            items.Add(new ItemData
            {
                Name = "OxygenTank1",
                DisplayName = "T1 Oxygen Tank",
                Description = "Increases your oxygen capacity"
            });
            items.Add(new ItemData
            {
                Name = "OxygenTank2",
                DisplayName = "T2 Oxygen Tank",
                Description = "Increases your oxygen capacity"
            });
            items.Add(new ItemData
            {
                Name = "OxygenTank3",
                DisplayName = "T3 Oxygen Tank",
                Description = "Increases your oxygen capacity"
            });
            items.Add(new ItemData
            {
                Name = "OxygenTank4",
                DisplayName = "T4 Oxygen Tank",
                Description = "Increases your oxygen capacity"
            });
            items.Add(new ItemData
            {
                Name = "Phytoplankton1",
                DisplayName = "Phytoplankton A",
                Description = "Use it in the incubator to create fish."
            });
            items.Add(new ItemData
            {
                Name = "Phytoplankton2",
                DisplayName = "Phytoplankton B",
                Description = "Use it in the incubator to create fish."
            });
            items.Add(new ItemData
            {
                Name = "Phytoplankton3",
                DisplayName = "Phytoplankton C",
                Description = "Use it in the incubator to create fish."
            });
            items.Add(new ItemData
            {
                Name = "Phytoplankton4",
                DisplayName = "Phytoplankton D",
                Description = "Use it in the incubator to create fish."
            });
            items.Add(new ItemData
            {
                Name = "PinChip1",
                DisplayName = "Microchip – T1 Blueprint Pinning",
                Description = "Allows you to pin one crafting recipe. Right click on an item to pin its recipe. Do it again to clear it."
            });
            items.Add(new ItemData
            {
                Name = "PinChip2",
                DisplayName = "Microchip – T2 Blueprint Pinning",
                Description = "Allows you to pin more crafting recipes. Right click on an item to pin its recipe. Do it again to clear it."
            });
            items.Add(new ItemData
            {
                Name = "PinChip3",
                DisplayName = "Microchip – T3 Blueprint Pinning",
                Description = "Allows you to pin more crafting recipes. Right click on an item to pin its recipe. Do it again to clear it."
            });
            items.Add(new ItemData
            {
                Name = "pod",
                DisplayName = "Living Compartment",
                Description = "Basic habitat providing oxygen"
            });
            items.Add(new ItemData
            {
                Name = "Pod4x",
                DisplayName = "Big Living Compartment",
                Description = "Bigger living compartment"
            });
            items.Add(new ItemData
            {
                Name = "Pod9xA",
                DisplayName = "Rounded Living Compartment",
                Description = "3x3 Living compartment with rounded corners"
            });
            items.Add(new ItemData
            {
                Name = "Pod9xB",
                DisplayName = "Living Compartment With Dome",
                Description = "3x3 Living compartment with dome"
            });
            items.Add(new ItemData
            {
                Name = "Pod9xC",
                DisplayName = "3X3 Living Compartment",
                Description = "3x3 Living compartment"
            });
            items.Add(new ItemData
            {
                Name = "podAngle",
                DisplayName = "Living Compartment Corner",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "PortalGenerator1",
                DisplayName = "Portal Generator",
                Description = "Allows you to reach distant wrecks with unique items to find"
            });
            items.Add(new ItemData
            {
                Name = "PulsarQuartz",
                DisplayName = "Pulsar Quartz",
                Description = "Quartz containing tremendous amounts of energy"
            });
            items.Add(new ItemData
            {
                Name = "QuasarQuartz",
                DisplayName = "Quasar Quartz",
                Description = "Quartz containing tremendous amounts of energy"
            });
            items.Add(new ItemData
            {
                Name = "RecyclingMachine",
                DisplayName = "Recycling Machine",
                Description = "Breaks items down into their core components"
            });
            items.Add(new ItemData
            {
                Name = "RedPowder1",
                DisplayName = "Explosive Powder",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "RocketAnimals1",
                DisplayName = "Animals Spreader Rocket",
                Description = "Gives a GLOBAL generation bonus by spreading animals around the planet"
            });
            items.Add(new ItemData
            {
                Name = "RocketBiomass1",
                DisplayName = "Plant Rocket",
                Description = "Increases moss spread. Gives a GLOBAL generation bonus by spreading bacteria from outer space."
            });
            items.Add(new ItemData
            {
                Name = "RocketDrones1",
                DisplayName = "Drone Visualization Rocket",
                Description = "Displays drones on the mapping screen"
            });
            items.Add(new ItemData
            {
                Name = "RocketHeat1",
                DisplayName = "Asteroid Attraction Rocket",
                Description = "Attracts uranium asteroids. Gives a GLOBAL heat generation bonus"
            });
            items.Add(new ItemData
            {
                Name = "RocketInformations1",
                DisplayName = "Map Information Rocket",
                Description = "Display points of interest on map"
            });
            items.Add(new ItemData
            {
                Name = "RocketInsects1",
                DisplayName = "Insect Spreader Rocket",
                Description = "Gives a GLOBAL generation bonus by spreading insects from outer space"
            });
            items.Add(new ItemData
            {
                Name = "RocketMap1",
                DisplayName = "T1 GPS Satellite",
                Description = "Provides geolocation to the mapping screen"
            });
            items.Add(new ItemData
            {
                Name = "RocketMap2",
                DisplayName = "T2 GPS Satellite",
                Description = "Provides better geolocation to the mapping screen"
            });
            items.Add(new ItemData
            {
                Name = "RocketMap3",
                DisplayName = "T3 GPS Satellite",
                Description = "Provides better geolocation to the mapping screen"
            });
            items.Add(new ItemData
            {
                Name = "RocketMap4",
                DisplayName = "T4 GPS Satellite",
                Description = "Provides better geolocation to the mapping screen. Allows you to move the map."
            });
            items.Add(new ItemData
            {
                Name = "RocketOxygen1",
                DisplayName = "Seed Spreader Rocket",
                Description = "Gives a GLOBAL generation bonus by spreading seeds from outer space"
            });
            items.Add(new ItemData
            {
                Name = "RocketPressure1",
                DisplayName = "Magnetic Field Protection Rocket",
                Description = "Attracts iridium asteroids. Gives a GLOBAL generation bonus by protecting the magnetic field"
            });
            items.Add(new ItemData
            {
                Name = "RocketReactor",
                DisplayName = "Rocket Engine",
                Description = "Rocket engine"
            });
            items.Add(new ItemData
            {
                Name = "Rod-alloy",
                DisplayName = "Super Alloy Rod",
                Description = "Extremely condensed Super Alloy"
            });
            items.Add(new ItemData
            {
                Name = "Rod-iridium",
                DisplayName = "Iridium Rod",
                Description = "Extremely condensed Iridium"
            });
            items.Add(new ItemData
            {
                Name = "Rod-osmium",
                DisplayName = "Osmium Rod",
                Description = "Extremely condensed Osmium"
            });
            items.Add(new ItemData
            {
                Name = "Rod-uranium",
                DisplayName = "Uranium Rod",
                Description = "Extremely condensed Uranium"
            });
            items.Add(new ItemData
            {
                Name = "ScreenBiomass",
                DisplayName = "Biomass Screen",
                Description = "Displays information about biomass"
            });
            items.Add(new ItemData
            {
                Name = "ScreenEnergy",
                DisplayName = "Screen - Energy Levels",
                Description = "Displays information about energy consumption"
            });
            items.Add(new ItemData
            {
                Name = "ScreenMap1",
                DisplayName = "Screen - Mapping",
                Description = "Shows a map of the surrounding area"
            });
            items.Add(new ItemData
            {
                Name = "ScreenMessage",
                DisplayName = "Screen - Transmissions",
                Description = "Displays transmissions received by the communication antenna"
            });
            items.Add(new ItemData
            {
                Name = "ScreenRockets",
                DisplayName = "Screen – Orbital Information",
                Description = "Displays information about rockets sent into orbit"
            });
            items.Add(new ItemData
            {
                Name = "ScreenTerraformation",
                DisplayName = "Screen - Terraformation",
                Description = "Displays information about terraformation"
            });
            items.Add(new ItemData
            {
                Name = "ScreenTerraStage",
                DisplayName = "Screen - Progress",
                Description = "Displays your progress on the different terraformation stages"
            });
            items.Add(new ItemData
            {
                Name = "ScreenUnlockables",
                DisplayName = "Screen - Blueprints",
                Description = "Displays information about new blueprints and how to unlock them"
            });
            items.Add(new ItemData
            {
                Name = "Seed0",
                DisplayName = "Lirma Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed0Growable",
                DisplayName = "Lirma Plant",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed1",
                DisplayName = "Shanga Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed1Growable",
                DisplayName = "Shanga Plant",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed2",
                DisplayName = "Pestera Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed2Growable",
                DisplayName = "Pestera Plant",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed3",
                DisplayName = "Nulna Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed3Growable",
                DisplayName = "Nulna Plant",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed4",
                DisplayName = "Tuska Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed4Growable",
                DisplayName = "Tuska Plant",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed5",
                DisplayName = "Orema Plant",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed5Growable",
                DisplayName = "Seed5growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed6",
                DisplayName = "Volnus Plant",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Seed6Growable",
                DisplayName = "Seed6growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "SeedGold",
                DisplayName = "Golden Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "SeedGoldGrowable",
                DisplayName = "Golden Plant",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "SeedSpreader1",
                DisplayName = "Flower Spreader",
                Description = "Insert a seed in this to grow flowers on a small outdoor area."
            });
            items.Add(new ItemData
            {
                Name = "SeedSpreader2",
                DisplayName = "T2 Flower Spreader",
                Description = "Insert a seed in this to grow flowers on a small outdoor area."
            });
            items.Add(new ItemData
            {
                Name = "Sign",
                DisplayName = "Sign",
                Description = "Displays a customized label"
            });
            items.Add(new ItemData
            {
                Name = "Silicon",
                DisplayName = "Silicon",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Silk",
                DisplayName = "Silk",
                Description = "Used to create materials"
            });
            items.Add(new ItemData
            {
                Name = "SilkGenerator",
                DisplayName = "Silk Generator",
                Description = "Produces silk"
            });
            items.Add(new ItemData
            {
                Name = "SilkWorm",
                DisplayName = "Silkworm",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-01",
                DisplayName = "Spacesuit Comto",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-02",
                DisplayName = "Spacesuit Blasto",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-03",
                DisplayName = "Spacesuit Primo",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-04",
                DisplayName = "Spacesuit Goldeo",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-05",
                DisplayName = "Spacesuit Scifo",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-06",
                DisplayName = "Spacesuit Cipto",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-07",
                DisplayName = "Spacesuit Beteo",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-08",
                DisplayName = "Spacesuit Tureo",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-09",
                DisplayName = "Spacesuit Fablo",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-10",
                DisplayName = "Spacesuit Tubio",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-11",
                DisplayName = "Spacesuit Vateo",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-12",
                DisplayName = "Spacesuit Widio",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-13",
                DisplayName = "Spacesuit Mekio",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-14",
                DisplayName = "Spacesuit Abyso",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-15",
                DisplayName = "Spacesuit Ettio",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-16",
                DisplayName = "Spacesuit Plesao",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Skin-17",
                DisplayName = "Spacesuit Rorao",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "SkinDisplayer",
                DisplayName = "Spacesuit Displayer",
                Description = "Insert a space suit to set it on display"
            });
            items.Add(new ItemData
            {
                Name = "SmartFabric",
                DisplayName = "Smart Fabric",
                Description = "Used for customizable items"
            });
            items.Add(new ItemData
            {
                Name = "Sofa",
                DisplayName = "Sofa",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "SofaAngle",
                DisplayName = "Corner Sofa",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "SofaColored",
                DisplayName = "Customizable Sofa",
                Description = "Click on it to change its color"
            });
            items.Add(new ItemData
            {
                Name = "SolarQuartz",
                DisplayName = "Solar Quartz",
                Description = "Quartz containing tremendous amounts of energy"
            });
            items.Add(new ItemData
            {
                Name = "Stairs",
                DisplayName = "Outdoor Stairs",
                Description = "A good way to reach new heights"
            });
            items.Add(new ItemData
            {
                Name = "Sulfur",
                DisplayName = "Sulfur",
                Description = "Sulfur"
            });
            items.Add(new ItemData
            {
                Name = "TableSmall",
                DisplayName = "Table",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Teleporter1",
                DisplayName = "Teleporter",
                Description = "Teleports you between places."
            });
            items.Add(new ItemData
            {
                Name = "TerraTokens100",
                DisplayName = "Terra Tokens: 100",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "TerraTokens1000",
                DisplayName = "Terra Tokens: 1000",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "TerraTokens500",
                DisplayName = "Terra Tokens: 500",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "TerraTokens5000",
                DisplayName = "Terra Tokens: 5000",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Titanium",
                DisplayName = "Titanium",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "TradePlatform1",
                DisplayName = "Trade Space Rocket",
                Description = "Allows you to send rockets into space to gain Terra Tokens. Can be used to unlock new recipes and items."
            });
            items.Add(new ItemData
            {
                Name = "Tree0Growable",
                DisplayName = "Tree0growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree0Seed",
                DisplayName = "Iterra Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree10Growable",
                DisplayName = "Tree10growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree10Seed",
                DisplayName = "Rosea Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree11Growable",
                DisplayName = "Tree11growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree11Seed",
                DisplayName = "Lillia Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree12Growable",
                DisplayName = "Tree12growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree12Seed",
                DisplayName = "Prunea Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree13Growable",
                DisplayName = "Tree13growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree13Seed",
                DisplayName = "Ruberu Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree1Growable",
                DisplayName = "Tree1growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree1Seed",
                DisplayName = "Linifolia Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree2Growable",
                DisplayName = "Tree2growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree2Seed",
                DisplayName = "Aleatus Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree3Growable",
                DisplayName = "Tree3growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree3Seed",
                DisplayName = "Cernea Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree4Growable",
                DisplayName = "Tree4growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree4Seed",
                DisplayName = "Elegea Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree5Growable",
                DisplayName = "Tree5growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree5Seed",
                DisplayName = "Humelora Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree6Growable",
                DisplayName = "Tree6growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree6Seed",
                DisplayName = "Aemora Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree7Growable",
                DisplayName = "Tree7growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree7Seed",
                DisplayName = "Pleom Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree8Growable",
                DisplayName = "Tree8growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree8Seed",
                DisplayName = "Soleus Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree9Growable",
                DisplayName = "Tree9growable",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Tree9Seed",
                DisplayName = "Shreox Tree Seed",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "TreePlanter",
                DisplayName = "Tree Pot",
                Description = "Insert a tree seed to grow a single tree"
            });
            items.Add(new ItemData
            {
                Name = "TreeRoot",
                DisplayName = "Tree Bark",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "TreeSpreader0",
                DisplayName = "Tree Spreader",
                Description = "Insert a tree seed in this to grow your first trees. Place on a water surface"
            });
            items.Add(new ItemData
            {
                Name = "TreeSpreader1",
                DisplayName = "T2 Tree Spreader",
                Description = "Insert a tree seed in this to grow trees"
            });
            items.Add(new ItemData
            {
                Name = "TreeSpreader2",
                DisplayName = "T3 Tree Spreader",
                Description = "Insert a tree seed in this to grow trees"
            });
            items.Add(new ItemData
            {
                Name = "Uranim",
                DisplayName = "Uranium",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "Vegetable0Growable",
                DisplayName = "Eggplant",
                Description = "Restores health"
            });
            items.Add(new ItemData
            {
                Name = "Vegetable0Seed",
                DisplayName = "Eggplant Seeds",
                Description = "Space eggplant seeds. Insert in a Food Grower"
            });
            items.Add(new ItemData
            {
                Name = "Vegetable1Growable",
                DisplayName = "Squash",
                Description = "Restores health"
            });
            items.Add(new ItemData
            {
                Name = "Vegetable1Seed",
                DisplayName = "Squash Seeds",
                Description = "Space squash seeds. Insert in a Food Grower"
            });
            items.Add(new ItemData
            {
                Name = "Vegetable2Growable",
                DisplayName = "Beans",
                Description = "Restores health"
            });
            items.Add(new ItemData
            {
                Name = "Vegetable2Seed",
                DisplayName = "Bean Seeds",
                Description = "Space beans seeds. Insert in a Food Grower"
            });
            items.Add(new ItemData
            {
                Name = "Vegetable3Growable",
                DisplayName = "Mushroom",
                Description = "Restores health"
            });
            items.Add(new ItemData
            {
                Name = "Vegetable3Seed",
                DisplayName = "Mushroom Seeds",
                Description = "Space mushroom seeds. Insert in a Food Grower"
            });
            items.Add(new ItemData
            {
                Name = "VegetableGrower1",
                DisplayName = "Food Grower",
                Description = "Grows food"
            });
            items.Add(new ItemData
            {
                Name = "VegetableGrower2",
                DisplayName = "T2 Food Grower",
                Description = "Grows food faster"
            });
            items.Add(new ItemData
            {
                Name = "Vegetube1",
                DisplayName = "T1 Vegetube",
                Description = "Insert a seed in this device to generate 0²"
            });
            items.Add(new ItemData
            {
                Name = "Vegetube2",
                DisplayName = "T2 Vegetube",
                Description = "Insert a seed in this device to generate 0²"
            });
            items.Add(new ItemData
            {
                Name = "VegetubeOutside1",
                DisplayName = "T3 Vegetube",
                Description = "Insert a seed in this device to generate 0²"
            });
            items.Add(new ItemData
            {
                Name = "WallInside",
                DisplayName = "Interior Wall",
                Description = "Interior wall"
            });
            items.Add(new ItemData
            {
                Name = "wallplain",
                DisplayName = "Plain Wall",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "WardenAustel",
                DisplayName = "Wardens Altar",
                Description = ""
            });
            items.Add(new ItemData
            {
                Name = "WardenKey",
                DisplayName = "Wardens Key",
                Description = "This strange device seems to be used to open a mechanism"
            });
            items.Add(new ItemData
            {
                Name = "WardensChip",
                DisplayName = "Warden Key Detector",
                Description = "Equip this and explore the world to reveal wardens hidden structures"
            });
            items.Add(new ItemData
            {
                Name = "WaterBottle1",
                DisplayName = "Water Bottle",
                Description = "Fully quench your thirst"
            });
            items.Add(new ItemData
            {
                Name = "WaterCollector1",
                DisplayName = "Atmospheric Water Collector",
                Description = "Automatically collects water from humid ambient air"
            });
            items.Add(new ItemData
            {
                Name = "WaterCollector2",
                DisplayName = "Lake Water Collector",
                Description = "Collects and filters water from water surfaces"
            });
            items.Add(new ItemData
            {
                Name = "WaterFilter",
                DisplayName = "Water Filter",
                Description = "Allows you to drink directly from lakes"
            });
            items.Add(new ItemData
            {
                Name = "WaterLifeCollector1",
                DisplayName = "Water Life Collector",
                Description = "Collects phytoplankton and fish eggs depending on its location"
            });
            items.Add(new ItemData
            {
                Name = "window",
                DisplayName = "Living Compartment Window",
                Description = "Glass wall for living compartments"
            });
            items.Add(new ItemData
            {
                Name = "Zeolite",
                DisplayName = "Zeolite",
                Description = ""
            });
        }
    }

    public class ModEntry : MonoBehaviour
    {
        private List<WindowData> windows = new List<WindowData>();
        private bool isAnyWindowShowing = false;

        private CursorLockMode currentCursorLockState = CursorLockMode.None;

        // Spawner Window
        private string searchInput = "";
        private Vector2 searchScrollPositon;
        private List<ItemData> displayedItems = new List<ItemData>();

        // Console Window
        private Vector2 scrollPosition;
        private string inputCommand = "";
        private Queue<string> logMessages = new Queue<string>();
        private const int MAX_LOG_MESSAGES = 100;

        

        public void Start()
        {
            windows.Add(new WindowData()
            {
                windowID = WindowManager.GetNextWindowID(),
                windowRect = new Rect(20 + (1 * 50), 20 + (1 * 50), 200, 100),
                showWindow = false,
                windowTitle = $"Player Options",
                windowType = WindowType.PLAYER
            });
            windows.Add(new WindowData()
            {
                windowID = WindowManager.GetNextWindowID(),
                windowRect = new Rect(20 + (2 * 50), 20 + (2 * 50), 250, 150),
                showWindow = false,
                windowTitle = $"Item Spawner",
                windowType = WindowType.SPAWNER
            });
            windows.Add(new WindowData()
            {
                windowID = WindowManager.GetNextWindowID(),
                windowRect = new Rect(20 + (3 * 50), 20 + (3 * 50), 400, 300),
                showWindow = false,
                windowTitle = $"Debug Console",
                windowType = WindowType.CONSOLE
            });
        }

        public void Update()
        {
            if (Keyboard.current.deleteKey.wasPressedThisFrame)
            {
                isAnyWindowShowing = !isAnyWindowShowing;

                // Toggle all window
                for (int i = 0; i < windows.Count; i++)
                {
                    if (isAnyWindowShowing && !windows[i].showWindow)
                    {
                        windows[i].showWindow = true;

                    }
                    else if (!isAnyWindowShowing && windows[i].showWindow)
                    {
                        windows[i].showWindow = false;
                    }
                }

                if (isAnyWindowShowing)
                {
                    Cursor.visible = true;
                    currentCursorLockState = Cursor.lockState;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.visible = false;
                    Cursor.lockState = currentCursorLockState;
                }
            }
        }

        public void OnGUI()
        {
            GUI.backgroundColor = Color.gray;

            for (int i = 0; i < windows.Count; i++)
            {
                if (windows[i].showWindow)
                {
                    windows[i].windowRect = GUILayout.Window(windows[i].windowID,
                                                           windows[i].windowRect,
                                                           WindowFunction,
                                                           windows[i].windowTitle);
                }
            }
        }

        private void UpdateDisplayedItems()
        {
            displayedItems.Clear();

            if (string.IsNullOrEmpty(searchInput))
            {
                displayedItems.AddRange(ItemIds.items);
            }
            else
            {
                string searchLower = searchInput.ToLower();
                foreach (var item in ItemIds.items)
                {
                    if (item.Name.ToLower().Contains(searchLower) ||
                        item.DisplayName.ToLower().Contains(searchLower))
                    {
                        displayedItems.Add(item);
                    }
                }
            }
        }

        // Function to draw the window content
        private void WindowFunction(int id)
        {
            // Find the WindowData corresponding to this window ID
            WindowData windowData = windows.Find(w => w.windowID == id);

            if (windowData == null) return;
            
            if (windowData.windowType == WindowType.PLAYER)
            {
                GUILayout.Label("Player Window");
                GUILayout.Space(20);

                if (GUILayout.Button("Fill Hunger"))
                {
                    LogMsg("Filling hunger...");
                }

                if (GUILayout.Button("Fill Food"))
                {
                    LogMsg("Filling food...");
                }

                if (GUILayout.Button("Fill Oxygen"))
                {
                    LogMsg("Filling oxygen...");
                }

                GUILayout.Space(20);
                // Close button
                if (GUILayout.Button("Close"))
                {
                    windowData.showWindow = false;
                }
            }
            else if (windowData.windowType == WindowType.SPAWNER)
            {
                GUILayout.Label("Item IDs", new GUIStyle(GUI.skin.label) { fontSize = 24 });
                searchInput = GUILayout.TextField(searchInput, new GUIStyle(GUI.skin.textField) { fontSize = 16 });

                if (GUI.changed)
                {
                    UpdateDisplayedItems();
                }

                searchScrollPositon = GUILayout.BeginScrollView(searchScrollPositon, GUILayout.Height(250));
                {
                    foreach (var item in displayedItems)
                    {
                        GUILayout.BeginHorizontal();

                        if (GUILayout.Button(item.Name, new GUILayoutOption[] { GUILayout.Width(120) }))
                        {
                            LogMsg($"Spawning {item.Name}...");
                            SpawnItem(item.Name, 1);
                        }
                        GUILayout.Label(item.Description, new GUIStyle(GUI.skin.label) { fontSize = 14 });

                        GUILayout.EndHorizontal();
                    }
                }
                GUILayout.EndScrollView();

                GUILayout.Space(20);
                // Close button
                if (GUILayout.Button("Close"))
                {
                    windowData.showWindow = false;
                }
            }
            else if (windowData.windowType == WindowType.CONSOLE)
            {
                scrollPosition = GUILayout.BeginScrollView(scrollPosition);
                for (int i = 0; i < logMessages.Count; i++)
                {
                    GUILayout.Label(logMessages.ElementAt(i).ToString());
                }
                GUILayout.EndScrollView();

                GUILayout.BeginHorizontal();
                {
                    inputCommand = GUILayout.TextField(inputCommand);
                    if (GUILayout.Button("Send", new GUILayoutOption[] { GUILayout.Width(50) }))
                    {
                        if (!string.IsNullOrEmpty(inputCommand))
                        {
                            ProcessCommand(inputCommand);
                            inputCommand = "";
                        }
                    }
                }
                GUILayout.EndHorizontal();

                GUILayout.Space(20);
                // Close button
                if (GUILayout.Button("Close"))
                {
                    windowData.showWindow = false;
                }
            }

            GUI.DragWindow();
        }

        private void ProcessCommand(string command = "")
        {
            if (string.IsNullOrEmpty(command)) return;

            string[] parts = command.Split(' ');

            switch (parts[0])
            {
                case "log":
                    LogMsg(string.Join(" ", parts, 1, parts.Length - 1));
                    break;
                case "help":
                    LogMsg("Available commands:\n" +
                        "  help: Shows this help message.\n" +
                        "  spawn itemId count: Spawns itemId with count (1-100).\n" +
                        "  clear: Clears the log.", false);
                    break;
                case "spawn":
                    if (parts.Length != 3)
                    {
                        LogMsg("Usage: spawn itemId count", false);
                        break;
                    }
                    string itemId = parts[1].Trim();
                    if (string.IsNullOrEmpty(itemId))
                    {
                        LogMsg("Invalid item ID. Item ID cannot be empty or whitespace.", false);
                        break;
                    }

                    if (int.TryParse(parts[2], out int count))
                    {
                        if (count <= 0 || count > 100)
                        {
                            LogMsg("Invalid count. Count must be between 1 and 100.", false);
                            break;
                        }
                        LogMsg($"Spawning {count} items with ID {itemId}");
                        SpawnItem(itemId, count);
                    }
                    else
                    {
                        LogMsg("Invalid item ID or count.", false);
                    }
                    break;
                case "clear":
                    logMessages.Clear();
                    break;
                default:
                    LogMsg($"Unknown command: {parts[0]}, type 'help' for a list of available commands.", false);
                    break;
            }
        }

        public void LogMsg(string message, bool usePrefix = true)
        {
            if (usePrefix) message = $"[{DateTime.Now:HH:mm:ss}] {message}";

            if (logMessages.Count >= MAX_LOG_MESSAGES)
            {
                logMessages.Dequeue();
            }

            logMessages.Enqueue(message);
        }

        // Spawn Item
        private void SpawnItem(string itemId, int count, bool onGround = false)
        {
            // !IMPORTANT We dont want an item of buildable inside player inventory or on ground
            PlayerMainController player = Managers.GetManager<PlayersManager>().GetActivePlayerController();
            PlayerBackpack backpack = player.GetPlayerBackpack();

            Group group = GroupsHandler.GetAllGroups().FirstOrDefault(g => g.GetId() == itemId);
            if (group == null)
            {
                LogMsg($"Item with ID {itemId} not found", false);
                return;
            }

            if (WorldObjectsHandler.Instance == null)
            {
                LogMsg("WorldObjectsHandler not found", false);
                return;
            }

            if (group is GroupConstructible)
            {
                LogMsg("Cannot spawn constructible items, attempting to spawn as buildable", false);
                player.StartCoroutine(SpawnConstructibleCoroutine(group as GroupConstructible));
                return;
            }

            if (onGround)
            {
                Ray aimRay = player.GetAimController().GetAimRay();
                LogMsg($"Spawning {count} items with ID {itemId} on the ground");
                WorldObjectsHandler.Instance.CreateAndDropOnFloor(group, aimRay.GetPoint(0.7f), 0f);
            }
            else if (!onGround && !backpack.GetInventory().IsFull())
            {
                LogMsg($"Spawning {count} items with ID {itemId} in your inventory");
                for (int i = 0; i < count; i++)
                {
                    backpack.GetInventory().AddItem(WorldObjectsHandler.Instance.CreateNewWorldObject(group, 0, null));
                }
            }
            else
            {
                LogMsg("Your inventory is full.", false);
            }
        }

        private System.Collections.IEnumerator SpawnConstructibleCoroutine(Group group)
        {
            GameObject gameObject = Object.Instantiate<GameObject>(group.GetAssociatedGameObject());
            ConstructibleGhost ghost = gameObject.AddComponent<ConstructibleGhost>();
            ghost.InitGhost((GroupConstructible)group, Managers.GetManager<PlayersManager>().GetActivePlayerController().GetAimController());
            yield return new WaitForEndOfFrame();
            AccessTools.Method(typeof(GhostPlacementChecker), "CheckPlacement", null, null).Invoke(ghost.gameObject.GetComponent<GhostPlacementChecker>(), new object[0]);
            bool flag = !ghost.Place();
            if (flag)
            {
                ghost.DestroyGhost();
            }
            yield break;
        }

        public void OnDestroy()
        {
            // Destroy Self
            if (Loader.GameObjectRef != null)
            {
                Destroy(Loader.GameObjectRef.GetComponent<ModEntry>());
            }
        }
    }
}
