public class ListNode {
    public int val;
    public ListNode next;

    public ListNode(int val) {
        this.val = val;
        this.next = null;
    }

    public ListNode(int val, ListNode next){
        this.val = val;
        this.next = next;
    }
}
public class LinkedList {

    private ListNode head;
    private ListNode tail;

    public LinkedList() {

        this.head = new ListNode(-1);
        this.tail = this.head;

    }

    public int Get(int index) {
        ListNode curr = head.next;
        int i = 0;
        while (curr != null) {
            if (i == index) {
                return curr.val;
            }
            i++;
            curr = curr.next;
        }
        return -1;
    }

    public void InsertHead(int val) {
        ListNode newNode = new ListNode(val);
        newNode.next = head.next;
        head.next = newNode;
        if (newNode.next == null) {
            tail = newNode;
        }
    }

    public void InsertTail(int val) {
        this.tail.next = new ListNode(val);
        this.tail = this.tail.next;
    }

    public bool Remove(int index) {
        int i = 0;
        ListNode curr = this.head;
        while (i < index && curr != null){
            i++;
            curr = curr.next;
        }

        if (curr != null  && curr.next != null) {
            if(curr.next == this.tail){
                this.tail = curr;
            }
            curr.next = curr.next.next;
            return true;
        }
        return false;
    }

    public List<int> GetValues() {
        List<int> res = new List<int>();
        ListNode curr = this.head.next;
        while (curr != null){
            res.Add(curr.val);
            curr = curr.next;
        }
        return res;
    }
}