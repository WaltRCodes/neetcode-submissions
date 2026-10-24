class State {
public:
    virtual void handleRequest(class Document* doc) = 0;
};

class Draft : public State {
public:
    void handleRequest(class Document* doc) override;
};
class Review : public State {
public:
    void handleRequest(class Document* doc) override;
};
class Published : public State {
public:
    void handleRequest(class Document* doc) override;
};

class Document {
private:
    State* state;
    bool approved;

public:
    Document() : approved(false), state(new Draft()) {}

    State* getState() const { return state; }

    void setState(State* newState) { delete state; state = newState; }

    void publish() { state->handleRequest(this); }

    void setApproval(bool approval) { approved = approval; }
    
    bool isApproved() const { return approved; }
};

void Draft::handleRequest(Document* doc) {
    doc->setState(new Review());
};

void Review::handleRequest(Document* doc) {
    if (doc->isApproved()) {
        doc->setState(new Published());
    } else {
        doc->setState(new Draft());
    }
};

void Published::handleRequest(Document* doc) {

}
