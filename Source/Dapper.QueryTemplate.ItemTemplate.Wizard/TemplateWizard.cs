using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using VSLangProj;

namespace Dapper.QueryTemplate.ItemTemplate.Wizard
{
    public class TemplateWizard : IWizard
    {
        private bool _shouldAddProjectItem;

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind,
            object[] customParams)
        {
            try
            {
                // Display a form to the user. The form collects
                // input for the custom message.
                var form = new EntryEntityNameForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _shouldAddProjectItem = true;
                    // Add custom parameters.
                    replacementsDictionary.Add("entity", form.EntityName);
                }
                else
                {
                    _shouldAddProjectItem = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            if (projectItem.Name.EndsWith(".tt.cs"))
            {
                projectItem.GetProperty("DependentUpon").Value = projectItem.Name.Replace(".tt.cs", ".tt");
            }

            if (projectItem.Name.EndsWith(".tt"))
            {
                projectItem.GetProperty("Generator").Value = "TextTemplatingFilePreprocessor";
                projectItem.GetProperty("CustomTool").Value = "TextTemplatingFilePreprocessor";
            }
        }

        public bool ShouldAddProjectItem(string filePath) => _shouldAddProjectItem;

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }
    }

    public static class PropertyExtensions
    {
        public static Property GetProperty(this ProjectItem projectItem, string propertyName)
        {
            foreach (Property property in projectItem.Properties)
            {
                if (property.Name == propertyName)
                {
                    return property;
                }
            }

            throw new InvalidOperationException($"{propertyName} is not exists.");
        }
    }
}