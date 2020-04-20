using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExportReaperMarkersToGrandMA2
{

    public class Timestamp
    {
        public TimelineFormat format;

        public int hours;
        public int minutes;
        public int seconds;
        public int milliseconds;

        public Timestamp(int hours, int minutes, int seconds, int milliseconds, TimelineFormat format)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.milliseconds = milliseconds;

            this.format = format;
        }
        
        public int GetFrameWithFPS(FPS fps)
        {   

            double frames = Math.Floor(milliseconds * ((int)fps / 1000D));
            double seconds = this.seconds * (int)fps;
            double minutes = this.minutes * (int)fps * 60;
            double hours = this.hours * (int)fps * 60 * 60;
            
            return (int)(frames + seconds + minutes + hours);
        }

        public static Timestamp GetTimestampFromFrame(int frame, FPS fps, TimelineFormat format)
        {
            int tempFrames = frame;

            int Hours = (int)Math.Floor(tempFrames / (60D * 60 * (int)fps));
            tempFrames -= 60 * 60 * (int)fps * Hours;

            int Minutes = (int)Math.Floor(tempFrames / (60D * (int)fps));
            tempFrames -= 60 * (int)fps * Minutes;

            int Seconds = (int)Math.Floor((double)tempFrames / (int)fps);
            tempFrames -= (int)fps * Seconds;

            int Milliseconds = (int) (tempFrames * Math.Round(1000D / (int)fps));

            return new Timestamp(Hours, Minutes, Seconds, Milliseconds, format);
        }

        public override string ToString()
        {
            switch (format)
            {
                case TimelineFormat.HH_MM_SS:
                    return string.Format("{0:0}:{1:00}:{2:00}.{3:000}", hours, minutes, seconds, milliseconds);
                case TimelineFormat.TotalFrames:
                    return GetFrameWithFPS(Timecode.current.GetFrameRate()).ToString();
                case TimelineFormat.HH_MM_SS_FF:
                    int frames = (int) (milliseconds * ((int)Timecode.current.GetFrameRate() / 1000D));
                    return string.Format("{0:0}:{1:00}:{2:00}:{3:00}", hours, minutes, seconds, frames);
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
                case TimelineFormat.HH_MM_SS:

                    if (!Regex.IsMatch(value, @"\b(\d{1,2}[:])?\d{1,2}[:]\d{1,2}[.]\d{1,3}\b"))
                    {
                        throw new TimelineFormatMatchException(TimelineFormat.HH_MM_SS, value);
                    }

                    string[] Second = Times[Times.Length - 1].Split('.');
                    
                    if (Second.Length != 2)
                        throw new TimelineFormatMatchException(TimelineFormat.HH_MM_SS, value);

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
                case TimelineFormat.TotalFrames:
                    return GetTimestampFromFrame(int.Parse(value), fps, timelineFormat);

                default:
                    throw new TimelineFormatException("Timeline Format not implemented or damaged! Timeline: " + value);

            }

            return new Timestamp(Hours, Minutes, Seconds, Milliseconds, timelineFormat);
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

