using System;
using System.Collections.Generic;
using System.Text;
using OSGeo.MapServer;

namespace MFEditorUI.CartoUI
{
    interface ILayerProperties
    {
        /// <summary>
        /// the layerobj used of the page
        /// </summary>
        layerObj Layer { set;}        

        /// <summary>
        /// activate the page
        /// </summary>
        void Activate();


        /// <summary>
        /// deactivate the page
        /// </summary>
        void Deactivate();       

        /// <summary>
        /// refresh the page
        /// </summary>
        void RefreshPage();
        
        /// <summary>
        /// apply the change to the layerobj
        /// </summary>
        void Apply();

        /// <summary>
        /// get the if the layerobj is changed
        /// </summary>
        bool IsDirty { get;}
        
    }
}
