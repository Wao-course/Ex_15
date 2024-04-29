const ROUTES = [
    {
        url: '/recommendations', // Example route for recommendations microservice
        auth: true, // Set to true if authentication is required
        creditCheck: true, // Set to true if credit check is required
        proxy: {
            target: "http://recommendations:5100", // Updated URL from Docker Compose
            changeOrigin: true,
            pathRewrite: {
                '^/recommendations': '', // Remove the prefix '/recommendations' from the forwarded request
            },
        }
    },
    {
        url: '/catalog', // Example route for product catalog microservice
        auth: true, // Set to true if authentication is required
        creditCheck: true, // Set to true if credit check is required
        proxy: {
            target: "http://productcatalog:5200", // Updated URL from Docker Compose
            changeOrigin: true,
            pathRewrite: {
                '^/catalog': '', // Remove the prefix '/catalog' from the forwarded request
            },
        }
    }
];

exports.ROUTES = ROUTES;
