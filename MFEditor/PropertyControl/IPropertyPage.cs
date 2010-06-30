using System;
using System.Collections.Generic;
using System.Text;

namespace MFEditor.PropertyControl
{
    public interface IPropertyPage
    {
        /// <summary>
        /// ancivate the current page
        /// </summary>
        void Activate();

        /// <summary>
        /// apply the current setting 
        /// </summary>
        void Apply();

        /// <summary>
        /// destory the current page
        /// </summary>
        void Deactivate();

        /// <summary>
        /// return if there is any change of current object
        /// </summary>
        bool IsPageDirty { get;}

        /// <summary>
        /// show tha page
        /// </summary>
        void Show();

        /// <summary>
        /// hide the page
        /// </summary>
        void Hide();

        /// <summary>
        /// set the object of the page
        /// </summary>
        /// <param name="inObject"></param>
        void SetObjects(object inObject);

        /// <summary>
        /// get the width of the page
        /// </summary>
        int Width { get;}

        /// <summary>
        /// get the height of the page
        /// </summary>
        int Height { get;}
    }
}
