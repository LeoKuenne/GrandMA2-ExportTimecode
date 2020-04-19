using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExportReaperMarkersToGrandMA2
{
    public enum TimestampFormat
    {
        HH_MM_SS_ss,
        TotalFrames
    }

    public class Timestamp
    {
        public TimestampFormat format;

        public int hours;
        public int minutes;
        public int seconds;
        public int milliseconds;

        public Timestamp(int hours, int minutes, int seconds, int milliseconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.milliseconds = milliseconds;

            this.format = TimestampFormat.HH_MM_SS_ss;
        }
        
        public int GetFrameWithFPS(FPS fps)
        {   

            double frames = Math.Floor(milliseconds * ((int)fps / 1000D));
            double seconds = this.seconds * (int)fps;
            double minutes = this.minutes * (int)fps * 60;
            double hours = this.hours * (int)fps * 60 * 60;
            
            return (int)(frames + seconds + minutes + hours);
        }

        public override string ToString()
        {
            switch (format)
            {
                case TimestampFormat.HH_MM_SS_ss:
                    return string.Format("{0:0}:{1:00}:{2:00}.{3:000}", hours, minutes, seconds, milliseconds);
                case TimestampFormat.TotalFrames:
                    return GetFrameWithFPS(Timecode.current.GetFrameRate()).ToString();
                default:
                    return string.Format("{0:0}:{1:00}:{2:00}.{3:000}", hours, minutes, seconds, milliseconds);
            }

        }

        public static Timestamp parseTimestamp(string value, TimelineFormat timelineFormat, FPS fps)
        {

            string[] Times = value.Split(':');
            
            int Milliseconds = 0;
            int Seconds = 0;
            int Minutes = 0;
            int Hours = 0;
            
            switch (timelineFormat)
            {
                case TimelineFormat.MM_SS:

                    if (!Regex.IsMatch(value, @"\b(\d{1,2}[:])?\d{1,2}[:]\d{1,2}[.]\d{1,3}\b"))
                    {
                        throw new TimelineFormatMatchException(TimelineFormat.MM_SS, value);
                    }

                    string[] Second = Times[Times.Length - 1].Split('.');
                    
                    if (Second.Length != 2)
                        throw new TimelineFormatMatchException(TimelineFormat.MM_SS, value);

                    Milliseconds = int.Parse(Second[1]);
                    Seconds = int.Parse(Second[0]);

                    if (Times.Length == 3)
                    {
                        Minutes = int.Parse(Times[1]);
                        Hours = int.Parse(Times[0]);
                    }
                    else if (Times.Length == 2)
                    {
                        Minutes = int.Parse(Times[0]);
                    }
                    else
                    {
                        throw new TimelineFormatException("Timeline Format not implemented or damaged!");
                    }


                    break;

                case TimelineFormat.HH_MM_SS_FF:

                    if (!Regex.IsMatch(value, @"\b\d{1,2}[:]\d{1,2}[:]\d{1,2}[:]\d{1,2}\b"))
                    {
                        throw new TimelineFormatMatchException(TimelineFormat.HH_MM_SS_FF, value);
                    }

                    if (Times.Length != 4 || int.Parse(Times[3]) >= (int)fps)
                        throw new TimelineFormatMatchException(TimelineFormat.HH_MM_SS_FF, value);

                    if (int.Parse(Times[3]) != 0)
                        Milliseconds = (int)(int.Parse(Times[3]) / ((int)fps / 1000D));
                    Seconds = int.Parse(Times[2]);
                    Minutes = int.Parse(Times[1]);
                    Hours = int.Parse(Times[0]);

                    break;

                default:
                    throw new TimelineFormatException("Timeline Format not implemented or damaged! Timeline: " + value);

            }

            return new Timestamp(Hours, Minutes, Seconds, Milliseconds);
        }

        public static explicit operator Timestamp(string value)
        {
            return parseTimestamp(value, Timecode.current.TimelineFormat, Timecode.current.Framerate);
            //return parseTimestamp(value, TimelineFormat.MM_SS, FPS.FPS25);
        }

        public static explicit operator string(Timestamp value)
        {
            return value.ToString();
        }

    }
}

