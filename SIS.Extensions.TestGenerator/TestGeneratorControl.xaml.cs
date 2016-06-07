//------------------------------------------------------------------------------
// <copyright file="TestGeneratorControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.Windows.Controls;
using EnvDTE;
using SIS.Extensions.TestGenerator.Managers;
using SIS.Extensions.TestGenerator.Templates;
using SIS.Extensions.TestGenerator.Transformers;
using SIS.Extensions.TestGenerator.ViewModels;

namespace SIS.Extensions.TestGenerator
{
    /// <summary>
    /// Interaction logic for TestGeneratorControl.
    /// </summary>
    public partial class TestGeneratorControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestGeneratorControl"/> class.
        /// </summary>
        public TestGeneratorControl(DTE currentDte)
        {
            var manager = new VisualStudioManager(currentDte, new FileTransformer(), new FileTemplateProvider());
            var vm = new TestGenerationViewModel(manager);

            Container = new ContainerViewModel(vm);
            this.InitializeComponent();
        }

        public ContainerViewModel Container { get; set; }
    }
}