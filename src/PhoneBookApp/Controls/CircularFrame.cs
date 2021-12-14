using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;

namespace PhoneBookApp.Controls
{
    public class CircularFrame : Frame
    {
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Height))
            {
                this.WidthRequest = Height;
                
                if (float.TryParse(Height.ToString(), out float fHeight))
                {
                    this.CornerRadius = fHeight / 2;
                }
            }
        }
    }
}
