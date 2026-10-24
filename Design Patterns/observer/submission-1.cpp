class Observer {
public:
    virtual void notify(string& itemName) = 0;
};

class Customer : public Observer {
private:
    string name;
    int notifications;

public:
    Customer(string& name) : name(name), notifications(0) {}

    void notify(string& itemName) override {
        notifications += 1;
    }

    int countNotifications() {
        return notifications;
    }
};

class OnlineStoreItem {
private:
    string itemName;
    int stock;
    vector<Observer*> observers;

public:
    OnlineStoreItem(string& itemName, int stock) : itemName(itemName), stock(stock) {}

    void subscribe(Observer* observer) {
        observers.push_back(observer);
    }

    void unsubscribe(Observer* observer) {
        observers.erase(remove(observers.begin(),observers.end(),observer),observers.end());
    }

    void updateStock(int newStock) {
        int oldStock = this->stock;
        this->stock = newStock;

        if (oldStock == 0 && newStock > 0) {
            notifyObservers();
        }
    }

private:
    void notifyObservers() {
        for (Observer* observer : observers) {
            observer->notify(itemName);
        }
    }
};
