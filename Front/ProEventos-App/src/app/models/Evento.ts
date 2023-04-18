import { Palestrante } from './Palestrante';
import { RedeSocial } from './RedeSocial';
import { Lote } from './lote';

export interface Evento {
  Id: number;
  local: string;
  DataEvento?: Date;
  tema: string;
  QtdPessoas: number;
  ImagemURL: string;
  Telefone: string;
  Email: string;
  Lotes: Lote[];
  RedesSociais: RedeSocial[];
  PalestrantesEventos: Palestrante[];
}
