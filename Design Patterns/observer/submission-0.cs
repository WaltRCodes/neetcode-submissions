public interface IObserver {
    void notify(string itemName);
}

public class Customer : IObserver {
    private string name;
    private int notifications;

    public Customer(string name) {
        this.name = name;
        this.notifications = 0;
    }

    public string getName() {
        return this.name;
    }

    public void notify(string itemName) {
        this.notifications += 1;
    }

    public int countNotifications() {
        return this.notifications;
    }
}

public class OnlineStoreItem {
    private string itemName;
    private int stock;
    private List<IObserver> observers;

    public OnlineStoreItem(string itemName, int stock) {
        this.itemName = itemName;
        this.stock = stock;
        this.observers = new List<IObserver>();
    }

    public void subscribe(IObserver observer) {
        observers.Add(observer);
    }

    public void unsubscribe(IObserver observer) {
        observers.Remove(observer);
    }

    public void updateStock(int newStock) {
        int oldStock = this.stock;
        this.stock = newStock;

        if (oldStock == 0 && newStock > 0){
            notifyObservers();
        }
    }

    public void notifyObservers(){
        foreach (var observer in observers){
            observer.notify(itemName);
        }
    }
}
