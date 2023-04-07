using System.Text;
using TMPro;
using UnityEngine;

namespace Block.Tools.Typography
{
    public class style : MonoBehaviour
    {
        public TMP_Text Textbox;
        public string Opt;
        public string Closet;

        [ContextMenu("read values from TMP")]
        public void ReadValuesFormTMP()
        {
            StringBuilder opSB = new StringBuilder();
            StringBuilder closeSB = new StringBuilder();
            if ((Textbox.fontStyle & FontStyles.Bold) != 0)
            {
                opSB.Append("<b>");
                closeSB.Append("</b>");
            }
            if ((Textbox.fontStyle & FontStyles.Italic) != 0)
            {
                opSB.Append("<i>");
                closeSB.Append("</i>");
            }
            if ((Textbox.fontStyle & FontStyles.UpperCase) != 0)
            {
                opSB.Append("<uppercase>");
                closeSB.Append("</uppercase>");
            }
            if ((Textbox.fontStyle & FontStyles.LowerCase) != 0)
            {
                opSB.Append("<lowercase>");
                closeSB.Append("</lowercase>");
            }

            Opt = opSB.ToString();
            Closet = closeSB.ToString();
        }
    }
}
