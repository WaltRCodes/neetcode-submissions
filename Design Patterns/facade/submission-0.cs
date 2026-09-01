public class Order {
    private string contents;
    private bool takeOut;

    public Order(string contents, bool takeOut) {
        this.contents = contents;
        this.takeOut = takeOut;
    }

    public string getOrder() {
        return contents;
    }

    public bool isTakeOut() {
        return takeOut;
    }
}

public class Cashier {
    public Order takeOrder(string contents, bool takeOut) {
        return new Order(contents, takeOut);
    }
}

public class Food {
    private string contents;

    public Food(string order) {
        this.contents = order;
    }

    public string getFood() {
        return contents;
    }
}

public class Chef {
    public Food prepareFood(Order order) {
        return new Food(order.getOrder());
    }
}

public class PackagedFood : Food {
    public PackagedFood(Food food) : base(food.getFood() + " in a bag") {
    }
}

public class KitchenStaff {
    public PackagedFood packageOrder(Food food) {
        return new PackagedFood(food);
    }
}

public class DriveThruFacade {
    private Cashier cashier = new Cashier();
    private Chef chef = new Chef();
    private KitchenStaff kitchenStaff = new KitchenStaff();

    public Food takeOrder(string orderContents, bool takeOut) {
        Order order = cashier.takeOrder(orderContents, takeOut);
        Food food = chef.prepareFood(order);
        if (order.isTakeOut()){
            return kitchenStaff.packageOrder(food);
        }
        return food;
    }
}
