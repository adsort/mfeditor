
using System;
using System.Drawing;

namespace MFEditor
{   

    public interface IColorSelector
    {
        bool DoModal();

        Color Color { get; set; }

        Point Location { get; set; }        
    }
}

