# Use a base image with Node.js installed
FROM node:latest

# Set the working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json (if available)
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application code
COPY . .

# Expose port 80 (or the port your API Gateway listens on)
EXPOSE 80

# Command to run the application
CMD ["node", "index.js"]