# Documentation

# SpacePark
Welcome to our SpacePark API! It's an ASP.NET Core Web API that we will implement into an application for our business SpacePark, the biggest parking company in the Milky Way! You're more than happy to study our API, do pull requests and download to customize for educational purposes. However if you try to outcompete our business we will sue you.

## Features
The API is created to handle VICs (Very Important Characters) from the Star Wars movies and their space ships at various space ports around our galaxy (and maybe even further). Of course it's only digital, COVID-friendly and the customer can use the API without any physical support. In the following section we will take you through the API step by step from the UI perspective;

1. The customer registrates themselves at arriving, then they can add a parking if they pass all following controls;

- If the customer is a valid VIC.
- If it's a valid VIV (Very Important Vehicle).
- If their space ship fits, sorry Death Star...
- If there's any available parking spots.
- If the customer already has an ongoing parking. Since there's a high demand on our space ports and they tends to be occupied, we have a limit on 1 parking / VIC.
 
If everything goes smooth the parking gets registrered in the database and the customer doesn't have do to anything until they leave.

2. When the VIC wants to depart they will add a payment by enter their parking id into the API. The API will subtract the arrival time from the current time and return the cost, which by deault is 10 SEK / minute. You as a Developer can change this at any time in the PostPayment-method inside the Paymentscontroller. You can probably make the API work for other types of vehicles, maybe cars on planet Earth. 

Of course the VIC can see their current parking or payments by enter the parking id, however they can neither delete nor update a parking since we don't want anyone to be able to park for free and there's no need to update a parking due to departing time gets defined when the VIC wants to leave. 

An additional feature is that an admin-user can add new space ports, however it's only you as a Developer that can add admins (set the property IsAdmin to "True" on the specific user in the database), after all we're most powerful creatures in the galaxy, aight? 

## Getting started 
To give you a smooth experience and get to know our the structure of our API we thought it would be a good idea to show some print screens and explain them. Since we are using Docker you can run the API through docker compose anywhere you want, but the API is developed in Visual Studio through C# with great support from Entity Framework and Restsharp:

[filestructure](https://user-images.githubusercontent.com/43240053/117443394-5ee49480-af38-11eb-9a93-12129609c1b1.png)

As you can see we have two main projects in the solution; NUnitTestProject and SpaceParkAPI. UnitTest1.cs contains all our tests, we have focused on testing all the endpoints in the controllers. 
Even though our tests hopfeully got you excited we think it's inside the SpaceParkAPI the action takes place.
It consists of a few key folders;

- `Dependencies`: contains the ASP.NET Core and .NET Core frameworks, and some extra packages like Restsharp.
- `Controllers`: Includes a controller class for each model. That's where our business logic with all the 
   endpoints sits. 
- `Data`: Is the home of our beloved DbContext. Doesn't seem to be much code for the world but without we    would literally loose our connections.
- `Models`:

## Authorization

## Requests

## Responses

## Status Codes

The API returns the following status codes in its API:

| Status Code | Description |
| :--- | :--- |
| 200 | `OK` |
| 201 | `CREATED` |
| 400 | `BAD REQUEST` |
| 404 | `NOT FOUND` |
| 500 | `INTERNAL SERVER ERROR` |
