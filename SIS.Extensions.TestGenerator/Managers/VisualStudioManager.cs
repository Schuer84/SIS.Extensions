using System;
using EnvDTE;
using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Managers
{
    public class VisualStudioManager : IVisualStudioManager
    {
        private readonly ITransform<string, IFile> _fileTransformer;
        private readonly DTE _dte;

        public VisualStudioManager(DTE dte, ITransform<string, IFile> fileTransformer)
        {
            _dte = dte;
            _fileTransformer = fileTransformer;
        }

        public string GenerateUnitTest(IFileTemplate template)
        {
            if(template == null)
            {
                throw new ArgumentNullException();
            }

            var file = template.File = _fileTransformer.Transform(GetFileContent());
            return file == null 
                ? string.Empty 
                : template.TransformText();
        }

        private string GetFileContent()
        {
            var currentDocument = _dte.ActiveDocument;
            if (currentDocument == null) return string.Empty;

            var currentSelection = (TextSelection)currentDocument.Selection;
                currentSelection.SelectAll();

            return currentSelection.Text;
        }
    }
}
