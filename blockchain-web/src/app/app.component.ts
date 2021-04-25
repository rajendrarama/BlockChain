import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { BlockChainService } from './block-chain.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit{
  displayedColumns = ['key','the15M','last','buy','sell','symbol'];
  constructor(public blockChainService: BlockChainService, private http: HttpClient) { }
  
  ngOnInit(): void {    
    this.blockChainService.startConnection();
    this.blockChainService.tickerDataListener();    
    this.startHttpRequest();
    
  }

  asIsOrder(a, b) {
    return 1;
  }
  
  private startHttpRequest = () => {
    this.http.get('https://localhost:44337/api/blockchain')
      .subscribe(res => {
        console.log(res);
      })
  }
}
