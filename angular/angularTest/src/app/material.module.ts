// material.module.ts

import { NgModule } from '@angular/core';
import { MatDatepickerModule } from '@angular/material/datepicker';

@NgModule({
  imports: [
    MatDatepickerModule
  ],
  exports: [
    MatDatepickerModule
  ]
})

export class MaterialModule {}