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

                    Color compliment;

                    // Compliments generated with help from http://www.colorsontheweb.com/colorwizard.asp
                    switch (currentAccentColorHex.ToString())
                    {
                        case "#FFF0A30A": // Amber
                            compliment = Color.FromArgb(255, 9, 86, 240); // #0956F0
                            break;
                        case "#FF825A2C": // Brown
                            compliment = Color.FromArgb(255, 44, 84, 130); // #2C5482
                            break;
                        case "#FF0050EF": // Cobalt
                            compliment = Color.FromArgb(255, 239, 158, 0); // #EF9E00
                            break;
                        case "#FFA20025": // Crimson
                            compliment = Color.FromArgb(255, 0, 162, 125); // #00A27D
                            break;
                        case "#FF1BA1E2": // Cyan
                            compliment = Color.FromArgb(255, 226, 92, 27); // #E25C1B
                            break;
                        case "#FF008A00": // Emerald
                            compliment = Color.FromArgb(255, 138, 0, 138); // #8A008A
                            break;
                        case "#FF60A917": // Green
                            compliment = Color.FromArgb(255, 96, 23, 169); // #6017A9
                            break;
                        case "#FF6A00FF": // Indigo
                            compliment = Color.FromArgb(255, 149, 255, 0); // #95FF00
                            break;
                        case "#FFA4C400": // Lime
                            compliment = Color.FromArgb(255, 32, 0, 196); // #2000C4
                            break;
                        case "#FFD80073": // Magenta
                            compliment = Color.FromArgb(255, 0, 216, 100); // #00D864
                            break;
                        case "#FF76608A": // Mauve
                            compliment = Color.FromArgb(255, 115, 138, 96); // #738A60
                            break;
                        case "#FF6D8764": // Olive
                            compliment = Color.FromArgb(255, 125, 99, 135); // #7D6387
                            break;
                        case "#FFFA6800": // Orange
                            compliment = Color.FromArgb(255, 0, 145, 250); // #0091FA
                            break;
                        case "#FFF472D0": // Pink
                            compliment = Color.FromArgb(255, 113, 244, 149); // #71F495
                            break;
                        case "#FFE51400": // Red
                            compliment = Color.FromArgb(255, 0, 209, 229); // #00D1E5
                            break;
                        case "#FF647687": // Steel
                            compliment = Color.FromArgb(255, 135, 117, 99); // #877563
                            break;
                        case "#FF87794E": // Taupe
                            compliment = Color.FromArgb(255, 78, 91, 135); // #4E5B87
                            break;
                        case "#FF00ABA9": // Teal
                            compliment = Color.FromArgb(255, 171, 0, 2); // #AB0002
                            break;
                        case "#FFAA00FF": // Violet
                            compliment = Color.FromArgb(255, 85, 255, 0); // #55FF00
                            break;
                        case "#FFE3C800": // Yellow
                            compliment = Color.FromArgb(255, 0, 27, 227); // #001BE3
                            break;
                        default:
                            // Fallback color - necessary as user may have a non-standard accent color (such as operator or OEM defined)
                            compliment = ((SolidColorBrush)Application.Current.Resources["PhoneBackgroundBrush"]).Color;
                            break;
                    }

                    Application.Current.Resources.Add(ResourceName, new SolidColorBrush(compliment));
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong - ask for your money back");
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
    }
}
