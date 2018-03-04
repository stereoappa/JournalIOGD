using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoadOfSql.Infrastructure.Controls
{
    public static class MoveControl
    {
        private static List<ScrollEngine> scrlrs = new List<ScrollEngine>();
        // static ScrollEngine scrollEngine;
        public static void EnableMove(Control c)
        {
            var scrollEngine = new ScrollEngine(c);
            scrlrs.Add(scrollEngine);
        }
        public static void DestructOlder(Control c)
        {
            if (scrlrs != null)
            {
                int ind = scrlrs.FindIndex(x => x.ScrollableControl == c);
                if (ind != -1)
                    scrlrs[ind].ScrollableControl = null;
            }
            //if (scrlrs != null)
            //    if (scrlrs.Find(x =>
            //    {
            //        if (x.ScrollableControl.Contains(c))
            //            x.ScrollableControl;
            //        //else return false;
            //    })) ;

            //scrlrs.ForEach(x => { x.ScrollableControl = null; });
        }

        public class ScrollEngine
        {
            private Control scrollableControl;
            private Point positionBeforeMove;
            public static bool DefaulScrollCondition()
            {
                return Form.MouseButtons.HasFlag(MouseButtons.Left);
            }
            public ScrollEngine(Control scrollableControl)
            {
                ScrollCondition = DefaulScrollCondition;
                ScrollableControl = scrollableControl;
                this.Scroll += ScrollEngine_Scroll;
            }

            private void ScrollEngine_Scroll(object sender, ScrollEventArgs e)
            {
                scrollableControl.Location += e.Offset;
            }

            public Control ScrollableControl
            {
                get { return scrollableControl; }
                set { Disconnect(); scrollableControl = value; Connect(); }
            }

            private void Connect()
            {
                if (scrollableControl != null)
                    scrollableControl.MouseMove += ScrollableControl_MouseMove;
            }
            private void Disconnect()
            {
                if (scrollableControl != null)
                    scrollableControl.MouseMove -= ScrollableControl_MouseMove;
            }
            public Func<bool> ScrollCondition { get; set; }

            private void ScrollableControl_MouseMove(object sender, MouseEventArgs e)
            {
                if (ScrollCondition())
                {
                    Size offset = new Size(Cursor.Position.X - positionBeforeMove.X, Cursor.Position.Y - positionBeforeMove.Y);
                    OnScroll(new ScrollEventArgs(offset));
                }
                positionBeforeMove = Cursor.Position;
            }
            protected virtual void OnScroll(ScrollEventArgs e)
            {
                if (Scroll != null)
                    Scroll(this, e);
            }

            public event EventHandler<ScrollEventArgs> Scroll;
            public class ScrollEventArgs : EventArgs
            {
                public ScrollEventArgs(Size offset)
                {
                    Offset = offset;
                }
                public Size Offset { get; private set; }
            }
        }
    }
}
