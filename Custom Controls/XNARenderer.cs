using System;
using System.Collections.Generic;
using System.Text;

namespace XNA_Map_Editor
{
    class XNARenderer : GraphicsDeviceControl
    {
        public EventHandler OnInitialize;
        public EventHandler OnDraw;        

        protected override void Initialize()
        {
            if (OnInitialize != null)
            {
                this.OnInitialize(this, null);
            }
        }

        protected override void Draw()
        {
            if (OnDraw != null)
            {
                this.OnDraw(this, null);
            }
        }

    }
}
