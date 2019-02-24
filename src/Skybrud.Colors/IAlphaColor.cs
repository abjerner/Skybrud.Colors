namespace Skybrud.Colors {

    /// <summary>
    /// Interface representing an instance ofg <see cref="IColor"/> with an addition of the <see cref="Alpha"/> property.
    /// </summary>
    public interface IAlphaColor : IColor {

        /// <summary>
        /// Gets or sets the opacity as a number between <c>0.0</c> (fully transparent) and <c>1.0</c> (fully opaque).
        /// </summary>
        float Alpha { get; set; }

    }

}