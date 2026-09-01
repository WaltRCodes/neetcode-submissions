public class Meal {
    private double cost;
    private bool takeOut;
    private string main;
    private string drink;

    public double getCost() {
        return this.cost;
    }

    public bool getTakeOut() {
        return this.takeOut;
    }

    public string getMain() {
        return this.main;
    }

    public string getDrink() {
        return this.drink;
    }

    public void setCost(double cost) {
        this.cost = cost;
    }

    public void setTakeOut(bool takeOut) {
        this.takeOut = takeOut;
    }

    public void setMain(string main) {
        this.main = main;
    }

    public void setDrink(string drink) {
        this.drink = drink;
    }
}

public class MealBuilder {

    private Meal meal;

    public MealBuilder() {
        meal = new Meal();
    }

    public MealBuilder addCost(double cost) {
        meal.setCost(cost);
        return this;
    }

    public MealBuilder addTakeOut(bool takeOut) {
        meal.setTakeOut(takeOut);
        return this;
    }

    public MealBuilder addMainCourse(string main) {
        meal.setMain(main);
        return this;
    }

    public MealBuilder addDrink(string drink) {
        meal.setDrink(drink);
        return this;
    }

    public Meal build() {
        return meal;
    }
}
