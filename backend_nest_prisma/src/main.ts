// src/app.module.ts
import { Module } from '@nestjs/common';
import { DocumentModule } from './documents/documents.module';

@Module({
  imports: [DocumentModule],
  controllers: [],
  providers: [],
})
export class AppModule {}
