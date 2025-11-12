import { sendNotification } from './api/sendNotification.js';
import { NotificationForm } from './components/NotificationForm.js';

const app = document.getElementById('app');
if (app) {
  app.innerHTML = `<h1>Notification Dashboard</h1>`;
  NotificationForm(app, sendNotification);
}