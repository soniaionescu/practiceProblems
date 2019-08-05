/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
   public ListNode RemoveNthFromEnd(ListNode head, int n) 
    {
        // count length
        int len = 0;
        ListNode node = head;
        while (node != null)
        {
            node = node.next;
            len++;
        }
        
        // move pointer to node before node to be removed
        int count = 0;
        ListNode tempHead = new ListNode(0);
        tempHead.next = head;
        node = tempHead;
        while (count < len - n)
        {
            node = node.next;
            count++;
        }
        
        // remove the next node
        node.next = node.next != null ? node.next.next : null;
        
        return tempHead.next;
    }
}
