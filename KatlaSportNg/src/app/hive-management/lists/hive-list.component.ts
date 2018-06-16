import { Component, OnInit } from '@angular/core';
import { HiveListItem } from '../models/hive-list-item';
import { HiveService } from '../services/hive.service';

@Component({
  selector: 'app-hive-list',
  templateUrl: './hive-list.component.html',
  styleUrls: ['./hive-list.component.css']
})
export class HiveListComponent implements OnInit {

  hives: HiveListItem[];

  constructor(private hiveService: HiveService) { }

  ngOnInit() {
    this.getHives();
  }

  getHives() {
    this.hiveService.getHives().subscribe(h => this.hives = h);
  }

  onDelete(hiveId: number) {
    this.setStatusById(hiveId, true);
  }

  onRestore(hiveId: number) {
    this.setStatusById(hiveId, false);
  }

  setStatusById(hiveId: number,status: boolean){
    var hive = this.hives.find(h => h.id == hiveId);
    this.hiveService.setHiveStatus(hiveId, true).subscribe(c => hive.isDeleted = status);
  }
}
