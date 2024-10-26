using Autodesk.Revit.UI;
using Environment.UI;
using Environment.Core;
using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Shell;
using Newtonsoft.Json.Bson;
using System.Windows.Controls;
using RibbonItem = Autodesk.Revit.UI.RibbonItem;
using static System.Net.WebRequestMethods;

namespace Environment
{
    public class SetupInterface
    {
        public SetupInterface() { }

        /// <summary>
        /// Creating Ribbon tabs, panels and buttons.
        /// </summary>
        /// 

        private List<Autodesk.Revit.UI.RibbonPanel> panelsOfPlugin;

        public List<Autodesk.Revit.UI.RibbonPanel> PanelsOfPlugin
        {
            get { return panelsOfPlugin; }
            set { panelsOfPlugin = value; }
        }

        public void Initialize(UIControlledApplication application)
        {
            // Create Ribbon Tab
            string tabName = "Environment";
            application.CreateRibbonTab(tabName);
            // Create Ribbon Panels
            CreatePanel01(application, tabName, "Standards");
        }
        #region CHECKER PANEL
        private Autodesk.Revit.UI.RibbonPanel CreatePanel01(UIControlledApplication application, string tabName, string panelName)
        {
            Autodesk.Revit.UI.RibbonPanel panel = application.CreateRibbonPanel(tabName, panelName);

            // Populate button data model
            RevitPushButtonDataModel buttonData01 = new RevitPushButtonDataModel
            {
                Label = "Rotate Families",
                Panel = panel,
                CommandNamespacePath = RotateFamilies.GetPath(),
                ToolTip = "Check file for standards, model and codes.",
                LongDescription = "Check which categories need to be checked for prefix in naming. Also check model issues, and problems with national codes.",
                IconImageName = "rotate.png",
                AvailabilityClassName = "Environment.Core.DocumentIsNotFamily"
            };
            // Create button from provided data
            PushButtonManager.Create(buttonData01);
            
            return panel;
        }

        #endregion

    }
}
