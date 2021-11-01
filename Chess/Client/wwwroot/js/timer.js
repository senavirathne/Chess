class Timer {
    constructor(Id) {
        this.TIME_LIMIT = 20;
        this.INCREMENT_FACTOR = 3;
        this.ID = Id
        this.base_timer_path_remaining = Id +"-timer-path-remaining";
        this.base_timer_label = Id + "-timer-label";
        this.FULL_DASH_ARRAY = 283;
        this.WARNING_THRESHOLD = this.TIME_LIMIT / 2;
        this.ALERT_THRESHOLD = this.TIME_LIMIT / 4;
        this.timePassed = 0;
        this.timeLeft = this.TIME_LIMIT;
        this.timerInterval = null;
        this.COLOR_CODES = {
            info: {
                color: "green"
            },

            warning: {
                color: "orange",
                threshold: this.WARNING_THRESHOLD
            },

            alert: {
                color: "red",
                threshold: this.ALERT_THRESHOLD
            }
        };
        this.remainingPathColor = this.COLOR_CODES.info.color;
    }

    Initiate() {
        document.getElementById(this.ID).innerHTML = `
        <div class="base-timer">
          <svg class="base-timer__svg" viewBox="0 0 100 100" >
            <g class="base-timer__circle">
              <circle class="base-timer__path-elapsed" cx="50" cy="50" r="45"></circle>
              <path
                id=${this.base_timer_path_remaining}
                stroke-dasharray="283"
                class="base-timer__path-remaining ${this.remainingPathColor}"
                d="
                  M 50, 50
                  m -45, 0
                  a 45,45 0 1,0 90,0
                  a 45,45 0 1,0 -90,0
                "
              ></path>
            </g>
          </svg>
          <span id=${this.base_timer_label} class="base-timer__label">${this.formatTime(
            this.timeLeft)
        }</span>
        </div>
        `;

        

    }

    pause() {
        this.onTimesUp();
        this.timeLeft += this.INCREMENT_FACTOR;
        this.timePassed -= this.INCREMENT_FACTOR;
        document.getElementById(this.base_timer_label).innerHTML = this.formatTime(
            this.timeLeft);

        this.setCircleDasharray();
        this.setRemainingPathColor(this.timeLeft);
        console.log(this.ID+" paused method invoked");
    }
    onTimesUp() {
        clearInterval(this.timerInterval);
    }
    startTimer() {
        console.log(this.ID+"'s startTimer is started");
        this.timerInterval = setInterval(() => {
            this.timePassed = this.timePassed += 1;
            this.timeLeft = this.TIME_LIMIT - this.timePassed;
            document.getElementById(this.base_timer_label).innerHTML = this.formatTime(
                this.timeLeft);

            this.setCircleDasharray();
            this.setRemainingPathColor(this.timeLeft);

            if (this.timeLeft === 0) {
                this.onTimesUp();
                window.location.reload(window.confirm("Game Over"));
            }
        }, 1000);
    }
    formatTime(time) {
        const minutes = Math.floor(time / 60);
        let seconds = time % 60;

        if (seconds < 10) {
            seconds = `0${seconds}`;
        }

        return `${minutes}:${seconds}`;
    }
    setRemainingPathColor(timeLeft) {
        const {alert, warning, info} = this.COLOR_CODES;

        if (timeLeft <= alert.threshold) {
            document.getElementById(this.base_timer_path_remaining).classList.remove(warning.color);
            document.getElementById(this.base_timer_path_remaining).classList.add(alert.color);
        } else if (timeLeft <= warning.threshold) {
            document.getElementById(this.base_timer_path_remaining).classList.remove(info.color);
            document.getElementById(this.base_timer_path_remaining).classList.add(warning.color);
        }
    }
    calculateTimeFraction() {
        const rawTimeFraction = this.timeLeft / this.TIME_LIMIT;
        return rawTimeFraction - 1 / this.TIME_LIMIT * (1 - rawTimeFraction);
    }
    setCircleDasharray() {
        const circleDasharray = `${(
            this.calculateTimeFraction() * this.FULL_DASH_ARRAY).toFixed(0)} 283`;
        document.getElementById(this.base_timer_path_remaining).setAttribute("stroke-dasharray", circleDasharray);
    }




}

let BlackTimer = new Timer("BlackTimer");
let WhiteTimer = new Timer("WhiteTimer");
export function initialize(TimeOut,Increment){
    
    WhiteTimer.TIME_LIMIT = TimeOut;
    WhiteTimer.INCREMENT_FACTOR = Increment;
    WhiteTimer.COLOR_CODES = {
        info: {
            color: "green"
        },

        warning: {
            color: "orange",
            threshold: TimeOut / 2
        },

        alert: {
            color: "red",
            threshold: TimeOut / 4
        }
    };
    WhiteTimer.Initiate();
    WhiteTimer.timeLeft = TimeOut;
    document.getElementById(WhiteTimer.base_timer_label).innerHTML = WhiteTimer.formatTime(
        WhiteTimer.timeLeft);
    WhiteTimer.setCircleDasharray();
    WhiteTimer.setRemainingPathColor(WhiteTimer.timeLeft);


    BlackTimer.TIME_LIMIT = TimeOut;
    BlackTimer.INCREMENT_FACTOR = Increment;
    BlackTimer.COLOR_CODES = {
        info: {
            color: "green"
        },

        warning: {
            color: "orange",
            threshold: TimeOut / 2
        },

        alert: {
            color: "red",
            threshold: TimeOut / 4
        }
    };
    BlackTimer.Initiate();
    BlackTimer.timeLeft = TimeOut;
    document.getElementById(BlackTimer.base_timer_label).innerHTML = BlackTimer.formatTime(
        BlackTimer.timeLeft);

    BlackTimer.setCircleDasharray();
    BlackTimer.setRemainingPathColor(BlackTimer.timeLeft);


}
export function startTimer(){
    WhiteTimer.startTimer();
}
export function pauseTimer(ID){
    if (ID === "WhiteTimer"){
        WhiteTimer.pause();
        BlackTimer.startTimer();
    }else if (ID === "BlackTimer"){
        BlackTimer.pause();
        WhiteTimer.startTimer();
    }

}
// initialize(15,5);