/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {

        // If the list is empty, nothing to copy
        if (head == null) {
            return null;
        }

        // --- STEP 1: Create cloned nodes and store them in the 'random' pointer ---
        // For each original node l1:
        //   - Create a clone l2
        //   - Temporarily store l2 in l1.random
        //   - Store original l1.random inside l2.next
        //
        // After this loop:
        //   l1.random → clone of l1
        //   clone.next → original random pointer of l1
        Node l1 = head;
        while (l1 != null) {
            Node l2 = new Node(l1.val);   // clone node
            l2.next = l1.random;          // store original random
            l1.random = l2;               // attach clone to original
            l1 = l1.next;
        }

        // The head of the new list is the clone of the original head
        Node newHead = head.random;

        // --- STEP 2: Fix the random pointers of the cloned nodes ---
        // For each original node l1:
        //   - l2 = l1.random (the clone)
        //   - l2.random should point to the clone of l1.random
        //     which is stored at l2.next.random (if it exists)
        l1 = head;
        while (l1 != null) {
            Node l2 = l1.random;  // clone node
            l2.random = (l2.next != null) ? l2.next.random : null;
            l1 = l1.next;
        }

        // --- STEP 3: Restore the original list and extract the cloned list ---
        // For each original node l1:
        //   - l2 = l1.random (clone)
        //   - Restore l1.random to its original value (stored in l2.next)
        //   - Set l2.next to the next clone (if exists)
        l1 = head;
        while (l1 != null) {
            Node l2 = l1.random;          // clone
            l1.random = l2.next;          // restore original random
            l2.next = (l1.next != null) ? l1.next.random : null; // link clone list
            l1 = l1.next;
        }

        // Return the head of the deep-copied list
        return newHead;
    }
}
