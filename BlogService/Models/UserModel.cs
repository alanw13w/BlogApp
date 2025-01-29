using BlogApp.Entities;

namespace BlogService.Models
{
    public class UserModel
    {
        public int UserModelId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public required string Pseudo { get; set; }

        public List<PostModel> PostModels { get; set; }


        static public UserModel fromDomainEntity(User user)
        {
            return new UserModel
            {
                UserModelId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Pseudo = user.Pseudo,
                PostModels = null,
            };
        }

        public User toDomainEntity()
        {
            return new User(this.UserModelId, this.FirstName, this.LastName, this.Password, this.Pseudo);
        }
    }
}
