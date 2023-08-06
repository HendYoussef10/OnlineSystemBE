using Service.Utilities.IUilities.IImageUtility;
using Service.Utilities.IUilities.ITextUitilies;
using Service.Utilities.Utilities.ImagesUtilities;
using Service.Utilities.Utilities.TextUtilities;

namespace Service.Utilities.BuilderUtilities
{
    public class UtilitesBuilder : IUtilitesBuilder
    {
        
        public IImageUtility BuildImage()
        {
            return ImageUtility.GetInstance();
        }

        public ITextUtility BuildText()
        {
            return TextUtility.Getinstance();
        }

    }
}
