using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SOD_CS_Library;

namespace ImageBoard
{
    class ConfigurationFileReader
    {
        /// <summary>
        /// Gets the key (parameter) in the config file
        /// </summary>
        /// <param name="str"></param>
        /// <returns>String from config file</returns>
        public string GetConfigSettings(string str)
        {
            return ConfigurationManager.AppSettings[str];
        }

        /// <summary>
        /// Converts the string value associated with a key to a double
        /// Can be easily casted as an int, float, etc.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Double converted from config file</returns>
        public double ConvertStringToDouble(string str)
        {
            return Convert.ToDouble(GetConfigSettings(str));
        }

        /// <summary>
        /// Converts a string with multiple values associated with a key to Point3D
        /// Delimeter is "," and converts string to a double
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        /// <returns>Point3D that is split and converted from config file</returns>
        public Point3D ConvertStringToPoint(string str)
        {

            double[] points = new double[3];

            string[] strArr = GetConfigSettings(str).Split(',');

            for (int i = 0; i < strArr.Length; i++)
            {
                points[i] = Convert.ToDouble(strArr[i]);
            }

            return new Point3D(points[0], points[1], points[2]);
        }

        public bool ConvertStringToBool(string str)
        {
            if (GetConfigSettings(str).Equals("true"))
                return true;
            else
                return false;
        }
    }
}
