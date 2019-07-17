using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    class DoublyLinkedListNode {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int nodeData) {
            this.data = nodeData;
            this.next = null;
            this.prev = null;
        }
    }

    class DoublyLinkedList {
        public DoublyLinkedListNode head;
        public DoublyLinkedListNode tail;

        public DoublyLinkedList() {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData) {
            DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

            if (this.head == null) {
                this.head = node;
            } else {
                this.tail.next = node;
                node.prev = this.tail;
            }

            this.tail = node;
        }
    }

    static void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep, TextWriter textWriter) {
        while (node != null) {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null) {
                textWriter.Write(sep);
            }
        }
    }

    // Complete the sortedInsert function below.

    /*
     * For your reference:
     *
     * DoublyLinkedListNode {
     *     int data;
     *     DoublyLinkedListNode next;
     *     DoublyLinkedListNode prev;
     * }
     *
     */
    static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data) {
        DoublyLinkedListNode current = head;
        DoublyLinkedListNode toAdd = new DoublyLinkedListNode(data);
        // check if you need to insert at the head
        if(data < current.data){
            toAdd.next = current;
            current.prev = toAdd;
            // toAdd is the new head so return toAdd
            return toAdd;
        }
        if(head == null){
            return toAdd;
        }
        // get to right spot in linked list if not
        bool insertIn = false; // this signifies if we had to insert at a node other than the head or the end
        bool insertEnd = false;
        // get to right spot in linked list
        if (current.data <= data){
            if(current.next != null){
                current = current.next;
                insertIn = true;
            }
            else if(current.next == null){
                insertIn = false;
                insertEnd = true;
            }
        }
        //now, if we're at the right spot, insert
        if(insertIn == true){
            current = current.next;
            toAdd.next = current.next;
            current.next = toAdd;
            toAdd.prev = current;
            Console.WriteLine("insertingIn");
            // head wasn't changed so return head
            return head;
        }
        // check if you had to insert at the end
        else if (insertEnd == true){
            current.next = toAdd;
            toAdd.prev = current;
            toAdd.next = null;
            // head wasn't changed so return head
            Console.WriteLine("InsertingEnd");
            return head;
        }
        // default to returning head
        return head;
    }

    static void Main(string[] args) {
