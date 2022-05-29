using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

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
        }

        public bool ShouldAddProjectItem(string filePath) => _shouldAddProjectItem;

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }
    }
}