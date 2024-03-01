using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAddInPractice1.Extensions.SelectionExtensions
{
    public static class SelectionExtensions
    {
        public static List<Element> PickElements(this UIDocument uiDocument)
        {
            throw new NotImplementedException();
        }
    }
    public class LinkableSelctionFilter : BaseSelectionFilter
    {
        private readonly Document _document;

        public LinkableSelctionFilter(
            Document document,
            Func<Element, bool> validateElement) 
            : base(validateElement)
        {
            this._document = document;
        }

        public override bool AllowElement(Element elem)
        {
            return true;
        }

        public override bool AllowReference(Reference reference, XYZ position)
        {
            if(!(_document.GetElement(reference.ElementId) is RevitLinkInstance linkInstance))
            // RevitLinkInstance
            // Revit에서는 하나의 대규모 프로젝트를 여러 개의 작은 프로젝트로 나누어 작업할 수 있습니다.
            // 이렇게 나누어진 작은 프로젝트들은 서로 다른 Revit 파일로 저장되며,
            // 이들 파일 간의 연결을 유지하고자 할 때 링크 기능을 사용
            {
                return ValidateElement(_document.GetElement(reference.ElementId));
            }

            var element = linkInstance.GetLinkDocument()
                .GetElement(reference.LinkedElementId);

            return ValidateElement(element);
        }

        /*        #region Properties
       private readonly Func<Element, bool> _validateElement;

       #endregion

       #region Constructor
       public LinkableSelctionFilter(Func<Element, bool> validateElement) 
       {
           _validateElement = validateElement;
       }

       #endregion

       #region Methods
       public bool AllowElement(Element elem)
       {
           throw new NotImplementedException();
       }

       public bool AllowReference(Reference reference, XYZ position)
       {
           throw new NotImplementedException();
       }

       #endregion*/

    }

    public abstract class BaseSelectionFilter : ISelectionFilter
    {
        protected readonly Func<Element, bool> ValidateElement;

        protected BaseSelectionFilter(Func<Element, bool> validateElement) 
        {
            ValidateElement = validateElement;
        }

        public abstract bool AllowElement(Element elem);
        public abstract bool AllowReference(Reference reference, XYZ position);

    }

    /* Implement Interface
    public class ElementSelectionFilter : ISelectionFilter
    {

        #region Properties
        private readonly Func<Element, bool> _validateElement;
        private readonly Func<Reference, bool> _validateReference;

        #endregion



        #region Constructor
        public ElementSelectionFilter(Func<Element, bool> validateElement)
        {
            _validateElement = validateElement;
        }

        public ElementSelectionFilter(Func<Element, bool> validateElement, Func<Reference, bool> validateReference)
        {
            _validateReference = validateReference;
        }

        #endregion



        #region Method
        public bool AllowElement(Element elem)
        {
            return _validateElement(elem);
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return _validateReference?.Invoke(reference) ?? true;
        }
        #endregion
    }
    */

    public class ElementSelectionFilter : BaseSelectionFilter
    {
        #region Properties
        private readonly Func<Reference, bool> _validateReference;

        #endregion



        #region Constructor
        public ElementSelectionFilter(Func<Element, bool> validateElement) : base(validateElement)
        {
        }
        public ElementSelectionFilter(Func<Element, bool> validateElement, Func<Reference, bool> validateReference) 
            : base(validateElement)
        {
            _validateReference = validateReference;
        }

        #endregion



        #region Method
        public override bool AllowElement(Element elem)
        {
            return ValidateElement(elem);
        }

        public override bool AllowReference(Reference reference, XYZ position)
        {
            return _validateReference?.Invoke(reference) ?? true;
        }

        #endregion

    }

}
