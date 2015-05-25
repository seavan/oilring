namespace Common.ContentProcessing
{
    public class MaterialProcessor : DefaultImageProcessor
    {
        public MaterialProcessor()
        {
            Add("large", new ProcessElement()
            {
                AdjustX = 400,
            });

            Add("mid", new ProcessElement()
                           {
                               CropX = 1,
                               CropY = 1,
                               CropActionField = CropAction.Proportional,
                               CropModeField = CropMode.Center,
                               AdjustX = 120,
                               AdjustY = 120
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