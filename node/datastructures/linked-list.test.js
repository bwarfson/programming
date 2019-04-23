const LinkedList = require('./linked-list.js');

test('shoule create linked list', () => {
    const linkedList = new LinkedList();
    expect(linkedList).toBeInstanceOf(LinkedList);
});

test('should add new node', () => {
    const linkedList = new LinkedList();
    linkedList.addToHead('test');
    expect(linkedList.length).toBe(1);
});

test('should reverse the linked list', () => {
    const linkedList = new LinkedList();
    linkedList.addToHead(5);
    linkedList.addToHead(4);
    linkedList.addToHead(3);
    linkedList.addToHead(2);
    linkedList.addToHead(1);
    expect(linkedList.head.value).toBe(1);
    linkedList.reverse();
    expect(linkedList.head.value).toBe(5);
});
