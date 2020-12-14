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

