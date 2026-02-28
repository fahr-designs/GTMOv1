using GardenKeeper.Domain.Entities;
using GardenKeeper.Domain.Enums;

namespace GardenKeeper.Infrastructure.Data;

public static class PlantSeedData
{
    public static Plant[] GetPlants() =>
    [
        // ── VEGETABLES ──────────────────────────────────────────────────────────
        new Plant
        {
            Id = 1,
            CommonName = "Tomato",
            ScientificName = "Solanum lycopersicum",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 75,
            SpacingInches = 24,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Basil, Parsley, Carrot, Marigold",
            CropRotationNotes = "Rotate out of nightshade family beds annually. Avoid planting after pepper or eggplant.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA, OpenFarm",
            Notes = "Kansas staple; start seeds indoors 6-8 weeks before last frost (mid-April)."
        },
        new Plant
        {
            Id = 2,
            CommonName = "Bell Pepper",
            ScientificName = "Capsicum annuum",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 70,
            SpacingInches = 18,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Tomato, Basil, Carrot",
            CropRotationNotes = "Nightshade family; rotate with brassicas or legumes.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA, OpenFarm",
            Notes = "Needs warm soil; transplant after danger of frost has passed."
        },
        new Plant
        {
            Id = 3,
            CommonName = "Cucumber",
            ScientificName = "Cucumis sativus",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 55,
            SpacingInches = 12,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.High,
            CompanionPlants = "Beans, Dill, Sunflower",
            CropRotationNotes = "Cucurbit family; rotate annually to prevent cucumber beetles.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA, OpenFarm"
        },
        new Plant
        {
            Id = 4,
            CommonName = "Zucchini",
            ScientificName = "Cucurbita pepo",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 50,
            SpacingInches = 36,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Corn, Beans, Nasturtium",
            CropRotationNotes = "Cucurbit family; rotate with nightshades or brassicas.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 5,
            CommonName = "Green Bean",
            ScientificName = "Phaseolus vulgaris",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 55,
            SpacingInches = 6,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Corn, Squash, Carrot, Cucumber",
            CropRotationNotes = "Legume; fixes nitrogen — plant before heavy feeders like corn.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA, OpenFarm"
        },
        new Plant
        {
            Id = 6,
            CommonName = "Sweet Corn",
            ScientificName = "Zea mays",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 80,
            SpacingInches = 12,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.High,
            CompanionPlants = "Beans, Squash, Sunflower",
            CropRotationNotes = "Heavy feeder; rotate with legumes to replenish nitrogen.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 7,
            CommonName = "Lettuce",
            ScientificName = "Lactuca sativa",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 45,
            SpacingInches = 8,
            SunRequirement = SunRequirement.PartialShade,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Carrot, Radish, Chives, Dill",
            CropRotationNotes = "Light feeder; good following heavy feeders.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA, OpenFarm",
            Notes = "Best as a spring or fall crop in Kansas; bolts in summer heat."
        },
        new Plant
        {
            Id = 8,
            CommonName = "Spinach",
            ScientificName = "Spinacia oleracea",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 40,
            SpacingInches = 6,
            SunRequirement = SunRequirement.PartialShade,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Strawberry, Peas, Brassicas",
            CropRotationNotes = "Good following root crops; avoid planting with chard.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 9,
            CommonName = "Carrot",
            ScientificName = "Daucus carota subsp. sativus",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 70,
            SpacingInches = 3,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Tomato, Lettuce, Chives, Rosemary",
            CropRotationNotes = "Root crop; rotate with leaf or fruit crops.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA, OpenFarm"
        },
        new Plant
        {
            Id = 10,
            CommonName = "Radish",
            ScientificName = "Raphanus sativus",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 25,
            SpacingInches = 2,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Lettuce, Spinach, Cucumber, Peas",
            CropRotationNotes = "Brassica family; rotate annually.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 11,
            CommonName = "Beet",
            ScientificName = "Beta vulgaris",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 60,
            SpacingInches = 4,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Onion, Lettuce, Cabbage",
            CropRotationNotes = "Avoid planting near spinach or chard; rotate with nightshades.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 12,
            CommonName = "Kale",
            ScientificName = "Brassica oleracea var. sabellica",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 60,
            SpacingInches = 18,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Beet, Celery, Onion, Herbs",
            CropRotationNotes = "Brassica family; rotate annually to prevent clubroot.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA, OpenFarm",
            Notes = "Cold-hardy; flavor improves after frost."
        },
        new Plant
        {
            Id = 13,
            CommonName = "Broccoli",
            ScientificName = "Brassica oleracea var. italica",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 65,
            SpacingInches = 18,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Onion, Celery, Beet, Chamomile",
            CropRotationNotes = "Brassica; do not follow other brassicas. Plant after legumes.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 14,
            CommonName = "Cabbage",
            ScientificName = "Brassica oleracea var. capitata",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 70,
            SpacingInches = 18,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Dill, Celery, Onion, Potato",
            CropRotationNotes = "Brassica; rotate with nightshades or cucurbits.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 15,
            CommonName = "Onion",
            ScientificName = "Allium cepa",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 100,
            SpacingInches = 4,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Carrot, Beet, Lettuce, Chamomile",
            CropRotationNotes = "Allium; rotate with brassicas or legumes.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA, OpenFarm"
        },
        new Plant
        {
            Id = 16,
            CommonName = "Garlic",
            ScientificName = "Allium sativum",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 240,
            SpacingInches = 6,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Tomato, Pepper, Beet, Rose",
            CropRotationNotes = "Allium; plant in fall, harvest summer. Rotate with brassicas.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA",
            Notes = "Plant cloves in October; harvest late June in Kansas."
        },
        new Plant
        {
            Id = 17,
            CommonName = "Pumpkin",
            ScientificName = "Cucurbita pepo",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 100,
            SpacingInches = 60,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Corn, Beans, Marigold",
            CropRotationNotes = "Cucurbit; rotate annually.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 18,
            CommonName = "Butternut Squash",
            ScientificName = "Cucurbita moschata",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 110,
            SpacingInches = 48,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Corn, Beans, Nasturtium",
            CropRotationNotes = "Cucurbit family; 3-year rotation recommended.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA, OpenFarm"
        },
        new Plant
        {
            Id = 19,
            CommonName = "Sweet Potato",
            ScientificName = "Ipomoea batatas",
            PlantType = PlantType.Vegetable,
            HardinessZones = "6a,6b,7a",
            DaysToMaturity = 100,
            SpacingInches = 12,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Beans, Thyme, Oregano",
            CropRotationNotes = "Avoid planting in same location as other morning-glories or tomatoes.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA",
            Notes = "Thrives in southern Kansas (zone 6b-7a); needs 100+ frost-free days."
        },
        new Plant
        {
            Id = 20,
            CommonName = "Potato",
            ScientificName = "Solanum tuberosum",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 80,
            SpacingInches = 12,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Beans, Corn, Horseradish",
            CropRotationNotes = "Nightshade; rotate with brassicas or legumes. Do not follow tomato.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 21,
            CommonName = "Eggplant",
            ScientificName = "Solanum melongena",
            PlantType = PlantType.Vegetable,
            HardinessZones = "6a,6b,7a",
            DaysToMaturity = 80,
            SpacingInches = 24,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Tomato, Pepper, Basil",
            CropRotationNotes = "Nightshade; rotate with legumes or brassicas.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 22,
            CommonName = "Swiss Chard",
            ScientificName = "Beta vulgaris subsp. vulgaris",
            PlantType = PlantType.Vegetable,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 60,
            SpacingInches = 12,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Beans, Cabbage, Onion",
            CropRotationNotes = "Related to beet; avoid following beet or spinach.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA"
        },

        // ── FRUITS ──────────────────────────────────────────────────────────────
        new Plant
        {
            Id = 23,
            CommonName = "Strawberry",
            ScientificName = "Fragaria × ananassa",
            PlantType = PlantType.Fruit,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 30,
            SpacingInches = 12,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Spinach, Lettuce, Thyme, Borage",
            CropRotationNotes = "Perennial; replace bed every 3-4 years. Avoid planting with cabbage.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA, OpenFarm",
            Notes = "June-bearing varieties most common in Kansas."
        },
        new Plant
        {
            Id = 24,
            CommonName = "Watermelon",
            ScientificName = "Citrullus lanatus",
            PlantType = PlantType.Fruit,
            HardinessZones = "6a,6b,7a",
            DaysToMaturity = 85,
            SpacingInches = 72,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.High,
            CompanionPlants = "Corn, Sunflower, Nasturtium",
            CropRotationNotes = "Cucurbit; 3-year rotation. Kansas summers ideal.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 25,
            CommonName = "Cantaloupe",
            ScientificName = "Cucumis melo var. cantalupensis",
            PlantType = PlantType.Fruit,
            HardinessZones = "6a,6b,7a",
            DaysToMaturity = 80,
            SpacingInches = 48,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Corn, Sunflower, Radish",
            CropRotationNotes = "Cucurbit family; rotate with nightshades or brassicas.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 26,
            CommonName = "Blackberry",
            ScientificName = "Rubus allegheniensis",
            PlantType = PlantType.Fruit,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 36,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Comfrey, Tansy, Marigold",
            CropRotationNotes = "Perennial bramble; permanent planting. Keep away from raspberries.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA",
            Notes = "Native-adjacent thorny varieties very well adapted to Kansas."
        },

        // ── HERBS ────────────────────────────────────────────────────────────────
        new Plant
        {
            Id = 27,
            CommonName = "Basil",
            ScientificName = "Ocimum basilicum",
            PlantType = PlantType.Herb,
            HardinessZones = "6a,6b,7a",
            DaysToMaturity = 30,
            SpacingInches = 12,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Tomato, Pepper, Oregano",
            CropRotationNotes = "Annual; rotate freely.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "OpenFarm",
            Notes = "Repels aphids and whiteflies; excellent tomato companion."
        },
        new Plant
        {
            Id = 28,
            CommonName = "Cilantro",
            ScientificName = "Coriandrum sativum",
            PlantType = PlantType.Herb,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 45,
            SpacingInches = 6,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Spinach, Lettuce, Dill, Carrot",
            CropRotationNotes = "Annual herb; minimal rotation concern.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "OpenFarm",
            Notes = "Bolts quickly in Kansas summer; grow in spring/fall."
        },
        new Plant
        {
            Id = 29,
            CommonName = "Parsley",
            ScientificName = "Petroselinum crispum",
            PlantType = PlantType.Herb,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 70,
            SpacingInches = 8,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Tomato, Asparagus, Rose",
            CropRotationNotes = "Biennial; carrot family. Rotate with other families.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 30,
            CommonName = "Dill",
            ScientificName = "Anethum graveolens",
            PlantType = PlantType.Herb,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 40,
            SpacingInches = 12,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Cucumber, Lettuce, Onion, Brassicas",
            CropRotationNotes = "Carrot family annual; keep away from mature fennel.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "OpenFarm"
        },
        new Plant
        {
            Id = 31,
            CommonName = "Chives",
            ScientificName = "Allium schoenoprasum",
            PlantType = PlantType.Herb,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 60,
            SpacingInches = 6,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Carrot, Tomato, Apple, Rose",
            CropRotationNotes = "Perennial allium; permanent planting in herb bed.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 32,
            CommonName = "Mint",
            ScientificName = "Mentha spicata",
            PlantType = PlantType.Herb,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 90,
            SpacingInches = 24,
            SunRequirement = SunRequirement.PartialShade,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Tomato, Brassicas, Peas",
            CropRotationNotes = "Perennial; contains aggressively — consider containers.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "OpenFarm",
            Notes = "Very invasive; grow in containers or with root barrier."
        },
        new Plant
        {
            Id = 33,
            CommonName = "Oregano",
            ScientificName = "Origanum vulgare",
            PlantType = PlantType.Herb,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 80,
            SpacingInches = 12,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Pepper, Tomato, Squash",
            CropRotationNotes = "Perennial herb; permanent bed planting.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "OpenFarm"
        },
        new Plant
        {
            Id = 34,
            CommonName = "Thyme",
            ScientificName = "Thymus vulgaris",
            PlantType = PlantType.Herb,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 90,
            SpacingInches = 12,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Tomato, Eggplant, Cabbage, Strawberry",
            CropRotationNotes = "Perennial; low maintenance. Good border plant.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA, OpenFarm"
        },
        new Plant
        {
            Id = 35,
            CommonName = "Sage",
            ScientificName = "Salvia officinalis",
            PlantType = PlantType.Herb,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 75,
            SpacingInches = 24,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Tomato, Cabbage, Carrot, Strawberry",
            CropRotationNotes = "Perennial shrubby herb; replace every 3-4 years.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA"
        },
        new Plant
        {
            Id = 36,
            CommonName = "Lavender",
            ScientificName = "Lavandula angustifolia",
            PlantType = PlantType.Herb,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 90,
            SpacingInches = 24,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Rose, Sage, Thyme, Brassicas",
            CropRotationNotes = "Perennial; permanent planting. Excellent pollinator attractor.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA, OpenFarm",
            Notes = "Excellent deer-resistant pollinator plant for Kansas."
        },

        // ── NATIVE PLANTS & FLOWERS ──────────────────────────────────────────────
        new Plant
        {
            Id = 37,
            CommonName = "Purple Coneflower",
            ScientificName = "Echinacea purpurea",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 18,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Black-eyed Susan, Wild Bergamot, Blazing Star",
            CropRotationNotes = "Perennial native; leave seed heads for birds over winter.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA",
            Notes = "Kansas native; drought-tolerant; blooms June-October."
        },
        new Plant
        {
            Id = 38,
            CommonName = "Black-eyed Susan",
            ScientificName = "Rudbeckia hirta",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 18,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Coneflower, Blazing Star, Wild Bergamot",
            CropRotationNotes = "Biennial/perennial native; self-seeds readily.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA",
            Notes = "Official wildflower of Maryland; widely naturalized in Kansas."
        },
        new Plant
        {
            Id = 39,
            CommonName = "Wild Bergamot",
            ScientificName = "Monarda fistulosa",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 24,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Coneflower, Black-eyed Susan, Prairie Clover",
            CropRotationNotes = "Perennial native; spreads by rhizomes. Divide every 3 years.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA",
            Notes = "Excellent native bee and butterfly plant; aromatic foliage."
        },
        new Plant
        {
            Id = 40,
            CommonName = "Prairie Blazing Star",
            ScientificName = "Liatris pycnostachya",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 18,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Coneflower, Black-eyed Susan, Wild Bergamot",
            CropRotationNotes = "Perennial corm; permanent planting.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA",
            Notes = "Kansas native; monarch butterfly magnet; blooms August-September."
        },
        new Plant
        {
            Id = 41,
            CommonName = "Butterfly Weed",
            ScientificName = "Asclepias tuberosa",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 18,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Prairie Blazing Star, Coneflower, Goldenrod",
            CropRotationNotes = "Deep tap root; do not transplant once established.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA",
            Notes = "Essential monarch butterfly host plant; native milkweed."
        },
        new Plant
        {
            Id = 42,
            CommonName = "Plains Sunflower",
            ScientificName = "Helianthus annuus",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 80,
            SpacingInches = 24,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Corn, Cucumber, Tomato",
            CropRotationNotes = "Annual; excellent insectary plant and bird food source.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA",
            Notes = "State flower of Kansas. Direct-sow after last frost."
        },
        new Plant
        {
            Id = 43,
            CommonName = "Blue Wild Indigo",
            ScientificName = "Baptisia australis",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 36,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Wild Bergamot, Prairie Clover, Coneflower",
            CropRotationNotes = "Long-lived perennial; fixes nitrogen. Do not move once established.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA",
            Notes = "Deep-rooted prairie legume; slow to establish but very long-lived."
        },
        new Plant
        {
            Id = 44,
            CommonName = "Compass Plant",
            ScientificName = "Silphium laciniatum",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 36,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Prairie Blazing Star, Wild Bergamot, Compass Plant",
            CropRotationNotes = "Perennial; tap root can reach 15 feet deep. Do not disturb.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA",
            Notes = "Iconic tallgrass prairie species; leaves orient north-south."
        },
        new Plant
        {
            Id = 45,
            CommonName = "Ironweed",
            ScientificName = "Vernonia fasciculata",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 24,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Moderate,
            CompanionPlants = "Goldenrod, Wild Bergamot, Ironweed",
            CropRotationNotes = "Perennial native; spreading clumps, divide every 4 years.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA",
            Notes = "Brilliant purple blooms in late summer; attracts many butterfly species."
        },
        new Plant
        {
            Id = 46,
            CommonName = "Wild Columbine",
            ScientificName = "Aquilegia canadensis",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 12,
            SunRequirement = SunRequirement.PartialShade,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Wild Ginger, Wild Bergamot, Ferns",
            CropRotationNotes = "Perennial; self-seeds. Good woodland edge plant.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA",
            Notes = "Native to eastern Kansas; hummingbird favorite; early spring bloomer."
        },
        new Plant
        {
            Id = 47,
            CommonName = "Purple Prairie Clover",
            ScientificName = "Dalea purpurea",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 18,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Prairie Blazing Star, Wild Bergamot, Coneflower",
            CropRotationNotes = "Perennial legume; fixes nitrogen. Permanent planting.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA",
            Notes = "Essential native bee plant; extremely drought-tolerant."
        },
        new Plant
        {
            Id = 48,
            CommonName = "Prairie Phlox",
            ScientificName = "Phlox pilosa",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 12,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Wild Columbine, Wild Bergamot, Coneflower",
            CropRotationNotes = "Perennial; divide every 3 years to keep vigorous.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA",
            Notes = "Fragrant spring bloomer; native to Kansas prairies."
        },
        new Plant
        {
            Id = 49,
            CommonName = "Wild Petunia",
            ScientificName = "Ruellia humilis",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 18,
            SunRequirement = SunRequirement.PartialShade,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Wild Columbine, Prairie Phlox, Coneflower",
            CropRotationNotes = "Perennial native; self-seeds freely.",
            TypicalStartMethod = StartMethod.Seed,
            DataSource = "USDA",
            Notes = "Low-growing native great for garden edges and dry spots."
        },
        new Plant
        {
            Id = 50,
            CommonName = "Prairie Dropseed",
            ScientificName = "Sporobolus heterolepis",
            PlantType = PlantType.NativePlant,
            HardinessZones = "5b,6a,6b,7a",
            DaysToMaturity = 365,
            SpacingInches = 24,
            SunRequirement = SunRequirement.FullSun,
            WaterRequirement = WaterRequirement.Low,
            CompanionPlants = "Purple Prairie Clover, Coneflower, Wild Bergamot",
            CropRotationNotes = "Perennial native grass; permanent planting.",
            TypicalStartMethod = StartMethod.Transplant,
            DataSource = "USDA",
            Notes = "Fragrant native bunchgrass; excellent four-season interest."
        }
    ];
}
