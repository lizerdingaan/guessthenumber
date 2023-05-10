export interface Response {
  Message: string;
  Id: number;
  Tries: number;
  PlayingGame: boolean;
  WonGame: boolean;
  games: [{}];
}
