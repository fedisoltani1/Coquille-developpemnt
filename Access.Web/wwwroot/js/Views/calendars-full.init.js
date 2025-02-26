! function (g) {
    "use strict";
    function e() { }
    e.prototype.init = function () {
        var e = new Date;
        var c = coursesCalender,
            v = (document.getElementById("calendar"));

        var m = new FullCalendar.Calendar(v, {
            locale: 'fr',
            height: 650,
            plugins: ["bootstrap", "interaction", "dayGrid", "timeGrid"],
            editable: !1,
            droppable: !1,
            selectable: !0,
            defaultView: "dayGridMonth",
            themeSystem: "bootstrap5",
            header: {
                left: "prev,next customToday",
                center: "title",
                right: "dayGridMonth,timeGridWeek,timeGridDay,listMonth"
            },
            customButtons: {
                customToday: {
                    text: 'Aujourd\'hui',
                    click: function () {
                        m.today();
                    }
                }
            },
            views: {
                dayGridMonth: {
                    buttonText: 'Mois'
                },
                timeGridWeek: {
                    buttonText: 'Semaine'
                },
                timeGridDay: {
                    buttonText: 'Jour'
                }
            },
            eventClick: function (info) {
                eventInfo(info.event.id); 
            },
            events: c
        });
        m.render();
    }, g.CalendarPage = new e, g.CalendarPage.Constructor = e
}(window.jQuery),
    function () {
        "use strict";
        window.jQuery.CalendarPage.init()
    }();
