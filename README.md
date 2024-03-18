# Exercises

## Exercise 01

This is tutorial will guide you through making an API Gateway in nodejs and express.

* [API Gateway with NodeJS and Express](https://medium.com/geekculture/create-an-api-gateway-using-nodejs-and-express-933d1ca23322)

Work through the tutorial

## Exercise 02

Continue on Nozama. 

1. You can choose between using the API gateway you just created - or create a new one
1. Setup the API Gateway so you can route through this API Gateway instead of through the individual services in Nozama
1. Add traceparent to all requests before handing them of to your Nozama services
    * You can use this library (https://www.npmjs.com/package/traceparent) or create the traceparent yourself
1. Add you API Gateway to the docker compose file and make sure you cannot access the internal (C#) services directly