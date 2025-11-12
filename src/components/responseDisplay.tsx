export function ResponseDisplay(container: HTMLElement, data: any) {
  const div = document.createElement('pre');
  div.textContent = JSON.stringify(data, null, 2);
  container.appendChild(div);
}
