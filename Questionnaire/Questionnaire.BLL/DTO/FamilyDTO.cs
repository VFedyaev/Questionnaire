using System;

namespace Questionnaire.BLL.DTO
{
    public class FamilyDTO
    {
        public int Id { get; set; }
        public string Sex { get; set; }
        public short Age { get; set; }
        public int FormId { get; set; }

        public FormDTO Form { get; set; }
    }
}