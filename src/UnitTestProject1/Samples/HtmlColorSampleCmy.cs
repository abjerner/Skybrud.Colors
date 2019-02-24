namespace UnitTestProject1.Samples {

    public class HtmlColorSampleCmy {

        public double Cyan { get; }

        public double Magenta { get; }

        public double Yellow { get; }

        public string Text => $"CMY: {Cyan}, {Magenta}, {Yellow}";

        public HtmlColorSampleCmy(double cyan, double magenta, double yellow) {
            Cyan = cyan;
            Magenta = magenta;
            Yellow = yellow;
        }

    }

}