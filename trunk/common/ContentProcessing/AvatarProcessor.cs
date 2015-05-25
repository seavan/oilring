namespace Common.ContentProcessing
{
    public class AvatarProcessor : DefaultImageProcessor
    {
        public AvatarProcessor()
        {
            Add("mid", new ProcessElement()
            {
                CropX = 1,
                CropY = 1,
                CropActionField = CropAction.Proportional,
                CropModeField = CropMode.Center,
                AdjustX = 220,
                AdjustY = 0
            });

            Add("small", new ProcessElement()
                             {
                                 CropX = 1,
                                 CropY = 1,
                                 CropActionField = CropAction.Proportional,
                                 CropModeField = CropMode.Center,
                                 AdjustX = 30,
                                 AdjustY = 30,
                                 IsThumb = true

                             });

        }
    }
}