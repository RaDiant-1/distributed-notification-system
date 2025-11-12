import express from "express";
import { startConsumer } from "./rabbitmq/consumer.js";
import dotenv from "dotenv";

dotenv.config();

const app = express();
app.use(express.json());

app.get("/", (req, res) => {
  res.send("Push Notification Service is running.");
});

app.listen(process.env.PORT || 4000, () => {
  console.log(`Push Notification Service running on port ${process.env.PORT || 4000}`);
});

// Start RabbitMQ consumer
startConsumer();
