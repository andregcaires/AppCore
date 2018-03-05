using System.ComponentModel.DataAnnotations;

namespace LojaConstrucao.Web.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}