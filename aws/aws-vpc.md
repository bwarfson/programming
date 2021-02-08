# Amazon Virtual Private Cloud (VPC)

## VPC
**Why VPC?** - We need is a logically isolated section of AWS that you can own and control, similar to separate networks in your on-premises datacenter.

> Amazon VPC is the networking layer for Amazon Elastic Compute Cloud (EC2) instances and enables you to launch AWS resources into an isolated virtual network that you’ve provisioned. A VPC is a virtual network dedicated to your IP address range, subnets, network access control lists (NACLs), security groups, and route tables to your AWS account. 
> -- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

> Your AWS account comes with a default VPC that has a subnet in each availability zone that is ready for you to use. If you don’t specify a subnet when you launch an instance, the instance will be launched into your default VPC.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

> A VPC spans all the availability zones in a particular region, whereas a subnet must reside entirely within one availability zone and cannot span across zones.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

> When you create a VPC, you must specify a range of IPv4 addresses for the VPC in the form of a Classless Inter-Domain Routing (CIDR) block; for example, 10.0.0.0/16. This is the primary CIDR block for your VPC.
-- <cite> [VPC and subnet basics](https://docs.aws.amazon.com/vpc/latest/userguide/VPC_Subnets.html) </cite>

## Subnets

> Subnet is “part of the network”, in other words, part of entire availability zone. Each subnet must reside entirely within one Availability Zone and cannot span zones.
-- <cite> [AWS VPC Subnets – in Layperson’s Terms](https://www.infoq.com/articles/aws-vpc-explained/) </cite>

## Public Subnet
> A subnet is called public when its traffic is routed to an Internet gateway. Your instance must have a public IPv4 address or an elastic IP address (IPv4), which is a static public IPv4 address assigned by AWS, if it needs to communicate with the Internet over IPv4.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

## Private Subnet
> A subnet is called private when it doesn’t have a route to the Internet gateway. The internal IPv4 address range of the subnet is always private, regardless of the type of subnet, and AWS does not announce this address block to the Internet.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

## Route Tables
> A route table has a set of rules that are used to determine where network traffic is directed. All your subnets in a VPC must be associated with a route table because this table controls the routing for the subnet. You can associate multiple subnets with the same route table; however, a single subnet can only be associated with one route table at any point in time.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

## Network Access Control Lists
> The VPC provides another layer of security by acting as a firewall for controlling traffic in and out of one or more subnets. The default VPC automatically comes with a modifiable default NACL, and it allows all inbound and outbound IPv4 and IPv6 traffic, if applicable. You can add or remove rules from the default NACL or create additional custom NACLs for your VPC.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

> All the subnets in your VPC must be associated with a NACL. Your subnet is automatically associated with the default NACL if you don’t configure it otherwise. A subnet can be associated with only one NACL at a time, but you can associate a NACL with multiple subnets.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

## Security Groups
> A security group acts as another virtual firewall at the instance level that controls the inbound and outbound traffic. 
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

> NACLs act at the subnet level, and security groups act at the instance level. 
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

> In a production environment, you’ll authorize only a specific IP address or range of addresses to access your instance.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

## Internet Gateways
> An Internet gateway is a highly available, redundant, and horizontally scaled VPC component that allows communication between the Internet and instances in your VPC.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

> It serves two purposes: to perform NAT for instances that have not been assigned public IPv4 addresses and to provide a target in your VPC route tables for Internet-routable traffic, including IPv4 and IPv6 traffic.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

> You need to make sure that your NACL and security group rules allow the relevant traffic to flow to and from the Internet for instances in a VPC subnet. You need to attach an Internet gateway to a VPC and make sure that the subnet’s route table points to it.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

## Dynamic Host Configuration Protocol Option Sets
> The options field of a Dynamic Host Configuration Protocol (DHCP) message contains configuration parameters like domain name, domain name server, and the NetBIOS node type, and it provides a standard for sending configuration details to hosts on the TCP/IP network.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

## Elastic Internet Protocols
> An elastic Internet Protocol (IP) address is a public static address that you can associate with an instance or network interface for any of your account VPCs.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

> If you want your instance to be accessible via an IPv4 address over the Internet, SSH, or RDP, you must associate an elastic IP address (i.e., a static public IPv4 address) to your instance, and you must configure your security group rules to allow access over IPv4.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

## Endpoints
> VPC endpoint services powered by the Private Link service do not require an Internet gateway, NAT device, VPN connection, or AWS Direct Connect connection, and they enable you to privately connect your VPC to supported AWS services. When you use the VPC endpoint, your instances do not require public IP addresses to communicate with other resources and the traffic does not leave the Amazon network.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

## Network Address Translation Devices
> If you want to enable instances in a private subnet to connect to the Internet but prevent the Internet from initiating connections with the instances, you need a NAT device. It forwards traffic from the instances in the private subnet to the Internet and then sends the response back to the instances.
-- <cite> AWS Certified Developer Associate All-In-One Exam Guide (Exam DVA-C01) </cite>

## Egress-Only Internet Gateways
> An egress-only Internet gateway is a highly available, redundant, and horizontally scaled VPC component. It allows outbound communication over IPv6 from instances from your VPC to the Internet, and it prevents the Internet from initiating an IPv6 connection with your instances.

### Summary
- VPC is the networking layer that enables you to launch AWS resources into a logically isolated virtual network. 
- A VPC subnet resides entirely within one availability zone and cannot span across zones.
- A subnet is called public when its traffic is routed to an Internet gateway, and it is called private when it doesn’t have a route to the Internet gateway.
- A route table has a set of rules that are used to determine where network traffic is directed.
- The route table controls the routing for the subnet, so all your subnets in a VPC must be associated with a route table.
- You can add another layer of security using a network access control list to your VPC, which acts as a firewall controlling traffic in and out of one or more subnets by allowing all the inbound and outbound IPv4 traffic and, if applicable, IPv6 traffic.
- Security groups act at the instance level, and NACLs act at the subnet level.
- A different set of security groups can be assigned to each instance in a subnet of your VPC.
- An Internet gateway allows communication between the Internet and instances in your VPC. It performs network address translation (NAT) for instances that have not been assigned public IPv4 addresses and also provides a target in your VPC route tables for Internet-routable traffic.
- The options field of a Dynamic Host Configuration Protocol (DHCP) message contains the configuration parameters and provides a standard for sending configuration details to hosts on the TCP/IP network.
- An elastic IP address is a public static address that you will be able to associate with an instance or network interface for any of your account VPCs.
- A VPC endpoint service is powered by Private Link, and it enables you to privately connect your VPC to supported AWS services using the Amazon network.
- A NAT device is used to enable instances in a private subnet to connect to the Internet but prevents the Internet from initiating connections with the instances.
- An egress-only Internet gateway allows outbound communication over IPv6 from instances from your VPC to the Internet, and it prevents the Internet from initiating an IPv6 connection with your instances. 
- A VPC peering connection routes the traffic between your own VPCs or with a VPC in another AWS account, or with a VPC in a different AWS region privately, where instances in both VPCs can communicate with each other as if they are in the same network.
- A virtual private gateway is a VPN concentrator attached to your VPC on the AWS side.
- A customer gateway is a software application or physical device on the client side of the site-to-site VPN connection that provides information to AWS about your customer gateway device.
- A site-to-site VPN connection allows access to your on-premises network from your VPC using Internet Protocol security (IPSec).
- A point-to-site (P2S) VPN gateway connection allows access to the instances in your VPC from your individual laptop or from a client computer.
- AWS Direct Connect uses a standard Ethernet fiber-optic cable to link your internal network to an AWS Direct Connect location. You connect one end of the cable to your router and the other end to an AWS Direct Connect router. AWS Direct Connect allows you to use a dedicated private network connection between your on-premises network and one of the AWS Direct Connect locations.
- A transit gateway is a network transit hub that you can attach to a VPN connection, an AWS Direct Connect gateway, or a VPC.

Exercise 1: Create a VPC Using Cloud Formation
Exercise 2: Add a Subnet to Your VPC Using Cloud Formation

### Questions
1. Your client decided to move to AWS and asked you define the logically isolated virtual network in AWS using the predefined IP address range. Which of the following will you need to create to accomplish this? VPC
2. You created the VPC using the given range of the CIDR block by your network team. However, your application become so popular that you need to add new features, high availability, and redundancy; your AWS architect asked you to increase the size of VPC. Is it possible to resize it? Yes, the VPC can be extended by adding four secondary IPV4 CIDR blocks, and you can decrease your VPC by deleting those secondary CIDR blocks. However, you cannot change the size of the IPv6 address range of your VPC.
3. You are designing your AWS network and need to create the largest VPC and smallest VPC based on your application requirements. What are the largest and smallest IPv4 VPCs that you are allowed to create in AWS? AWS VPCs can vary in size from 16 addresses (/28 netmask), which is the smallest, to 65,536 addresses (/16 netmask), which is the largest.
4. A user has created a VPC with one public subnet and one private subnet. The user wants to run the patch updates for the instances in the private subnet, but the instances are not able to connect to the Internet. How can the instances from the user’s private subnet connect to the Internet? You need to use a NAT device (NAT gateway or NAT instance) to enable instances in a private subnet to connect to the Internet to do patching and software updates but it prevents the incoming traffic initiated from Internet with these instances.
5. Your client asked you to automatically provision the VPC and all its related components quickly, so you decided to use the VPC wizard in the AWS Management VPC console. What options are provided for you by default in the VPC wizard? You can create four types of VPCs using the VPC wizard: Amazon VPC with a single public subnet only, Amazon VPC with public and private subnets, Amazon VPC with public and private subnets and AWS site-to-site VPN access, and Amazon VPC with a private subnet only and AWS site-to-site VPN access.
6. VPC endpoints allow you to privately connect to your services from those hosted on the AWS VPC without requiring an Internet gateway, a NAT device, or VPN connection. What two types of endpoints are available in Amazon VPC? (Choose two.) Amazon VPC offers two types of endpoints: gateway endpoints and interface endpoints. Endpoints allow you to privately connect your VPC to your services hosted on AWS without requiring an Internet gateway, NAT device, or VPN connection.
7. Security groups in a VPC operate at the instance level, where you specify which traffic is allowed to or from an Amazon EC2 instance. NACLs operate at the subnet level and evaluate all the traffic entering and exiting a subnet. Which of the following is not true? A. Security groups can be used to set only allow rules, not deny rules; however, network ACLs can be used to set both allow and deny rules.
A. Security groups can be used to set both allow and deny rules.
B. NACLs do not filter traffic between instances in the same subnet.
C. NACLs perform stateless filtering, while security groups perform stateful filtering.
D. NACLs can be used to set both allow and deny rules.
8. True or False: Transitive peering relationships are supported in Amazon VPC peering. For example, if I peer VPC X to VPC Y and I peer VPC Y to VPC Z, does that mean VPCs X and Z are peered? . No, transitive peering relationships are not supported in AWS.
9. Which of the following is false about elastic IP address pricing? B. False. You will incur costs when the elastic IP address is associated with a stopped EC2 instance.
A. You will not incur costs when the elastic IP address is associated with a running EC2 instance.
B. You will not incur costs when the elastic IP address is associated with a stopped EC2 instance.
C. You will not incur costs when the IP address is from a BYOIP address pool.
D. You will not incur costs when the instance has only one elastic IP address attached to it.
10. A user has created a VPC with two public subnets and three security groups. The user has launched an instance in a public subnet and attached an elastic IP. He is still unable to connect to that EC2 instance. The Internet gateway has also been created. What could be the reason for the connection error? You need to configure the Internet gateway with the route table to route traffic and then the user will be able to connect to the EC2 instance.