# NServiceBus Example
This is a sample project to demonstrate the use of NServiceBus when it comes to communication between microservices.

## Description
This application will demonstrate the communication between four (4) microservices when it comes to the lifecycle of a product order. These are the microservices involved
- Orders
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
Once cloned, you need to install the nuget packages that are included. This is a multiple startup configured project set to run in the following order:
- Orders
- Payments
- Notifications
- Shop Client

## Functionality
When running the project, the `ShopClient` project is started on a browser. This is a React app implemented in ASP.NET Core 2.1.
The user can simulate an order by clicking on the "Create Order" button. Once this is clicked a set of commands and events will be ran in the background.
In order to view the messages the React app is set up so that it retrieves these messages from the server every 1s to simulate a live "feed". The user can also cancel an order and view
the corresponding messages being issued in the relevant tables.

#### When order is created
- A message is sent to client to inform that order was placed
- A payment is created and processed
- A message has been sent to client to inform that the order has been successfully processed.

#### When order is cancelled
- A command is issued to refund the payment
- Two messages were sent to customer informing him of order cancel and refund.