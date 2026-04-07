using System;

// 1) Interface = Common Rule for all meal types
interface IMealPlan
{
    string GetMealName();       // Meal type name
    string GetBreakfast();      // Breakfast item
    string GetLunch();          // Lunch item
    string GetDinner();         // Dinner item
}

// 2) Vegetarian Meal Plan
class VegetarianMeal : IMealPlan
{
    public string GetMealName() => "Vegetarian";

    public string GetBreakfast() => "Poha + Milk";
    public string GetLunch() => "Dal + Rice + Salad";
    public string GetDinner() => "Paneer Curry + Roti";
}

// 3) Vegan Meal Plan
class VeganMeal : IMealPlan
{
    public string GetMealName() => "Vegan";

    public string GetBreakfast() => "Oats + Fruits";
    public string GetLunch() => "Chana Salad + Brown Rice";
    public string GetDinner() => "Vegetable Soup + Roti";
}

// 4) Keto Meal Plan
class KetoMeal : IMealPlan
{
    public string GetMealName() => "Keto";

    public string GetBreakfast() => "Boiled Eggs + Nuts";
    public string GetLunch() => "Grilled Chicken + Cheese";
    public string GetDinner() => "Paneer + Green Veggies";
}

// 5) High Protein Meal Plan
class HighProteinMeal : IMealPlan
{
    public string GetMealName() => "High Protein";

    public string GetBreakfast() => "Egg Omelette + Milk";
    public string GetLunch() => "Chicken Breast + Dal";
    public string GetDinner() => "Fish + Salad";
}

// 6) Generic class Meal<T> where T must be IMealPlan
class Meal<T> where T : IMealPlan, new()
{
    // Generic method to generate and print meal plan
    public void GeneratePlan()
    {
        T meal = new T(); // Create object of selected meal type

        Console.WriteLine("\n Your Meal Plan Type: " + meal.GetMealName());
        Console.WriteLine(" Breakfast : " + meal.GetBreakfast());
        Console.WriteLine(" Lunch     : " + meal.GetLunch());
        Console.WriteLine("Dinner    : " + meal.GetDinner());
    }
}

// 7) Main Program
class MealPlanGenerator
{
    static void Main()
    {
        Console.WriteLine("=== Personalized Meal Plan Generator ===");
        Console.WriteLine("1. Vegetarian");
        Console.WriteLine("2. Vegan");
        Console.WriteLine("3. Keto");
        Console.WriteLine("4. High Protein");

        Console.Write("\nEnter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        // Validate choice + Generate meal plan dynamically
        if (choice == 1)
        {
            Meal<VegetarianMeal> plan = new Meal<VegetarianMeal>();
            plan.GeneratePlan();
        }
        else if (choice == 2)
        {
            Meal<VeganMeal> plan = new Meal<VeganMeal>();
            plan.GeneratePlan();
        }
        else if (choice == 3)
        {
            Meal<KetoMeal> plan = new Meal<KetoMeal>();
            plan.GeneratePlan();
        }
        else if (choice == 4)
        {
            Meal<HighProteinMeal> plan = new Meal<HighProteinMeal>();
            plan.GeneratePlan();
        }
        else
        {
            Console.WriteLine("❌ Invalid Choice! Please select 1-4");
        }

        Console.WriteLine("\nPress Enter to Exit...");
        Console.ReadLine();
    }
}
