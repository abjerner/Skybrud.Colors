namespace UnitTestProject1.Samples {

    public class HtmlColorSampleRgb {

        public int Red { get; }

        public double RedDecimal => Red / 255d;

        public int Green { get; }

        public double GreenDecimal => Green / 255d;

        public int Blue { get; }

        public double BlueDecimal => Blue / 255d;

        public string Css => "rgb(" + Red + ", " + Green + ", " + Blue + ")";

        public string Text => $"RGB: {Red}, {Green}, {Blue}";

        public HtmlColorSampleRgb(int red, int green, int blue) {
            Red = red;
            Green = green;
            Blue = blue;
        }

    }

}