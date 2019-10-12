/* общие данные для нескольких модулей и компонентов */

export interface Order {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
