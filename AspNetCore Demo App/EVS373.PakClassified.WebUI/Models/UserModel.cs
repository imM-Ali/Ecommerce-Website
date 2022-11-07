using System;


namespace EVS373.PakClassified.WebUI.Models
{

    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ApiKey { get; set; }

        public string LoginId { get; set; }

        public string Password { get; set; }

        public string SecurityQuestion { get; set; }

        public string SecurityAnswer { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? Age
        {
            get
            {
                if (BirthDate.HasValue)
                {
                    return (int)(DateTime.Today.Subtract(BirthDate.Value).TotalDays / 365.25);
                }
                return null;
            }
        }

        public string ContactNumber { get; set; }

        public byte[] Image { get; set; }

        public RoleModel Role { get; set; }

    }
}
