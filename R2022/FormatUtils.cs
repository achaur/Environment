using Autodesk.Revit.DB;

namespace R2022
{
    public static class FormatUtils
    {
        public static double FormatDegreesToRadians(string angle, Units units)
        {
            FormatOptions angleFormatOptions = units.GetFormatOptions(SpecTypeId.Angle);
            ForgeTypeId unitTypeId = angleFormatOptions.GetUnitTypeId();

            double.TryParse(angle, out double angleParsed);

            if (unitTypeId == UnitTypeId.Radians)
                return angleParsed;
            
            if (unitTypeId == UnitTypeId.DegreesMinutes)
                return UnitUtils.ConvertToInternalUnits(angleParsed, UnitTypeId.DegreesMinutes);

            if (unitTypeId == UnitTypeId.Gradians)
                return UnitUtils.ConvertToInternalUnits(angleParsed, UnitTypeId.Gradians);

            if (unitTypeId == UnitTypeId.Degrees)
                return UnitUtils.ConvertToInternalUnits(angleParsed, UnitTypeId.Degrees);

            return 0;
        }
    }
}
