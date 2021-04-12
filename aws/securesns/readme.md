
## Using AWS STS
[AmazonSecurityTokenServiceClient.AssumeRole (AssumeRoleRequest)](https://docs.aws.amazon.com/sdkfornet/latest/apidocs/items/MSecurityTokenSecurityTokenServiceAssumeRoleAssumeRoleRequestNET45.html)
- You can send AWS STS API calls either to a global endpoint or to one of the Regional endpoints.
- If you choose an endpoint closer to you, you can reduce latency and improve the performance of your API calls.
- If you are using one of the various AWS SDKs, then use that SDK's method to select a Region before you make the API call. 
- Security Token Service is an extension of IAM and is one of several web services offered by AWS that does not incur any costs to use. 
- The main purpose and function of STS is to issue temporary security credentials for AWS resources to trusted and authenticated entities.
- These credentials operate identically to the long-term keys that typical IAM users have, with a couple of special characteristics:
    - They automatically expire and become unusable after a short and defined period of time elapses
    - They are issued dynamically
- These characteristics offer several advantages in terms of application security and development and are useful for cross-account delegation and access.  STS solves two problems for owners of AWS resources:
    - Meets the IAM best-practices requirement to regularly rotate access keys
    - You do not need to distribute access keys to external entities or store them within an application


### [AssumeRole](https://docs.aws.amazon.com/STS/latest/APIReference/API_AssumeRole.html)
- The AssumeRole API operation is useful for allowing existing IAM users to access AWS resources that they don't already have access to.
- This call must be made using valid AWS security credentials. 

### Roles
- Roles are a secure way to grant trusted entities access to your resources.
- You can think about roles in terms of a jacket that an IAM user can wear for a short period of time, and while wearing this jacket, the user has privileges that they wouldn’t normally have when they aren’t wearing it. 


### AWS resources you will need
- IAM User for the application
- IAM Group 
- IAM Role
- IAM Policy
- The Amazon Resource Name (ARN) of the role that the app should assume.


- Create Topic
- Create a Role.  
- For this role, we will specify that users form our sns publish group are the only ones that can wear the jacket. This is done by including the client’s AWS account ID in the Principal statement.

Great, now we have a role that our trusted client can wear.

But, right now our client can’t do anything except wear the jacket.  Let’s give the jacket some special powers, publishing to sns.

We will do this by creating a security policy for this role. 


