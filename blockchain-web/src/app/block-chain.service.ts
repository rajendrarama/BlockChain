import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class BlockChainService {
  connection: signalR.HubConnection;
  dataSource: any;
  
  constructor() { 
  }

  public startConnection = () => {
    this.connection = new signalR.HubConnectionBuilder()
                            .withUrl('https://localhost:44337/blockchainhub')
                            .build();
    this.connection
      .start()
      .then(() => console.log(`Connection started ${this.connection.connectionId}`))
      .catch(err => console.log('Error while starting connection: ' + err))
  }
  
  public tickerDataListener = () => {    
    this.connection.on('tickerdata', (data) => {      
      this.dataSource = data;
    });
  }
}
