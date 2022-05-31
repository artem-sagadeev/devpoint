import { Component, OnInit, ViewChild } from '@angular/core';
import { Developer } from 'src/app/models/developer';
import { Post } from 'src/app/models/post';
import { Project } from 'src/app/models/project';
import { SwiperComponent } from 'swiper/angular';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  @ViewChild(SwiperComponent) swiper?: SwiperComponent;

  developer: Developer = {
    id: '1',
    name: 'Ben',
    subscriberCount: 22000,
    description: 'Ho-ho-ho!\nNo...',
    tags: [{ name: 'Tag 1' }, { name: 'Tag 2' }, { name: 'Tag 3' }, { name: 'Tag 4' }, { name: 'Tag 5' }],
    imgPath: 'assets/img/ben.png'
  };

  projects: Project[] = Array(5).fill(
      {
        id: '1',
        name: 'Talking Ben',
        tags: [{ name: 'Mobile' }]
      }
    )

  posts: Post[] = [
    {
      id: '1',
      title: 'Talking Ben on PC!',
      content: 'Talking Ben just released on PC for Windows and Linux on Steam! Only for 399$!',
      tags: [{ name: 'News' }]
    }
  ];

  constructor() {}

  ngOnInit(): void {}

  swipePrev() {
    this.swiper?.swiperRef.slidePrev();
  }

  swipeNext() {
    this.swiper?.swiperRef.slideNext();
  }
}
