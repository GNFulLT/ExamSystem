using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace OnlineExamSystem
{
    public static class ControlAnimations
    {
        public enum MoveType { Linear = 0,PositiveAccelerated }
        private static int DEPTH = 10;
        /// <summary>
        ///  Move the control to indicated location If you want to wait until animation finish use Asnyc version!
        /// </summary>
        /// <param name="control">Control that needs to move</param>
        /// <param name="location">After the animation Where you want control to be</param>
        /// <param name="movetype">Movetype animation</param>
        /// <param name="millisecond">Delay between every movement in millisecond </param>
        public static void MoveAnimation(this Control control,Point location,MoveType movetype,int millisecond)
        {
            MoveAnimation_Root(control, location, movetype, millisecond);
       
        }
        /// <summary>
        ///  Move the control to indicated location If you want to wait until animation finish use this! Returns true when it finished
        /// </summary>
        /// <param name="control">Control that needs to move</param>
        /// <param name="location">After the animation Where you want control to be</param>
        /// <param name="movetype">Movetype animation</param>
        /// <param name="millisecond">Delay between every movement in millisecond </param>
        public async static Task<bool> MoveAnimation_Async(this Control control, Point location, MoveType movetype, int millisecond)
        {
            await MoveAnimation_Root(control, location, movetype, millisecond);
            return true;
        }
        private static Task MoveAnimation_Root(Control control, Point location, MoveType movetype, int millisecond)
        {
            return Task.Run(() =>
            {
                float float_location_x = control.Location.X;
                float float_location_y = control.Location.Y;

                float distance_x = location.X - control.Location.X;
                float distance_y = location.Y - control.Location.Y;
                float destinated_x = 0;
                float destinated_y = 0;
                float ratio_x = distance_x / (Math.Abs(distance_x) + Math.Abs(distance_y));
                float ratio_y = distance_y / (Math.Abs(distance_x) + Math.Abs(distance_y));
                try
                {
                    while (Math.Abs(destinated_y) <= Math.Abs(distance_y) && Math.Abs(destinated_x) <= Math.Abs(distance_x))
                    {
                        float should_go_x = 0;
                        float should_go_y = 0;
                        if (movetype == MoveType.Linear)
                        {
                            should_go_x = DEPTH * ratio_x;
                            should_go_y = DEPTH * ratio_y;
                        }
                        else if (movetype == MoveType.PositiveAccelerated)
                        {
                            should_go_x = (DEPTH * ratio_x) / (((Math.Abs(distance_x) + 1) / DEPTH) / ((Math.Abs(destinated_x) + 1) / 2));
                            should_go_y = (DEPTH * ratio_y) / (((Math.Abs(distance_y) + 1) / DEPTH) / ((Math.Abs(destinated_y) + 1) / 2));
                        }
                        else
                        {
                            should_go_x = (DEPTH * ratio_x) / (((Math.Abs(distance_x) + 1) / DEPTH) / ((Math.Abs(destinated_x) + 1) / 2));
                            should_go_y = (DEPTH * ratio_y) / (((Math.Abs(distance_y) + 1) / DEPTH) / ((Math.Abs(destinated_y) + 1) / 2));
                        }
                        float_location_x += should_go_x;
                        float_location_y += should_go_y;
                        control.Invoke(new Action(() =>
                        {
                            control.Location = new Point(Convert.ToInt32(float_location_x), Convert.ToInt32(float_location_y));
                        }));
                        destinated_x += should_go_x;
                        destinated_y += should_go_y;
                        Thread.Sleep(millisecond);
                    }
                    control.Invoke(new Action(() =>
                    {
                        control.Location = new Point(location.X, location.Y);
                    }));
                }
                catch
                {
                    return;
                }


            });
        }


    }
}
