
public class Formatter
{
    public static string FormatTime(int time)
    {
        int hours = (time / 3600);
        int minutes = (time - (hours * 3600)) / 60;
        int seconds = time - (hours * 3600) - (minutes * 60);
        return string.Format("{0}:{1}:{2}", hours.ToString("00"), minutes.ToString("00"), seconds.ToString("00"));
    }
}
