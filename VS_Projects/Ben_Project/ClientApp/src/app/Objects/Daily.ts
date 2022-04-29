export interface Daily {
    latitude: number;
    longitude: number;
    daily: any[];
    data: any[];
}


function Daily(end, latitude, longitude, daily, data) {
    this.latitude = latitude;
    this.longitude = longitude;
    this.daily = daily;
    this.data = data;
}
