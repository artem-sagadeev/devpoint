import { Tag } from './tag';

export class Post {
  id?: string = '';
  title?: string = '';
  content?: string = '';
  date?: string = '';
  hasUserAccess: boolean = true;
  tags?: Tag[] = [];
}
