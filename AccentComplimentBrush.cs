//-----------------------------------------------------------------------
// <copyright file="AccentComplimentBrush.cs" company="Matt lacey Limited">
//     Copyright © 2013 Matt Lacey
// </copyright>
//-----------------------------------------------------------------------

namespace MRLacey
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Hacky way of adding an extra application level SolidColorBrush that compliments the PhoneAccentBrush
    /// </summary>
    public class AccentComplimentBrush
    {
        /// <summary>
        /// The resource name - as it can be referenced by within the app
        /// </summary>
        private const string ResourceName = "AccentComplimentBrush";

        /// <summary>
        /// Initializes a new instance of the <see cref="AccentComplimentBrush"/> class.
        /// </summary>
        public AccentComplimentBrush()
        {
            try
            {
                // This doesn't work in the designer - so don't even try
                if (DesignerProperties.IsInDesignTool)
                {
                    return;
                }

                // Make sure we don't try and add the resource more than once - would happne if referenced on multiple pages or in app and page(s)
                if (!Application.Current.Resources.Contains(ResourceName))
                {
                    var currentAccentColorHex = (Color)Application.Current.Resources["PhoneAccentColor"];

                    var hsl = HslColor.FromColor(currentAccentColorHex);
                    hsl.ConvertToCompliment();

                    Color compliment = hsl.ToColor();

                    Application.Current.Resources.Add(ResourceName, new SolidColorBrush(compliment));
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong - ask for your money back");
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }

        /// <summary>
        /// Color as Hue, Saturation and Luminosity rather than RGB values
        /// </summary>
        private struct HslColor
        {
            /// <summary>
            /// The alpha value
            ///  from 0 to 1
            /// </summary>
            private double alpha;

            /// <summary>
            /// The hue value
            ///  from 0 to 360
            /// </summary>
            private double hue;

            /// <summary>
            /// The saturation value
            ///  from 0 to 1
            /// </summary>
            private double saturation;

            /// <summary>
            /// The luminosity value
            ///  from 0 to 1
            /// </summary>
            private double luminosity;

            /// <summary>
            /// Create the HSL representation of the color.
            /// </summary>
            /// <param name="color">The color to convert from.</param>
            /// <returns>The HSLColor</returns>
            public static HslColor FromColor(Color color)
            {
                var hslc = new HslColor();
                hslc.alpha = color.A;

                double red = ByteToPercent(color.R);
                double green = ByteToPercent(color.G);
                double blue = ByteToPercent(color.B);

                double max = Math.Max(blue, Math.Max(red, green));
                double min = Math.Min(blue, Math.Min(red, green));

                if (max == min)
                {
                    hslc.hue = 0;
                }
                else if (max == red && green >= blue)
                {
                    hslc.hue = 60 * ((green - blue) / (max - min));
                }
                else if (max == red && green < blue)
                {
                    hslc.hue = (60 * ((green - blue) / (max - min))) + 360;
                }
                else if (max == green)
                {
                    hslc.hue = (60 * ((blue - red) / (max - min))) + 120;
                }
                else if (max == blue)
                {
                    hslc.hue = (60 * ((red - green) / (max - min))) + 240;
                }

                hslc.luminosity = .5 * (max + min);

                if (max == min)
                {
                    hslc.saturation = 0;
                }
                else if (hslc.luminosity <= .5)
                {
                    hslc.saturation = (max - min) / (2 * hslc.luminosity);
                }
                else if (hslc.luminosity > .5)
                {
                    hslc.saturation = (max - min) / (2 - (2 * hslc.luminosity));
                }

                return hslc;
            }

            /// <summary>
            /// Convert the color to it's compliment (opposite position on the color wheel).
            /// </summary>
            public void ConvertToCompliment()
            {
                this.hue += 180;

                if (this.hue > 360)
                {
                    this.hue -= 360;
                }
            }

            /// <summary>
            /// Convert the H, L and S values back to RGB as a System.Color.
            /// </summary>
            /// <returns>The H, S and L values converted back to RGB</returns>
            public Color ToColor()
            {
                double q = 0;

                if (this.luminosity < .5)
                {
                    q = this.luminosity * (1 + this.saturation);
                }
                else
                {
                    q = this.luminosity + this.saturation - (this.luminosity * this.saturation);
                }

                double p = (2 * this.luminosity) - q;
                double hk = this.hue / 360;
                double r = GetComponent(Normalize(hk + (1.0 / 3.0)), p, q);
                double g = GetComponent(Normalize(hk), p, q);
                double b = GetComponent(Normalize(hk - (1.0 / 3.0)), p, q);

                return Color.FromArgb(PercentToByte(this.alpha), PercentToByte(r), PercentToByte(g), PercentToByte(b));
            }

            /// <summary>
            /// Convert byte to percentage.
            /// </summary>
            /// <param name="value">The value to convert.</param>
            /// <returns>The byte as a percentage (between 0 and 1)</returns>
            private static double ByteToPercent(byte value)
            {
                double d = value;
                d /= 255;
                return d;
            }

            /// <summary>
            /// Convert percent to byte.
            /// </summary>
            /// <param name="value">The value to convert.</param>
            /// <returns>The percentage (0 to 1) value to a byte</returns>
            private static byte PercentToByte(double value)
            {
                value *= 255;
                value += .5;

                if (value > 255)
                {
                    value = 255;
                }
                else if (value < 0)
                {
                    value = 0;
                }

                return (byte)value;
            }

            /// <summary>
            /// Normalizes the specified value between 0 and 1.
            /// </summary>
            /// <param name="value">The value to normalize.</param>
            /// <returns>The normalized value</returns>
            private static double Normalize(double value)
            {
                if (value < 0)
                {
                    value += 1;
                }
                else if (value > 1)
                {
                    value -= 1;
                }

                return value;
            }

            /// <summary>
            /// Gets the component.
            /// </summary>
            /// <param name="tc">The t c.</param>
            /// <param name="p">The p.</param>
            /// <param name="q">The q.</param>
            /// <returns>The component value</returns>
            private static double GetComponent(double tc, double p, double q)
            {
                if (tc < (1.0 / 6.0))
                {
                    return p + ((q - p) * 6 * tc);
                }
                else if (tc < .5)
                {
                    return q;
                }
                else if (tc < (2.0 / 3.0))
                {
                    return p + ((q - p) * 6 * ((2.0 / 3.0) - tc));
                }

                return p;
            }
        }
    }
}