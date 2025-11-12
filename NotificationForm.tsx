export function NotificationForm(container: HTMLElement, sendNotification: Function) {
  const form = document.createElement('form');

  const messageInput = document.createElement('input');
  messageInput.placeholder = 'Enter your message';
  messageInput.name = 'message';

  const typeSelect = document.createElement('select');
  typeSelect.name = 'type';
  ['email', 'push'].forEach(option => {
    const opt = document.createElement('option');
    opt.value = option;
    opt.text = option;
    typeSelect.appendChild(opt);
  });

  const submitBtn = document.createElement('button');
  submitBtn.type = 'submit';
  submitBtn.textContent = 'Send Notification';

  const responseDiv = document.createElement('div');

  form.append(messageInput, typeSelect, submitBtn);
  container.append(form, responseDiv);

  form.addEventListener('submit', async (e) => {
    e.preventDefault();
    const data = {
      message: messageInput.value,
      type: typeSelect.value
    };
    const result = await sendNotification(data);
    responseDiv.textContent = JSON.stringify(result, null, 2);
  });
}