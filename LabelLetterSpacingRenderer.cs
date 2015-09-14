using WantifyMobile.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Wantify.Mobile.Forms.Views;
using Foundation;
using UIKit;

[assembly: ExportRenderer (typeof(LabelLetterSpacing), typeof(LabelLetterSpacingRenderer))]

namespace Project.iOS
{
    public class LabelLetterSpacingRenderer : LabelRenderer
    {
        protected override void OnElementChanged (ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged (e);

            var data = Element as LabelLetterSpacing;
            if (data == null || Control == null) {
                return;
            }
                
            var text = Control.Text;
            var attributedString = new NSMutableAttributedString (text);

            var nsKern = new NSString ("NSKern");
            var spacing = NSObject.FromObject (data.LetterSpacing);
            var range = new NSRange (0, text.Length - 1);

            attributedString.AddAttribute(nsKern, spacing, range);
            Control.AttributedText = attributedString;
        }
    }
}