// src/document/document.service.ts
import { Injectable } from '@nestjs/common';
import { PrismaService } from '../../prisma/prisma.service';

@Injectable()
export class DocumentsService {
  constructor(private prisma: PrismaService) {}

  async getAllDocuments() {
    return this.prisma.document.findMany();
  }

  async getDocumentById(id: number) {
    return this.prisma.document.findUnique({ where: { id } });
  }

  async createDocument(data: { title: string; content: string; authorId?: number }) {
    return this.prisma.document.create({
      data: {
        title: data.title,
        content: data.content,
        author: data.authorId ? { connect: { id: data.authorId } } : undefined,
      },
    });
  }
}
