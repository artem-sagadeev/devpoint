import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from '../../../../models/subscription';
import { EntityType } from '../../../../models/entity';
import * as moment from 'moment';
import { MatDialog } from '@angular/material/dialog';
import { UnsubscribeConfirmModalComponent } from './unsubscribe-confirm-modal/unsubscribe-confirm-modal.component';

@Component({
  selector: 'app-subscription-partial',
  templateUrl: './subscription-partial.component.html',
  styleUrls: ['./subscription-partial.component.css'],
})
export class SubscriptionPartialComponent implements OnInit {
  @Input() subscription?: Subscription;
  link?: string;
  entityTypes = EntityType;
  endTime?: string;
  loading: boolean = true;
  constructor(public dialog: MatDialog) {}

  ngOnInit(): void {
    this.link = '/';
    switch (this.subscription?.entity?.type) {
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
    this.link += `/${this.subscription?.entity?.id ?? 0}`;

    this.endTime = moment(this.subscription?.endTime).format('DD.MM.YYYY');
  }

  openDialog() {
    const dialogRef = this.dialog.open(UnsubscribeConfirmModalComponent);

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  onLoad() {
    this.loading = false;
  }
}
