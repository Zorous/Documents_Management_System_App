// src/document/document.module.ts
import { Module } from '@nestjs/common';
import { DocumentsService } from './documents.service';
import { DocumentsController } from './documents.controller';
import { PrismaService } from '../../prisma/prisma.service';

@Module({
  imports: [],
  providers: [DocumentsService, PrismaService],
  controllers: [DocumentsController],
})
export class DocumentModule {}
