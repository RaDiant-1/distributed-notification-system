import amqplib from "amqplib";
import { sendPushNotification } from "../notifications/pushSender.js";
import fs from "fs";
import path from "path";

const logFile = path.join("logs", "service.log");

function log(message) {
  fs.appendFileSync(logFile, `[${new Date().toISOString()}] ${message}\n`);
}

export async function startConsumer() {
  try {
    const conn = await amqplib.connect(process.env.RABBITMQ_URL);
    const channel = await conn.createChannel();
    const queue = "notifications";

    await channel.assertQueue(queue, { durable: true });
    console.log("Waiting for messages in queue:", queue);

    channel.consume(queue, async (msg) => {
      if (msg !== null) {
        const data = JSON.parse(msg.content.toString());
        try {
          await sendPushNotification(data);
          log(`SUCCESS: ${JSON.stringify(data)}`);
        } catch (err) {
          log(`ERROR: ${JSON.stringify(data)} - ${err.message}`);
        }
        channel.ack(msg);
      }
    });
  } catch (err) {
    console.error("RabbitMQ consumer error:", err);
    log(`RABBITMQ ERROR: ${err.message}`);
  }
}
