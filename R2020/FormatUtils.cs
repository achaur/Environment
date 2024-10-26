using Autodesk.Revit.DB;

namespace R2020
{
    public class FormatUtils
    {
        public static double FormatDegreesToRadians(string angle, Units units)
        {
            FormatOptions angleFormatOptions = units.GetFormatOptions(UnitType.UT_Angle);

            DisplayUnitType displayUnitType = angleFormatOptions.DisplayUnits;
            double.TryParse(angle, out double angleParsed);

            if (displayUnitType == DisplayUnitType.DUT_RADIANS)
                return angleParsed;

            if (displayUnitType == DisplayUnitType.DUT_DECIMAL_DEGREES)
                return UnitUtils.ConvertToInternalUnits(angleParsed, DisplayUnitType.DUT_DECIMAL_DEGREES);

            if (displayUnitType == DisplayUnitType.DUT_GRADS)
                return UnitUtils.ConvertToInternalUnits(angleParsed, DisplayUnitType.DUT_GRADS);

            if (displayUnitType == DisplayUnitType.DUT_DEGREES_AND_MINUTES)
                return UnitUtils.ConvertToInternalUnits(angleParsed, DisplayUnitType.DUT_DEGREES_AND_MINUTES);

            return 0;
        }
    }
}
