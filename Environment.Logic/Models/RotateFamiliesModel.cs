using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Environment.Logic.Utils;

namespace Environment.Logic
{
    public class RotateFamiliesModel
    {
        #region PROPERTIES

        private readonly UIDocument _uidoc;
        private readonly Document _doc;
        private readonly UIApplication _uiApplication;
        private Dictionary<ElementId, double> _elementIdRotationAngle = new Dictionary<ElementId, double>();
        public List<ElementId> _selectedIds { get; set; }

        #endregion

        #region CONSTRUCTOR

        public RotateFamiliesModel(UIDocument uidoc, UIApplication app)
        {
            _uidoc = uidoc;
            _doc = uidoc.Document;
            _uiApplication = app;
        }


        #endregion

        #region METHODS
        public int SelectFamilyInstances()
        {
            try
            {
                IList<Reference> references = _uidoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, new SelectionUtils.SelectFamilyInstances());

                if (null != references && references?.Count != 0)
                {
                    _selectedIds = new List<ElementId>();

                    foreach (Reference reference in references)
                    {
                        _selectedIds.Add(reference.ElementId);
                    }
                    return _selectedIds.Count;
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return 0;
        }


        public void RotateSelectedFamilies(string angle, string rotationPoint, bool randomRotation, bool cancelRotation)
        {
            double radians = 0;

            if (!randomRotation && !cancelRotation)
            {
                radians = RevitVersionControl.ConverDegreesToRadians(_doc, angle);
            }

            var random = new Random();

            using (Transaction trans = new Transaction(_doc, "Rotate Families"))
            {
                trans.Start();

                foreach (ElementId elementId in _selectedIds)
                {
                    if (cancelRotation)
                    {
                        radians = _elementIdRotationAngle[elementId] * -1;
                    }
                    if (randomRotation && !cancelRotation)
                    {
                        double degrees = random.Next(0, 361);

                        // Convert degrees to radians
                        radians = degrees * (Math.PI / 180);
                    }

                    FamilyInstance familyInstance = _doc.GetElement(elementId) as FamilyInstance;

                    if (null != familyInstance)
                    {
                        XYZ point = rotationPoint == "Base Point" ? ((LocationPoint)familyInstance.Location).Point :
                            (familyInstance.get_BoundingBox(null).Min + familyInstance.get_BoundingBox(null).Max) * 0.5;

                        ElementTransformUtils.RotateElement(_doc, familyInstance.Id, Line.CreateBound(point, point.Add(XYZ.BasisZ.Multiply(5))), radians);
                    }

                    if (!cancelRotation)
                    { 
                        if (!_elementIdRotationAngle.ContainsKey(elementId))
                        {
                            _elementIdRotationAngle.Add(elementId, radians);
                        }
                        else
                        {
                            _elementIdRotationAngle[elementId] += radians;
                        }
                    }
                }

                trans.Commit();
            }
        }

        #endregion
    }
}