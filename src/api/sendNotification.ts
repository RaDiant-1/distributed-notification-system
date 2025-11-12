import axios from 'axios';

export async function sendNotification(data: { message: string; type: string }) {
  try {
    const response = await axios.post('https://your-aspnet-api/notifications', data);
    return response.data;
  } catch (error) {
    return { error: (error as any).message };
  }
}
