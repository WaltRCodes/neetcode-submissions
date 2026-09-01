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
    public void ReorderList(ListNode head) {
        // Edge case: empty list or single node — nothing to reorder
        if (head == null || head.next == null) return;

        // --- STEP 1: Find the middle of the list using slow/fast pointers ---
        ListNode slow = head;
        ListNode fast = head.next;

        // Move fast by 2 steps and slow by 1 step
        // When fast reaches the end, slow will be at the midpoint
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        // --- STEP 2: Reverse the second half of the list ---
        // 'second' starts at the node after the midpoint
        ListNode second = slow.next;

        // Break the list into two halves
        ListNode prev = slow.next = null;

        // Reverse the second half in-place
        while (second != null) {
            ListNode tmp = second.next; // store next node
            second.next = prev;         // reverse pointer
            prev = second;              // move prev forward
            second = tmp;               // move second forward
        }

        // After reversal, 'prev' is the head of the reversed second half

        // --- STEP 3: Merge the two halves alternatingly ---
        ListNode first = head;
        second = prev; // second half head

        // Merge nodes: first → second → first.next → second.next → ...
        while (second != null) {
            ListNode tmp1 = first.next;   // store next node in first half
            ListNode tmp2 = second.next;  // store next node in second half

            first.next = second;          // link first → second
            second.next = tmp1;           // link second → next of first

            first = tmp1;                 // advance first pointer
            second = tmp2;                // advance second pointer
        }
    }
}
