# Build stage
FROM node:latest AS build
# Set working directory in the container
WORKDIR /app
# Copy package.json and package-lock.json
COPY package*.json .
# Install dependencies
RUN npm install
# Copy the rest of the application files
COPY . .

# Expose port 80 (or the port your API Gateway listens on)
EXPOSE 80

# Command to run the application
CMD ["node", "index.js"]