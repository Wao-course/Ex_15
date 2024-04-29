const express = require('express')
const {setupCreditCheck} = require("./auth/creditcheck");
const crypto = require('crypto')

const {ROUTES} = require("./auth/routes");
const {setupRateLimit} = require("./auth/ratelimit");

const {setupLogging} = require("./auth/logging");
const {setupProxies} = require("./auth/proxy");
const {setupAuth} = require("./auth/auth");
const TraceParent = require('traceparent')

const app = express()
const port = 3000;

// Middleware to add traceparent header to all incoming requests
app.use((req, res, next) => {
    // Generate traceparent header
    const version = Buffer.alloc(1).toString('hex')
    const traceId = crypto.randomBytes(16).toString('hex')
    const id = crypto.randomBytes(8).toString('hex')
    const flags = '01'

    const header = `${version}-${traceId}-${id}-${flags}`

    const parent = TraceParent.fromString(header)

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

