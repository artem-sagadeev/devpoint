import { Tag } from './tag';

export enum EntityType {
  Developer,
  Company,
  Project,
}

export class Entity {
  id: string = '';
  name: string = '';
  tags: Tag[] = [];
  subscriberCount?: number = 0;
  imgPath?: string = '/assets/img/avatar.jpg';
  description?: string = '';

  get type(): EntityType {
    return 0;
  }
}
