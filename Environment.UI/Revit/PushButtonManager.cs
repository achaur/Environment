using System;
using System.IO;
using System.Reflection;
using Autodesk.Revit.UI;
using Environment.Core;
using Environment.Resources;
using RibbonItem = Autodesk.Revit.UI.RibbonItem;

namespace Environment.UI
{
    // Revit push button methods
    public static class PushButtonManager
    {
        private static readonly string _assembly = CoreAssembly.GetAssemblyLocation();

        // Create the push button data provided in <see cref="RevitPushButtonDataModel">
        public static PushButton Create(RevitPushButtonDataModel data)
        {
            PushButtonData buttonData = MakePushButtonData(data);

            // Return created button and host it on panel provided in required data model
            return data.Panel.AddItem(buttonData) as PushButton;
        }

        public static PushButtonData MakePushButtonData(RevitPushButtonDataModel data)
        {
            string name = data.Label;
            // Sets the button data
            PushButtonData buttonData = new PushButtonData(name, data.Label, _assembly, data.CommandNamespacePath)
            {
                ToolTip = data.ToolTip,
                LongDescription = data.LongDescription,
                LargeImage = ResourceImage.GetIcon(data.IconImageName),
                AvailabilityClassName = data.AvailabilityClassName
            };
            if (null != data.HelpSourceLink && string.Empty != data.HelpSourceLink)
                buttonData.SetContextualHelp(new ContextualHelp(ContextualHelpType.Url, data.HelpSourceLink));

            return buttonData;
        }
    }
}
