public abstract class Coffee {
    public abstract double getCost();
}

public class SimpleCoffee : Coffee {
    public override double getCost() {
        return 1.1;
    }
}

public abstract class CoffeeDecorator : Coffee {
    protected Coffee decoratedCoffee;

    public CoffeeDecorator(Coffee coffee) {
        this.decoratedCoffee = coffee;
    }

    public override double getCost() {
        return decoratedCoffee.getCost();
    }
}

public class MilkDecorator : CoffeeDecorator {
    public MilkDecorator(Coffee coffee) : base(coffee) {}

    public override double getCost() {
        return base.getCost() + 0.5;
    }
}

public class SugarDecorator : CoffeeDecorator {
    public SugarDecorator(Coffee coffee) : base(coffee) {}

    public override double getCost(){
        return base.getCost() + 0.2;
    }
}

public class CreamDecorator : CoffeeDecorator {
    public CreamDecorator(Coffee coffee) : base(coffee) {}

    public override double getCost(){
        return base.getCost() + 0.7;
    }
}
