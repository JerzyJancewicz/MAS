using System.ComponentModel.DataAnnotations;

namespace MAS5.Models.UserM
{
    public interface IEmployee
    {
        public string JobTitle { get; set; }
        public bool IsPossibleRaise(int AmmountOfHandledTasks);
    }
}
