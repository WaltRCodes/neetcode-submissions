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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        // Create a dummy node to simplify edge cases
        // (e.g., removing the first node)
        ListNode dummy = new ListNode(0, head);

        // Left pointer starts at dummy
        ListNode left = dummy;

        // Right pointer starts at the actual head
        ListNode right = head;

        // --- STEP 1: Move 'right' n steps ahead ---
        // This creates a gap of n nodes between left and right
        while (n > 0) {
            right = right.next;
            n--;
        }

        // --- STEP 2: Move both pointers until 'right' reaches the end ---
        // When right hits null, left will be just before the node to remove
        while (right != null) {
            left = left.next;
            right = right.next;
        }

        // --- STEP 3: Remove the target node ---
        // Skip the node at left.next
        left.next = left.next.next;

        // Return the real head (dummy.next)
        return dummy.next;
    }
}
