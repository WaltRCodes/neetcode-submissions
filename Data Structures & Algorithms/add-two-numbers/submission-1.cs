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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {

        // Dummy node to simplify list construction
        ListNode dummy = new ListNode();
        ListNode cur = dummy;

        // Carry holds the overflow when sum >= 10
        int carry = 0;

        // Continue while either list has nodes left OR carry still exists
        while (l1 != null || l2 != null || carry != 0) {

            // Extract values from current nodes, or 0 if the list is exhausted
            int v1 = (l1 != null) ? l1.val : 0;
            int v2 = (l2 != null) ? l2.val : 0;

            // Compute sum of digits + carry
            int val = v1 + v2 + carry;

            // Update carry for next iteration
            carry = val / 10;

            // Current digit is remainder after removing carry
            val = val % 10;

            // Append new digit node to result list
            cur.next = new ListNode(val);

            // Move forward in result list
            cur = cur.next;

            // Advance l1 and l2 if possible
            l1 = (l1 != null) ? l1.next : null;
            l2 = (l2 != null) ? l2.next : null;
        }

        // Return the head of the constructed list
        return dummy.next;
    }
}
