namespace Common.ContentProcessing
{
    public class ProcessElement
    {
        public int CropX = 0;
        public int CropY = 0;
        public int AdjustX = 0;
        public int AdjustY = 0;
        public CropAction CropActionField = CropAction.None;
        public CropMode CropModeField = CropMode.None;
        public bool IsThumb = false;
        public bool IsOriginalSize = false;
    }
}