import { Component, OnInit } from '@angular/core';
import { Subscription } from '../../../models/subscription';
import { EntityType } from '../../../models/entity';
import { plainToTyped } from 'type-transformer';
import { Company } from '../../../models/company';
import { Developer } from '../../../models/developer';

@Component({
  selector: 'app-subscriptions',
  templateUrl: './subscriptions.component.html',
  styleUrls: ['./subscriptions.component.css'],
})
export class SubscriptionsComponent implements OnInit {
  subscriptions: Subscription[] = [
    {
      id: 0,
      endTime: new Date(Date.now()),
      isAutoRenewal: true,
      tariff: {
        id: 0,
        pricePerMonth: 1000,
        subscriptionType: EntityType.Company,
        subscriptionLevel: {
          id: 0,
          name: 'Basic',
        },
      },
      entity: plainToTyped(
        {
          id: '1',
          name: 'Talking Ben Incorporated',
          subscriberCount: 1,
          description: 'Very professional company!',
          tags: [
            { name: 'Tag 1' },
            { name: 'Tag 2' },
            { name: 'Tag 3' },
            { name: 'Tag 4' },
            { name: 'Tag 5' },
          ],
          imgPath: 'assets/img/ben.png',
        },
        Company,
      ),
    },

    {
      id: 1,
      endTime: new Date(Date.now()),
      isAutoRenewal: true,
      tariff: {
        id: 1,
        pricePerMonth: 20000,
        subscriptionType: EntityType.Developer,
        subscriptionLevel: {
          id: 0,
          name: 'Pro',
        },
      },
      entity: plainToTyped(
        {
          id: '1',
          name: 'Ben',
          subscriberCount: 1,
          imgPath: 'assets/img/ben.png',
        },
        Developer,
      ),
    },
  ];
  constructor() {}

  ngOnInit(): void {}
}
