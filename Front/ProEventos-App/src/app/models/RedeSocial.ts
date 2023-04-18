import { Evento } from './Evento';

export interface RedeSocial {
  Id: number;
  Nome: String;
  URL: String;
  EventoId?: number;
  PalestranteId?: number;
}
