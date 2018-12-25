using System.Collections.Generic;

namespace Questionnaire.BLL.DTO
{
    public class FormDataDTO
    {
        public string QuestionName { get; set; }
        public IEnumerable<FormOptionDTO> Options { get; set; }
    }

    public class FormOptionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool MultipleAnswer { get; set; }
    }
}
