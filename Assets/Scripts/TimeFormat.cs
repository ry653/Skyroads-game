using System;

public static class TimeFormat
{
    public static string Format(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        if (timeSpan.Days != 0) return timeSpan.Days + "Дней" + timeSpan.Hours + " часов " + timeSpan.Minutes + " минут " + timeSpan.Seconds + " cекунд ";
        else if (timeSpan.Hours != 0) return timeSpan.Hours + " часов " + timeSpan.Minutes + " м " + timeSpan.Seconds + " c ";
        else if (timeSpan.Minutes != 0) return timeSpan.Minutes + " м " + timeSpan.Seconds + " c ";
        else if (timeSpan.Seconds != 0) return timeSpan.Seconds + " c ";
        else return "";


    }
}
