let Time = {
    hours: 22,
    minutes: 59,
    seconds: 50
};

function getTime(Time){
    let sec = String(Time.seconds);
    if(sec.length == 1) {sec = "0" + sec}
    let min = String(Time.minutes);
    if(min.length == 1) {min = "0" + min}
    let hour = String(Time.hours);
    if(hour.length == 1) {hour = "0" + hour}

    alert(`${hour}:${min}:${sec}`);
}

function TimePlusOne(Time){
    Time.seconds++;
    if(Time.seconds == 60) {Time.seconds = 0; Time.minutes++;}
    if(Time.minutes == 60) {Time.minutes = 0; Time.hours++;}
    if(Time.hours == 24) {Time.hours = 0;}
}

function TimeMinusOne(Time){
    Time.seconds--;
    if(Time.seconds < 0) {Time.seconds = 59; Time.minutes--;}
    if(Time.minutes < 0) {Time.minutes = 59; Time.hours--;}
    if(Time.hours < 0) {Time.hours = 23;}
}

function getTimeChange(Time, secsToChange){
    if (secsToChange == 0) {return;}
    if (secsToChange < 0)
    {
        for (let sec = 0; sec > secsToChange; sec--) {
            TimeMinusOne(Time);
        }
    }
    if (secsToChange > 0)
    {
        for (let sec = 0; sec < secsToChange; sec++) {
            TimePlusOne(Time);
        }
    }
    getTime(Time);
}

getTimeChange(Time, 10);