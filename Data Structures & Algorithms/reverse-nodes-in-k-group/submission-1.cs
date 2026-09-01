/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {

        // Dummy node simplifies edge cases (e.g., reversing from the head)
        ListNode dummy = new ListNode(0, head);

        // groupPrev points to the node BEFORE the current k‑group
        ListNode groupPrev = dummy;

        while (true) {

            // Find the k-th node from groupPrev
            // If fewer than k nodes remain, stop
            ListNode kth = GetKth(groupPrev, k);
            if (kth == null) {
                break;
            }

            // The node after the k-group (used to reconnect later)
            ListNode groupNext = kth.next;

            // Reverse the k nodes
            ListNode prev = groupNext;        // tail connection point
            ListNode curr = groupPrev.next;   // first node in the group

            // Standard linked-list reversal, but stop at groupNext
            while (curr != groupNext) {
                ListNode tmp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tmp;
            }

            // After reversing:
            // prev = new head of the reversed group (kth)
            // groupPrev.next = old head of group (now tail)

            // Save the old head of the group (now the tail)
            ListNode tmpNode = groupPrev.next;

            // Connect previous group to the new head
            groupPrev.next = kth;

            // Move groupPrev to the end of the reversed group
            groupPrev = tmpNode;
        }

        return dummy.next;
    }

    // Returns the k-th node from curr (curr itself is position 0)
    // If fewer than k nodes remain, returns null
    private ListNode GetKth(ListNode curr, int k) {
        while (curr != null && k > 0) {
            curr = curr.next;
            k--;
        }
        return curr;
    }
}
