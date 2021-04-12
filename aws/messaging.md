```mermaid
sequenceDiagram
    participant Scentsy Domain
    participant SNS CreateCustomerTopic
    participant SNS AwardPointsTopic
    participant SQS CreateCustomerQueue
    participant SQS AwardPointsQueue
    participant Lambda CreateCustomerFunction
    participant Lambda AwardPointsFunction
    Scentsy Domain->>SNS CreateCustomerTopic: PublishCreateCustomerMessage
    SQS CreateCustomerQueue->>SNS CreateCustomerTopic: Subscribes to CreateCustomer Topic
    Lambda CreateCustomerFunction->>SQS CreateCustomerQueue: Subscribes to CreateCustomerQueue 
    Lambda CreateCustomerFunction->>SNS AwardPointsTopic: PublishAwardPointsMessage
    SQS AwardPointsQueue->>SNS AwardPointsTopic: Subscribes to AwardPoints Topic
    Lambda AwardPointsFunction->>SQS AwardPointsQueue: Subscribes to AwardPointsQueue
    Scentsy Domain->>SNS AwardPointsTopic: PublishCreateCustomerMessage
```