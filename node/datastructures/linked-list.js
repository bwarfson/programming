class Node {
    constructor(value) {
        this.value = value;
        this.next = null;
    }
}

class LinkedList {
    constructor() {
        this.head = null;
        this.length = 0;
    }

    addToHead(value) {
        const newNode = new Node(value);
        newNode.next = this.head;
        this.head = newNode;
        this.length = this.length + 1;
    }

    print() {
        let current = this.head;

        while (current != null) {
            console.log(current.value);
            current = current.next;
        }
    }

    reverse() {
        let prev = null;
        let current = this.head;
        let next = null;

        while (current != null) {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }
        this.head = prev;
    }
}

module.exports = LinkedList;
