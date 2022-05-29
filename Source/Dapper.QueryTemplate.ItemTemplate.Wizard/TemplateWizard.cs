using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;

namespace Dapper.QueryTemplate.ItemTemplate.Wizard
{
    public class TemplateWizard : IWizard
    {
        private UserInputForm inputForm;
        private string customMessage;

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind,
            object[] customParams)
        {
            try
            {
                // Display a form to the user. The form collects
                // input for the custom message.
                inputForm = new UserInputForm();
                inputForm.ShowDialog();

                customMessage = UserInputForm.CustomMessage;

                // Add custom parameters.
                replacementsDictionary.Add("entity", customMessage);
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

        public bool ShouldAddProjectItem(string filePath) => true;

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void RunFinished()
        {
        }
    }
}