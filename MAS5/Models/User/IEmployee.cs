using System.ComponentModel.DataAnnotations;

namespace MAS5.Models.User.User
{
    public interface IEmployee
    {
        public string JobTitle { get; set; }
        public bool IsPossibleRaise(int AmmountOfHandledTasks);
    }
}
