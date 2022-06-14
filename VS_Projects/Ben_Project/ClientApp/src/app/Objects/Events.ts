export interface Events {
  id: number,
  name: string;
  location: string
}


function HighScore(id, name, location) {
  this.id = id;
  this.name = name;
  this.location = location;
}
