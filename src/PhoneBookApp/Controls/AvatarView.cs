using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Controls
{
    public class AvatarView : GraphicsView
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(
                nameof(Text),
                typeof(string),
                typeof(AvatarView),
                string.Empty,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var avatarView = ((AvatarView)bindable);
                    avatarView.CircleDrawable.Text = (string)newValue;

                });

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public CircleDrawable CircleDrawable { get; } = new CircleDrawable();

        public AvatarView()
        {
            Drawable = CircleDrawable;
        }
    }
}
