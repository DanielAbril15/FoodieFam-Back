using FoodieFam_Back.Models;

namespace FoodieFam_Back.DTOs.RecipeDto
{
    public class RecipeInsertDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public int Time { get; set; }
        public int Portions { get; set; }

        public int Likes { get; set; }

        public Guid? UserId { get; set; }
            

    }
}
