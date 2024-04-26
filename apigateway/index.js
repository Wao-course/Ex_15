const express = require('express')
const {setupCreditCheck} = require("./auth/creditcheck");

const {ROUTES} = require("./auth/routes");
const {setupRateLimit} = require("./auth/ratelimit");

const {setupLogging} = require("./auth/logging");
const {setupProxies} = require("./auth/proxy");
const {setupAuth} = require("./auth/auth");

const app = express()
const port = 3000;


setupLogging(app);
setupRateLimit(app, ROUTES);
setupCreditCheck(app, ROUTES);

setupAuth(app, ROUTES);
setupProxies(app, ROUTES);

app.listen(port, () => {
    console.log(`Example app listening at http://localhost:${port}`)
})

