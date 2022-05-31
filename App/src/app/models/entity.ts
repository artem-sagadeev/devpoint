import { Tag } from './tag';

export class Entity {
  id: string = '';
  name: string = '';
  tags: Tag[] = [];
  subscriberCount?: number = 0;
  imgPath?: string = '/assets/img/avatar.jpg';
  description?: string = '';
}
