public class Node {
    public int key;
    public int value;
    public Node next;

    public Node(int key, int value) {
        this.key = key;
        this.value = value;
        this.next = null;
    }
}
public class HashTable {
    private int capacity;
    private int size;
    private Node[] table;

    public HashTable(int capacity) {
        this.capacity = capacity;
        this.size = 0;
        this.table = new Node[this.capacity];
    }

    private int HashFunction(int key) {
        return key % this.capacity;
    }

    public void Insert(int key, int value) {
        int index = this.HashFunction(key);
        Node node = this.table[index];

        if (node == null) {
            this.table[index] = new Node(key, value);
            this.size++;
        } else {
            Node prev = null;
            while (node != null) {
                if (node.key == key) {
                    node.value = value;
                    return;
                }
                prev = node;
                node = node.next;
            }
            prev.next = new Node(key, value);
            this.size++;
        }
        if ((double) this.size / this.capacity >= 0.5) {
            this.Resize();
        }
    }

    public int Get(int key) {
        int index = this.HashFunction(key);
        Node node = this.table[index];

        while (node!=null){
            if (node.key == key) {
                return node.value;
            }
            node = node.next;

        }
        return -1;
    }

    public bool Remove(int key) {
        int index = this.HashFunction(key);
        Node node = this.table[index];
        Node prev = null;

        while (node != null) {
            if (node.key == key) {
                if (prev != null) {
                    prev.next = node.next;
                } else {
                    this.table[index] = node.next;
                }
                this.size--;
                return true;
            }
            prev = node;
            node = node.next;
        }
        return false;
    }

    public int GetSize() {
        return this.size;
    }

    public int GetCapacity() {
        return this.capacity;
    }

    public void Resize() {
        int newCapacity = this.capacity * 2;
        Node[] newTable = new Node[newCapacity];

        for (int i = 0; i < this.capacity; i++) {
            Node node = this.table[i];
            while (node != null) {
                int index = node.key % newCapacity;
                if (newTable[index] == null) {
                    newTable[index] = new Node(node.key, node.value);
                } else {
                    Node newNode = newTable[index];
                    while (newNode.next != null) {
                        newNode = newNode.next;
                    }
                    newNode.next = new Node(node.key, node.value);
                }
                node = node.next;
            }
        }
        this.capacity = newCapacity;
        this.table = newTable;
    }
}
