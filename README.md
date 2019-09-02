# NServiceBus Example
This is a sample project to demonstrate the use of NServiceBus when it comes to communication between microservices.

## Description
This application will demonstrate the communication between four (4) microservices when it comes to the lifecycle of a product order. These are the microservices involved
- Orders
- Sales
- Notifications
- Payments

## User Stories
- [x] As a customer I want to be able to place an order
- [x] As a customer I want to be able to cancel an order that has been already placed
- [x] As a customer I want to get a refund when I cancel my order
- [x] As a customer I want to receive an e-mail notification when my order has been received
- [x] As a customer I want to receive an e-mail notification when my order payment has been processed
- [x] As a customer I want to receive an e-mail notification when my order has been cancelled
- [x] As a customer I want to receive an e-mail notification when my order refund has been processed

## Structure
The microservices are built as .NET Core APIs. During the startup of each project the NServiceBus configuration takes place that creates their endpoints and allows for communication using the `LearningTransport` transport.
This can easily be switched over to other transports such as rabbitMQ.

## Installation
In order to run the example you will need to clone the repository using `git clone https://github.com/lakylekidd/nservicebus-example.git`. 
Once cloned, you need to install the nuget packages that are included. This is a multiple startup configured project.