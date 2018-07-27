namespace UnitTestProject1.Samples {

    public class HtmlColorSampleHsl {

        public double Hue { get; }

        public double HueDecimal => Hue / 360d;

        public double Saturation { get; }

        public double SaturationDecimal => Saturation / 100d;

        public double Lightness { get; }

        public double LightnessDecimal => Lightness / 100d;

        public string Css => "hsl(" + Hue + ", " + Saturation + "%, " + Lightness + "%)";

        public string Text => $"HSL: {Hue}, {Saturation}, {Lightness}";

        public HtmlColorSampleHsl(double hue, double saturation, double lightness) {
            Hue = hue;
            Saturation = saturation;
            Lightness = lightness;
        }

    }

}