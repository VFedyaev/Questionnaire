using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Questionnaire.DAL.Entities;

namespace Questionnaire.DAL.EF
{
    public class QuestionnaireContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<SurveyGeography> SurveyGeographies { get; set; }
        public DbSet<HousingType> HousingTypes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Interviewer> Interviewers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Data> Datas { get; set; }

        public QuestionnaireContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<QuestionnaireContext>(null);
        }
    }
}
