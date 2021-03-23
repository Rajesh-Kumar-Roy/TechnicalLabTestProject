
import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
  name: 'nullToNA'
})
export class NullToDashPipe implements PipeTransform {

  transform(value: any): string {
    if (value == null || value == '' || value == undefined) {
      return 'N/A';
    } else {
      return value;
    }
  }

}
