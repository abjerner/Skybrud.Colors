namespace UnitTestProject1.Samples {

    public class HtmlColorSampleHsl {

        public double Hue { get; }

        public double Saturation { get; }

        public double Lightness { get; }

        public string Css => "hsl(" + Hue + ", " + Saturation + "%, " + Lightness + "%)";

        public string Text => $"HSL: {Hue}, {Saturation}, {Lightness}";

        public HtmlColorSampleHsl(double hue, double saturation, double lightness) {
            Hue = hue;
            Saturation = saturation;
            Lightness = lightness;
        }

    }

}