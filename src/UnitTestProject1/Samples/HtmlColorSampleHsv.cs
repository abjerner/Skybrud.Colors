namespace UnitTestProject1.Samples {

    public class HtmlColorSampleHsv {

        public double Hue { get; }

        public double HueDecimal => Hue / 360d;

        public double Saturation { get; }

        public double SaturationDecimal => Saturation / 100d;

        public double Value { get; }

        public double ValueDecimal => Value / 100d;

        public string Text => $"HSV: {Hue}, {Saturation}, {Value}";

        public HtmlColorSampleHsv(double hue, double saturation, double value) {
            Hue = hue;
            Saturation = saturation;
            Value = value;
        }

    }

}