using System;

using Commando.Colors;

namespace Commando.Progress
{
    public class ProgressBar
    {
        private char Sign { get; set; }
        private int Width { get; set; }
        private int Percent { get; set; }
        private bool IsDone { get; set; }
        private string Status { get; set; }

        public ProgressBar(char sign, string status = "")
        {
            Sign = sign;
            Width = 10;
            IsDone = false;
            Status = status;
            Draw();
        }

        public ProgressBar() : this('=') { }

        public void Increase(int percent)
        {
            Percent += percent;
            if (Percent > 100) Percent = 100;
            Draw(true);
        }

        public void Increase(int percent, string status)
        {
            Status = status;
            Increase(percent);
        }

        private void Draw(bool redraw = false)
        {
            if (IsDone)
            {
                return;
            }
            if (Percent == 100) Done();

            var str = string.Format("[{0," + -1 * Width + "}] {1}% {2}", new string(Sign, Percent/Width), Percent, Status.Yellow());
            if (redraw) ClearCurrentConsoleLine();
            if (IsDone) str += Environment.NewLine;
            Console.Write(str);
        }

        private void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        private void Done()
        {
            Status = "Done";
            IsDone = true;
        }
    }
}