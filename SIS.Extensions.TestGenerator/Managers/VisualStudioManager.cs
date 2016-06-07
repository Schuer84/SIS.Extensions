using System;
using System.Windows;
using EnvDTE;
using SIS.Extensions.TestGenerator.Contracts;

namespace SIS.Extensions.TestGenerator.Managers
{
    public class VisualStudioManager : IVisualStudioManager
    {
        private readonly IFileTemplateProvider _fileTemplateProvider;
        private readonly ITransform<string, IFile> _fileTransformer;
        private readonly DTE _dte;

        public VisualStudioManager(DTE dte, ITransform<string, IFile> fileTransformer, IFileTemplateProvider fileTemplateProvider)
        {
            _dte = dte;
            _fileTransformer = fileTransformer;
            _fileTemplateProvider = fileTemplateProvider;

            
        }

        public string GenerateUnitTest()
        {
            var content = GetFileContent();
            if (string.IsNullOrEmpty(content)) return content;
            
            var file = _fileTransformer.Transform(content);
            if (file == null) return null;

            return _fileTemplateProvider
                            .GetFileTemplate(file)
                            .TransformText();

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
