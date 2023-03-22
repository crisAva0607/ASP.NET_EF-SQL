namespace RESUME_BUILDER.Models
{
    public class HomeViewModel
    {
        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? Role { get; set; }

        public string? Address { get; set; }

        public string? ContactNumber { get; set; }

        public string? Objective { get; set; }

        public List<Link1> LinkList { get; set; }

        public List<Education1> EducationList { get; set; }

        public List<Skill1> SkillList { get; set; }
        public List<Experience1> ExperienceList { get; set; }

        public List<Training1> TrainingList { get; set; }
        public List<CharacterReference1> CharacterReference { get; set; }
    }

    public class Link1
    {
        public string GitHub { get; set; }
        public string Gmail { get; set; }
    }
    public class Education1
    {
        public string? School { get; set; }
        public string? Course { get; set; }
        public string? YearAttended { get; set; }
    }
    public class Skill1
    {
        public string? skillName { get; set; }
       
    }
    public class Experience1
    {
        public string? role { get; set; }
        public string? company { get; set; }

    }
    public class Training1
    {
        public string? trainingName { get; set; }
        public string? yearAttended { get; set; }

    }
    public class CharacterReference1
    {
        public string? name { get; set; }
        public string? job { get; set; }
        public string? company { get; set; }
        public string? contactNumber { get; set; }

    }
}
