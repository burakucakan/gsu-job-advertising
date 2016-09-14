using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSUKariyer.COMMON.Helpers.General;
using System.Web.UI;
using System.IO;

namespace GSUKariyer.COMMON.Helpers.WEB
{
    public class BaseCompressedPage : BasePage
    {
        #region Compression Codes

        protected override void SavePageStateToPersistenceMedium(Object state)
        {
            Object viewState = state;
            if (state is Pair)
            {
                Pair statePair = (Pair)state;
                PageStatePersister.ControlState = statePair.First;
                viewState = statePair.Second;
            }

            using (StringWriter writer = new StringWriter())
            {
                new LosFormatter().Serialize(writer, viewState);
                string base64 = writer.ToString();
                byte[] compressed = Compressor.DeflaterCompression.Compress(Convert.FromBase64String((base64)));
                PageStatePersister.ViewState = Convert.ToBase64String(compressed);
            }
            PageStatePersister.Save();
        }
        protected override Object LoadPageStateFromPersistenceMedium()
        {
            PageStatePersister.Load();
            String base64 = PageStatePersister.ViewState.ToString();
            byte[] state = Compressor.DeflaterCompression.Decompress(Convert.FromBase64String(base64));
            string serializedState = Convert.ToBase64String(state);
            object viewState = new LosFormatter().Deserialize(serializedState);
            return new Pair(PageStatePersister.ControlState, viewState);
        }

        #endregion
    }
}
