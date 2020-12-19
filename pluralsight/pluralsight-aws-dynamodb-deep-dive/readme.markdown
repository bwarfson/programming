# [AWS DynamoDB Deep Dive](https://app.pluralsight.com/course-player?clipId=616e9f09-5d9a-4147-a38a-30ea98eede3c)

## Introduction

### CAP Therem

Why can't we have the best of SQL and NoSQL databases?  **CAP theorem**

Three system gguarantees:
- **Consistency** Receive the latest data on every read
- **Availability** Every request receives a non-error reply
- **Partition Tolerance** System works despite some packets dropped

We can only have two of the above.  

A distributed system should always have partition tolerance.  So in a distributed system we have to choose between availability and consistency.  

SQL databases select CA, no partition tolerance

### Configuring the AWS account
```
aws configure
aws dynamodb list-tables --endpoint http://localhost:4566
```
---
## Getting started with Dynamodb

### **Data**
- Tables have no schema
- No collection of tables
- In a single table, different items can have a differnt structure

This type of thing is allowed:

| ID   | Name           | Title   |
| ---  | ---            | ---     |
| 1234 | John           | Mr.     |
| 2345 | [Peter, Kevin] | null    |

**Partition Key**
- Fetch a single item
- Every table should have a partition key attribute
- Every item should have it
- Same type in all columns
- Each item should have a unique value
- Using the partion key you can get a single item

- Item should be smaller then 400kb
- Can't store big files in DynamoDB
- Use S3 for big files

### **Scaling**

RCU/WCU read vs write 

### **Composite Keys**

- Composed of a partition key and a sort key
- Fetch multiple items
- Key composed of two attributes
- All items should have both
- Pair should be unique

Example Posts

Have a table of posts
- UserId
- Timestamp

Need to find all posts by one user sorted by time.  Can't do this with just a partition key.  

| UserId | Timestamp | Message |
|---|---|---|
| 1 | 1000 | lunch time? |
| 1 | 2000 | just had my sandwich |
| 1 | 3000 | this forum is boring.... |
| 2 | 1150 | hello everybody |
| 3 | 6000 | kitten photos here: |


Make UserId partition key and timestamp a sort key.  

**Query:** UserId = 1 returns 3 rows

**Query:** UserId = 1 AND Timestamp >= 2000 returns 2 rows

**Query:** UserId = 1 AND Timestamp = 2000 returns 1 row

**Scans** are a last resort because they are much slower and expensive

### Secondary Indexes

Why we need indexes?  Can't search an entire table everytime when the table is large.  

- Indexes are a data structure gives you a position for a record.  
  
Two types of indexes
- **Local Secondary Index (LSI)** Select a different sort order for a partition key
- **Global Secondary Index (GSI)** Access data using a different partition key



