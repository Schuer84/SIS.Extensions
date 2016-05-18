//------------------------------------------------------------------------------
// <copyright file="TestGenerator.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace SIS.Extensions.TestGenerator
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("8af3d78b-6a98-46d3-87ae-372d71cd5ea6")]
    public class TestGenerator : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestGenerator"/> class.
        /// </summary>
        public TestGenerator() : base(null)
        {
            this.Caption = "TestGenerator";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.

            var dte = (DTE)Microsoft.VisualStudio.Shell.Package.GetGlobalService(typeof(DTE));


            this.Content = new TestGeneratorControl(dte);
        }
    }
}
