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

        public void RotateSelectedFamilies(string angle, string rotationPoint, bool randomRotation)
        {
            double radians = 0;

            if (randomRotation)
            {
                double degrees = new Random().Next(0, 361);

                // Convert degrees to radians
                radians = degrees * (Math.PI / 180);
            }
            else
            {
                radians = RevitVersionControl.ConverDegreesToRadians(_doc, angle);
            }

            using (Transaction trans = new Transaction(_doc, "Rotate Families"))
            {
                trans.Start();

                foreach (ElementId elementId in _selectedIds)
                { 
                    FamilyInstance familyInstance = _doc.GetElement(elementId) as FamilyInstance;

                    if (null != familyInstance)
                    {
                        XYZ point = rotationPoint == "Base Point" ? ((LocationPoint)familyInstance.Location).Point :
                            (familyInstance.get_BoundingBox(null).Min + familyInstance.get_BoundingBox(null).Max) * 0.5;

                        ElementTransformUtils.RotateElement(_doc, familyInstance.Id, Line.CreateBound(point, point.Add(XYZ.BasisZ.Multiply(5))), radians);
                    }
                }

                trans.Commit();
            }
        }

        #endregion
    }
}