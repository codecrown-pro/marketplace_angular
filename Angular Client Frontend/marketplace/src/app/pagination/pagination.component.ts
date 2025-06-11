import { Component, Input, OnInit } from '@angular/core';
import { PagingService } from '../core/paging-service/paging.service';

export interface PaginationModel {
  pageNumber: number,
  leftEnd: boolean,
  rightEnd: boolean,
  blueFlag: boolean
}

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent implements OnInit {

  @Input()
  model: PaginationModel;

  

  constructor(public pageService: PagingService) { }

  ngOnInit(): void {
    console.log(JSON.stringify(this.model))
  }

  decNav(): number {
    
    return +this.pageService.currentIndex - +1;
  }
  incNav(): number {
    
    return +this.pageService.currentIndex + +1;
  }

}
