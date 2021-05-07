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
 
If everything goes smooth the parking starts and the customer doesn't have do to anything until they leave.

2. When the VIC wants to depart they will add a payment by enter their parking id into the API. The API will subtract the arrival time from the current time and return the cost, which by deault is 10 SEK / minute. You as a Developer can change this at any time in the PostPayment-method inside the Paymentscontroller. You can probably make the API work for other types of vehicles, maybe cars on planet Earth. 

1. 

## Getting started 

## Requests

## Responses

## Status Codes

Gophish returns the following status codes in its API:

| Status Code | Description |
| :--- | :--- |
| 200 | `OK` |
| 201 | `CREATED` |
| 400 | `BAD REQUEST` |
| 404 | `NOT FOUND` |
| 500 | `INTERNAL SERVER ERROR` |
