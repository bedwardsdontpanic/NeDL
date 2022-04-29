export interface SingleDay {
    summary: string;
    weekday: string;
    tempHigh: number;
    tempLow: number;
    dateTime: Date;
    sunset: Date;
    sunrise: Date;
}

function SingleDay(summary, weekday, tempHigh, tempLow, dateTime, sunset, sunrise) {
    this.summary = summary;
    this.weekday = weekday;
    this.tempHigh = tempHigh;
    this.tempLow = tempLow;
    this.dateTime = dateTime;
    this.sunrise = sunrise;
    this.sunset = sunset;
}
