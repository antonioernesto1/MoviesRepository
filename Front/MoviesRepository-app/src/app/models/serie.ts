import { Categoria } from "./categoria";

export interface Serie {
  id: number;
  nome: string;
  trailerUrl: string;
  capaUrl: string;
  trailerEmbedUrl: string;
  anoLancamento: number;
  categorias: Categoria[];
  sinopse: string;
}
