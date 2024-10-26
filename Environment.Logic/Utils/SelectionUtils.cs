using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Environment.Logic
{
    public class SelectionUtils
    {
        public class SelectionFilter : ISelectionFilter
        {
            public string _name;
            public SelectionFilter(string name)
            {
                _name = name;
            }
            public bool AllowElement(Element element)
            {
                if (element?.Category?.Name == _name)
                {
                    return true;
                }
                return false;
            }

            public bool AllowReference(Reference refer, XYZ point)
            {
                return false;
            }
        }
        public class SelectFamilyInstances : ISelectionFilter
        {
            public string _name;
            public bool AllowElement(Element element)
            {
                if (element != null)
                {
                    if (element is FamilyInstance)
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool AllowReference(Reference refer, XYZ point)
            {
                return false;
            }
        }
    }
}
