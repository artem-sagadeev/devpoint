import { Tag } from './tag';

export class Post {
  id: string = '';
  title: string = '';
  content: string = '';
  tags: Tag[] = [];
}
