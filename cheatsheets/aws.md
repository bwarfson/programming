# AWS

### Difference between Internet gateway and NAT gateway?
- Attaching an IGW to a VPC allows instances with public IPs to access the internet
- NAT(s) Gateway allow instances with no public IPs to access the internet

### What makes a subnet public?
- A subnet is deemed to be a Public Subnet if it has a Route Table that directs traffic to the Internet Gateway.

### If my lambda is in a vpc how do I reach the internet? 
- configure your lambda to use a (or multiple) specific subnets (the Lambda console will suggest you associate at least 2 subnets in different availability zones to your lambda to ensure availability)
- create a NAT Gateway in a different subnet
- have the route table associated with your lambda's subnets send all outbound traffic (0.0.0.0/0) to the NAT Gateway you created (you do that by choosing the NAT in the target field)
- have the route table in the NAT's subnet send all outbound traffic to an Internet Gateway

### What is a policy?
- Grant or deny abilities applied to roles. groups, or objects.

### What is a Role?
- Delagates access to AWS resources

