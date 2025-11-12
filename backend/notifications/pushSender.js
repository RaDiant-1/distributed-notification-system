import admin from "firebase-admin";
import fs from "fs";

const serviceAccount = JSON.parse(fs.readFileSync(process.env.FCM_SERVICE_ACCOUNT));

admin.initializeApp({
  credential: admin.credential.cert(serviceAccount),
});

export async function sendPushNotification({ title, body, token }) {
  const message = {
    notification: { title, body },
    token,
  };
  await admin.messaging().send(message);
}
