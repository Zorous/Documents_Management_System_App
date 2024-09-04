// src/document/document.controller.ts
import { Controller, Get, Post, Body, Param } from '@nestjs/common';
import { DocumentsService } from './documents.service';

@Controller('documents')
export class DocumentsController {
  constructor(private readonly documentService: DocumentsService) {}

  @Get()
  async getAllDocuments() {
    return this.documentService.getAllDocuments();
  }

  @Get(':id')
  async getDocumentById(@Param('id') id: string) {
    return this.documentService.getDocumentById(+id);
  }

  @Post()
  async createDocument(@Body() createDocumentDto: { title: string; content: string; authorId?: number }) {
    return this.documentService.createDocument(createDocumentDto);
  }
}
