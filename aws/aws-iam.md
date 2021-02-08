# Groups
> Groups is a collection of IAM users that lets you specify permissions for multiple users. Any users who are assigned to a group automatically inherit the group permissions, which makes it easier to manage the permissions from one place.

**EXAM TIP**   IAM Groups is not truly an identity because it cannot be identified as a Principal in a permission policy. This helps you attach policies to multiple users at one time and manage them easily.

# IAM Roles
> You can create an IAM role in your account, similar to an IAM user that has specific permissions that define what the identity (role) can and cannot do in AWS. You can assume a role if required, and it’s not associated with one person. A role provides you with temporary security credentials for your session, but it does not have a password or access keys associated with it. Roles can be used to delegate access to services, applications, or users that do not have access to your AWS resources. You can grant users in your AWS account access to resources, or grant users from one AWS account access to resources in another account.

## AWS Service Role
> A role can be assumed by a service to perform actions on your behalf in your account.

## AWS Service-Linked Role
> A service-linked role is linked directly to an AWS service and includes all the permissions that the service requires to call other AWS services. 

## Role Chaining
> When a role assumes a second role through the AWS CLI or API, it’s called role chaining, which limits the session to a maximum of one hour. 

## Delegation
> You can delegate by granting permissions to someone so they have access to resources that you control. This involves setting up a trust between the account that owns the resource and the account that contains the users who need to access the resource.

## Federation
> A federation is the trust relationship between AWS and an external identity provider, where users can log in to a web identity provider, Amazon, Facebook, Google, or an enterprise identity system. When you use a trust relationship between AWS and these external identity providers, the user is assigned to an IAM role and receives temporary credentials, which allow them to access your AWS resources.

## Role for Cross-Account Access
> A role can be used to grant access to resources in one account to a trusted user in another account.

# Policies and Permissions
