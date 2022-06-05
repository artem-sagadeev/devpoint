import { Component, OnInit } from '@angular/core';
import { Entity, EntityType } from '../../../models/entity';
import { plainToTyped } from 'type-transformer';
import { Developer } from '../../../models/developer';
import { Subscription } from '../../../models/subscription';
import { Tariff } from '../../../models/tariff';
import { MatDialog } from '@angular/material/dialog';
import { UnsubscribeConfirmModalComponent } from '../../account/subscriptions/subscription-partial/unsubscribe-confirm-modal/unsubscribe-confirm-modal.component';
import { SubscribeConfirmModalComponent } from './subscribe-confirm-modal/subscribe-confirm-modal.component';

@Component({
  selector: 'app-pricing',
  templateUrl: './pricing.component.html',
  styleUrls: ['./pricing.component.css'],
})
export class PricingComponent implements OnInit {
  entity?: Entity;
  currentSubscription?: Subscription;
  link?: string;
  constructor(public dialog: MatDialog) {}

  ngOnInit(): void {
    this.entity = plainToTyped(
      {
        id: '0',
        name: 'Talking Ben',
      },
      Developer,
    );

    this.currentSubscription = plainToTyped(
      {
        tariff: plainToTyped(
          {
            id: 1,
          },
          Tariff,
        ),
      },
      Subscription,
    );

    this.link = '/';
    switch (this.entity?.type) {
      case EntityType.Project:
        this.link += 'project';
        break;
      case EntityType.Company:
        this.link += 'company';
        break;
      case EntityType.Developer:
        this.link += 'developer';
        break;
    }
    this.link += `/${this.entity?.id ?? 0}`;
  }

  onSubscribe(id: number) {
    const dialogRef = this.dialog.open(SubscribeConfirmModalComponent, {
      data: {
        price: this.getPrice(id),
        type:
          (this.currentSubscription?.tariff?.id ?? id) > id
            ? 'Downgrade'
            : (this.currentSubscription?.tariff?.id ?? id) < id
            ? 'Upgrade'
            : 'Subscribe',
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
    });
  }

  getPrice(id: number) {
    if ((this.currentSubscription?.tariff?.id ?? -1) < id)
      switch (id) {
        case 0:
          return 9.99;
        case 1:
          return 19.99;
        case 2:
          return 39.99;
      }
    return 0;
  }
}
