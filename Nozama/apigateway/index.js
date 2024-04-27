const express = require('express')
const {setupCreditCheck} = require("./auth/creditcheck");

const {ROUTES} = require("./auth/routes");
const {setupRateLimit} = require("./auth/ratelimit");

const {setupLogging} = require("./auth/logging");
const {setupProxies} = require("./auth/proxy");
const {setupAuth} = require("./auth/auth");

const app = express()
const port = 3000;

// Middleware to add traceparent header to all incoming requests
app.use((req, res, next) => {
    // Generate traceparent header
    const traceparent = TraceParent.fromRandom();
    
    // Add traceparent header to the request
    req.headers['traceparent'] = traceparent.toString();
    
    // Continue to the next middleware
    next();
});

setupLogging(app);
setupRateLimit(app, ROUTES);
setupCreditCheck(app, ROUTES);

setupAuth(app, ROUTES);
setupProxies(app, ROUTES);

app.listen(port, () => {
    console.log(`Example app listening at http://localhost:${port}`)
})

