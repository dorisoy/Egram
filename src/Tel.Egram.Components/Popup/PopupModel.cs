using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using PropertyChanged;
using ReactiveUI;

namespace Tel.Egram.Components.Popup
{
    [AddINotifyPropertyChangedInterface]
    public class PopupModel : ISupportsActivation
    {
        public PopupContext Context { get; set; }

        public bool IsVisible { get; set; } = true;

        public PopupModel(PopupContext context)
        {
            Context = context;
            
            this.WhenActivated(disposables =>
            {
                this.BindPopup()
                    .DisposeWith(disposables);
            });
        }

        private PopupModel()
        {
        }

        public static PopupModel Hidden()
        {
            return new PopupModel
            {
                IsVisible = false
            };
        }

        public ViewModelActivator Activator { get; } = new ViewModelActivator();
    }
}