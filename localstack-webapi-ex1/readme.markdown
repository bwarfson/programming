[Mocking AWS with LocalStack in .NET Core 3](https://shtanko-michael.medium.com/mocking-aws-with-localstack-in-net-core-3-ef32ae888706)

**Benefits of using LocalStack:**
- You can save money during development and testing
- You can work offline!
- More straightforward and convenient debugging. No one else can use your own services.
- Very fast introduction of new Amazon services in the application
-You still can use aws cli to easily control each of your services.
All you need to do is add endpoint argument to any request.
For example, to create an Amazon SQS queue:

```
aws sqs create-queue --queue-name MyQueue --endpoint http://localhost:4576
```

**Installing LocalStack on your local machine**
- Install Python with pip
- Install Docker
- Install **Localstack** via **pip**

```
pip install localstack
```
- Run to launch LocalStack’s servises using Docker by default

```
localstack start
```

- Create S3 bucket dev-files and make it public by default

```
aws s3 mb s3://dev-files --endpoint http://localhost:4566
aws s3api put-bucket-acl --bucket dev-files --acl public-read-write --endpoint http://localhost:4566
```

- Install several nuget packages

```
dotnet add package AWSSDK.S3 --version 3.3.110.1
dotnet add package AWSSDK.CloudWatchLogs --version 3.3.101.78
dotnet add package AWSSDK.Extensions.NETCore.Setup --version 3.3.100.1
dotnet add package Serilog.AspNetCore --version 3.2.0
dotnet add package Serilog.Sinks.AwsCloudWatch --version 4.0.155
```

- Now we can replace real Amazon services with LocalStack services in ConfigureServices method of Startup.cs

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
}
```

```
aws logs get-log-events --log-group-name dev-logs --log-stream-name 2020-12-10 --endpoint http://localhost:4566
```