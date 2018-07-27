namespace UnitTestProject1.Samples {

    public class HtmlColorSampleCmyk {

        public double Cyan { get; }

        public double Magenta { get; }

        public double Yellow { get; }

        public double Key { get; }

        public string Css => "cmyk(" + Cyan + ", " + Magenta + ", " + Yellow + ", " + Key + ")";

        public string Text => $"CMYK: {Cyan}, {Magenta}, {Yellow}, {Key}";

        public HtmlColorSampleCmyk(double cyan, double magenta, double yellow, double key) {
            Cyan = cyan;
            Magenta = magenta;
            Yellow = yellow;
            Key = key;
        }

    }

}