using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environment.Logic.Utils
{
    public static class RevitVersionControl
    {
        public static double ConverDegreesToRadians(Document doc, string angle)
        {
            string version = doc.Application.VersionNumber;

            var units = doc.GetUnits();

            switch (version) 
            {
                case "2020":
                    return R2020.FormatUtils.FormatDegreesToRadians(angle, units);
                case "2021":
                    return R2020.FormatUtils.FormatDegreesToRadians(angle, units);
                case "2022":
                    return R2022.FormatUtils.FormatDegreesToRadians(angle, units);
                case "2023":
                    return R2022.FormatUtils.FormatDegreesToRadians(angle, units);
                case "2024":
                    return R2022.FormatUtils.FormatDegreesToRadians(angle, units);
                case "2025":
                    return R2022.FormatUtils.FormatDegreesToRadians(angle, units);
            }
            return 0;
        }
    }
}
