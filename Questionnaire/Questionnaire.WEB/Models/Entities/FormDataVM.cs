using System.Collections.Generic;

namespace Questionnaire.WEB.Models.Entities
{
    public class FormDataVM
    {
        public string QuestionName { get; set; }
        public IEnumerable<FormOptionVM> Options { get; set; }
        public int FormId { get; set; }
    }

    public class FormOptionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool MultipleAnswer { get; set; }
    }
}