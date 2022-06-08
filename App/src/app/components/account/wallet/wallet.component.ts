import { Component, OnInit } from '@angular/core';
import { AppService } from '../../../services/app.service';
import { PaymentEntry } from '../../../models/PaymentEntry';

@Component({
  selector: 'app-wallet',
  templateUrl: './wallet.component.html',
  styleUrls: ['./wallet.component.css'],
})
export class WalletComponent implements OnInit {
  amount: number = 0;
  deposit: number = 0;
  withdraw: number = 0;
  successMessage?: string;
  page: number = 0;

  withdrawals?: PaymentEntry[];
  deposits?: PaymentEntry[];
  constructor(private app: AppService) {}

  ngOnInit(): void {
    this.app.getWalletAmount().subscribe((amount) => {
      this.amount = amount;
    });

    this.app.getAllWithdrawals().subscribe((entries) => {
      this.withdrawals = entries;
    });

    this.app.getAllDeposits().subscribe((entries) => {
      this.deposits = entries;
    });
  }

  onWithdrawal() {
    if (this.withdraw)
      this.app.withdraw(this.withdraw).subscribe((withdrawal) => {
        this.amount -= this.withdraw!;
        this.withdraw = 0;
        this.successMessage = 'Withdrawal request successful!';
        if (!this.withdrawals) this.withdrawals = [];
        this.withdrawals = [withdrawal, ...this.withdrawals];
      });
  }

  onDeposit() {
    if (this.deposit)
      this.app.deposit(this.deposit).subscribe((deposit) => {
        this.amount += this.deposit!;
        this.deposit = 0;
        this.successMessage = 'Deposit request successful!';
        if (!this.deposits) this.deposits = [];
        this.deposits = [deposit, ...this.deposits];
      });
  }
}
