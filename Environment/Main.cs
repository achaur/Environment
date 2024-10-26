using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Linq.Expressions;

//testComment

namespace Environment
{
    /// <summary>
    /// Startup class for all Revit plugin (described in .addin file).
    /// OnStartup() after initializing on startup returns Result.Succeeded.
    /// </summary>
    public class Main : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {  
            SetupInterface ui = new SetupInterface();
            ui.Initialize(application);

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
