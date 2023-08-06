using Service.Utilities.IUilities.IImageUtility;
using Service.Utilities.IUilities.ITextUitilies;

namespace Service.Utilities.BuilderUtilities
{
    public interface IUtilitesBuilder
    {
        ITextUtility BuildText();
        IImageUtility BuildImage();
    }
}