import { Categoria } from './categoria';

export interface Filme {
  id: number;
  nome: string;
  trailerUrl: string;
  trailerEmbedUrl: string;
  capaUrl: string;
  posterUrl: string;
  anoLancamento: number;
  sinopse: string;
  duracao: string;
  categorias: Categoria[];
}
