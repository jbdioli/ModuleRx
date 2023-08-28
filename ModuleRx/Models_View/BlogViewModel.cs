using PropertyChanged;

namespace ModuleRx.Models_View
{
    [AddINotifyPropertyChangedInterface]
    public class BlogViewModel
    {
        public int PostId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string body { get; set; }
    }
}