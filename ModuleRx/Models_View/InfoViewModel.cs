using PropertyChanged;

namespace ModuleRx.Models_View
{
    [AddINotifyPropertyChangedInterface]
    public class InfoViewModel
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}