using Font = Microsoft.Maui.Graphics.Font;

namespace PhoneBookApp.Controls
{
    public class CircleDrawable : IDrawable
    {
        private ICanvas canvas;
        private RectF dirtyRect;

        public string Text;

        private Color backgroundColor
        {
            get
            {
                var current = App.Current;

                if (current?.Resources is not null && 
                    current.Resources.TryGetValue("PrimaryColor", out object primaryColor) && 
                    primaryColor is Color backgroundColor)
                {
                    return backgroundColor;
                }

                return Colors.Black;
            }
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            this.canvas = canvas;
            this.dirtyRect = dirtyRect;

            //canvas.StrokeColor = Colors.Red;
            //canvas.StrokeSize = 10;
            //canvas.FillColor = Colors.Lime;
            //canvas.FillCircle(10, 10, 100);

            //canvas.DrawRectangle(dirtyRect);

            var gradients = new GradientStopCollection()
            {
                new GradientStop(backgroundColor, 0),
                new GradientStop(backgroundColor.AddLuminosity(0.1f), 1)
            };

            var gradientBrush = new LinearGradientBrush(gradients, new Point(0, 0), new Point(1, 0));

            canvas.SetFillPaint(gradientBrush, dirtyRect);
            //canvas.FillColor = backgroundColor;
            canvas.FillCircle(dirtyRect.Center, dirtyRect.Width / 2);

            //canvas.SetFillPaint

            if (!string.IsNullOrEmpty(Text))
            {
                UpdateText(Text);
            }
        }

        public void UpdateText(string text)
        {
            if (canvas is null)
                return;

            canvas.FontColor = Colors.White;
            canvas.FontSize = dirtyRect.Width / 2;
            canvas.Font = Font.Default;
            canvas.DrawString(text, dirtyRect, HorizontalAlignment.Center, VerticalAlignment.Center);
        }
    }
}
