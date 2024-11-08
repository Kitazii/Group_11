FROM node:20-alpine

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

# Build the application for production
RUN npm run build

# Install `serve` to serve the built app
RUN npm install -g serve

# Expose port 3000 to access the app
EXPOSE 3000

# Start the app using `serve` on port 3000
CMD ["serve", "-s", "build", "-l", "3000"]
